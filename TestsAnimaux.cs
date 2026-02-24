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
    public partial class TestsAnimaux : Form
    {
        private int idProduit;
        private int idVersion;
        private int idPhase;
        private List<TestAnimal> listTestAnimaux = new List<TestAnimal>();
        DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
        Image imgStatut;
        public TestsAnimaux(int _idProduit, int _idVersion, int _idPhase)
        {
            InitializeComponent();
            idProduit = _idProduit;
            idVersion = _idVersion;
            idPhase = _idPhase;

            listTestAnimaux = GetTestAnimaux();
            //Initialise colonne de statut des tests
            imageCol.Name = "Statut";
            imageCol.HeaderText = "Statut";
            //genererTests();

            Uri imagePath = new Uri(@"..\..\img\valider.png", UriKind.Relative);
            imgStatut = Image.FromFile(imagePath.ToString());
            imgStatut = new Bitmap(imgStatut, 32, 32);
            
            //affiche l'image sur toute la colonne
            imageCol.Image = imgStatut;

        }


        private List<TestAnimal> GetTestAnimaux()
        {
            List<TestAnimal> list = new List<TestAnimal>();

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                String queryTestAnimaux = "SELECT ta.idEssai, a.libelle, ta.effectif, ad.libelle, ta.tauxReussite, ta.Statut from testanimal ta left join animal a on ta.idAnimal=a.idAnimal left join voieadmin ad on ta.idAdmin=ad.idAdmin left join valider v on v.idProduit = ta.idProduit and v.idVersion = ta.idVersion and v.idPhase = ta.idPhase where ta.idProduit = " + idProduit+" and ta.idVersion = "+idVersion;

                Console.WriteLine("Requete de recup des Ressources : " + queryTestAnimaux);
                MySqlCommand cmd = new MySqlCommand(queryTestAnimaux, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                int idEssai = -1;
                string sujet = "";
                int effectif = 0;
                string voieAdmin = "";
                string tauxReussite = "";
                int statut = -1;

                while (reader.Read())
                {

                    if (!reader.IsDBNull(0))
                    {
                        idEssai = reader.GetInt32(0);
                    }

                    if (!reader.IsDBNull(1))
                    {
                        sujet = reader.GetString(1);
                    }

                    if (!reader.IsDBNull(2))
                    {
                        effectif = reader.GetInt32(2);
                    }

                    if (!reader.IsDBNull(3))
                    {
                        voieAdmin = reader.GetString(3);
                    }

                    if (!reader.IsDBNull(4))
                    {
                        tauxReussite = reader.GetString(4);
                    }

                    if (!reader.IsDBNull(5))
                    {
                        statut = reader.GetInt32(5);
                    }


                    list.Add(new TestAnimal()
                    {
                        Id_Essai = idEssai,
                        Sujet = sujet,
                        Effectif = effectif,
                        Administration = voieAdmin,
                        Taux_Reussite = tauxReussite +"%",
                        Statut_ = statut
                    });

                }
                reader.Close();
                dbCon.Close();
            }
            return list;
        }




        private void genererTests()
        {
            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                String queryTestAnimaux = "SELECT ta.idEssai, a.libelle, ta.effectif, ad.libelle, ta.tauxReussite from testanimal ta left join animal a on ta.idAnimal=a.idAnimal left join voieadmin ad on ta.idAdmin=ad.idAdmin where idProduit = @idProduit and idVersion = @idVersion";

                using (MySqlCommand cmdTestAnimaux = new MySqlCommand(queryTestAnimaux, dbCon.Connection))
                {
                    cmdTestAnimaux.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;
                    cmdTestAnimaux.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersion;
                    MySqlDataReader rdTestAnim = cmdTestAnimaux.ExecuteReader();

                    //int nbRow = 2;

                    while (rdTestAnim.Read())
                    {
                        /*
                        RowStyle rowTestAnimal = new RowStyle(SizeType.Percent, 15F);
                        Label lblEssai = new Label() { Text = rdTestAnim.GetString(0), Font = new System.Drawing.Font("Microsoft Sans Serif", 16), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };
                        Label lblSujet = new Label() { Text = rdTestAnim.GetString(1), Font = new System.Drawing.Font("Microsoft Sans Serif", 16), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };
                        Label lblEffectif = new Label() { Text = rdTestAnim.GetString(2), Font = new System.Drawing.Font("Microsoft Sans Serif", 16), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };
                        Label lblVoieAdmin = new Label() { Text = rdTestAnim.GetString(3), Font = new System.Drawing.Font("Microsoft Sans Serif", 16), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };
                        Label lblTauxReussite = new Label() { Text = rdTestAnim.GetString(4), Font = new System.Drawing.Font("Microsoft Sans Serif", 16), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };

                        lblEssai.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
                        lblSujet.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
                        lblEffectif.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
                        lblVoieAdmin.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
                        lblTauxReussite.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

                        tblPanTestAnim.RowStyles.Add(rowTestAnimal);

                        //tblPanTestAnim.RowCount++;

                        tblPanTestAnim.Controls.Add(lblEssai, 0, nbRow);
                        tblPanTestAnim.Controls.Add(lblSujet, 1, nbRow);
                        tblPanTestAnim.Controls.Add(lblEffectif, 2, nbRow);
                        tblPanTestAnim.Controls.Add(lblVoieAdmin, 3, nbRow);
                        tblPanTestAnim.Controls.Add(lblTauxReussite, 4, nbRow);
                        nbRow++;
                        */
                    }
                    rdTestAnim.Close();
                }
            }
            dbCon.Close();
        }


            private void btnRetourMenu_Click(object sender, EventArgs e)
        {
            MainPageRDValence mainPage = new MainPageRDValence();
            mainPage.StartPosition = this.StartPosition;
            mainPage.Show();
            this.Hide();
        }

        private void btnValidUpgrade_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous démarrer un test animal ?", "NOUVEAU TEST ANIMAL", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                //Connection Base de données r_d_valence
                DBConnection dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "r_d_valence";

                if (dbCon.IsConnect())
                {
                    //calcul d'un nouveau identifiant de test
                    int idEssai = -1;

                    string queryMaxIdEssai = "SELECT MAX(idEssai) FROM affecter";
                    using (MySqlCommand cmdMaxIdEssai = new MySqlCommand(queryMaxIdEssai, dbCon.Connection))
                    {
                        MySqlDataReader rdMaxIdEssai = cmdMaxIdEssai.ExecuteReader();

                        while (rdMaxIdEssai.Read())
                        {
                            idEssai = rdMaxIdEssai.GetInt32(0) + 1;
                        }
                        rdMaxIdEssai.Close();
                    }
                    if (idEssai!=-1)
                    {
                        EssaiAnimaux essaiAnim = new EssaiAnimaux(idProduit, idVersion, idPhase, idEssai);
                        this.Hide();
                        essaiAnim.StartPosition = FormStartPosition.CenterParent;
                        essaiAnim.Show();
                    }
                    else{
                        MessageBox.Show("Un problème est survenu lors de la création d'un nouveau test animal", "PROBLEME CREATION TEST ANIMAL", MessageBoxButtons.OK);
                    }
                }
                dbCon.Close();
            }

        }

        private void TestsAnimaux_Load(object sender, EventArgs e)
        {
            List<TestAnimal> testAnimaux = this.listTestAnimaux;

            BindingSource source = new BindingSource();
            source.DataSource = testAnimaux;
            dataGridTestAnimaux.DataSource = source;

            dataGridTestAnimaux.Columns.Add(imageCol);

            imageCol.Name = "Statut";
            imageCol.HeaderText = "Statut";

            Uri imagePath = new Uri(@"..\..\img\valider.png", UriKind.Relative);
            imgStatut = Image.FromFile(imagePath.ToString());
            imgStatut = new Bitmap(imgStatut, 32, 32);


            foreach (DataGridViewRow row in dataGridTestAnimaux.Rows)
            {
                foreach (TestAnimal test in testAnimaux)
                {

                    Console.WriteLine(test.Sujet + " - " + test.Effectif + " - " + test.Administration + " - " + test.Taux_Reussite + " - " + test.Statut_);
                    Console.WriteLine(row.Cells["Sujet"].Value.ToString() + " - " + row.Cells["Effectif"].Value.ToString() + " - " + row.Cells["Administration"].Value.ToString() + " - " + row.Cells["Taux_Reussite"].Value.ToString());

                    if (test.Sujet.Equals(row.Cells["Sujet"].Value.ToString()) && test.Effectif== Int32.Parse(row.Cells["Effectif"].Value.ToString()) && test.Administration.Equals(row.Cells["Administration"].Value.ToString()) && test.Taux_Reussite.Equals(row.Cells["Taux_Reussite"].Value.ToString()) && test.Statut_.ToString().Equals("1"))
                    {
                        row.Cells["Statut"].Value = new Bitmap(imgStatut, 32, 32);
                        break;
                    }
                    else
                    {
                        row.Cells["Statut"].Value = new Bitmap(imgStatut, 1, 1);
                    }
                }
            }

            dataGridTestAnimaux.Columns["Id_Essai"].Visible = false;
            dataGridTestAnimaux.Columns["Statut_"].Visible = false;
        }


        private void btnRetourRecette_Click(object sender, EventArgs e)
        {
            idPhase = idPhase - 1;
            Console.WriteLine("OUVERTURE DU PRODUIT : "+ idProduit + " à la phase "+ idPhase + " et à la version " + idVersion  );
            RechercheProduit rechProd = new RechercheProduit(idProduit, idVersion, idPhase);
            this.Hide();
            rechProd.StartPosition = FormStartPosition.CenterParent;
            rechProd.Show();
        }

        private void dataGridTestAnimaux_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex != -1) //Click sur un test et non entete de colonne
            {
                var testAnimalClic = listTestAnimaux[e.RowIndex];
                Console.WriteLine("Clicked idEssai :" + testAnimalClic.Id_Essai);

                EssaiAnimaux essaiAnim = new EssaiAnimaux(idProduit, idVersion, idPhase, testAnimalClic.Id_Essai);
                this.Hide();
                essaiAnim.StartPosition = FormStartPosition.CenterParent;
                essaiAnim.Show();

            }
        }
    }
}
