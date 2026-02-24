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
    public partial class TestHumains : Form
    {
        private int idProduit;
        private int idVersion;
        private int idPhase;
        private List<TestHumain> listTestHumains = new List<TestHumain>();
        DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
        Image imgStatut;


        public TestHumains(int _idProduit, int _idVersion, int _idPhase)
        {
            InitializeComponent();

            idProduit = _idProduit;
            idVersion = _idVersion;
            idPhase = _idPhase;

            listTestHumains = GetTestHumains();
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


        private List<TestHumain> GetTestHumains()
        {
            List<TestHumain> list = new List<TestHumain>();

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                String queryTestHumains = "SELECT th.idEssai, g.libelle, th.effectif, age.libelle, es.libelle, th.placebo, th.tauxReussite, th.Statut from testhumain th left join genre g on th.idSexe=g.idGenre left join trancheage age on th.idTrancheAge=age.idTrancheAge left join etatsujet es on es.idEtat= th.idEtatSujet left join valider v on v.idProduit = th.idProduit and v.idVersion = th.idVersion and v.idPhase = th.idPhase where th.idProduit = "+idProduit+" and th.idVersion = "+idVersion+" ";
                    //"SELECT ta.idEssai, a.libelle, ta.effectif, ad.libelle, ta.tauxReussite, ta.Statut from testanimal ta left join animal a on ta.idAnimal=a.idAnimal left join voieadmin ad on ta.idAdmin=ad.idAdmin left join valider v on v.idProduit = ta.idProduit and v.idVersion = ta.idVersion and v.idPhase = ta.idPhase where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion;

                Console.WriteLine("Requete de recup des Ressources : " + queryTestHumains);
                MySqlCommand cmd = new MySqlCommand(queryTestHumains, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                int idEssai = -1;
                string sexe = "";
                int effectif = 0;
                string age = "";
                string etatSujet = "";
                string placebo = "";
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
                        sexe = reader.GetString(1);
                    }

                    if (!reader.IsDBNull(2))
                    {
                        effectif = reader.GetInt32(2);
                    }

                    if (!reader.IsDBNull(3))
                    {
                        age = reader.GetString(3);
                    }

                    if (!reader.IsDBNull(4))
                    {
                        etatSujet = reader.GetString(4);
                    }

                    if (!reader.IsDBNull(5))
                    {
                        placebo = reader.GetString(5);
                    }

                    if (!reader.IsDBNull(6))
                    {
                        tauxReussite = reader.GetString(6);
                    }

                    if (!reader.IsDBNull(7))
                    {
                        statut = reader.GetInt32(7);
                    }

                    list.Add(new TestHumain()
                    {
                        Id_Essai = idEssai,
                        Sexe = sexe,
                        Effectif = effectif,
                        Tranche_age= age,
                        Etat_sujet= etatSujet,
                        Placebo = placebo,
                        Taux_Reussite = tauxReussite + "%",
                        Statut_ = statut
                    });

                }
                reader.Close();
                dbCon.Close();
            }
            return list;
        }

        private void btnValidUpgrade_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous démarrer un essai clinique ?", "NOUVEAU ESSAI CLINIQUE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                 MessageBox.Show("Pour débuter, l'essai doit avoir obtenu un avis favorable du Comité de protection des personnes (C.P.P.) et une autorisation de l'Agence nationale de sécurité du médicament et des produits de santé (ANSM).", "NOUVEAU ESSAI CLINIQUE", MessageBoxButtons.OK);
                
                    //Connection Base de données r_d_valence
                    DBConnection dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "r_d_valence";

                    if (dbCon.IsConnect())
                    {
                        //calcul d'un nouveau identifiant de test
                        int idEssai = 0;

                        string queryMaxIdEssai = "SELECT MAX(idEssai) FROM affecter where idProduit = "+ idProduit +" and idPhase = "+ idPhase + " and idVersion = "+idVersion;
                        Console.WriteLine("SELECT MAX(idEssai) FROM affecter where idProduit = " + idProduit + " and idPhase = " + idPhase + " and idVersion = " + idVersion);
                        using (MySqlCommand cmdMaxIdEssai = new MySqlCommand(queryMaxIdEssai, dbCon.Connection))
                        {
                            MySqlDataReader rdMaxIdEssai = cmdMaxIdEssai.ExecuteReader();

                            while (rdMaxIdEssai.Read())
                            {
                                if (!rdMaxIdEssai.IsDBNull(0))
                                {
                                    idEssai = rdMaxIdEssai.GetInt32(0);
                                }
                            }
                            rdMaxIdEssai.Close();
                        }

                        idEssai++;

                        Console.WriteLine("ID ESSAI : "+idEssai);

                        if (idEssai != 0)
                        {
                            EssaiClinique essaiClinique = new EssaiClinique(idProduit, idVersion, idPhase, idEssai);
                            this.Hide();
                            essaiClinique.StartPosition = FormStartPosition.CenterParent;
                            essaiClinique.Show();
                        }
                        else
                        {
                            MessageBox.Show("Un problème est survenu lors de la création d'un nouvel essai clinique", "PROBLEME CREATION ESSAI CLINIQUE", MessageBoxButtons.OK);
                        }
                    }
                    dbCon.Close();
                
            }
        }

        private void TestHumains_Load(object sender, EventArgs e)
        {
            List<TestHumain> testHumains = this.listTestHumains;

            BindingSource source = new BindingSource();
            source.DataSource = testHumains;
            dataGridTestHumain.DataSource = source;

            dataGridTestHumain.Columns.Add(imageCol);

            imageCol.Name = "Statut";
            imageCol.HeaderText = "Statut";

            Uri imagePath = new Uri(@"..\..\img\valider.png", UriKind.Relative);
            imgStatut = Image.FromFile(imagePath.ToString());
            imgStatut = new Bitmap(imgStatut, 32, 32);


            foreach (DataGridViewRow row in dataGridTestHumain.Rows)
            {
                foreach (TestHumain test in testHumains)
                {

                    //Console.WriteLine(test.Etat_sujet + " - " + test.Effectif + " - " + test.Placebo + " - " + test.Taux_Reussite + " - " + test.Statut_);
                   // Console.WriteLine(row.Cells["Sujet"].Value.ToString() + " - " + row.Cells["Effectif"].Value.ToString() + " - " + row.Cells["Administration"].Value.ToString() + " - " + row.Cells["Taux_Reussite"].Value.ToString());

                    if (test.Sexe.Equals(row.Cells["Sexe"].Value.ToString()) && test.Effectif == Int32.Parse(row.Cells["Effectif"].Value.ToString()) && test.Placebo.Equals(row.Cells["Placebo"].Value.ToString()) && test.Etat_sujet.Equals(row.Cells["Etat_sujet"].Value.ToString()) && test.Tranche_age.Equals(row.Cells["Tranche_age"].Value.ToString()) && test.Taux_Reussite.Equals(row.Cells["Taux_Reussite"].Value.ToString()) && test.Statut_.ToString().Equals("1"))
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

            dataGridTestHumain.Columns["Id_Essai"].Visible = false;
            dataGridTestHumain.Columns["Statut_"].Visible = false;
        }

        private void btnRetourMenu_Click(object sender, EventArgs e)
        {
            MainPageRDValence mainPage = new MainPageRDValence();
            mainPage.StartPosition = this.StartPosition;
            mainPage.Show();
            this.Hide();
        }

        private void dataGridTestHumain_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex != -1) //Click sur un test et non entete de colonne
            {
                var testHumainClic = listTestHumains[e.RowIndex];
                Console.WriteLine("Clicked idEssai :" + testHumainClic.Id_Essai);

                EssaiClinique essaiClinique = new EssaiClinique(idProduit, idVersion, idPhase, testHumainClic.Id_Essai);
                this.Hide();
                essaiClinique.StartPosition = FormStartPosition.CenterParent;
                essaiClinique.Show();
            }
        }
    }
}
