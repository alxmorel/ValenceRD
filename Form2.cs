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
            //set label Date du jour a ajourd'hui
            lblTabDateInsertProd.Text = DateTime.Now.ToString();

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
                    /*Localhost*/  string queryInsertProduit = "Insert into produit values ("+lblIdSelectFromInput.Text+",\""+ inputTabNomScienProd.Text+"\", \""+ inputTabNomProduit.Text+"\")";
                                   string queryInsertTraiter = "Insert into traiter values (" + lblIdSelectFromInput + ", idTraitementSymptome)";
                    var cmd = new MySqlCommand(queryInsertProduit, dbCon.Connection);
                    var cmd1 = new MySqlCommand(queryInsertTraiter, dbCon.Connection);
                    cmd.ExecuteNonQuery();
                   // cmd1.ExecuteNonQuery();
                }

            }

            RechercheProduit rechProd = new RechercheProduit();
            rechProd.Show();
            this.Hide();
        }
    }
}
