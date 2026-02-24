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
    public partial class EssaiAnimaux : Form
    {
        private int idProduit;
        private int idVersion;
        private int idPhase;
        private int idEssai;
        private int statut;
        private List<EffetSecs> listEffetSecs = new List<EffetSecs>();
        DataGridViewComboBoxColumn cmbNature = new DataGridViewComboBoxColumn();
        DataGridViewComboBoxColumn cmbFrequence = new DataGridViewComboBoxColumn();
        DataGridViewComboBoxColumn cmbGravite = new DataGridViewComboBoxColumn();

        private DateTime dateInsertProd = new DateTime();
        private DateTime dateValidation = new DateTime();


        public EssaiAnimaux(int _idProduit, int _idVersion, int _idPhase, int _idEssai)
        {
            InitializeComponent();
            idProduit = _idProduit;
            idVersion = _idVersion;
            idPhase = _idPhase;
            idEssai = _idEssai;
            statut = 0;

            listEffetSecs = GetEffetSecs();
            InitializeInput();

            //paramétrage des bordures des boutons
            btnValidUpgrade.FlatAppearance.BorderColor = Color.DarkSlateGray;

        }

        private void InitializeInput()
        {

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                //initialise la liste des animaux
                string queryAnimal = "SELECT libelle FROM animal";
                MySqlCommand cmdAnimal = new MySqlCommand(queryAnimal, dbCon.Connection);
                MySqlDataReader rdAnimal = cmdAnimal.ExecuteReader();

                while (rdAnimal.Read())
                {
                    comboSujet.Items.Add(rdAnimal.GetString(0));
                }
                rdAnimal.Close();

                comboSujet.Items.Add("");

                //initialise la liste des voies d'administration
                string queryAdmin = "SELECT libelle FROM voieadmin";
                MySqlCommand cmdAdmin = new MySqlCommand(queryAdmin, dbCon.Connection);
                MySqlDataReader rdAdmin = cmdAdmin.ExecuteReader();

                while (rdAdmin.Read())
                {
                    inputVoieAdmin.Items.Add(rdAdmin.GetString(0));
                }
                rdAdmin.Close();

                comboSujet.Items.Add("");


                //initialise la liste des durées de pharmacocinétique
                string queryPharmDur = "SELECT libelle FROM pharmacodur";
                MySqlCommand cmdPharmDur = new MySqlCommand(queryPharmDur, dbCon.Connection);
                MySqlDataReader rdPharmDur = cmdPharmDur.ExecuteReader();

                while (rdPharmDur.Read())
                {
                    inputPharmacoDur.Items.Add(rdPharmDur.GetString(0));
                }
                rdPharmDur.Close();

                inputPharmacoDur.Items.Add("");

                ////////////////////////////////////////////////////////////////////////////
                //INITIALISE LES INPUT SI EXISTANT
                //Récupère le statut du test humain si existant
                string queryStatut = "SELECT Statut FROM testanimal where idProduit = " + idProduit + " and idVersion = " + idVersion + " and idEssai = " + idEssai;
                MySqlCommand cmd = new MySqlCommand(queryStatut, dbCon.Connection);
                MySqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    if (!rd.IsDBNull(0))
                    {
                        statut = rd.GetInt32(0);
                    }
                }
                rd.Close();


                //initialise ComboSujet
                string querySujet = "SELECT libelle FROM animal a left join testanimal ta on ta.idAnimal=a.idAnimal where ta.idProduit = "+idProduit + " and ta.idVersion = "+ idVersion + " and ta.idEssai = "+ idEssai;
                 cmd = new MySqlCommand(querySujet, dbCon.Connection);
                 rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    comboSujet.Text = rd.GetString(0);
                }
                rd.Close();

                //initialise Effectif
                string queryEffectif = "SELECT effectif FROM testanimal ta where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryEffectif, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    inputEffectif.Value = rd.GetInt32(0);
                }
                rd.Close();

                //initialise Taux de reussite
                string queryTauxReussite = "SELECT tauxReussite FROM testanimal ta where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryTauxReussite, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    inputTauxReussite.Text = rd.GetString(0);
                }
                rd.Close();

                //initialise voieAdmin
                string queryVoieAdmin = "SELECT libelle FROM voieAdmin a left join testanimal ta on ta.idAdmin=a.idAdmin where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryVoieAdmin, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    inputVoieAdmin.Text = rd.GetString(0);
                }
                rd.Close();


                //initialise pharmacocinétique du medic
                string queryPharmacin = "SELECT pharmacocin FROM testanimal ta where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryPharmacin, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    inputPharmacocin.Value = rd.GetInt32(0);
                }
                rd.Close();

                //initialise durée de pharmacocinétique
                string queryPharmaDur = "SELECT libelle FROM pharmacodur a left join testanimal ta on ta.idPharmDur=a.idPharmDur where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryPharmaDur, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    inputPharmacoDur.Text = rd.GetString(0);
                }
                rd.Close();


                //initialise commentaire de l'essai animal
                string queryCom = "SELECT commentaire FROM testanimal ta where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryCom, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    inputCommentaire.Text = rd.GetString(0);
                }
                rd.Close();


                //recupération de la date d'insertion et date validation du produit 
                string queryDtInsert = "select dateInsertion, dateValidation from valider where idProduit = @idProduit and idPhase = @idPhase and idVersion = @idVersion";
                using (MySqlCommand cmdDtInsert = new MySqlCommand(queryDtInsert, dbCon.Connection))
                {
                    cmdDtInsert.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;
                    cmdDtInsert.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhase;
                    cmdDtInsert.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersion;
                    MySqlDataReader rdDtInsert = cmdDtInsert.ExecuteReader();

                    while (rdDtInsert.Read())
                    {
                        dateInsertProd = DateTime.Parse(rdDtInsert.GetString(0));
                        dateValidation = DateTime.Parse(rdDtInsert.GetString(1));
                    }
                    rdDtInsert.Close();
                }


            }
            dbCon.Close();
        }

        private List<EffetSecs> GetEffetSecs()
        {
            List<EffetSecs> list = new List<EffetSecs>();
            cmbNature.Name = "Nature_";
            cmbNature.HeaderText = "Nature_";
            cmbFrequence.Name = "Frequence_";
            cmbFrequence.HeaderText = "Frequence_";
            cmbGravite.Name = "Gravite_";
            cmbGravite.HeaderText = "Gravite_";

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                //initialise la liste des nature
                string queryselectNature = "SELECT libelle FROM effet_secondaire";
                MySqlCommand cmdselectNature = new MySqlCommand(queryselectNature, dbCon.Connection);
                MySqlDataReader rdSelectNature = cmdselectNature.ExecuteReader();

                while (rdSelectNature.Read())
                {
                    cmbNature.Items.Add(rdSelectNature.GetString(0));
                }
                rdSelectNature.Close();

                //initialise la liste des Frequence
                string queryFrequence = "SELECT libelle FROM frequence";
                MySqlCommand cmdFrequence = new MySqlCommand(queryFrequence, dbCon.Connection);
                MySqlDataReader rdFrequence = cmdFrequence.ExecuteReader();

                while (rdFrequence.Read())
                {
                    cmbFrequence.Items.Add(rdFrequence.GetString(0));
                }
                rdFrequence.Close();

                //initialise la liste des Frequence
                string queryGravite = "SELECT libelle FROM gravite";
                MySqlCommand cmdGravite = new MySqlCommand(queryGravite, dbCon.Connection);
                MySqlDataReader rdGravite = cmdGravite.ExecuteReader();

                while (rdGravite.Read())
                {
                    cmbGravite.Items.Add(rdGravite.GetString(0));
                }
                rdGravite.Close();

                //Récupère les effets secondaires existants
                string query = "SELECT e.idEffetSecondaire, fr.idFrequence, g.idGravite ,e.libelle, fr.libelle, g.libelle from affecter a left join effet_secondaire e on a.idEffetSecondaire = e.idEffetSecondaire left join frequence fr on a.idFrequence = fr.idFrequence left join gravite g on a.idGravite = g.idGravite where idProduit = " + idProduit + " and idPhase = " + idPhase + " and idVersion = " + idVersion + " and idEssai = "+idEssai;
                Console.WriteLine("Requete de recup des Effets Secondaire : " + query);
                MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                int idEff = -1;
                int idFreq = -1;
                int idGrav = -1;
                string nature = "";
                string frequence = "";
                string gravite = "";


                while (reader.Read())
                {

                    if (!reader.IsDBNull(0))
                    {
                        idEff = reader.GetInt32(0);
                    }

                    if (!reader.IsDBNull(1))
                    {
                        idFreq = reader.GetInt32(1);
                    }

                    if (!reader.IsDBNull(2))
                    {
                        idGrav = reader.GetInt32(2);
                    }

                    if (!reader.IsDBNull(3))
                    {
                        nature = reader.GetString(3);
                    }

                    if (!reader.IsDBNull(4))
                    {
                        frequence = reader.GetString(4);
                    }

                    if (!reader.IsDBNull(5))
                    {
                        gravite = reader.GetString(5);
                    }

                    list.Add(new EffetSecs()
                    {
                        id_Effet_Sec = idEff,
                        id_Frequence = idFreq,
                        id_Gravite = idGrav,
                        nature = nature,
                        frequence = frequence,
                        gravite = gravite
                    });

                }
                reader.Close();
                dbCon.Close();

            }
            return list;
        }


        private void btnRetourMenu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous Sauvegarder ce test animal avant de retourner au menu ?", "SAUVEGARDE TEST ANIMAL", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (sauvegardeEssaiAnimal())
                {
                    TestsAnimaux testAnim = new TestsAnimaux(idProduit, idVersion, idPhase);
                    this.Hide();
                    testAnim.StartPosition = FormStartPosition.CenterParent;
                    testAnim.Show();
                }
            }
            else
            {
                TestsAnimaux testAnim = new TestsAnimaux(idProduit, idVersion, idPhase);
                this.Hide();
                testAnim.StartPosition = FormStartPosition.CenterParent;
                testAnim.Show();
            }
        }

        private void btnValidUpgrade_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous Sauvegarder ce test animal ?", "SAUVEGARDE TEST ANIMAL", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if(!sauvegardeEssaiAnimal()){
                    MessageBox.Show("Le test animal n'a pas été sauvegardé", "TEST ANIMAL NON SAUVEGARDE", MessageBoxButtons.OK);
                }
            }
        }


        private bool sauvegardeEssaiAnimal()
        {
            if (!comboSujet.Text.Equals("") && inputEffectif.Value != 0 && !inputTauxReussite.Text.Equals("") && !inputVoieAdmin.Text.Equals("") && inputPharmacocin.Value != 0 && !inputPharmacoDur.Text.Equals(""))
            {

                //Connection Base de données r_d_valence
                DBConnection dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "r_d_valence";

                if (dbCon.IsConnect())
                {
                    int idAnimal = -1;

                    //recup idAnimal
                    string queryIdAnimal = "SELECT idAnimal FROM animal where libelle = @libelle";
                    using (MySqlCommand cmdIdAnim = new MySqlCommand(queryIdAnimal, dbCon.Connection))
                    {
                        cmdIdAnim.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = comboSujet.Text;
                        MySqlDataReader rdIdAnim = cmdIdAnim.ExecuteReader();

                        while (rdIdAnim.Read())
                        {
                            idAnimal = rdIdAnim.GetInt32(0);
                        }
                        rdIdAnim.Close();
                    }

                    //Si idAnimal = -1 insertion du nouvel animal
                    if (idAnimal == -1)
                    {
                        string queryMaxIdAnim = "SELECT MAX(idAnimal) FROM animal";
                        using (MySqlCommand cmdMaxIdAnim = new MySqlCommand(queryMaxIdAnim, dbCon.Connection))
                        {
                            MySqlDataReader rdMaxIdAnim = cmdMaxIdAnim.ExecuteReader();

                            while (rdMaxIdAnim.Read())
                            {
                                idAnimal = rdMaxIdAnim.GetInt32(0) + 1;
                            }
                            rdMaxIdAnim.Close();
                        }

                        //insertion du nouvel animal
                        String insertAnim = "insert into animal values (@idAnimal, @libelle)";

                        Console.WriteLine(" C'EST LA REQUETE d'INSERTION DE L'ANIMAL : " + insertAnim);

                        using (MySqlCommand cmdInsertAnim = new MySqlCommand(insertAnim, dbCon.Connection))
                        {
                            cmdInsertAnim.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = idAnimal;
                            cmdInsertAnim.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = comboSujet.Text;

                            cmdInsertAnim.ExecuteNonQuery();
                        }
                    }


                    int idVoieAdmin = -1;

                    //recup idVoieAdmin
                    string queryIdVoieAdmin = "SELECT idAdmin FROM voieadmin where libelle = @libelle";
                    using (MySqlCommand cmdIdVoieAdmin = new MySqlCommand(queryIdVoieAdmin, dbCon.Connection))
                    {
                        cmdIdVoieAdmin.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = inputVoieAdmin.Text;
                        MySqlDataReader rdIdVoieAdmin = cmdIdVoieAdmin.ExecuteReader();

                        while (rdIdVoieAdmin.Read())
                        {
                            idVoieAdmin = rdIdVoieAdmin.GetInt32(0);
                        }
                        rdIdVoieAdmin.Close();
                    }

                    //Si idVoieAdmin = -1 (pas trouvé le libelle) insertion de la nouvelle voie d'administration
                    if (idVoieAdmin == -1)
                    {
                        //Calcul du nouvel id
                        string queryMaxIdAdmin = "SELECT MAX(idAdmin) FROM voieadmin";
                        using (MySqlCommand cmdMaxIdAdmin = new MySqlCommand(queryMaxIdAdmin, dbCon.Connection))
                        {
                            MySqlDataReader rdMaxIdAdmin = cmdMaxIdAdmin.ExecuteReader();

                            while (rdMaxIdAdmin.Read())
                            {
                                idVoieAdmin = rdMaxIdAdmin.GetInt32(0) + 1;
                            }
                            rdMaxIdAdmin.Close();
                        }

                        //insertion de la nouvelle voie d'administration
                        String insertAdmin = "insert into voieadmin values (@idAdmin, @libelle)";

                        Console.WriteLine(" C'EST LA REQUETE d'INSERTION DE LA VOIE D'ADMIN : " + insertAdmin);

                        using (MySqlCommand cmdInsertAdmin = new MySqlCommand(insertAdmin, dbCon.Connection))
                        {
                            cmdInsertAdmin.Parameters.Add("@idAdmin", MySqlDbType.Int32).Value = idVoieAdmin;
                            cmdInsertAdmin.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = inputVoieAdmin.Text;

                            cmdInsertAdmin.ExecuteNonQuery();
                        }
                    }

                    int idPharmDur = -1;

                    //recup idPharmDur
                    string queryIdPharmDur = "SELECT idPharmDur FROM pharmacodur where libelle = @libelle";
                    using (MySqlCommand cmdIdPharmDur = new MySqlCommand(queryIdPharmDur, dbCon.Connection))
                    {
                        cmdIdPharmDur.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = inputPharmacoDur.Text;
                        MySqlDataReader rdIdPharmDur = cmdIdPharmDur.ExecuteReader();

                        while (rdIdPharmDur.Read())
                        {
                            idPharmDur = rdIdPharmDur.GetInt32(0);
                        }
                        rdIdPharmDur.Close();
                    }

                    //Suppression du testAnimal si déjà existant
                    string queryDeleteTestAnim = "DELETE FROM testanimal WHERE idProduit=" + idProduit + " and idVersion = " + idVersion + " and idPhase = " + idPhase + " and idEssai = " + idEssai;
                    MySqlCommand cmdDeleteTestAnim = new MySqlCommand(queryDeleteTestAnim, dbCon.Connection);
                    MySqlDataReader reader = cmdDeleteTestAnim.ExecuteReader();
                    reader.Close();

                    //Insertion dans testAnimal 
                    String insertTestAnim = "insert into testanimal values (@idAnimal, @idProduit, @idVersion, @idPhase, @idEssai, @idAdmin, @effectif, @tauxReussite, @pharmacocin, @idPharmDur, @commentaire, @statut)";

                    Console.WriteLine(" C'EST LA REQUETE d'INSERTION DE L'ESSAI ANIMAL : " + insertTestAnim);

                    using (MySqlCommand cmdInsertTestAnim = new MySqlCommand(insertTestAnim, dbCon.Connection))
                    {
                        cmdInsertTestAnim.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = idAnimal;
                        cmdInsertTestAnim.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;
                        cmdInsertTestAnim.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersion;
                        cmdInsertTestAnim.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhase;
                        cmdInsertTestAnim.Parameters.Add("@idEssai", MySqlDbType.Int32).Value = idEssai;
                        cmdInsertTestAnim.Parameters.Add("@idAdmin", MySqlDbType.Int32).Value = idVoieAdmin;
                        cmdInsertTestAnim.Parameters.Add("@effectif", MySqlDbType.Int32).Value = inputEffectif.Value;
                        cmdInsertTestAnim.Parameters.Add("@tauxReussite", MySqlDbType.Float).Value = float.Parse(inputTauxReussite.Text);
                        cmdInsertTestAnim.Parameters.Add("@pharmacocin", MySqlDbType.Int32).Value = inputPharmacocin.Value;
                        cmdInsertTestAnim.Parameters.Add("@idPharmDur", MySqlDbType.Int32).Value = idPharmDur;
                        cmdInsertTestAnim.Parameters.Add("@commentaire", MySqlDbType.VarChar).Value = inputCommentaire.Text;
                        cmdInsertTestAnim.Parameters.Add("@statut", MySqlDbType.Int32).Value = statut;

                        cmdInsertTestAnim.ExecuteNonQuery();
                    }

                    //Supprime les effets secondaire pour ce produit a cette version et phase
                    string queryDeleteEffetSec = "DELETE FROM affecter WHERE idProduit=" + idProduit + " and idVersion = " + idVersion + " and idPhase = " + idPhase + " and idEssai = " + idEssai;
                    MySqlCommand cmdDeleteEffetSec = new MySqlCommand(queryDeleteEffetSec, dbCon.Connection);
                    MySqlDataReader reader1 = cmdDeleteEffetSec.ExecuteReader();
                    reader1.Close();

                    //Sauvegarde des Effets Secondaires
                    foreach (DataGridViewRow row in dataGridEffetSec.Rows)
                    {
                        DataGridViewComboBoxCell comboBoxCellNature = (row.Cells["Nature_"] as DataGridViewComboBoxCell);
                        DataGridViewComboBoxCell comboBoxCellFrequence = (row.Cells["Frequence_"] as DataGridViewComboBoxCell);
                        DataGridViewComboBoxCell comboBoxCellGravite = (row.Cells["Gravite_"] as DataGridViewComboBoxCell);
                        string nature = comboBoxCellNature.Value.ToString();
                        string frequence = comboBoxCellFrequence.Value.ToString();
                        string gravite = comboBoxCellGravite.Value.ToString();

                        Console.WriteLine("Valeur nature : " + row.Cells["nature"].Value.ToString());
                        Console.WriteLine("Valeur Nature_ : " + row.Cells["Nature_"].Value.ToString());
                        //Console.WriteLine("Valeur res.nature : " + res.nature);

                        int idEffetSec = -1;
                        int idFrequence = -1;
                        int idGravite = -1;

                        string queryselectEffetSec = "SELECT idEffetSecondaire FROM effet_secondaire where libelle = @effetSec";
                        using (MySqlCommand cmdselectidEffetSec = new MySqlCommand(queryselectEffetSec, dbCon.Connection))
                        {
                            cmdselectidEffetSec.Parameters.Add("@effetSec", MySqlDbType.VarChar).Value = nature;
                            MySqlDataReader rd = cmdselectidEffetSec.ExecuteReader();

                            while (rd.Read())
                            {
                                idEffetSec = rd.GetInt32(0);
                            }
                            rd.Close();
                        }

                        string queryselectFreq = "SELECT idFrequence FROM frequence where libelle = @frequence";
                        using (MySqlCommand cmdselectidFreq = new MySqlCommand(queryselectFreq, dbCon.Connection))
                        {
                            cmdselectidFreq.Parameters.Add("@frequence", MySqlDbType.VarChar).Value = frequence;
                            MySqlDataReader rd = cmdselectidFreq.ExecuteReader();

                            while (rd.Read())
                            {
                                idFrequence = rd.GetInt32(0);
                            }
                            rd.Close();
                        }


                        string queryselectGravite = "SELECT idGravite FROM gravite where libelle = @gravite";
                        using (MySqlCommand cmdselectidGravite = new MySqlCommand(queryselectGravite, dbCon.Connection))
                        {
                            cmdselectidGravite.Parameters.Add("@gravite", MySqlDbType.VarChar).Value = gravite;
                            MySqlDataReader rd = cmdselectidGravite.ExecuteReader();

                            while (rd.Read())
                            {
                                idGravite = rd.GetInt32(0);
                            }
                            rd.Close();
                        }


                        if (idEffetSec != -1 & idFrequence != -1 && idGravite != -1)
                        {
                            String insertEffetSec = "insert into affecter values (@idProduit, @idVersion, @idPhase, @idEssai, @idEffetSec, @idFrequence, @idGravite)";

                            Console.WriteLine(" C'EST LA REQUETE d'INSERTION DES EFFETS SECONDAIRES : " + insertEffetSec);
                            Console.WriteLine(idProduit + " - " + idVersion + " - " + idPhase + " - " + idEssai + " - " + idEffetSec + " - " + idFrequence + " - " + idGravite);

                            using (MySqlCommand cmdInsertEffetSec = new MySqlCommand(insertEffetSec, dbCon.Connection))
                            {
                                cmdInsertEffetSec.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;
                                cmdInsertEffetSec.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersion;
                                cmdInsertEffetSec.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhase;
                                cmdInsertEffetSec.Parameters.Add("@idEssai", MySqlDbType.Int32).Value = idEssai;
                                cmdInsertEffetSec.Parameters.Add("@idEffetSec", MySqlDbType.Int32).Value = idEffetSec;
                                cmdInsertEffetSec.Parameters.Add("@idFrequence", MySqlDbType.VarChar).Value = idFrequence;
                                cmdInsertEffetSec.Parameters.Add("@idGravite", MySqlDbType.VarChar).Value = idGravite;

                                cmdInsertEffetSec.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Test Animal Enregistré avec succès !", "TEST ANIMAL SAUVEGARDE", MessageBoxButtons.OK);
                    
                }
                dbCon.Close();

                return true;
            }
            else
            {
                MessageBox.Show("Attention certains éléments ne sont pas renseignés ! veuillez remplir l'ensemble des champs avant de procéder à la sauvegarde.", "TEST ANIMAL NON SAUVEGARDE", MessageBoxButtons.OK);
                return false;
            }
        }

        private void btnAjoutEffet_Click(object sender, EventArgs e)
        {
            saveChangeDatagrid();

            List<EffetSecs> effets = this.listEffetSecs;
            
            effets.Add(new EffetSecs()
            {
                nature = "Troubles de la vision",
                frequence = ">1/10",
                gravite = "faible"
            });
            
            BindingSource source = new BindingSource();
            source.DataSource = effets;
            dataGridEffetSec.DataSource = source;

            majActionDataGrid();
        }

        public void saveChangeDatagrid()
        {
            //supprime l'ensembles des effets secondaires
            List<EffetSecs> effets = this.listEffetSecs;
            effets.Clear();
            
            //Enregistre les modifications sur les effets secondaires
            foreach (DataGridViewRow row in dataGridEffetSec.Rows)
            {
               string nature = row.Cells["Nature_"].Value.ToString();
               string frequence = row.Cells["Frequence_"].Value.ToString();
               string gravite = row.Cells["Gravite_"].Value.ToString();

                effets.Add(new EffetSecs()
                {
                    nature = nature,
                    frequence = frequence,
                    gravite = gravite
                });
            }
        }

        private void btnRetireEffet_Click(object sender, EventArgs e)
        {
            saveChangeDatagrid();
            //recharge le datagridView
            List<EffetSecs> effets = this.listEffetSecs;

            EffetSecs effetASup = new EffetSecs {nature = "", frequence = "", gravite = "" };

            foreach (DataGridViewRow row in dataGridEffetSec.Rows)
            {
                if (row.Selected || row.Cells[0].Selected || row.Cells[1].Selected || row.Cells[2].Selected)
                {
                    for (int i = 0; i < effets.Count; i++)
                    {
                        if (effets[i].nature.Equals(row.Cells["Nature_"].Value.ToString()) && effets[i].frequence.Equals(row.Cells["Frequence_"].Value.ToString()) && effets[i].gravite.Equals(row.Cells["Gravite_"].Value.ToString()))
                        {
                            effetASup = effets[i];
                            Console.WriteLine("EFFET A SUPPRIMER !! : " + effetASup.nature);
                        }
                    }

                }
            }

            //on supprime l'effet de la liste des effets secondaires
            effets.Remove(effetASup);

            BindingSource source = new BindingSource();
            source.DataSource = listEffetSecs;
            dataGridEffetSec.DataSource = source;

            majActionDataGrid();
        }

        private void EssaiAnimaux_Load(object sender, EventArgs e)
        {
            List<EffetSecs> effetSecs = this.listEffetSecs;

            BindingSource source = new BindingSource();
            source.DataSource = effetSecs;
            dataGridEffetSec.DataSource = source;
            dataGridEffetSec.Columns["id_Effet_Sec"].Visible = false;
            dataGridEffetSec.Columns["id_Frequence"].Visible = false;
            dataGridEffetSec.Columns["id_Gravite"].Visible = false;
            dataGridEffetSec.Columns["nature"].Visible = false;
            dataGridEffetSec.Columns["frequence"].Visible = false;
            dataGridEffetSec.Columns["gravite"].Visible = false;

            dataGridEffetSec.Columns.Add(cmbNature);
            dataGridEffetSec.Columns.Add(cmbFrequence);
            dataGridEffetSec.Columns.Add(cmbGravite);

            majActionDataGrid();
        }

        private void majActionDataGrid()
        {
            foreach (DataGridViewRow row in dataGridEffetSec.Rows)
            {
                foreach (EffetSecs res in listEffetSecs)
                {
                   if (res.nature.Equals(row.Cells["nature"].Value.ToString()) && res.gravite.Equals(row.Cells["gravite"].Value.ToString()) && res.frequence.Equals(row.Cells["frequence"].Value.ToString()))
                    {
                        Console.WriteLine("ROW : "+row.Selected);

                        Console.WriteLine("listEffetSec Nature : "+ res.nature);
                        Console.WriteLine("listEffetSec frequence : " + res.frequence);
                        Console.WriteLine("listEffetSec gravite : " + res.gravite);
                        
                        DataGridViewComboBoxCell comboBoxCellNature = (row.Cells["Nature_"] as DataGridViewComboBoxCell);
                        DataGridViewComboBoxCell comboBoxCellFrequence = (row.Cells["Frequence_"] as DataGridViewComboBoxCell);
                        DataGridViewComboBoxCell comboBoxCellGravite = (row.Cells["Gravite_"] as DataGridViewComboBoxCell);

                        comboBoxCellNature.Value = res.nature;
                        comboBoxCellFrequence.Value = res.frequence;
                        comboBoxCellGravite.Value = res.gravite;


                    }
                }
            }
        }

        private void dataGridEffetSec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Couleur de ligne rouge quand clique pour suppression d'effet secondaire
             DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
            CellStyle.BackColor = Color.Red;
            dataGridEffetSec.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = CellStyle;
            */
        }

        private void lblPhasprecli_Click(object sender, EventArgs e)
        {

        }

        private void lblNomProduit_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnPhaseSuivante_Click(object sender, EventArgs e)
        {
            //Rend le statut de la phase valide
            validerPhase();
            //Ouvre la vue de test humain
        }


        public void validerPhase()
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous sauvegarder l'essai animal et passer à la phase suivante ? \n Toutes les informations concernant cette phase du produit seront sauvegardées", "PASSER A LA PHASE SUIVANTE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (sauvegardeEssaiAnimal())
                {
                    DBConnection dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "r_d_valence";

                    //2 insert dans valider : le premier pour dire que l'étape précédente est validée, le second pour dire que la nouvelle étape est en cours de validation.
                    if (dbCon.IsConnect())
                    {
                        Console.WriteLine("DB CONNECTION FAITE !");

                        //update le testAnimal en mettant le statut à 1
                        string queryUpdateTestAnim = "UPDATE testAnimal set Statut =1 where idEssai = "+ idEssai +" and idProduit = " + idProduit + " and idVersion = " + idVersion + " and idPhase = " + idPhase;
                        MySqlCommand cmdUpdateTestAnim = new MySqlCommand(queryUpdateTestAnim, dbCon.Connection);
                        cmdUpdateTestAnim.ExecuteNonQuery();

                        //validation de l'ancienne phase
                        string queryUpdateValider1 = "UPDATE valider set validation =1, commentaire= \"" + inputCommentaire.Text + "\" where idProduit = " + idProduit + " and idVersion = " + idVersion + " and idPhase = " + idPhase;
                        MySqlCommand cmdUpdateValider1 = new MySqlCommand(queryUpdateValider1, dbCon.Connection);
                        cmdUpdateValider1.ExecuteNonQuery();


                        //incrément de l'id de phase courante
                        idPhase++;

                        string query = "SELECT idProduit, idVersion, idPhase " +
                                       "FROM valider v " +
                                       "where v.idPhase = " + idPhase + " " +
                                       "and v.idProduit = " + idProduit + " " +
                                       "and v.idVersion = " + idVersion;

                        MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            //ouvre le produit trouvé dans la phase Test Humain
                            TestHumains testHumains = new TestHumains(idProduit, idVersion, idPhase);
                            this.Hide();
                            testHumains.StartPosition = FormStartPosition.CenterParent;
                            testHumains.Show();
                        }
                        else
                        {
                            //Si pas de validation de phase pour se produit 
                            reader.Close();

                            //maj de la date de validation du produit
                            dateValidation = DateTime.Today;

                            //Insertion de la nouvelle validation de phase
                            string queryInsertValider = "insert into valider values (@idPhase, @idVersion, @idProduit, @dateInsertProd, @dateValidation, 0, \"\")";
                            Console.WriteLine("REQUETE D'INSERT NOUVEL PHASE : " + queryInsertValider);
                            using (MySqlCommand cmdInsertValider = new MySqlCommand(queryInsertValider, dbCon.Connection))
                            {
                                cmdInsertValider.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhase;
                                cmdInsertValider.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersion;
                                cmdInsertValider.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;
                                cmdInsertValider.Parameters.Add("@dateInsertProd", MySqlDbType.Datetime).Value = dateInsertProd;
                                cmdInsertValider.Parameters.Add("@dateValidation", MySqlDbType.Datetime).Value = dateValidation;
                                cmdInsertValider.ExecuteNonQuery();
                            }
                            reader.Close();

                            //ouvre le produit en phase test Humain
                            TestHumains testHumains = new TestHumains(idProduit, idVersion, idPhase);
                            this.Hide();
                            testHumains.StartPosition = FormStartPosition.CenterParent;
                            testHumains.Show();
                        }

                    }
                    dbCon.Close();
                }
                else
                {
                    MessageBox.Show("Attention, L'essai animal n'a pas été sauvegardée, la phase n'a pas pu être passée", "ESSAI ANIMAL NON SAUVEGARDE", MessageBoxButtons.OK);
                }
            }
        }


    }
}
