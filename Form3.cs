using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValenceRD
{
    public partial class UpgradeProduit : Form
    {
        int idProduitSelect = -1;
        int maxIdVersion = 0;
        string symptomeProdAUp = "";

        public UpgradeProduit()
        {
            InitializeComponent();
            
            //ajoute les produits upgradables à la liste 
            initElements();
        }

        private void initElements()
        {
            //initialise la date d'insertion à la date du jour
            lblTabDateInsertProd.Text = DateTime.Today.ToString("dd-MM-yyyy");

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                Console.WriteLine("DB CONNECTION FAITE !");

                //recupération de l'id de la version du produit 
                string queryProduitUpg = "SELECT nomScientifique FROM produit order by nomScientifique";
                MySqlCommand cmdProduitUpg = new MySqlCommand(queryProduitUpg, dbCon.Connection);
                MySqlDataReader readerProduitUpg = cmdProduitUpg.ExecuteReader();

                while (readerProduitUpg.Read())
                {
                   inputListProduit.Items.Add(readerProduitUpg.GetString(0));
                }
                readerProduitUpg.Close();

            }
            dbCon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPageRDValence mainPage = new MainPageRDValence();
            this.Hide();
            mainPage.StartPosition = this.StartPosition;
            mainPage.Show();
        }

        [Obsolete]
        private void btnValidUpgrade_Click(object sender, EventArgs e)
        {

            //Vérifie qu'un produit est selectionné et qu'un symptome est bien entré

            if (inputListProduit.SelectedItem != null)
            {
                //Connection Base de données r_d_valence
                DBConnection dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "r_d_valence";

                if (dbCon.IsConnect())
                {
                    Console.WriteLine("DB CONNECTION FAITE !");

                    //Insertion dans valider pour la phase recherche et développement à l'état 0
                    //Insertion de la nouvelle validation de phase
                    string queryInsertValider = "insert into valider values (@idPhaseCour, @idVersionProduit, @idProduit, @dateInsertProd, @dateValidation, 0, \"\")";
                    Console.WriteLine("REQUETE D'INSERT NOUVEL PHASE : " + queryInsertValider);
                    using (MySqlCommand cmdInsertValider = new MySqlCommand(queryInsertValider, dbCon.Connection))
                    {
                        cmdInsertValider.Parameters.Add("@idPhaseCour", MySqlDbType.Int32).Value = 1;
                        cmdInsertValider.Parameters.Add("@idVersionProduit", MySqlDbType.Int32).Value = maxIdVersion;
                        cmdInsertValider.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduitSelect;
                        cmdInsertValider.Parameters.Add("@dateInsertProd", MySqlDbType.Datetime).Value = DateTime.Today;
                        cmdInsertValider.Parameters.Add("@dateValidation", MySqlDbType.Datetime).Value = DateTime.Parse("1999-01-01");
                        cmdInsertValider.ExecuteNonQuery();
                    }
                }
                dbCon.Close();

                //ouvre la page de recherche et dev
                RechercheProduit rechProd = new RechercheProduit(Int32.Parse(lblIdSelectFromInput.Text), maxIdVersion, 1);
                this.Hide();
                rechProd.StartPosition = FormStartPosition.CenterParent;
                rechProd.Show();
            }
            else
            {
                MessageBox.Show("Attention, un produit doit-être selectionné pour pouvoir l'upgrader !", "AUCUN PRODUIT N'EST SELECTIONNE", MessageBoxButtons.OK);
            }

        }

        private void inputIdUpgrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Console.WriteLine("Le produit à Up est : ["+inputListProduit.Text+"]");

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                Console.WriteLine("DB CONNECTION FAITE !");

                maxIdVersion = 0;

                //recupération de l'id de la version du produit 
                string queryProduitUpg1 = "SELECT distinct produit.nomScientifique, version.idVersion, version.commentaire, traitement_Symptome.libelle, produit.idProduit " +
                                "FROM produit " +
                                "left join traiter on produit.idProduit = traiter.idProduit " +
                                "left join traitement_symptome on traiter.idTraitementSymptome = traitement_Symptome.idTraitementSymptome " +
                                "left JOIN valider ON produit.idProduit = valider.idProduit " +
                                "LEFT JOIN version on valider.idVersion = version.idVersion " +
                                "LEFT JOIN phase on valider.idPhase = phase.idPhase " +
                                "Where produit.nomScientifique =@produitSelect " +
                                "order by produit.idProduit";
                using (MySqlCommand cmdProduitUpg1 = new MySqlCommand(queryProduitUpg1, dbCon.Connection))
                {
                    cmdProduitUpg1.Parameters.Add("@produitSelect", MySqlDbType.VarChar).Value = inputListProduit.Text;
                    MySqlDataReader readerProduitUpg1 = cmdProduitUpg1.ExecuteReader();

                    while (readerProduitUpg1.Read())
                    {

                        if (readerProduitUpg1.GetString(0).Equals(inputListProduit.Text))
                        {
                            Console.WriteLine("maxIdVersion : " + maxIdVersion);
                            Console.WriteLine("readerProduitUpg.GetInt32(1) : " + readerProduitUpg1.GetInt32(1));
                            if (maxIdVersion < readerProduitUpg1.GetInt32(1))
                            {
                                maxIdVersion = readerProduitUpg1.GetInt32(1);
                                symptomeProdAUp = readerProduitUpg1.GetString(3);
                                idProduitSelect = readerProduitUpg1.GetInt32(4);
                            }
                        }
                    }
                    readerProduitUpg1.Close();
                }


                maxIdVersion++;
                Console.WriteLine("Version a upgrade : " + maxIdVersion);

                /*
                string queryVersionSup = "select commentaire from version where idVersion = "+maxIdVersion;
                MySqlCommand cmdVersionSup = new MySqlCommand(queryVersionSup, dbCon.Connection);
                MySqlDataReader readerVersionSup = cmdVersionSup.ExecuteReader();

                while (readerVersionSup.Read())
                {
                    Console.WriteLine("Version a ecrire avant initialisation : " + versionComm);
                    versionComm = readerVersionSup.GetString(0);
                }
                readerVersionSup.Close();
            

            Console.WriteLine("Version à écrire après initialisation : "+versionComm);

            */
            }
            dbCon.Close();
            //Initialise l'identifiant du produit à upgrader
            if (idProduitSelect!=-1)
            {
                lblIdSelectFromInput.Text = idProduitSelect.ToString();
            }

            //Initialise le nom du produit selectionné
            lblTabNomProd.Text = inputListProduit.Text;

            //Initialise le commentaire de version v+1
            lblTabNumVersion.Text = maxIdVersion.ToString();

            //Initialise le symptome du produit selectionné
            lblTabSymptome.Text = symptomeProdAUp;
        }
    }
}
