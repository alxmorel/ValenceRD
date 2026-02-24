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

        public List<Ressources> listRessources { get; set; }

        public PageCreaProduit()
        {
            InitializeComponent();
            listRessources = getListRessources();

            //Ajoute les ressources humaine dans la liste des ressources
            setListBoxRessources();

            //Connection Base de données r_d_valence
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                string query = "SELECT libelle FROM Traitement_Symptome";
                MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
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
                MySqlCommand cmdId = new MySqlCommand(queryId, dbCon.Connection);
                MySqlDataReader readerId = cmdId.ExecuteReader();

                int maxId = -1;

                while (readerId.Read())
                {
                    string idProduitCourant = readerId.GetString(0);
                   
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

                readerId.Close();
                dbCon.Close();
            }
            //set label Date du jour à aujourd'hui
            lblTabDateInsertProd.Text = DateTime.Today.ToString("dd-MM-yyyy");

        }


        private void setListBoxRessources()
        {
            foreach (Ressources ress in listRessources)
            {
                listBoxRessTot.Items.Add(ress.prenom + " " + ress.nom);
            }
        }

        private List<Ressources> getListRessources()
        {
            List<Ressources> list = new List<Ressources>();

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                string SelectRess = "Select idRessource, nom, prenom from ressource";

                using (MySqlCommand cmdSelectRess = new MySqlCommand(SelectRess, dbCon.Connection))
                {
                    MySqlDataReader reader = cmdSelectRess.ExecuteReader(); //Récupère l'identifiant du symptome qu'il traite

                    while (reader.Read())
                    {
                        list.Add(new Ressources()
                        {
                            id_Ressource = reader.GetInt32(0),
                            nom = reader.GetString(1),
                            prenom = reader.GetString(2)
                        });
                    }
                    reader.Close();
                }
            }
            dbCon.Close();

            return list;
        }

                internal static void show()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPageRDValence mainPage = new MainPageRDValence();
            this.Hide();
            mainPage.StartPosition = this.StartPosition;
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

                    string queryInsertValider = "insert into valider values (@idPhaseCour, @idVersionProduit, @idProduit, @dateInsertProd, \"1999-01-01\", 0, \"Mise en place des protocoles de recherches\")";
                    Console.WriteLine("REQUETE D'INSERT NOUVEL PHASE : " + queryInsertValider);
                    using (MySqlCommand cmdInsertValider = new MySqlCommand(queryInsertValider, dbCon.Connection))
                    {
                        cmdInsertValider.Parameters.Add("@idPhaseCour", MySqlDbType.Int32).Value = 1;
                        cmdInsertValider.Parameters.Add("@idVersionProduit", MySqlDbType.Int32).Value = 1;
                        cmdInsertValider.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = Int32.Parse(lblIdSelectFromInput.Text);
                        cmdInsertValider.Parameters.Add("@dateInsertProd", MySqlDbType.Datetime).Value = DateTime.Today;
                        cmdInsertValider.ExecuteNonQuery();
                    }


                    dbCon.Close();
                }

            }

            //ouvre le produit créé
            RechercheProduit rechProd = new RechercheProduit(Int32.Parse(lblIdSelectFromInput.Text), 1, 1);
            this.Hide();
            rechProd.StartPosition = FormStartPosition.CenterParent;
            rechProd.Show();
        }

        private void btnAjoutRess_Click(object sender, EventArgs e)
        {
            bool estPresent = false;

            foreach (object itemRess in listBoxRessTot.SelectedItems)
            {
                foreach (object itemImp in listBoxRessImp.Items)
                {
                    if (itemRess.Equals(itemImp))
                    {
                        estPresent = true;
                    }
                }
                if (!estPresent)
                {
                    listBoxRessImp.Items.Add(itemRess);
                    
                }
                estPresent = false;
            }
        }

        private void btnSuppRess_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxRessImp);
            selectedItems = listBoxRessImp.SelectedItems;

            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                listBoxRessImp.Items.Remove(selectedItems[i]);
            }
        }
    }
}
