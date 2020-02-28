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
    public partial class PageCreaProduit : Form
    {
        public PageCreaProduit()
        {
            InitializeComponent();


            //Connection Base de données r_d_valence
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                /*MenaOvh*/ //string query = "SELECT Produit.idProduit, Produit.nomScientifique, Traitement_Syptome.libelle FROM Produit, Traitement_Syptome, Traiter where Produit.idProduit = Traiter.idProduit and Traiter.idTraitementSymptome = Traitement_Syptome.idTraitementSymptome";
                /*Localhost*/
                string query = "SELECT libelle FROM Traitement_Symptome";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                //addComboBox Data for Symptome
                while (reader.Read())
                {
                    string libelleSymptome = reader.GetString(0);
                    Console.WriteLine(libelleSymptome);
                    inputTabSymptome.Items.Add(libelleSymptome);
                }
                reader.Close();
                
                //génère idProduit
                string queryId = "SELECT idProduit FROM produit";
                var cmdId = new MySqlCommand(queryId, dbCon.Connection);
                reader = cmdId.ExecuteReader();

                int maxId = -1;

                while (reader.Read())
                {
                    string idProduitCourant = reader.GetString(0);
                   
                    if(Int32.Parse(idProduitCourant) > maxId)
                    {
                        maxId = Int32.Parse(idProduitCourant);
                    }

                }

                if (maxId!=-1)
                {
                    maxId++;
                    lblIdSelectFromInput.Text = maxId.ToString();
                }
                

                reader.Close();
                dbCon.Close();
            }
            //set label Date du jour à aujourd'hui
            lblTabDateInsertProd.Text = DateTime.Today.ToString("dd-MM-yyyy");

        }

        internal static void show()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPageRDValence mainPage = new MainPageRDValence();
            this.Hide();
            mainPage.Show();
            
        }

        private void btnCreerProduit_Click(object sender, EventArgs e)
        {
            //Vérifie que le nom du produit generique et scientifique ainsi que le symptome sont référencés
            if (!inputTabNomProduit.Text.Equals("") && !inputTabNomScienProd.Text.Equals("") && inputTabSymptome.SelectedItem!=null)
            {
                //Connection Base de données r_d_valence
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "r_d_valence";

                if (dbCon.IsConnect())
                {

                    /*MenaOvh*/ //string query = "SELECT Produit.idProduit, Produit.nomScientifique, Traitement_Syptome.libelle FROM Produit, Traitement_Syptome, Traiter where Produit.idProduit = Traiter.idProduit and Traiter.idTraitementSymptome = Traitement_Syptome.idTraitementSymptome";
                    /*Localhost*/  String queryInsertProduit = "Insert into produit values ("+lblIdSelectFromInput.Text+",\""+ inputTabNomScienProd.Text+"\", \""+ inputTabNomProduit.Text+"\")";
                                   String queryIdSympt = "SELECT traitement_symptome.idTraitementSymptome FROM traitement_symptome where traitement_symptome.libelle = \"" + inputTabSymptome.SelectedItem.ToString() + "\"";
                                   
                    MySqlCommand cmdInsertProd = new MySqlCommand(queryInsertProduit, dbCon.Connection);
                    MySqlCommand cmdSelectIdSympt = new MySqlCommand(queryIdSympt, dbCon.Connection);

                    cmdInsertProd.ExecuteNonQuery(); //Insert le produit dans la table produit

                    var reader = cmdSelectIdSympt.ExecuteReader(); //Récupère l'identifiant du symptome qu'il traite
                    var idSymtpomeSelect = 1;

                    if (reader.HasRows)
                    {
                        Console.WriteLine("Execution Requète Insertion Traiter");
                        reader.Read();
                        idSymtpomeSelect = reader.GetInt32(0);
                    }
                    reader.Close();

                    String queryInsertTraiter = "Insert into traiter values (" + Int32.Parse(lblIdSelectFromInput.Text) + ", " + idSymtpomeSelect+ ")";
                    MySqlCommand cmdInsertTraiter = new MySqlCommand(queryInsertTraiter, dbCon.Connection);
                    cmdInsertTraiter.ExecuteNonQuery(); // Insertion dans la table traiter

                    //string formatForMySql = lblTabDateInsertProd.Text.ToString("yyyy-MM-dd HH:mm:ss");
                    //DateTime Dateinsertprod = Convert.ToDateTime(lblTabDateInsertProd.Text);

                    String queryInsertValider = "Insert into valider values (1, 1, "+ Int32.Parse(lblIdSelectFromInput.Text)+", \""+ lblTabDateInsertProd.Text + "\", \"1999-01-01\" ,0, \"Mise en place des protocoles de recherches\" )";
                    var cmd3 = new MySqlCommand(queryInsertValider, dbCon.Connection);
                    cmd3.ExecuteNonQuery();

                    dbCon.Close();
                }

            }

            
            RechercheProduit rechProd = new RechercheProduit();
            rechProd.Show();
            this.Hide();
        }
    }
}
