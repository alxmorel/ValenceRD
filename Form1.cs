using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ValenceRD
{
    public partial class MainPageRDValence : Form
    {

        public MainPageRDValence()
        {
            InitializeComponent();
            //Connection Base de données r_d_valence
           
            

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT produit.idProduit, produit.nomScientifique, traitement_symptome.libelle FROM produit, traitement_symptome, traiter where produit.idProduit = traiter.idProduit and traiter.idTraitementSymptome = traitement_symptome.idTraitementSymptome";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string idProduit = reader.GetString(0);
                    string nomScientifique = reader.GetString(1);
                    string symptome = reader.GetString(2);
                    Console.WriteLine(idProduit + "," + nomScientifique + "," + symptome);

                    AddItem(idProduit, nomScientifique, symptome);
                }
                dbCon.Close();
            }

        }


        private void AddItem(string idProduit, string nomScientifique, string symptome)
        {
            TableLayoutRowStyleCollection styles = tblDataProduits.RowStyles;
                foreach (RowStyle style in styles)
                {
                // Set the row height to 20 pixels.
                if (styles.IndexOf(style) > 1)
                {
                    style.SizeType = SizeType.Absolute;
                    style.Height = 30;
                }
                
                }
            //get a reference to the previous existent 
           // RowStyle temp = tblDataProduits.RowStyles[tblDataProduits.RowCount - 1];
            //increase panel rows count by one
            tblDataProduits.RowCount++;
            //add a new RowStyle as a copy of the previous one
           // tblDataProduits.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            //add your three controls
            tblDataProduits.Controls.Add(new LinkLabel() { Text = idProduit/*, Font = new Font(this.Font.FontFamily, 30)*/ }, 0, tblDataProduits.RowCount - 1);
            tblDataProduits.Controls.Add(new LinkLabel() { Text = nomScientifique /*, Font = new Font(this.Font.FontFamily, 30)*/ }, 1, tblDataProduits.RowCount - 1);
            tblDataProduits.Controls.Add(new LinkLabel() { Text = symptome/*, Font = new Font(this.Font.FontFamily, 30)*/ }, 2, tblDataProduits.RowCount - 1);
            
        }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
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

        private void lblColIdProdtbl_Click(object sender, EventArgs e)
        {

        }
    }
}
