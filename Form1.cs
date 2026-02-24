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
                //string query = "SELECT produit.idProduit, produit.nomScientifique, version.commentaire, traitement_Symptome.libelle, phase.libelle, valider.dateInsertion, valider.dateValidation FROM produit left outer join traiter on produit.idProduit = traiter.idProduit left outer join traitement_symptome on traiter.idTraitementSymptome = traitement_Symptome.idTraitementSymptome LEFT OUTER JOIN valider ON produit.idProduit = valider.idProduit LEFT OUTER JOIN version on valider.idVersion = version.idVersion LEFT OUTER JOIN phase on valider.idPhase = phase.idPhase order by idProduit";

                string query = "SELECT distinct produit.idProduit, produit.nomScientifique, version.commentaire, traitement_Symptome.libelle, phase.libelle, valider.dateInsertion, valider.dateValidation, version.idVersion, phase.idPhase, produit.nomGenerique " +
                                "FROM produit " +
                                "left join traiter on produit.idProduit = traiter.idProduit " +
                                "left join traitement_symptome on traiter.idTraitementSymptome = traitement_Symptome.idTraitementSymptome " +
                                "left JOIN valider ON produit.idProduit = valider.idProduit " +
                                "LEFT JOIN version on valider.idVersion = version.idVersion " +
                                "LEFT JOIN phase on valider.idPhase = phase.idPhase " +
                                "order by produit.idProduit";
                                //"inner join recette on produit.idProduit = recette.idProduit and phase.idPhase = recette.idPhase order by idProduit";

                MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                String symptome = "";
                String version = "";
                String phase = "";
                DateTime date_insertion;
                DateTime date_derniere_validation;
                

                while (reader.Read())
                {
                    int idVersion = reader.GetInt32(7);
                    int idPhase = reader.GetInt32(8);
                    int idProduit = reader.GetInt32(0);
                    string nomScientifique = reader.GetString(1);
                    string nomGenerique = "";
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


                    if (!reader.IsDBNull(9))
                    {
                        nomGenerique = reader.GetString(9);
                    }
                    else
                    {
                        nomGenerique = "";
                    }

                    Console.WriteLine(idProduit + "," + nomScientifique + "," + symptome);

                    list.Add(new Produits()
                    {
                        id_Produit = idProduit,
                        id_Version = idVersion,
                        id_Phase = idPhase,
                        nom_Scientifique = nomScientifique,
                        nom_Generique = nomGenerique,
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


        private void button1_Click(object sender, EventArgs e)
        {
            PageCreaProduit form2 = new PageCreaProduit();
            form2.StartPosition = FormStartPosition.CenterParent;
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpgradeProduit upgradeProd = new UpgradeProduit();
            upgradeProd.StartPosition = FormStartPosition.CenterParent;
            this.Hide();
            upgradeProd.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        

        private void LblIdProduitForm_Click(object sender, EventArgs e)
        {

        }

        private void lblTabIdProd1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RechercheProduit rechProd = new RechercheProduit();
            rechProd.StartPosition = FormStartPosition.CenterParent;
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

            dataGridView1.Columns["id_Version"].Visible = false;
            dataGridView1.Columns["id_Phase"].Visible = false;
            dataGridView1.Columns["nom_Generique"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex!=-1) //Click sur id Produit
            {
                var produitCLic = listProduits[e.RowIndex];
                Console.WriteLine("Clicked IDProduit :" + produitCLic.id_Produit);
                if (produitCLic.id_Phase == 2)
                {
                    TestsAnimaux testAnim = new TestsAnimaux(produitCLic.id_Produit, produitCLic.id_Version, produitCLic.id_Phase);
                    this.Hide();
                    testAnim.StartPosition = FormStartPosition.CenterParent;
                    testAnim.Show();
                }
                else
                {
                    RechercheProduit rechProd = new RechercheProduit(produitCLic.id_Produit, produitCLic.id_Version, produitCLic.id_Phase);
                    this.Hide();
                    rechProd.StartPosition = FormStartPosition.CenterParent;
                    rechProd.Show();
                }
               
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

        private void lblDeco_hover(object sender, EventArgs e)
        {
            this.panDeconnexion.BackColor = Color.LightBlue;
        }

        private void hover_imgDeco(object sender, EventArgs e)
        {
            this.panDeconnexion.BackColor = Color.LightBlue;
        }

        private void hover_panDeco(object sender, EventArgs e)
        {
            this.panDeconnexion.BackColor = Color.LightBlue;
        }

        private void leave_panDeco(object sender, EventArgs e)
        {
            this.panDeconnexion.BackColor = Color.Transparent;
        }

        private void lblDeco_leave(object sender, EventArgs e)
        {
            this.panDeconnexion.BackColor = Color.Transparent;
        }

        private void leave_imgDeco(object sender, EventArgs e)
        {
            this.panDeconnexion.BackColor = Color.Transparent;
        }


        private void imgDeco_click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Connexion formCo = new Form_Connexion();
            formCo.StartPosition = this.StartPosition;
            formCo.Show();
        }

        private void panDeco_click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Connexion formCo = new Form_Connexion();
            formCo.StartPosition = this.StartPosition;
            formCo.Show();
        }

        private void lblDeco_click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Connexion formCo = new Form_Connexion();
            formCo.StartPosition = this.StartPosition;
            formCo.Show();
        }

        private void SupprimerProduit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le produit sélectionné ? \n Cette opération entraînera la suppression ", "SUPPRIMER LE PRODUIT SELECTIONNE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                bool prodtrouve = false;

                //Suppression du produits
                List<Produits> produits = this.listProduits;

                Produits prodASup = new Produits { id_Produit = 1, nom_Scientifique = "", version = "", symptome = "", phase_Courante = "", date_insertion_produit = DateTime.Today, date_derniere_validation = DateTime.Today };

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected || row.Cells[0].Selected || row.Cells[1].Selected || row.Cells[1].Selected)
                    {
                        for (int i = 0; i < produits.Count; i++)
                        {
                            if (produits[i].id_Produit == Int32.Parse(row.Cells[0].Value.ToString()) && produits[i].nom_Scientifique.Equals(row.Cells[1].Value.ToString()) && produits[i].version.Equals(row.Cells[2].Value.ToString()) && produits[i].phase_Courante.Equals(row.Cells[4].Value.ToString()))
                            {
                                prodtrouve = true;
                                prodASup = produits[i];
                                Console.WriteLine("PRODUITS A SUPPRIMER !! : " + prodASup.id_Produit + ", " + prodASup.nom_Scientifique + ", " + prodASup.phase_Courante + ", " + prodASup.version);
                            }
                        }

                    }
                }

                if (prodtrouve)
                {
                    DBConnection dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "r_d_valence";

                    if (dbCon.IsConnect())
                    {
                        Console.WriteLine("DB CONNECTION FAITE !");

                        //récupération de l'idPhase
                        int idPhaseASup = -1;

                        string queryPhaseASup = "Select idPhase from phase where libelle = @libellePhase";
                        Console.WriteLine("Requete idPhase " + queryPhaseASup);
                        using (MySqlCommand cmdPhase = new MySqlCommand(queryPhaseASup, dbCon.Connection))
                        {
                            cmdPhase.Parameters.Add("@libellePhase", MySqlDbType.VarChar).Value = prodASup.phase_Courante;

                            MySqlDataReader readerPhase = cmdPhase.ExecuteReader();
                            while (readerPhase.Read())
                            {
                                idPhaseASup = Int32.Parse(readerPhase.GetString(0));
                                Console.WriteLine("idPhase a sup : "+idPhaseASup);
                            }
                            readerPhase.Close();
                        }

                        //récupération de l'idVersion
                        int idVersionASup = -1;

                        string queryVersionASup = "Select idVersion from version where commentaire = @libelleVersion";
                        Console.WriteLine("Requete idVersion " + queryVersionASup);
                        using (MySqlCommand cmdVersion = new MySqlCommand(queryVersionASup, dbCon.Connection))
                        {
                            cmdVersion.Parameters.Add("@libelleVersion", MySqlDbType.VarChar).Value = prodASup.version;

                            MySqlDataReader readerVersion = cmdVersion.ExecuteReader();
                            while (readerVersion.Read())
                            {
                                idVersionASup = Int32.Parse(readerVersion.GetString(0));
                                Console.WriteLine("idVersion a sup : " + idVersionASup);
                            }
                            readerVersion.Close();
                        }


                        //Suppression des ingredients de la recette du produit à cette phase
                        string queryDeleteRecette = "Delete from recette where idProduit = @idProduit and idPhase = @idPhase";
                        Console.WriteLine("Requete deletteRecette : "+ queryDeleteRecette);
                        using (MySqlCommand cmdDeleteRecette = new MySqlCommand(queryDeleteRecette, dbCon.Connection))
                        {
                            cmdDeleteRecette.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhaseASup;
                            cmdDeleteRecette.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = prodASup.id_Produit;
                            cmdDeleteRecette.ExecuteNonQuery();
                        }


                        //Suppression de la validation de la phase
                        string queryDeleteValider = "Delete from valider where idProduit = @idProduit and idPhase = @idPhase and idVersion = @idVersion";
                        Console.WriteLine("Requete queryDeleteValider : " + queryDeleteValider);
                        using (MySqlCommand cmdDeleteValider = new MySqlCommand(queryDeleteValider, dbCon.Connection))
                        {
                            cmdDeleteValider.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhaseASup;
                            cmdDeleteValider.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = prodASup.id_Produit;
                            cmdDeleteValider.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersionASup;
                            cmdDeleteValider.ExecuteNonQuery();
                        }

                    }
                    dbCon.Close();

                    //suppression du produit à supprimer
                    produits.Remove(prodASup);

                    //maj du tableau des phases de produit
                    BindingSource source = new BindingSource();
                    source.DataSource = listProduits;
                    dataGridView1.DataSource = source;
                }
                else
                {
                    MessageBox.Show("Le produit à supprimer n'a pas été trouvé", "PRODUIT NON TROUVE", MessageBoxButtons.OK);
                }

            }
        }

        private void gérerLesRessourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageCreaProduit form2 = new PageCreaProduit();
            form2.StartPosition = FormStartPosition.CenterParent;
            form2.Show();
            this.Hide();
        }

        private void upgradeUnProduitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpgradeProduit upgradeProd = new UpgradeProduit();
            upgradeProd.StartPosition = FormStartPosition.CenterParent;
            this.Hide();
            upgradeProd.Show();
        }

    }
}
