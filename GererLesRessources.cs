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
    public partial class GererLesRessources : Form
    {
        private string idRessFiltre;
        private string prenomRessFiltre;
        private string nomRessFiltre;


        public List<Ressources> ListRessources { get; set; }
        public List<RessourcesTotal> listRessourcesTot { get; set; }
        DataGridViewComboBoxColumn cmbAction = new DataGridViewComboBoxColumn();
        private int idProduit;
        private int idPhase;
        private int idVersion;

        public GererLesRessources(int _idProduit, int _idPhase, int _idVersion)
        {
            InitializeComponent();

            idRessFiltre = comboId.Text;
            prenomRessFiltre = comboPrenom.Text;
            nomRessFiltre = comboNom.Text;

            idProduit = _idProduit;
            idPhase = _idPhase;
            idVersion = _idVersion;
            ListRessources = getListRessources(idProduit, idPhase, idVersion);
            listRessourcesTot = getListRessourcesTotal();
        }


        private List<RessourcesTotal> getListRessourcesTotal()
        {
            List<RessourcesTotal> listTot = new List<RessourcesTotal>();

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                //initialise la liste des ressources total
                string queryselectRess = "SELECT idRessource, prenom, nom from ressource order by idRessource";
                MySqlCommand cmdselectRess = new MySqlCommand(queryselectRess, dbCon.Connection);
                MySqlDataReader readerselectRess = cmdselectRess.ExecuteReader();

                comboId.Items.Add("");
                comboPrenom.Items.Add("");
                comboNom.Items.Add("");

                while (readerselectRess.Read())
                {
                    comboId.Items.Add(readerselectRess.GetString(0));
                    comboPrenom.Items.Add(readerselectRess.GetString(1));
                    comboNom.Items.Add(readerselectRess.GetString(2));

                    listTot.Add(new RessourcesTotal()
                    {
                        id_Ressource = readerselectRess.GetInt32(0),
                        prenom = readerselectRess.GetString(1),
                        nom = readerselectRess.GetString(2)
                    });
                }
                readerselectRess.Close();
            }
            dbCon.Close();

            return listTot;
        }

        private void GererLesRessources_Load(object sender, EventArgs e)
        {
            //Ressources totales
            List<RessourcesTotal> ressourcesTot = this.listRessourcesTot;

            BindingSource source1 = new BindingSource();
            source1.DataSource = ressourcesTot;

            dataGridView2.DataSource = source1;

            //ressources impliquées
            List<Ressources> ressources = this.ListRessources;

            BindingSource source = new BindingSource();
            source.DataSource = ressources;

            dataGridView1.DataSource = source;

            dataGridView1.Columns["chargeTravail"].Visible = false;
            dataGridView1.Columns["textAction"].Visible = false;

            dataGridView1.Columns.Add(cmbAction);

            majActionDataGrid();

        }


        private void majActionDataGrid()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (Ressources res in ListRessources)
                {
                    if (res.nom.Equals(row.Cells["nom"].Value.ToString()) && res.prenom.Equals(row.Cells["prenom"].Value.ToString()))
                    {
                        DataGridViewComboBoxCell comboBoxCell = (row.Cells["Action"] as DataGridViewComboBoxCell);
                        comboBoxCell.Value = res.textAction;
                    }
                }
            }
        }


        private List<Ressources> getListRessources(int idProduit, int idPhase, int idVersion)
        {
            List<Ressources> list = new List<Ressources>();
            cmbAction.Name = "Action";
            cmbAction.HeaderText = "Action";

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {

                //initialise la liste des opérations
                string queryselectOperation = "SELECT libelle FROM etape where idEtape >0 order by idEtape";
                MySqlCommand cmdselectOperation = new MySqlCommand(queryselectOperation, dbCon.Connection);
                MySqlDataReader readerselectOperation = cmdselectOperation.ExecuteReader();

                while (readerselectOperation.Read())
                {
                    cmbAction.Items.Add(readerselectOperation.GetString(0));
                }
                readerselectOperation.Close();



                string SelectRess = "select r.idRessource, nom, prenom, e.libelle from ressource r left join travailler t on r.idRessource = t.idRessource left join etape e on e.idEtape = t.idEtape where idProduit = @idProd and idPhase = @idPhase and idVersion = @idVersion ";

                using (MySqlCommand cmdSelectRess = new MySqlCommand(SelectRess, dbCon.Connection))
                {
                    cmdSelectRess.Parameters.Add("@idProd", MySqlDbType.Int32).Value = idProduit;
                    cmdSelectRess.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhase;
                    cmdSelectRess.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersion;
                    MySqlDataReader reader = cmdSelectRess.ExecuteReader(); //Récupère l'identifiant du symptome qu'il traite

                    while (reader.Read())
                    {

                        list.Add(new Ressources()
                        {
                            id_Ressource = reader.GetInt32(0),
                            nom = reader.GetString(1),
                            prenom = reader.GetString(2),
                            textAction = reader.GetString(3)
                        });
                    }
                    reader.Close();
                }

            }
            dbCon.Close();

            return list;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {


            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous sauvegarder la gestion des ressources de la recette avant de quitter ? \n Toutes modifications non sauvegardées seront perdues", "SAUVEGARDER LA GESTION DES RESSOURCES", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (SauvegarderRessources())
                {
                    RechercheProduit rechProd = new RechercheProduit(idProduit, idVersion, idPhase);
                    this.Hide();
                    rechProd.StartPosition = FormStartPosition.CenterParent;
                    rechProd.Show();
                }
                else
                {
                    MessageBox.Show("Attention, La gestion des ressources de la recette n'a pas été sauvegardée", "GESTION RESSOURCES NON SAUVEGARDEE", MessageBoxButtons.OK);
                }
            }
            else
            {
                RechercheProduit rechProd = new RechercheProduit(idProduit, idVersion, idPhase);
                this.Hide();
                rechProd.StartPosition = FormStartPosition.CenterParent;
                rechProd.Show();
            } 
        }


        private bool SauvegarderRessources()
        {
            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {

                //Supprime les ressources de ce produit à cette phase et cette version
                string queryDeleteOperation = "delete FROM travailler where idVersion = @idVersion and idPhase = @idPhase and idProduit = @idProd";
                using (MySqlCommand cmdDeleteTravail = new MySqlCommand(queryDeleteOperation, dbCon.Connection))
                {
                    cmdDeleteTravail.Parameters.Add("@idProd", MySqlDbType.Int32).Value = idProduit;
                    cmdDeleteTravail.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhase;
                    cmdDeleteTravail.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersion;
                    MySqlDataReader reader = cmdDeleteTravail.ExecuteReader();
                    reader.Close();
                }

                //Pour chaque ressources dans le tableau, ajoute la ressource et l'action effectuée (idEtape) à cette cette phase et version de ce produit dans la table travailler
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (Ressources res in ListRessources)
                    {
                        if (res.nom.Equals(row.Cells["nom"].Value.ToString()) && res.prenom.Equals(row.Cells["prenom"].Value.ToString()))
                        {
                            DataGridViewComboBoxCell comboBoxCell = (row.Cells["Action"] as DataGridViewComboBoxCell);
                            string action = comboBoxCell.Value.ToString();
                            int idEtapeRess = -1;

                            string queryselectOperation = "SELECT idEtape FROM etape where libelle = @action";
                            using (MySqlCommand cmdselectidEtape = new MySqlCommand(queryselectOperation, dbCon.Connection))
                            {
                                cmdselectidEtape.Parameters.Add("@action", MySqlDbType.VarChar).Value = action;
                                MySqlDataReader rd = cmdselectidEtape.ExecuteReader();

                                while (rd.Read())
                                {
                                    idEtapeRess = rd.GetInt32(0);
                                }
                                rd.Close();
                            }


                            if (idEtapeRess != -1)
                            {
                                string InsertTravail = "insert into travailler values(@idRess, @idProd, @idVersion, @idPhase, @idEtape)";
                                using (MySqlCommand cmdInsertTravail = new MySqlCommand(InsertTravail, dbCon.Connection))
                                {
                                    cmdInsertTravail.Parameters.Add("@idRess", MySqlDbType.Int32).Value = res.id_Ressource;
                                    cmdInsertTravail.Parameters.Add("@idProd", MySqlDbType.Int32).Value = idProduit;
                                    cmdInsertTravail.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersion;
                                    cmdInsertTravail.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhase;
                                    cmdInsertTravail.Parameters.Add("@idEtape", MySqlDbType.Int32).Value = idEtapeRess;
                                    MySqlDataReader reader = cmdInsertTravail.ExecuteReader();
                                    reader.Close();
                                }

                            }
                        }
                    }
                }

                dbCon.Close();
                return true;
            }

            else
            {
                return false;
            }
        }



        private void btnCreerProduit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Êtes-vous sûr de vouloir Appliquer cette gestion des ressources ? \n Cette opération entraînera une modification des données en base pour cette recette ", "APPLIQUER LA GESTION ACTUELLE DES RESSOURCES", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                if (SauvegarderRessources())
                {
                    MessageBox.Show("Gestion des ressources sauvegardée avec succès !", "GESTION DES RESSOURCES SAUVEGARDEE", MessageBoxButtons.OK);

                    //retour page recette
                    RechercheProduit rechProd = new RechercheProduit(idProduit, idVersion, idPhase);
                    this.Hide();
                    rechProd.StartPosition = FormStartPosition.CenterParent;
                    rechProd.Show();
                }
                else
                {
                    MessageBox.Show("Attention, La gestion des ressources de la recette n'a pas été sauvegardée", "GESTION RESSOURCES NON SAUVEGARDEE", MessageBoxButtons.OK);
                }
            }
        }

        private void btnRetireRess_Click(object sender, EventArgs e)
        {
            //recharge le datagridView
            List<Ressources> ressources = this.ListRessources;

            Ressources ressASup = new Ressources { id_Ressource=-1, prenom = "", nom = "", textAction="" };

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected || row.Cells[0].Selected || row.Cells[1].Selected || row.Cells[2].Selected)
                {
                    for (int i = 0; i < ressources.Count; i++)
                    {
                        if (ressources[i].id_Ressource.ToString().Equals(row.Cells["id_Ressource"].Value.ToString())){
                            
                            ressASup = ressources[i];
                            Console.WriteLine("RESSOURCE A SUPPRIMER !! : " + ressASup.nom + " "+ ressASup.prenom);

                            //suppression de la ressource dans la liste des ressources
                            ressources.Remove(ressASup);

                            //maj du tableau des phases de produit
                            BindingSource source = new BindingSource();
                            source.DataSource = ListRessources;
                            dataGridView1.DataSource = source;

                            majActionDataGrid();
                        }
                    }

                }
            }
        }

        private void btnAjoutRessource_Click(object sender, EventArgs e)
        {
            List<Ressources> ressources = this.ListRessources;
            bool estPresent = false;
            Ressources ressAjouter = new Ressources();


            //vérification que la ressource selectionnée n'est pas présente dans datagridview1
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Selected || row.Cells[0].Selected || row.Cells[1].Selected || row.Cells[2].Selected)
                {
                    ressAjouter.id_Ressource = Int32.Parse(row.Cells["id_Ressource"].Value.ToString());
                    ressAjouter.prenom = row.Cells["prenom"].Value.ToString();
                    ressAjouter.nom = row.Cells["nom"].Value.ToString();

                    for (int i = 0; i < ressources.Count; i++)
                    {
                        if (row.Cells["id_Ressource"].Value.ToString().Equals(ressources[i].id_Ressource.ToString()))
                        {
                            estPresent = true;
                        }
                    }

                }
            }

            //Si la ressource n'est pas déja dans la recette on peut l'ajouter
            if (!estPresent)
            {
                ressources.Add(new Ressources()
                {
                    id_Ressource = ressAjouter.id_Ressource,
                    prenom = ressAjouter.prenom,
                    nom = ressAjouter.nom,
                    textAction = "Mélanger"
                });

                BindingSource source = new BindingSource();
                source.DataSource = ressources;
                dataGridView1.DataSource = source;

                majActionDataGrid();
            }
            else{
                MessageBox.Show("La ressource sélectionnée est déjà présente dans la recette !", "RESSOURCE DEJA PRESENTE", MessageBoxButtons.OK);
            }

        }


        private void filterComboBox(string _idRess, string _prenom, string _nom)
        {
                List<RessourcesTotal> listRessourcesFiltre = new List<RessourcesTotal>();

            listRessourcesFiltre = listRessourcesTot.Where(ress =>
                                                                ress.id_Ressource.ToString().ToLower().Contains(_idRess.ToLower()) &&
                                                                ress.prenom.ToLower().Contains(_prenom.ToLower()) &&
                                                                ress.nom.ToLower().Contains(_nom.ToLower())
                                                           )
                                                 .Select(ress => new RessourcesTotal()
                                                 {
                                                     id_Ressource = ress.id_Ressource,
                                                     prenom = ress.prenom,
                                                     nom = ress.nom
                                                 }).ToList();

                BindingSource source = new BindingSource();
                source.DataSource = listRessourcesFiltre;
                dataGridView2.DataSource = source;
            

        }


        private void comboId_SelectedIndexChanged(object sender, EventArgs e)
        {
            idRessFiltre = comboId.Text;
            /*
            foreach (RessourcesTotal ress in listRessourcesTot)
            {
                if (ress.id_Ressource == Int32.Parse(comboId.Text))
                {
                    comboPrenom.Text = ress.prenom;
                    comboNom.Text = ress.nom;
                }
            }
            */
            filterComboBox(idRessFiltre, prenomRessFiltre, nomRessFiltre);

        }

        private void comboPrenom_SelectedIndexChanged(object sender, EventArgs e)
        {
            prenomRessFiltre = comboPrenom.Text;
            /*
            foreach (RessourcesTotal ress in listRessourcesTot)
            {
                if (ress.prenom.Equals(comboPrenom.Text))
                {
                    comboId.Text = ress.id_Ressource.ToString();
                    comboNom.Text = ress.nom;
                }
            }
            */
            filterComboBox(idRessFiltre, prenomRessFiltre, nomRessFiltre);
        }

        private void comboNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            nomRessFiltre = comboNom.Text;
            /*
            foreach (RessourcesTotal ress in listRessourcesTot)
            {
                if (ress.nom.Equals(comboNom.Text))
                {
                    comboPrenom.Text = ress.prenom;
                    comboId.Text = ress.id_Ressource.ToString();
                }
            }
            */
            filterComboBox(idRessFiltre, prenomRessFiltre, nomRessFiltre);
        }
    }
}
