using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ValenceRD
{
    public partial class MainPageRDValence : Form
    {
       public List<Produits> listProduits { get; set; }

        private String idProduitFiltre;
        private String nomProduitFiltre;
        private String versionFiltre;
        private String symptomeFiltre;
        private String phaseCourFiltre;
        private DateTime dateInserFiltreDeb;
        private DateTime dateValidFiltreDeb;
        private DateTime dateInserFiltreFin;
        private DateTime dateValidFiltreFin;

        public MainPageRDValence()
        {
            listProduits = GetProduits();
            InitializeComponent();

            idProduitFiltre = inputIdentifiantForm.Text;
            nomProduitFiltre = inputNomProdForm.Text;
            versionFiltre = inputNumVersionForm.Text;
            symptomeFiltre = InputSymptomeForm.Text;
            phaseCourFiltre = inputPhaseForm.Text;
            dateInserFiltreDeb = inputDateInsertProdFormDeb.Value;
            dateValidFiltreDeb = inputDateValidFormDeb.Value;
            dateInserFiltreFin = inputDateInsertProdFormFin.Value;
            dateValidFiltreFin = inputDateValidFormFin.Value;

            LoadInputForm(); // Charge les entrées du formulaire

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
                string query = "SELECT produit.idProduit, produit.nomScientifique, version.commentaire, traitement_Symptome.libelle, phase.libelle, valider.dateInsertion, valider.dateValidation FROM produit left outer join traiter on produit.idProduit = traiter.idProduit left outer join traitement_symptome on traiter.idTraitementSymptome = traitement_Symptome.idTraitementSymptome LEFT OUTER JOIN valider ON produit.idProduit = valider.idProduit LEFT OUTER JOIN version on valider.idVersion = version.idVersion LEFT OUTER JOIN phase on valider.idPhase = phase.idPhase order by idProduit";
               
                MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                String symptome = "";
                String version = "";
                String phase = "";
                DateTime date_insertion;
                DateTime date_derniere_validation;
                while (reader.Read())
                {
                    string idProduit = reader.GetString(0);
                    string nomScientifique = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        version = reader.GetString(2);
                    }
                    else
                    {
                        version = "";
                    }
                    if (!reader.IsDBNull(3))
                    {
                        symptome = reader.GetString(3);
                    }
                    else
                    {
                        symptome = "";
                    }

                    if (!reader.IsDBNull(4))
                    {
                        phase = reader.GetString(4);
                    }
                    else
                    {
                        phase = "";
                    }

                    if (!reader.IsDBNull(5))
                    {
                        date_insertion = DateTime.Parse(reader.GetString(5));
                    }
                    else
                    {
                        date_insertion = DateTime.Parse("1999-01-01");
                    }

                    if (!reader.IsDBNull(6))
                    {
                        date_derniere_validation = DateTime.Parse(reader.GetString(6));
                    }
                    else
                    {
                        date_derniere_validation = DateTime.Parse("1999-01-01");
                    }

                    Console.WriteLine(idProduit + "," + nomScientifique + "," + symptome);

                    list.Add(new Produits()
                    {
                        id_Produit = Int32.Parse(idProduit),
                        nom_Scientifique = nomScientifique,
                        version = version,
                        symptome = symptome,
                        phase_Courante = phase,
                        date_insertion_produit = date_insertion,
                        date_derniere_validation = date_derniere_validation
                        
                    });
                }
                reader.Close();
            }
            dbCon.Close();
            return list;
        }

        private void LoadInputForm()
        {
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                //charge les symptomes dans la combobox du formulaire de filtre
                string querySympt = "SELECT libelle from traitement_symptome";
                
                MySqlCommand cmdTrait_sympt = new MySqlCommand(querySympt, dbCon.Connection);
                MySqlDataReader readerTrait_sympt = cmdTrait_sympt.ExecuteReader();

                InputSymptomeForm.Items.Add("");
                while (readerTrait_sympt.Read())
                {
                    InputSymptomeForm.Items.Add(readerTrait_sympt.GetString(0));
                }
                readerTrait_sympt.Close();

                //charge les phases dans la combobox du formulaire de filtre
                string queryPhase = "SELECT libelle from phase";

                MySqlCommand cmdPhase = new MySqlCommand(queryPhase, dbCon.Connection);
                MySqlDataReader readerPhase = cmdPhase.ExecuteReader();

                inputPhaseForm.Items.Add("");
                while (readerPhase.Read())
                {
                    inputPhaseForm.Items.Add(readerPhase.GetString(0));
                }
                readerPhase.Close();
            }
            dbCon.Close();

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
        /*
        private void button1_Click_1(object sender, EventArgs e)
        {
            List<Produits> produits = this.listProduits;
            List<Produits> prodSelect = this.listProduits;
            String identifiant = "";
            String nomProduit = "";
            String numVersion = "";
            String symptome ="";
            String phase = "";
            String dateInsertProd = "";

            if (inputIdentifiantForm != null || !inputIdentifiantForm.Text.Equals(""))
            {
                identifiant = inputIdentifiantForm.Text;
            }

            if (inputNomProdForm != null || !inputNomProdForm.Text.Equals(""))
            {
                nomProduit = inputNomProdForm.Text;
            }

            if (inputNumVersionForm != null || !inputNumVersionForm.Text.Equals(""))
            {
                numVersion = inputNumVersionForm.Text;
            }

            if (InputSymptomeForm.SelectedItem != null || !InputSymptomeForm.SelectedItem.ToString().Equals(""))
            {
                symptome = InputSymptomeForm.SelectedItem.ToString();
            }

            if (inputPhaseForm.SelectedItem != null || !inputPhaseForm.SelectedItem.ToString().Equals(""))
            {
                phase = inputPhaseForm.SelectedItem.ToString();
            }

            if (inputDateInsertProdFormDeb.Value != null || !inputDateInsertProdFormDeb.Value.ToString().Equals(""))
            {
                dateInsertProd = inputDateInsertProdFormDeb.Value.ToString();
            }

            Console.WriteLine("date insertion produit : "+ dateInsertProd);

        }
        */

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
            // TODO: cette ligne de code charge les données dans la table 'r_d_valenceDataSet.phase'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.phaseTableAdapter.Fill(this.r_d_valenceDataSet.phase);
            // TODO: cette ligne de code charge les données dans la table 'r_d_valenceDataSet.traitement_symptome'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.traitement_symptomeTableAdapter.Fill(this.r_d_valenceDataSet.traitement_symptome);
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
                RechercheProduit rechProd = new RechercheProduit(produitCLic.id_Produit, produitCLic.nom_Scientifique, produitCLic.version, produitCLic.symptome, produitCLic.phase_Courante, produitCLic.date_insertion_produit, produitCLic.date_derniere_validation);
                this.Hide();
                rechProd.Show();
            }
        }

        private void inputIdentifiantForm_TextChanged(object sender, EventArgs e)
        {
            idProduitFiltre = inputIdentifiantForm.Text;
            FilterProduits(idProduitFiltre, nomProduitFiltre, versionFiltre, symptomeFiltre, phaseCourFiltre, dateInserFiltreDeb, dateValidFiltreDeb, dateInserFiltreFin, dateValidFiltreFin);
        }

        private void FilterProduits(String _idProduit, string _nomscien, string _version, string _sympt, string _phase, DateTime _dateInsDeb, DateTime _dateValDeb, DateTime _dateInsFin, DateTime _dateValFin)
        {
            List<Produits> listProduitsFiltre = new List<Produits>();

            listProduitsFiltre = listProduits.Where(prod => 
                                                            prod.id_Produit.ToString().ToLower().Contains(_idProduit.ToLower()) && 
                                                            prod.nom_Scientifique.ToLower().Contains(_nomscien.ToLower()) &&
                                                            prod.version.ToLower().Contains(_version.ToLower()) &&
                                                            prod.symptome.ToLower().Contains(_sympt.ToLower()) &&
                                                            prod.phase_Courante.ToLower().Contains(_phase.ToLower()) && 
                                                            DateTime.Compare(prod.date_insertion_produit, _dateInsDeb) >= 0 &&
                                                            DateTime.Compare(prod.date_derniere_validation, _dateValDeb) >=0 &&
                                                            DateTime.Compare(prod.date_insertion_produit, _dateInsFin) <= 0 &&
                                                            DateTime.Compare(prod.date_derniere_validation, _dateValFin) <= 0
                                                    )
                                             .Select(prod => new Produits()
                                             {
                                                 id_Produit = prod.id_Produit,
                                                 nom_Scientifique = prod.nom_Scientifique,
                                                 version = prod.version,
                                                 symptome = prod.symptome,
                                                 phase_Courante = prod.phase_Courante,
                                                 date_insertion_produit = prod.date_insertion_produit,
                                                 date_derniere_validation = prod.date_derniere_validation
                                             }).ToList();

            BindingSource source = new BindingSource();
            source.DataSource = listProduitsFiltre;
            dataGridView1.DataSource = source;
        }

        private void inputNomProdForm_TextChanged(object sender, EventArgs e)
        {
            nomProduitFiltre = inputNomProdForm.Text;
            FilterProduits(idProduitFiltre, nomProduitFiltre, versionFiltre, symptomeFiltre, phaseCourFiltre, dateInserFiltreDeb, dateValidFiltreDeb, dateInserFiltreFin, dateValidFiltreFin);
        }

        private void inputNumVersionForm_TextChanged(object sender, EventArgs e)
        {
            versionFiltre = inputNumVersionForm.Text;
            FilterProduits(idProduitFiltre, nomProduitFiltre, versionFiltre, symptomeFiltre, phaseCourFiltre, dateInserFiltreDeb, dateValidFiltreDeb, dateInserFiltreFin, dateValidFiltreFin);
        }

        private void InputSymptomeForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            symptomeFiltre = InputSymptomeForm.SelectedItem.ToString();
            FilterProduits(idProduitFiltre, nomProduitFiltre, versionFiltre, symptomeFiltre, phaseCourFiltre, dateInserFiltreDeb, dateValidFiltreDeb, dateInserFiltreFin, dateValidFiltreFin);
        }

        private void inputPhaseForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            phaseCourFiltre = inputPhaseForm.SelectedItem.ToString();
            FilterProduits(idProduitFiltre, nomProduitFiltre, versionFiltre, symptomeFiltre, phaseCourFiltre, dateInserFiltreDeb, dateValidFiltreDeb, dateInserFiltreFin, dateValidFiltreFin);
        }

        private void inputDateInsertProdForm_ValueChanged(object sender, EventArgs e)
        {
            dateInserFiltreDeb = inputDateInsertProdFormDeb.Value;
            FilterProduits(idProduitFiltre, nomProduitFiltre, versionFiltre, symptomeFiltre, phaseCourFiltre, dateInserFiltreDeb, dateValidFiltreDeb, dateInserFiltreFin, dateValidFiltreFin);
        }

        private void inputDateValidForm_ValueChanged(object sender, EventArgs e)
        {
            dateValidFiltreDeb = inputDateValidFormDeb.Value;
            FilterProduits(idProduitFiltre, nomProduitFiltre, versionFiltre, symptomeFiltre, phaseCourFiltre, dateInserFiltreDeb, dateValidFiltreDeb, dateInserFiltreFin, dateValidFiltreFin);
        }

        private void inputDateInsertProdFormFin_ValueChanged(object sender, EventArgs e)
        {
            dateInserFiltreFin = inputDateInsertProdFormFin.Value;
            FilterProduits(idProduitFiltre, nomProduitFiltre, versionFiltre, symptomeFiltre, phaseCourFiltre, dateInserFiltreDeb, dateValidFiltreDeb, dateInserFiltreFin, dateValidFiltreFin);
        }

        private void inputDateValidFormFin_ValueChanged(object sender, EventArgs e)
        {
            dateInserFiltreFin = inputDateInsertProdFormFin.Value;
            FilterProduits(idProduitFiltre, nomProduitFiltre, versionFiltre, symptomeFiltre, phaseCourFiltre, dateInserFiltreDeb, dateValidFiltreDeb, dateInserFiltreFin, dateValidFiltreFin);
        }
    }
}
