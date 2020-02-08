using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ValenceRD
{
    public partial class MainPageRDValence : Form
    {
       public List<Produits> listProduits { get; set; }

        public MainPageRDValence()
        {
            listProduits = GetProduits();
            InitializeComponent();
        }

        private List<Produits> GetProduits()
        {
            List<Produits> list = new List<Produits>();

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                /*MenaOvh*/ //string query = "SELECT Produit.idProduit, Produit.nomScientifique, Traitement_Syptome.libelle FROM Produit, Traitement_Syptome, Traiter where Produit.idProduit = Traiter.idProduit and Traiter.idTraitementSymptome = Traitement_Syptome.idTraitementSymptome order by idProduit";
                /*Localhost*/
                string query = "SELECT produit.idProduit, produit.nomScientifique, traitement_Symptome.libelle FROM produit left outer join traiter on produit.idProduit = traiter.idProduit left outer join traitement_symptome on traiter.idTraitementSymptome = traitement_Symptome.idTraitementSymptome order by idProduit";

                MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                string symptome = "";
                while (reader.Read())
                {
                    string idProduit = reader.GetString(0);
                    string nomScientifique = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        symptome = reader.GetString(2);
                    }
                    else
                    {
                        symptome = "";
                    }
                    Console.WriteLine(idProduit + "," + nomScientifique + "," + symptome);

                    list.Add(new Produits()
                    {
                        id_Produit = Int32.Parse(idProduit),
                        nom_Scientifique = nomScientifique,
                        symptome = symptome,
                        version = "",
                        phase_Courante = "",
                        date_insertion_produit = "",
                        date_derniere_validation = ""
                        
                    });

                }
                reader.Close();
                dbCon.Close();
            }
            return list;
        }


        /*private void AddItem(string idProduit, string nomScientifique, string symptome)
        {
            TableLayoutRowStyleCollection styles = tblDataProduits.RowStyles;
                foreach (RowStyle style in styles){
                        style.SizeType = SizeType.Absolute;
                        style.Height = 30;
                }

            //increase panel rows count by one
                tblDataProduits.RowCount++;
            
            //add our three controls
            tblDataProduits.Controls.Add(new LinkLabel() { Text = idProduit, Font = new Font(this.Font.FontFamily, 12), LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline,  AutoSize = true,}, 0, tblDataProduits.RowCount - 1);
            tblDataProduits.Controls.Add(new LinkLabel() { Text = nomScientifique , Font = new Font(this.Font.FontFamily, 12), LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline, AutoSize = true }, 1, tblDataProduits.RowCount - 1);
            tblDataProduits.Controls.Add(new LinkLabel() { Text = symptome, Font = new Font(this.Font.FontFamily, 12), LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline, AutoSize = true }, 2, tblDataProduits.RowCount - 1);

        }*/
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PageCreaProduit form2 = new PageCreaProduit();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpgradeProduit upgradeProd = new UpgradeProduit();
            this.Hide();
            upgradeProd.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }


        private void LblIdProduitForm_Click(object sender, EventArgs e)
        {

        }

        private void lblTabIdProd1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RechercheProduit rechProd = new RechercheProduit();
            rechProd.Show();
            this.Hide();
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainPageRDValence_Load(object sender, EventArgs e)
        {
            Console.WriteLine("HELLLLLLOOOOO !!!");
            List<Produits> produits = this.listProduits;
            dataGridView1.DataSource = produits;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1) //Click sur id Produit
            {
                var produitCLic = listProduits[e.RowIndex];
                Console.WriteLine("Clicked IDProduit :" + produitCLic.id_Produit);
                RechercheProduit rechProd = new RechercheProduit(produitCLic.id_Produit, produitCLic.nom_Scientifique, produitCLic.symptome, produitCLic.version, produitCLic.phase_Courante, produitCLic.date_insertion_produit, produitCLic.date_derniere_validation);
                this.Hide();
                rechProd.Show();
            }
        }
    }
}
