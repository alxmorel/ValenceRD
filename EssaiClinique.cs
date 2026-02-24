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
    public partial class EssaiClinique : Form
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


        public EssaiClinique(int _idProduit, int _idVersion, int _idPhase, int _idEssai)
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

                //initialise la liste des Sexes
                string queryGenre = "SELECT libelle FROM genre";
                MySqlCommand cmdGenre = new MySqlCommand(queryGenre, dbCon.Connection);
                MySqlDataReader rdGenre = cmdGenre.ExecuteReader();

                while (rdGenre.Read())
                {
                    comboSexe.Items.Add(rdGenre.GetString(0));
                }
                rdGenre.Close();

                comboSexe.Items.Add("");

                //initialise la liste des etats sujet
                string queryEtatSujet = "SELECT libelle FROM etatsujet";
                MySqlCommand cmdES = new MySqlCommand(queryEtatSujet, dbCon.Connection);
                MySqlDataReader rdES = cmdES.ExecuteReader();

                while (rdES.Read())
                {
                    comboEtatSujet.Items.Add(rdES.GetString(0));
                }
                rdES.Close();

                comboEtatSujet.Items.Add("");


                //initialise la liste des tranches d'age
                string queryAdmin = "SELECT libelle FROM trancheage";
                MySqlCommand cmdAdmin = new MySqlCommand(queryAdmin, dbCon.Connection);
                MySqlDataReader rdAdmin = cmdAdmin.ExecuteReader();

                while (rdAdmin.Read())
                {
                    inputTrancheAge.Items.Add(rdAdmin.GetString(0));
                }
                rdAdmin.Close();

                inputTrancheAge.Items.Add("");


                //initialise la liste des placebo
                comboPlacebo.Items.Add("oui");
                comboPlacebo.Items.Add("non");


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
                string queryStatut = "SELECT Statut FROM testhumain where idProduit = " + idProduit + " and idVersion = " + idVersion + " and idEssai = " + idEssai;
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


                //initialise ComboSexe
                string querySexe = "SELECT libelle FROM genre a left join testhumain ta on ta.idSexe=a.idGenre where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                 cmd = new MySqlCommand(querySexe, dbCon.Connection);
                 rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    comboSexe.Text = rd.GetString(0);
                }
                rd.Close();

                //initialise Effectif
                string queryEffectif = "SELECT effectif FROM testhumain ta where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryEffectif, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    inputEffectif.Value = rd.GetInt32(0);
                }
                rd.Close();

                //initialise Taux de reussite
                string queryTauxReussite = "SELECT tauxReussite FROM testhumain ta where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryTauxReussite, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    inputTauxReussite.Text = rd.GetString(0);
                }
                rd.Close();

                //initialise tranche age
                string queryVoieAdmin = "SELECT libelle FROM trancheage a left join testhumain ta on ta.idTrancheAge=a.idTrancheAge where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryVoieAdmin, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    inputTrancheAge.Text = rd.GetString(0);
                }
                rd.Close();

                //initialise Etat Sujet
                string queryES = "SELECT libelle FROM etatsujet a left join testhumain ta on ta.idEtatSujet=a.idEtat where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryES, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    comboEtatSujet.Text = rd.GetString(0);
                }
                rd.Close();


                //initialise placebo
                string queryPlacebo = "SELECT placebo FROM testhumain where idProduit = " + idProduit + " and idVersion = " + idVersion + " and idEssai = " + idEssai;
                cmd = new MySqlCommand(queryPlacebo, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    comboPlacebo.Text = rd.GetString(0);
                }
                rd.Close();


                //initialise pharmacocinétique du medic
                string queryPharmacin = "SELECT pharmacocin FROM testhumain ta where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryPharmacin, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    inputPharmacocin.Value = rd.GetInt32(0);
                }
                rd.Close();

                //initialise durée de pharmacocinétique
                string queryPharmaDur = "SELECT libelle FROM pharmacodur a left join testhumain ta on ta.idPharmDur=a.idPharmDur where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
                cmd = new MySqlCommand(queryPharmaDur, dbCon.Connection);
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    inputPharmacoDur.Text = rd.GetString(0);
                }
                rd.Close();


                //initialise commentaire de l'essai animal
                string queryCom = "SELECT commentaire FROM testhumain ta where ta.idProduit = " + idProduit + " and ta.idVersion = " + idVersion + " and ta.idEssai = " + idEssai;
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
                string query = "SELECT e.idEffetSecondaire, fr.idFrequence, g.idGravite ,e.libelle, fr.libelle, g.libelle from affecter a left join effet_secondaire e on a.idEffetSecondaire = e.idEffetSecondaire left join frequence fr on a.idFrequence = fr.idFrequence left join gravite g on a.idGravite = g.idGravite where idProduit = " + idProduit + " and idPhase = " + idPhase + " and idVersion = " + idVersion + " and idEssai = " + idEssai;
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




        private bool sauvegardeEssaiClinique()
        {
            if (!comboSexe.Text.Equals("") && inputEffectif.Value != 0 && !inputTauxReussite.Text.Equals("") && !inputTrancheAge.Text.Equals("") && !comboEtatSujet.Text.Equals("") && !comboPlacebo.Text.Equals("") && inputPharmacocin.Value != 0 && !inputPharmacoDur.Text.Equals(""))
            {

                //Connection Base de données r_d_valence
                DBConnection dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "r_d_valence";

                if (dbCon.IsConnect())
                {
                    int idGenre = -1;

                    //recup idAnimal
                    string queryIdGenre = "SELECT idGenre FROM genre where libelle = @libelle";
                    using (MySqlCommand cmdGenre = new MySqlCommand(queryIdGenre, dbCon.Connection))
                    {
                        cmdGenre.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = comboSexe.Text;
                        MySqlDataReader rdGenre = cmdGenre.ExecuteReader();

                        while (rdGenre.Read())
                        {
                            idGenre = rdGenre.GetInt32(0);
                        }
                        rdGenre.Close();
                    }

                    //Si idAnimal = -1 insertion du nouvel animal
                    if (idGenre == -1)
                    {
                        string queryMaxIdGenre = "SELECT MAX(idGenre) FROM genre";
                        using (MySqlCommand cmdMaxGenre = new MySqlCommand(queryMaxIdGenre, dbCon.Connection))
                        {
                            MySqlDataReader rdMaxGenre = cmdMaxGenre.ExecuteReader();

                            while (rdMaxGenre.Read())
                            {
                                idGenre = rdMaxGenre.GetInt32(0) + 1;
                            }
                            rdMaxGenre.Close();
                        }

                        //insertion du nouvel animal
                        String insertGenre = "insert into genre values (@idGenre, @libelle)";

                        Console.WriteLine(" C'EST LA REQUETE d'INSERTION DU SEXE : " + insertGenre);

                        using (MySqlCommand cmdInsGenre = new MySqlCommand(insertGenre, dbCon.Connection))
                        {
                            cmdInsGenre.Parameters.Add("@idGenre", MySqlDbType.Int32).Value = idGenre;
                            cmdInsGenre.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = comboSexe.Text;

                            cmdInsGenre.ExecuteNonQuery();
                        }
                    }


                    int idTrancheAge = -1;

                    //recup idTrancheAge
                    string queryIdTA = "SELECT idTrancheAge FROM trancheage where libelle = @libelle";
                    using (MySqlCommand cmdIdTa = new MySqlCommand(queryIdTA, dbCon.Connection))
                    {
                        cmdIdTa.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = inputTrancheAge.Text;
                        MySqlDataReader rdIdTa = cmdIdTa.ExecuteReader();

                        while (rdIdTa.Read())
                        {
                            idTrancheAge = rdIdTa.GetInt32(0);
                        }
                        rdIdTa.Close();
                    }

                    //Si idTrancheAge = -1 (pas trouvé le libelle) insertion de la nouvelle Tranche d'Age
                    if (idTrancheAge == -1)
                    {
                        //Calcul du nouvel id
                        string queryMaxIdTrancheAge = "SELECT MAX(idTrancheAge) FROM trancheage";
                        using (MySqlCommand cmdMaxTa = new MySqlCommand(queryMaxIdTrancheAge, dbCon.Connection))
                        {
                            MySqlDataReader rdMaxTa = cmdMaxTa.ExecuteReader();

                            while (rdMaxTa.Read())
                            {
                                idTrancheAge = rdMaxTa.GetInt32(0) + 1;
                            }
                            rdMaxTa.Close();
                        }

                        //insertion de la nouvelle tranche d'age
                        String insertTa = "insert into trancheage values (@idTrancheAge, @libelle)";

                        Console.WriteLine(" C'EST LA REQUETE d'INSERTION DE LA TRANCHE D'AGE : " + insertTa);

                        using (MySqlCommand cmdInsTa = new MySqlCommand(insertTa, dbCon.Connection))
                        {
                            cmdInsTa.Parameters.Add("@idTrancheAge", MySqlDbType.Int32).Value = idTrancheAge;
                            cmdInsTa.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = inputTrancheAge.Text;

                            cmdInsTa.ExecuteNonQuery();
                        }
                    }


                    //Recup idEtatSujet
                    int idEtatSujet = -1;

                    string queryIdES = "SELECT idEtat FROM etatsujet where libelle = @libelle";
                    using (MySqlCommand cmdES = new MySqlCommand(queryIdES, dbCon.Connection))
                    {
                        cmdES.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = comboEtatSujet.Text;
                        MySqlDataReader rdES = cmdES.ExecuteReader();

                        while (rdES.Read())
                        {
                            idEtatSujet = rdES.GetInt32(0);
                        }
                        rdES.Close();
                    }

                    //Si idTrancheAge = -1 (pas trouvé le libelle) insertion de la nouvelle Tranche d'Age
                    if (idEtatSujet == -1)
                    {
                        //Calcul du nouvel id
                        string queryMaxIdEtatSujet = "SELECT MAX(idEtat) FROM etatsujet";
                        using (MySqlCommand cmdMaxES = new MySqlCommand(queryMaxIdEtatSujet, dbCon.Connection))
                        {
                            MySqlDataReader rdMaxES = cmdMaxES.ExecuteReader();

                            while (rdMaxES.Read())
                            {
                                idEtatSujet = rdMaxES.GetInt32(0) + 1;
                            }
                            rdMaxES.Close();
                        }

                        //insertion du nouvel etat sujet
                        String insertES = "insert into etatsujet values (@idEtatSujet, @libelle)";

                        Console.WriteLine(" C'EST LA REQUETE d'INSERTION DE l'ETAT SUJET : " + insertES);

                        using (MySqlCommand cmdInsES = new MySqlCommand(insertES, dbCon.Connection))
                        {
                            cmdInsES.Parameters.Add("@idEtatSujet", MySqlDbType.Int32).Value = idEtatSujet;
                            cmdInsES.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = comboEtatSujet.Text;

                            cmdInsES.ExecuteNonQuery();
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

                    //Suppression du test humain si déjà existant
                    string QdeleteTestHumain = "DELETE FROM testhumain WHERE idProduit=" + idProduit + " and idVersion = " + idVersion + " and idPhase = " + idPhase + " and idEssai = " + idEssai;
                    MySqlCommand cmd = new MySqlCommand(QdeleteTestHumain, dbCon.Connection);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    rd.Close();

                    //Insertion dans testhumain 
                    String QinsertTestHumain = "insert into testhumain values (@idProduit, @idVersion, @idPhase, @idEssai, @idSexe, @effectif, @idTrancheAge, @idEtatSujet, @placebo, @tauxReussite, @pharmacocin, @idPharmDur, @commentaire, @statut)";

                    Console.WriteLine(" C'EST LA REQUETE d'INSERTION DU TEST HUMAIN : " + QinsertTestHumain);

                    using (MySqlCommand cmdInsertTestHumain = new MySqlCommand(QinsertTestHumain, dbCon.Connection))
                    {
                        cmdInsertTestHumain.Parameters.Add("@idSexe", MySqlDbType.Int32).Value = idGenre;
                        cmdInsertTestHumain.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;
                        cmdInsertTestHumain.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersion;
                        cmdInsertTestHumain.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhase;
                        cmdInsertTestHumain.Parameters.Add("@idEssai", MySqlDbType.Int32).Value = idEssai;
                        cmdInsertTestHumain.Parameters.Add("@idTrancheAge", MySqlDbType.Int32).Value = idTrancheAge;
                        cmdInsertTestHumain.Parameters.Add("@idEtatSujet", MySqlDbType.Int32).Value = idEtatSujet;
                        cmdInsertTestHumain.Parameters.Add("@placebo", MySqlDbType.VarChar).Value = comboPlacebo.Text;
                        cmdInsertTestHumain.Parameters.Add("@effectif", MySqlDbType.Int32).Value = inputEffectif.Value;
                        cmdInsertTestHumain.Parameters.Add("@tauxReussite", MySqlDbType.Float).Value = float.Parse(inputTauxReussite.Text);
                        cmdInsertTestHumain.Parameters.Add("@pharmacocin", MySqlDbType.Int32).Value = inputPharmacocin.Value;
                        cmdInsertTestHumain.Parameters.Add("@idPharmDur", MySqlDbType.Int32).Value = idPharmDur;
                        cmdInsertTestHumain.Parameters.Add("@commentaire", MySqlDbType.VarChar).Value = inputCommentaire.Text;
                        cmdInsertTestHumain.Parameters.Add("@statut", MySqlDbType.Int32).Value = statut;

                        cmdInsertTestHumain.ExecuteNonQuery();
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
                            MySqlDataReader rdEffeSec = cmdselectidEffetSec.ExecuteReader();

                            while (rdEffeSec.Read())
                            {
                                idEffetSec = rdEffeSec.GetInt32(0);
                            }
                            rdEffeSec.Close();
                        }

                        string queryselectFreq = "SELECT idFrequence FROM frequence where libelle = @frequence";
                        using (MySqlCommand cmdselectidFreq = new MySqlCommand(queryselectFreq, dbCon.Connection))
                        {
                            cmdselectidFreq.Parameters.Add("@frequence", MySqlDbType.VarChar).Value = frequence;
                            MySqlDataReader rdFreq = cmdselectidFreq.ExecuteReader();

                            while (rdFreq.Read())
                            {
                                idFrequence = rdFreq.GetInt32(0);
                            }
                            rdFreq.Close();
                        }


                        string queryselectGravite = "SELECT idGravite FROM gravite where libelle = @gravite";
                        using (MySqlCommand cmdselectidGravite = new MySqlCommand(queryselectGravite, dbCon.Connection))
                        {
                            cmdselectidGravite.Parameters.Add("@gravite", MySqlDbType.VarChar).Value = gravite;
                            MySqlDataReader rdGrav = cmdselectidGravite.ExecuteReader();

                            while (rdGrav.Read())
                            {
                                idGravite = rdGrav.GetInt32(0);
                            }
                            rdGrav.Close();
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

                    MessageBox.Show("Essai Clinique Enregistré avec succès !", "ESSAI CLINIQUE SAUVEGARDE", MessageBoxButtons.OK);

                }
                dbCon.Close();

                return true;
            }
            else
            {
                MessageBox.Show("Attention certains éléments ne sont pas renseignés ! veuillez remplir l'ensemble des champs avant de procéder à la sauvegarde.", "ESSAI CLINIQUE NON SAUVEGARDE", MessageBoxButtons.OK);
                return false;
            }
        }




        private void btnRetourMenu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous Sauvegarder cet essai clinique avant de retourner au menu ?", "SAUVEGARDE ESSAI CLINIQUE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (sauvegardeEssaiClinique())
                {
                    TestHumains testHumains = new TestHumains(idProduit, idVersion, idPhase);
                    this.Hide();
                    testHumains.StartPosition = FormStartPosition.CenterParent;
                    testHumains.Show();
                }
            }
            else
            {
                TestHumains testHumains = new TestHumains(idProduit, idVersion, idPhase);
                this.Hide();
                testHumains.StartPosition = FormStartPosition.CenterParent;
                testHumains.Show();
            }
        }

        private void btnValidUpgrade_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous Sauvegarder cet essai clinique ?", "SAUVEGARDE ESSAI CLINIQUE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (!sauvegardeEssaiClinique())
                {
                    MessageBox.Show("L'essai clinique n'a pas été sauvegardé", "ESSAI CLINIQUE NON SAUVEGARDE", MessageBoxButtons.OK);
                }
            }
        }
    }
}
