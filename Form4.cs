using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Image = iTextSharp.text.Image;

namespace ValenceRD
{
    public partial class RechercheProduit : Form
    {

        public List<Ingredients> listIngredients { get; set; }
        private int idProduit;
        private DateTime dateInsertProd = new DateTime();
        private DateTime dateValidation = new DateTime();
        private Panel panEtapeCourante = null;
        private int idPhase;
        private int idVersionProduit;
        private string lblVersion;
        private string lblPhase;
        private List<String> listOperations = new List<string>();
        private List<Etape> listEtape = new List<Etape>();
        private List<Ressources> listRessources = new List<Ressources>();
        private List<EffetSecs> listEffetSecs = new List<EffetSecs>();

        //Constructeurs
        public RechercheProduit() // Si nouveau produit
        {
            listIngredients = GetIngredients();
            listEtape = GetEtapes();
            listRessources = GetRessources();
            InitializeComponent();
            initializeInputRecette();
        }

        public RechercheProduit(int _idProd, int _idVersion, int _idPhase)
        {

            idProduit = _idProd;
            idVersionProduit = _idVersion;
            idPhase = _idPhase;
            InitializeComponent();
            initializeInputRecette();
            listIngredients = GetIngredients();
            listEtape = GetEtapes();
            listRessources = GetRessources();
           // listEffetSecs = GetEffetSecs();

            GenerationEtape();
            lblPhaseCour.Text=lblPhase;
            lblVersionProduit.Text = lblVersion;
           

            progressBar1.Maximum = 5;
            progressBar1.Value = _idPhase;
        }


        private void initializeInputRecette()
        {
            Console.WriteLine("initializeInputRecette");
            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                Console.WriteLine("DB CONNECTION FAITE !");

                //recupération du label de la version du produit 
                string queryLblVersion = "select commentaire from version where idVersion = @idVersion";
                using (MySqlCommand cmdLblVersion = new MySqlCommand(queryLblVersion, dbCon.Connection))
                {
                    cmdLblVersion.Parameters.Add("@idVersion", MySqlDbType.Int32).Value=idVersionProduit;
                    MySqlDataReader rdLblVersion = cmdLblVersion.ExecuteReader();

                    while (rdLblVersion.Read())
                    {
                        lblVersion = rdLblVersion.GetString(0);
                    }
                    rdLblVersion.Close();
                }
                    


                //initialise le label de la phase courante à partir de l'id de la phase du produit
                String queryIdPhase = "Select libelle from phase where idPhase = @idPhase";
                using (MySqlCommand cmdPhase = new MySqlCommand(queryIdPhase, dbCon.Connection))
                {
                    cmdPhase.Parameters.Add("@idPhase", MySqlDbType.Int32).Value=idPhase;
                    MySqlDataReader readerPhase = cmdPhase.ExecuteReader();

                    while (readerPhase.Read())
                    {
                        lblPhase = readerPhase.GetString(0);
                    }
                    readerPhase.Close();
                }
                    


                //ajoute le nom scientifique du produit dans la page de recherche
                string queryNomScien = "SELECT nomScientifique FROM produit where idProduit = @idProduit";
                using (MySqlCommand cmdNomScien = new MySqlCommand(queryNomScien, dbCon.Connection))
                {
                    cmdNomScien.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;
                    MySqlDataReader rdNomScien = cmdNomScien.ExecuteReader();

                    while (rdNomScien.Read())
                    {
                        lblNomProduit.Text = rdNomScien.GetString(0);
                    }
                    rdNomScien.Close();
                }


                //ajoute le symptome du produit dans la page de recherche
                string querySympt = "select libelle from traitement_symptome ts left join traiter t on ts.idTraitementSymptome = t.idTraitementSymptome where idProduit = @idProduit";
                using (MySqlCommand cmdSympt = new MySqlCommand(querySympt, dbCon.Connection))
                {
                    cmdSympt.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;
                    MySqlDataReader rdSympt = cmdSympt.ExecuteReader();

                    while (rdSympt.Read())
                    {
                        lblSymptProd.Text = rdSympt.GetString(0);
                    }
                    rdSympt.Close();
                }


                //ajoute le commentaire de phase dans la page de recherche
                string queryCommentairePhase = "SELECT commentaire FROM valider where idPhase = @idPhase AND idVersion = @idVersion AND idProduit = @idProduit";
                using (MySqlCommand cmdCommentairePhase = new MySqlCommand(queryCommentairePhase, dbCon.Connection))
                {
                    cmdCommentairePhase.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;
                    cmdCommentairePhase.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhase;
                    cmdCommentairePhase.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersionProduit;
                    MySqlDataReader readerCommentairePhase = cmdCommentairePhase.ExecuteReader();

                    while (readerCommentairePhase.Read())
                    {
                        inputCommentairePhase.Text = readerCommentairePhase.GetString(0);
                    }
                    readerCommentairePhase.Close();
                }


                //recupération de la date d'insertion et date validation du produit 
                string queryDtInsert = "select dateInsertion, dateValidation from valider where idProduit = @idProduit and idPhase = @idPhase and idVersion = @idVersion";
                using (MySqlCommand cmdDtInsert = new MySqlCommand(queryDtInsert, dbCon.Connection))
                {
                    cmdDtInsert.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;
                    cmdDtInsert.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhase;
                    cmdDtInsert.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersionProduit;
                    MySqlDataReader rdDtInsert = cmdDtInsert.ExecuteReader();

                    while (rdDtInsert.Read())
                    {
                        dateInsertProd = DateTime.Parse(rdDtInsert.GetString(0));
                        dateValidation = DateTime.Parse(rdDtInsert.GetString(1));
                    }
                    rdDtInsert.Close();
                }

                //initialise la liste des opérations
                string queryselectOperation = "SELECT libelle FROM etape where idEtape >0 order by idEtape";
                using (MySqlCommand cmdselectOperation = new MySqlCommand(queryselectOperation, dbCon.Connection))
                {
                    MySqlDataReader readerselectOperation = cmdselectOperation.ExecuteReader();

                    while (readerselectOperation.Read())
                    {
                        listOperations.Add(readerselectOperation.GetString(0));
                    }
                    readerselectOperation.Close();
                }
                    

            }
            dbCon.Close();
        }

        private List<Etape> GetEtapes()
        {
            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            List<Etape> list = new List<Etape>();

            if (dbCon.IsConnect())
            {
                string queryEtape = "select distinct recette.idEtape, temps, libelle, ordreEtape from recette inner join Etape on recette.idEtape = etape.idEtape where recette.idEtape>0 and idProduit = " + idProduit + " and recette.idPhase = "+ idPhase + " and recette.idVersion = "+ idVersionProduit +" order by ordreEtape";
                Console.WriteLine("Requete de recup des Etapes : "+queryEtape);
                MySqlCommand cmdEtape = new MySqlCommand(queryEtape, dbCon.Connection);
                MySqlDataReader readerEtape = cmdEtape.ExecuteReader();

                int idEtape = 0;
                string libelle = "";
                double dureeEtape = 0;
                int ordreEtape=1;

                while (readerEtape.Read())
                {
                    if (!readerEtape.IsDBNull(0))
                    {
                        idEtape = int.Parse(readerEtape.GetString(0));
                    }
                    if (!readerEtape.IsDBNull(1))
                    {
                        dureeEtape = double.Parse(readerEtape.GetString(1));
                    }
                    if (!readerEtape.IsDBNull(2))
                    {
                        libelle = readerEtape.GetString(2);
                    }

                    if (!readerEtape.IsDBNull(3))
                    {
                        ordreEtape = readerEtape.GetInt32(3);
                    }

                    Console.WriteLine("NOUVELLE ETAPE (idEtape : " + idEtape + " libelle : " + libelle + " dureeEtape : " + dureeEtape + " ordreEtape : "+ ordreEtape + ")");
                    list.Add(new Etape()
                    {
                        idEtape = idEtape,
                        libelle = libelle,
                        duree = dureeEtape,
                        ordre = ordreEtape
                    });
                }
                readerEtape.Close();
            }
            dbCon.Close();
            return list;
        }



        private List<Ressources> GetRessources()
        {
            List<Ressources> list = new List<Ressources>();

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {

                string query = "SELECT r.idRessource, libelle, nom, prenom from ressource r LEFT JOIN travailler t on t.idRessource = r.idRessource LEFT JOIN etape e ON t.idEtape = e.idEtape where idProduit =" + idProduit + " and t.idVersion = " + idVersionProduit + " and t.idPhase = " + idPhase;
                Console.WriteLine("Requete de recup des Ressources : " + query);
                MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                int idRess = -1;
                string actionRess = "";
                string nomRess = "";
                string prenomRess = "";


                while (reader.Read())
                {

                    if (!reader.IsDBNull(0))
                    {
                        idRess = reader.GetInt32(0);
                    }

                    if (!reader.IsDBNull(1))
                    {
                       actionRess = reader.GetString(1);
                    }

                    if (!reader.IsDBNull(2))
                    {
                        nomRess = reader.GetString(2);
                    }

                    if (!reader.IsDBNull(3))
                    {
                        prenomRess = reader.GetString(3);
                    }

                    
                    list.Add(new Ressources()
                        {
                            id_Ressource = idRess,
                            textAction = actionRess,
                            nom = nomRess,
                            prenom = prenomRess

                        });
                    
                }
                reader.Close();
                dbCon.Close();
            }
            return list;
        }


        private List<EffetSecs> GetEffetSecs()
        {
            List<EffetSecs> list = new List<EffetSecs>();

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {

                string query = "SELECT e.idEffetSecondaire, e.libelle, frequence, gravite from affecter a left join effet_secondaire e on a.idEffetSecondaire=e.idEffetSecondaire where idProduit = "+idProduit+" and idPhase = "+idPhase+" and idVersion = "+idVersionProduit;
                Console.WriteLine("Requete de recup des Effets Secondaire : " + query);
                MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                int idEff = -1;
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
                        nature = reader.GetString(1);
                    }

                    if (!reader.IsDBNull(2))
                    {
                        frequence = reader.GetString(2);
                    }

                    if (!reader.IsDBNull(3))
                    {
                        gravite = reader.GetString(3);
                    }


                    list.Add(new EffetSecs()
                    {
                        id_Effet_Sec = idEff,
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


        private List<Ingredients> GetIngredients()
        {
            List<Ingredients> list = new List<Ingredients>();

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {

                string query = "SELECT n.libelle, m.quantite, m.uniteMesure, m.idEtape from recette m LEFT JOIN nomenclature n on m.idNomenclature = n.idNomenclature where idProduit =" + idProduit+ " and m.idVersion = " + idVersionProduit + " and m.idPhase = " + idPhase;
                Console.WriteLine("Requete de recup des ingredients : " + query);
                MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                string libelleIngredient = "";
                int quantiteIng = 0;
                string uniteMesure = "";
                int idEtapeIng = 0;

                while (reader.Read())
                {

                    if (!reader.IsDBNull(0))
                    {
                        libelleIngredient = reader.GetString(0);
                    }

                    if (!reader.IsDBNull(1))
                    {
                        quantiteIng = reader.GetInt32(1);
                    }

                    if (!reader.IsDBNull(2))
                    {
                        uniteMesure = reader.GetString(2);
                    }

                    if (!reader.IsDBNull(3))
                    {
                        idEtapeIng = int.Parse(reader.GetString(3));
                    }

                    //Console.WriteLine(libelleIngredient + "," + quantiteIng + " " + uniteMesure);
                    if (!libelleIngredient.Equals(""))
                    {
                        list.Add(new Ingredients()
                        {
                            nom_Ingredient = libelleIngredient,
                            quantite = quantiteIng,
                            unite_Mesure = uniteMesure,
                            etape = idEtapeIng
                        });
                    }

                }
                reader.Close();
                dbCon.Close();
            }
            return list;
        }


        private void GenerationEtape()
        {
            int i = 0;
            foreach (Etape etape in listEtape.Where(eta => eta.idEtape!=0))
            {
                Console.WriteLine("generation de l'etape : "+ etape.libelle);
                AjoutEtape(etape.libelle, etape.duree);
                foreach (Ingredients ing in listIngredients.Where(ing => ing.etape == etape.idEtape))
                {
                    Console.WriteLine("Generation de l'ingredient à l'étape : " +(etape.idEtape -1)+ ", ingredient : "+ ing.nom_Ingredient);
                    AjoutIngredientExistant(i, ing.nom_Ingredient, ing.quantite);
                }
                i++;
            }
        }



        private void btnRetourMenu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous sauvegarder la recette avant de quitter ? \n Toutes modifications non sauvegardées seront perdues", "SAUVEGARDER LA RECETTE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (SauvegarderRecette())
                {
                    MainPageRDValence mainPage = new MainPageRDValence();
                    mainPage.StartPosition = this.StartPosition;
                    mainPage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Attention, La recette n'a pas été sauvegardée", "RECETTE NON SAUVEGARDEE", MessageBoxButtons.OK);
                }
            }
            else
            {
                MainPageRDValence mainPage = new MainPageRDValence();
                mainPage.StartPosition = this.StartPosition;
                mainPage.Show();
                this.Hide();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void RechercheProduit_Load(object sender, EventArgs e)
        {
            List<Ingredients> ingredients = this.listIngredients;
            List<Ressources> ressources = this.listRessources;
            List<EffetSecs> effetSecs = this.listEffetSecs;

            BindingSource source = new BindingSource();
            source.DataSource = ingredients.Where(ing => ing.etape == 0);
            dataGridView1.DataSource = source;

            //N'affiche pas la colonne etape si le datagridView contient des ingredients
            if (dataGridView1.Columns.Count > 1)
            {
                dataGridView1.Columns["etape"].Visible = false;
            }


            BindingSource source1 = new BindingSource();
            source1.DataSource = ressources;
            dataGridRessource.DataSource = source1;
            dataGridRessource.Columns["id_Ressource"].Visible = false;

            BindingSource source2 = new BindingSource();
            source2.DataSource = effetSecs;
            //dataGridEffetSec.DataSource = source2;
            //dataGridEffetSec.Columns["id_Effet_Sec"].Visible = false;
        }

        private void AjouterMatiere_Click(object sender, EventArgs e)
        {
            //AjoutMatiere ajoutMat = new AjoutMatiere(idProduit);
            //ajoutMat.Show();
            //ajoutMat.StartPosition = this.StartPosition;
            List<Ingredients> ingredients = this.listIngredients;
            ingredients.Add(new Ingredients()
            {
                nom_Ingredient = "",
                quantite = 0,
                unite_Mesure = ""
            });

            BindingSource source = new BindingSource();
            source.DataSource = ingredients.Where(ing => ing.etape == 0);
            dataGridView1.DataSource = source;

            //N'affiche pas la colonne etape si le datagridView contient des ingredients
            if (dataGridView1.Columns.Count > 1)
            {
                dataGridView1.Columns["etape"].Visible = false;
            }
        }

        private bool SauvegarderRecette()
        {
            Boolean estComboVide = EstAllComboBoxVide();
            Boolean dupli = false;
            Boolean estLblIngVide = false;
            string libelleCourant = "";
            int count = 0;

            //Si datagridView contient des ingrédients 
            if (dataGridView1.Columns.Count<2)
            {
                Console.WriteLine("dataGridView1.Columns.Count<2, PAS DE SAUVEGARDE NECESSAIRE CAR PAS D'INGREDIENT : dataGridView1.Rows.Count = " + dataGridView1.Columns.Count);
                MessageBox.Show("Sauvegarde de la recette réalisée avec succès", "RECETTE SAUVEGARDEE", MessageBoxButtons.OK);
                return true;
            }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    libelleCourant = row.Cells["nom_Ingredient"].Value.ToString();
                    dupli = false;
                    count = 0;

                    //si libellé courant est vide on affiche une info comme quoi les produit sans libelle ne seront pas sauvegardé
                    if (libelleCourant.Equals(""))
                    {
                        estLblIngVide = true;
                    }

                    foreach (DataGridViewRow row1 in dataGridView1.Rows)
                    {
                        //si libelle courant est égal à un autre libelle de gridDataView et libelle courant n'est pas vide
                        if (row1.Cells["nom_Ingredient"].Value.ToString().Equals(libelleCourant) && !libelleCourant.Equals(""))
                        {
                            count++;

                            if (count > 1)
                            {
                                dupli = true;
                                break;
                            }
                        }
                    }
                }


                //Si un label est vide on prévient l'utilisateur qu'il ne pourra pas sauvegarder cet ingrédient
                if (estLblIngVide == true)
                {
                    DialogResult dialogResult2 = MessageBox.Show("Attention, les ingrédients avec un nom vide ne seront pas sauvegardé !", "Libellé Vide", MessageBoxButtons.OK);
                }


                //Si l'élément n'est pas en duplicatat
                if (dupli == false && !estComboVide)
                {
                    //Connection Base de données r_d_valence
                    DBConnection dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "r_d_valence";

                    if (dbCon.IsConnect())
                    {

                        //Supprime les ingrédients existant pour ce produit
                        string queryDeleteIngredients = "DELETE FROM recette WHERE idProduit=" + idProduit + " and idVersion = " + idVersionProduit + " and idPhase = " + idPhase;
                        MySqlCommand cmdDeleteIngredients = new MySqlCommand(queryDeleteIngredients, dbCon.Connection);
                        MySqlDataReader reader = cmdDeleteIngredients.ExecuteReader();
                        reader.Close();

                        string libelleIngredient = "";
                        int quantiteIng = 0;
                        string uniteIng = "";
                        string queryInsertIngredients = "";
                        //loop sur datagridview
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            libelleIngredient = row.Cells["nom_Ingredient"].Value.ToString();

                            // Si l'ingrédient courant a un libelle 
                            if (!libelleIngredient.Equals(""))
                            {
                                string querySelectIdIng = "select idNomenclature from nomenclature where libelle = \"" + libelleIngredient + "\"";
                                MySqlCommand cmdselectIdIng = new MySqlCommand(querySelectIdIng, dbCon.Connection);
                                MySqlDataReader reader1 = cmdselectIdIng.ExecuteReader();
                                int idIngredient = -1;

                                //si l'ingrédient existe on lui assigne son id présent en base de données
                                if (reader1.Read())
                                {
                                    idIngredient = Int32.Parse(reader1.GetString(0));
                                }
                                reader1.Close();

                                //si idIngredient =-1 (n'existe pas en base de données) on créé un nouvel ingrédient a partir du libelle et on génère un maxIdNomenclature
                                if (idIngredient == -1)
                                {

                                    //génère idIngredient
                                    string queryIngredient = "SELECT idNomenclature FROM nomenclature";
                                    MySqlCommand cmdIngredient = new MySqlCommand(queryIngredient, dbCon.Connection);
                                    MySqlDataReader reader2 = cmdIngredient.ExecuteReader();

                                    int maxId = -1;

                                    while (reader2.Read())
                                    {
                                        int idIngCourant = Int32.Parse(reader2.GetString(0));

                                        if (idIngCourant > maxId)
                                        {
                                            maxId = idIngCourant;
                                        }
                                    }

                                    if (maxId != -1)
                                    {
                                        maxId++;
                                        idIngredient = maxId;
                                    }
                                    reader2.Close();


                                    //insertion du nouvel ingrédient dans la table nomenclature
                                    String queryInsertNomencl = "insert into nomenclature values(" + idIngredient + ", \"" + libelleIngredient + "\")";

                                    Console.WriteLine(" C'EST LA REQUETE d'INSERTION DANS NOMENCLATURE : " + queryInsertNomencl);

                                    MySqlCommand cmdInsertNomencl = new MySqlCommand(queryInsertNomencl, dbCon.Connection);
                                    cmdInsertNomencl.ExecuteNonQuery();
                                }


                                quantiteIng = Int32.Parse(row.Cells["quantite"].Value.ToString());
                                uniteIng = row.Cells["unite_Mesure"].Value.ToString();

                                //insertion des produits à l'étape initiale
                                //queryInsertIngredients = "insert into manipuler values (" + idProduit + ", 0, " + idIngredient + ", \"" + quantiteIng + "\", \"" + uniteIng + "\")";
                                queryInsertIngredients = "insert into recette values (" + idIngredient + ", 0, 0, " + idProduit + ", " + idPhase +", "+ idVersionProduit +", null, \"" + quantiteIng + "\", \"" + uniteIng + "\")";

                                Console.WriteLine(" C'EST LA REQUETE d'INSERTION DES INGREDIENTS : " + queryInsertIngredients);

                                MySqlCommand cmdInsertIngredients = new MySqlCommand(queryInsertIngredients, dbCon.Connection);
                                cmdInsertIngredients.ExecuteNonQuery();
                            }

                        }//fin loop dataGridView

                        //Sauvegarde du commentaire de la phase courante

                        string querySaveComPhase = "UPDATE valider set commentaire = \"" + inputCommentairePhase.Text + "\" WHERE idPhase = " + idPhase + " AND idVersion = " + idVersionProduit + " AND idProduit = " + idProduit + "";
                        MySqlCommand cmdSaveComPhase = new MySqlCommand(querySaveComPhase, dbCon.Connection);
                        cmdSaveComPhase.ExecuteNonQuery();

                        //SAUVEGARDE DE LA RECETTE
                        //Sauvegarde des Etapes (Boucle) 

                        //Enregistrement de l'ordre des étapes
                        int ordreEtape = 1;
                        int idEtape = 0;
                        int idMatImpSelect = 0;
                        double dureeOpCour = 0;

                        string matImpSelect = "";
                        int quantiteIngCour = 0;
                        string uniteMesureIngCour = "";

                        //boucle sur les étapes de la recette
                        foreach (TableLayoutPanel tblPanCour in flowLayoutEtapes.Controls.OfType<TableLayoutPanel>())
                        {
                            Console.WriteLine("ETAPE COURANTE : " + tblPanCour);

                            foreach (TableLayoutPanel tblInTblPanCour in tblPanCour.Controls.OfType<TableLayoutPanel>())
                            {
                                //Récupération de l'opération courante
                                if (tblInTblPanCour.Name.Equals("tblPanOperation"))
                                {
                                    Console.WriteLine("TABLE LAYOUT OPERATION COURANTE");

                                    foreach (ComboBox comboBoxCour in tblInTblPanCour.Controls.OfType<ComboBox>())
                                    {
                                        //sauvegarde l'opération selectionnée par la combobox courante
                                        string operationSelect = comboBoxCour.Text;

                                        //Récupération de l'idEtape
                                        string querySelectIdEtape = "select idEtape from etape where libelle = \"" + operationSelect + "\"";
                                        MySqlCommand cmdselectIdEtape = new MySqlCommand(querySelectIdEtape, dbCon.Connection);
                                        MySqlDataReader readerSelectIdEtape = cmdselectIdEtape.ExecuteReader();
                                        idEtape = 0;

                                        if (readerSelectIdEtape.Read())
                                        {
                                            idEtape = int.Parse(readerSelectIdEtape.GetString(0));
                                        }
                                        readerSelectIdEtape.Close();
                                    }
                                }

                                //Récupération de la durée de l'opération
                                else if (tblInTblPanCour.Name.Equals("panDureeOp"))
                                {
                                    TableLayoutPanel panMinDurOp = tblInTblPanCour.Controls.OfType<TableLayoutPanel>().First();
                                    TextBox txtBoxCour = panMinDurOp.Controls.OfType<TextBox>().First();

                                    //sauvegarde l'opération selectionnée par la combobox courante
                                    dureeOpCour = double.Parse(txtBoxCour.Text);
                                }
                                else if (tblInTblPanCour.Name.Equals("panMatImp"))
                                {
                                    ComboBox comboBoxCour = tblInTblPanCour.Controls.OfType<ComboBox>().First();

                                    //Récupération de la matière selectionnée par la combobox courante
                                    matImpSelect = comboBoxCour.Text;
                                    Console.WriteLine("PANEL INGREDIENT COURANT :" + matImpSelect);

                                    //Récupération de l'unité de mesure de l'ingrédient
                                    for (int i = 0; i < listIngredients.Count; i++)
                                    {
                                        if (listIngredients[i].nom_Ingredient.Equals(matImpSelect))
                                        {
                                            uniteMesureIngCour = listIngredients[i].unite_Mesure;
                                        }
                                    }

                                }//récupération de la quantité de cet ingrédient dans l'étape
                                else if (tblInTblPanCour.Name.Equals("panQuantiteMat"))
                                {
                                    NumericUpDown inputQuantite = tblInTblPanCour.Controls.OfType<NumericUpDown>().First();

                                    quantiteIngCour = int.Parse(inputQuantite.Text);
                                    Console.WriteLine("QUANTITE DE L'ingredient " + matImpSelect + " = " + quantiteIngCour);


                                    //Récupération de l'id de l'ingrédient selectionné
                                    string querySelectIdIng = "select idNomenclature from nomenclature where libelle = \"" + matImpSelect + "\"";
                                    MySqlCommand cmdselectIdmatImpSelect = new MySqlCommand(querySelectIdIng, dbCon.Connection);
                                    MySqlDataReader readerSelectIdIng = cmdselectIdmatImpSelect.ExecuteReader();
                                    idMatImpSelect = 0;

                                    Console.WriteLine("REQUETE SELECT ID ING :" + querySelectIdIng);

                                    while (readerSelectIdIng.Read())
                                    {
                                        idMatImpSelect = Int32.Parse(readerSelectIdIng.GetString(0));
                                        Console.WriteLine("ID de l'ingredient selectionné ! : " + idMatImpSelect);
                                    }
                                    readerSelectIdIng.Close();

                                    //Insertion de l'ingrédient courant dans la table manipuler
                                    Console.WriteLine("MANIPULER : idMatImpSelect : " + idMatImpSelect + ", idEtape : " + idEtape + ", ordreEtape : " + ordreEtape + ", idProduit : " + idProduit + ", dureeOpCour : " + dureeOpCour + ", quantiteIngCour : " + quantiteIngCour + ", uniteMesureIngCour : " + uniteMesureIngCour);
                                    //string queryInsertManipuler = "Insert into manipuler values (" + idProduit + ", " + idEtape + ", " + idMatImpSelect + ", " + quantiteIngCour + ", \"" + uniteMesureIngCour + "\" )";
                                    string queryInsertManipuler = "Insert into recette values (" + idMatImpSelect + ", " + idEtape + ", " + ordreEtape + ", " + idProduit + ", " + idPhase + ", "+ idVersionProduit +", " + dureeOpCour + ", " + quantiteIngCour + ", \"" + uniteMesureIngCour + "\" )";
                                    var cmdInsertManipuler = new MySqlCommand(queryInsertManipuler, dbCon.Connection);
                                    MySqlDataReader readerInsertManipuler = cmdInsertManipuler.ExecuteReader();
                                    readerInsertManipuler.Close();

                                    matImpSelect = "";
                                    quantiteIngCour = 0;
                                    uniteMesureIngCour = "";
                                }
                            }

                            ordreEtape++;
                        }


                        dbCon.Close();
                    }//fin connexion

                    
                    return true;

                }//fin if dupli == false

            //Si dupli == true on affiche un message d'erreur
            if (dupli == true)
            {
                DialogResult dialogResult1 = MessageBox.Show("Attention, vous ne pouvez pas avoir 2 fois le même ingrédient dans votre recette !", "Duplicata", MessageBoxButtons.OK);
            }

            if (estComboVide)
            {
                DialogResult dialogResult1 = MessageBox.Show("Attention, tous les éléments doivent être renseignés pour procéder à la sauvegarde. \n Supprimez les éléments en trop, ou ajoutez-y les bonnes informations", "ELEMENTS NON RENSEIGNES", MessageBoxButtons.OK);
            }

            return false;

        }//fin sauvegarder recette


        private void SauvegarderRecette_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous sauvegarder la recette ? \n Si vous avez supprimé/ajouté des ingrédients ou des étapes, les modifications seront prises en compte", "SAUVEGARDER LA RECETTE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                
                if (SauvegarderRecette())
                {
                    MessageBox.Show("Sauvegarde de la recette réalisée avec succès", "RECETTE SAUVEGARDEE", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("La sauvegarde de la recette a échouée", "PROBLEME DE SAUVEGARDE", MessageBoxButtons.OK);
                }
            }
        }//fin sauvegarder Recette click




        private Boolean EstAllComboBoxVide()
        {
            foreach (TableLayoutPanel tblPanCour in flowLayoutEtapes.Controls.OfType<TableLayoutPanel>())
            {
                Console.WriteLine("ETAPE COURANTE : " + tblPanCour);

                foreach (TableLayoutPanel tblInTblPanCour in tblPanCour.Controls.OfType<TableLayoutPanel>())
                {
                    foreach (ComboBox comboBoxCour in tblInTblPanCour.Controls.OfType<ComboBox>())
                    {
                        if (comboBoxCour.Text.Equals(""))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }




        private void retireMatiere_Click(object sender, EventArgs e)
        {
            //recharge le datagridView
            List<Ingredients> ingredients = this.listIngredients;

            Ingredients ingASup = new Ingredients { nom_Ingredient = "", quantite = 0, unite_Mesure = "" };

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected || row.Cells[0].Selected || row.Cells[1].Selected || row.Cells[2].Selected)
                {
                    for (int i = 0; i < ingredients.Count; i++)
                    {
                        if (ingredients[i].nom_Ingredient.Equals(row.Cells[0].Value.ToString()))
                        {
                            ingASup = ingredients[i];
                            Console.WriteLine("INGREDIENTS A SUPPRIMER !! : " + ingASup.nom_Ingredient);
                        }
                    }

                }
            }



            Boolean estDansEtape = false;

            foreach (TableLayoutPanel tblPanCour in flowLayoutEtapes.Controls.OfType<TableLayoutPanel>())
            {
                Console.WriteLine("TABLE LAYOUT COURANT : " + tblPanCour);

                foreach (TableLayoutPanel tblInTblPanCour in tblPanCour.Controls.OfType<TableLayoutPanel>())
                {
                    Console.WriteLine("ITEM COURANT : " + tblInTblPanCour);

                    foreach (ComboBox comboBoxCour in tblInTblPanCour.Controls.OfType<ComboBox>())
                    {
                        Console.WriteLine("ITEM COURANT : " + comboBoxCour.Text);

                        if (comboBoxCour.Text.ToString().Equals(ingASup.nom_Ingredient))
                        {
                            estDansEtape = true;
                            Console.WriteLine("Lingredient est présent dans une ETAPE !!!! ");
                        }
                    }

                }
            }


            //Si la matière a supprimer n'est pas dans une étape on supprime
            if (!estDansEtape)
            {
                //on supprime la matière de la liste des ingredients
                ingredients.Remove(ingASup);


                foreach (TableLayoutPanel tblPanCour in flowLayoutEtapes.Controls.OfType<TableLayoutPanel>())
                {
                    Console.WriteLine("TABLE LAYOUT COURANT : " + tblPanCour);

                    foreach (TableLayoutPanel tblInTblPanCour in tblPanCour.Controls.OfType<TableLayoutPanel>())
                    {
                        Console.WriteLine("ITEM COURANT : " + tblInTblPanCour);
                        if (!tblInTblPanCour.Name.Equals("tblPanOperation"))
                        {
                            foreach (ComboBox comboBoxCour in tblInTblPanCour.Controls.OfType<ComboBox>())
                            {
                                //sauvegarde la matière selectionnée par la combobox courante
                                String matImpSelect = comboBoxCour.Text;
                                //comboBoxCour.Items.Remove(ingASup);

                                comboBoxCour.Items.Clear();
                                //Initialise les matières premières dans la combobox
                                comboBoxCour.Items.Add("");

                                foreach (Ingredients ing in listIngredients.Where(ing => ing.etape == 0))
                                {
                                    comboBoxCour.Items.Add(ing.nom_Ingredient);
                                }

                                comboBoxCour.SelectedIndex = comboBoxCour.FindStringExact(matImpSelect);

                            }

                        }

                    }
                }




            }//Sinon on affiche un message d'erreur
            else
            {
                MessageBox.Show("Vous ne pouvez pas supprimer cet ingrédient car il est présent dans une étape de la recette", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            BindingSource source = new BindingSource();
            source.DataSource = listIngredients.Where(ing => ing.etape == 0);
            dataGridView1.DataSource = source;
        }//fin retirer matière

        private void AjoutEtape(String libelleEtape, double dureeEtape)
        {

            Panel panSelectEtape = new Panel();
            //panSelectEtape.Size = new Size(345, 260);
            panSelectEtape.Size = new Size(345, 425);

            TableLayoutPanel tablePanEtape = new TableLayoutPanel();
            tablePanEtape.Name = "tablePanEtape";

            RowStyle rowOperation = new RowStyle(SizeType.Absolute, 62F);
            //RowStyle rowMatImp = new RowStyle(SizeType.Absolute, 62F);

            ColumnStyle colOp = new ColumnStyle(SizeType.Absolute, 200F);
            ColumnStyle colDuree = new ColumnStyle(SizeType.Absolute, 95F);
            ColumnStyle colSupMatImp = new ColumnStyle(SizeType.Absolute, 30F);
            ColumnStyle colDureeMin = new ColumnStyle(SizeType.Absolute, 37F);

            TextBox txtDureeOp = new TextBox();

            txtDureeOp.Size = new Size(26, 20);
            txtDureeOp.Text = dureeEtape.ToString();

            Button btnAddMat = new Button();
            btnAddMat.Name = "btnAddMat";
            btnAddMat.BackColor = Color.MediumSeaGreen;
            btnAddMat.Text = "+";
            btnAddMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
            btnAddMat.Size = new Size(196, 27);
            btnAddMat.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            //NumericUpDown inputQuantiteMatImp = new NumericUpDown();
            //inputQuantiteMatImp.Size = new Size(76, 20);

            Label lblmin = new Label() { Text = "min", Font = new System.Drawing.Font("Microsoft Sans Serif", 8) };
            Label lblOperation = new Label() { Text = "Opération", Font = new System.Drawing.Font("Microsoft Sans Serif", 16), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };
            Label lblDureeOp = new Label() { Text = "Durée", Font = new System.Drawing.Font("Microsoft Sans Serif", 12), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };
            //Label lblQuantMatImp = new Label() { Text = "Quantité", Font = new Font("Microsoft Sans Serif", 12), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };
            //Label lblMatImpl = new Label() { Text = "Matière Impliquée", Font = new Font("Microsoft Sans Serif", 16), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };

            lblDureeOp.Size = new Size(76, 25);
            lblOperation.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            lblDureeOp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            lblOperation.TextAlign = ContentAlignment.TopCenter;
            /*
            lblMatImpl.TextAlign = ContentAlignment.TopCenter;
            lblQuantMatImp.TextAlign = ContentAlignment.TopCenter;
            lblQuantMatImp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            lblMatImpl.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            */

            ComboBox comboOperation = new ComboBox();
            // ComboBox comboMatImp = new ComboBox();

            //initialise les operations dans la combobox
            for (int i = 0; i < listOperations.Count; i++)
            {
                comboOperation.Items.Add(listOperations[i]);
            }

            comboOperation.Text = libelleEtape;

            //affecte la quantite max de matiere premiere qu'on puisse selectionner selon la matière actuelle
            /*
            comboMatImp.SelectedIndexChanged += (s, ev) => {

                if (!comboMatImp.Text.Equals(""))
                {
                    Ingredients ingredient = listIngredients.Where(ing =>
                                                                 ing.nom_Ingredient.Equals(comboMatImp.Text)
                                                         )
                                                  .Select(ing => new Ingredients()
                                                  {
                                                      nom_Ingredient = ing.nom_Ingredient,
                                                      quantite = ing.quantite,
                                                      unite_Mesure = ing.unite_Mesure
                                                  }).First();

                    inputQuantiteMatImp.Maximum = ingredient.quantite;
                }
                else
                {
                    inputQuantiteMatImp.Maximum = 0;
                }

            };

            //Initialise les matières premières dans la combobox
            comboMatImp.Items.Add("");

            foreach (Ingredients ing in listIngredients)
            {
                comboMatImp.Items.Add(ing.nom_Ingredient);
            }

            comboMatImp.SelectedIndex = comboMatImp.FindStringExact("");
            */
            comboOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboOperation.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            /*
            comboMatImp.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMatImp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            */

            TableLayoutPanel panOperation = new TableLayoutPanel();
            TableLayoutPanel panDureeOp = new TableLayoutPanel();
            TableLayoutPanel panMinDurOp = new TableLayoutPanel();
            /*
            TableLayoutPanel panMatImp = new TableLayoutPanel();
            TableLayoutPanel panQuantiteMat = new TableLayoutPanel();
            */
            panOperation.Name = "tblPanOperation";
            panDureeOp.Name = "panDureeOp";
            /*
            panMatImp.Name = "panMatImp";
            panQuantiteMat.Name = "panQuantiteMat";
            */
            //Applique le style des lignes et colonnes
            tablePanEtape.RowStyles.Add(rowOperation);

            //tablePanEtape.RowStyles.Add(rowMatImp);

            tablePanEtape.ColumnStyles.Add(colOp);
            tablePanEtape.ColumnStyles.Add(colDuree);
            tablePanEtape.ColumnStyles.Add(colSupMatImp);
            panMinDurOp.ColumnStyles.Add(colDureeMin);

            tablePanEtape.RowCount = 2;
            tablePanEtape.ColumnCount = 3;
            tablePanEtape.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tablePanEtape.AutoScroll = true;
            //tablePanEtape.Size = new Size(343, 258);
            tablePanEtape.Size = new Size(343, 418);
            tablePanEtape.BackColor = Color.FloralWhite;

            //panSelectEtape.Controls.Add(tablePanEtape);

            flowLayoutEtapes.Controls.Add(tablePanEtape);

            panOperation.RowCount = 2;
            panOperation.Controls.Add(lblOperation, 0, 0);
            panOperation.Controls.Add(comboOperation, 0, panOperation.RowCount);

            /*
            panMatImp.RowCount = 2;
            panMatImp.Controls.Add(lblMatImpl, 0, 0);
            panMatImp.Controls.Add(comboMatImp, 0, panMatImp.RowCount);

            panQuantiteMat.RowCount = 2;
            panQuantiteMat.Controls.Add(lblQuantMatImp, 0, 0);
            panQuantiteMat.Controls.Add(inputQuantiteMatImp, 0, panQuantiteMat.RowCount);
            */
            panMinDurOp.ColumnCount = 2;
            panMinDurOp.Controls.Add(txtDureeOp, 0, 0);
            panMinDurOp.Controls.Add(lblmin, 1, 0);

            panDureeOp.RowCount = 2;
            panDureeOp.Controls.Add(lblDureeOp, 0, 0);
            panDureeOp.Controls.Add(panMinDurOp, 0, 1);
            panDureeOp.Size = new Size(82, 55);

            tablePanEtape.Controls.Add(panOperation, 0, 0);
            tablePanEtape.Controls.Add(panDureeOp, 1, 0);
            /*
            tablePanEtape.Controls.Add(panMatImp, 0, 1);
            tablePanEtape.Controls.Add(panQuantiteMat, 1, 1);
            */
            tablePanEtape.Controls.Add(btnAddMat, 0, tablePanEtape.RowCount);

            panDureeOp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            panMinDurOp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            panOperation.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            /*
            panMatImp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            panQuantiteMat.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            */
            btnAddMat.Click += (senderbtnAdd, eventbtnAdd) =>
            {
                BtnAddMatImp_Click(tablePanEtape, eventbtnAdd);
            };

            tablePanEtape.LostFocus += (senderbtnAdd, eventbtnAdd) =>
            {
                Panel pan = (Panel)senderbtnAdd;
                pan.BorderStyle = BorderStyle.None;
                Console.WriteLine("Leave panSelectEtape : " + pan.Controls);
            };

            tablePanEtape.Click += (senderbtnAdd, eventbtnAdd) =>
            {
                Panel pan = (Panel)senderbtnAdd;
                pan.Focus();
                panEtapeCourante = pan;
                Console.WriteLine("panEtapeCourante MODIFICATION : " + panEtapeCourante);
                pan.BorderStyle = BorderStyle.FixedSingle;
                Console.WriteLine("Click panSelectEtape : " + pan.Controls);
            };


        }



        private void AjoutIngredientExistant(int idEtape, string nomIng, int quantiteIng)
        {
            TableLayoutPanel tableLayoutOperation = flowLayoutEtapes.Controls.OfType<TableLayoutPanel>().ElementAt(idEtape);

            var btnAddMatImp = (Button)tableLayoutOperation.GetControlFromPosition(0, tableLayoutOperation.RowCount);

            Label lblQuantMatImp = new Label() { Text = "Quantité", Font = new System.Drawing.Font("Microsoft Sans Serif", 12), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };
            Label lblMatImpl = new Label() { Text = "Matière Impliquée", Font = new System.Drawing.Font("Microsoft Sans Serif", 15), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };
            TableLayoutPanel panel = new TableLayoutPanel();
            TableLayoutPanel panel1 = new TableLayoutPanel();
            Button btnSupMat = new Button();
            ComboBox inputMatPrem = new ComboBox();
            NumericUpDown inputUpDownNumeric = new NumericUpDown();
            RowStyle rowOperation = new RowStyle(SizeType.Absolute, 62F);

            panel.Name = "panMatImp";
            panel1.Name = "panQuantiteMat";

            btnSupMat.BackColor = Color.Maroon;
            btnSupMat.Text = "-";
            btnSupMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
            btnSupMat.Size = new Size(32, 27);

            //Supprime la ligne d'ingrédient de l'opération en question
            btnSupMat.Click += (senderbtnSup, eventbtnSup) =>
            {


                tableLayoutOperation.Controls.Remove(btnSupMat);
                panel1.Controls.Remove(inputUpDownNumeric);
                panel1.Controls.Remove(lblQuantMatImp);
                tableLayoutOperation.Controls.Remove(panel1);

                panel.Controls.Remove(inputMatPrem);
                panel.Controls.Remove(lblMatImpl);
                tableLayoutOperation.Controls.Remove(panel);
                tableLayoutOperation.RowStyles.Remove(rowOperation);
                //tableLayoutOperation.RowCount -= 1;
                //supprimer la ligne à la position du btnSupMat plutot que enlever une ligne du tablLayoutPanel
            };


            inputMatPrem.DropDownStyle = ComboBoxStyle.DropDownList;
            inputMatPrem.SelectedIndexChanged += (s, ev) =>
            {

                if (!inputMatPrem.Text.Equals(""))
                {
                    Ingredients ingredient = listIngredients.Where(ing =>
                                                                 ing.nom_Ingredient.Equals(inputMatPrem.Text) && ing.etape==0
                                                         )
                                                  .Select(ing => new Ingredients()
                                                  {
                                                      nom_Ingredient = ing.nom_Ingredient,
                                                      quantite = ing.quantite,
                                                      unite_Mesure = ing.unite_Mesure
                                                  }).First();

                    inputUpDownNumeric.Maximum = ingredient.quantite;
                    Console.WriteLine("QUANTITE INGREDIENT "+ingredient.nom_Ingredient+" : " +ingredient.quantite);
                }
                else
                {
                    inputUpDownNumeric.Maximum = 0;
                }

            };

            inputMatPrem.Items.Add("");

            foreach (Ingredients ing in listIngredients.Where(ing => ing.etape==0))
            {
                inputMatPrem.Items.Add(ing.nom_Ingredient);
            }

            inputMatPrem.SelectedIndex = inputMatPrem.FindStringExact(nomIng);
            inputUpDownNumeric.Value = quantiteIng;


            panel.RowCount = 2;
            panel1.RowCount = 2;

            tableLayoutOperation.RowCount = tableLayoutOperation.RowCount + 1;

            tableLayoutOperation.RowStyles.Add(rowOperation);

            tableLayoutOperation.Controls.Add(panel, 0, tableLayoutOperation.RowCount - 2);
            tableLayoutOperation.Controls.Add(panel1, 1, tableLayoutOperation.RowCount - 2);
            tableLayoutOperation.Controls.Add(btnSupMat, 2, tableLayoutOperation.RowCount - 2);

            panel.Controls.Add(lblMatImpl, 0, panel.RowCount - 1);
            panel.Controls.Add(inputMatPrem, 0, panel.RowCount);

            panel1.Controls.Add(lblQuantMatImp, 0, panel1.RowCount - 1);
            panel1.Controls.Add(inputUpDownNumeric, 0, panel1.RowCount);

            panel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            panel1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            //inputUpDownNumeric.Anchor = ( AnchorStyles.Right | AnchorStyles.Left);
            inputMatPrem.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            btnSupMat.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);

            inputUpDownNumeric.Size = new Size(76, 20);

            tableLayoutOperation.Controls.Add(btnAddMatImp, 0, tableLayoutOperation.RowCount);
            /*
            if (sender is Button)
            {
                tableLayoutOperation.Controls.Add(btnAddMatImp, 0, tableLayoutOperation.RowCount - 1);
            }
            else if (btnAddMatImp != null)
            {
                tableLayoutOperation.Controls.Add(btnAddMatImp, 0, tableLayoutOperation.RowCount);
            }
            */
        }//Fin AjoutIngredient

        private void btnAjoutEtape_click(object sender, EventArgs e)
        {
            AjoutEtape("", 0);
        }


        private void BtnAddMatImp_Click(object sender, EventArgs e)
        {
            TableLayoutPanel tableLayoutOperation = (TableLayoutPanel)sender;

            var btnAddMatImp = (Button)tableLayoutOperation.GetControlFromPosition(0, tableLayoutOperation.RowCount);

            Label lblQuantMatImp = new Label() { Text = "Quantité", Font = new System.Drawing.Font("Microsoft Sans Serif", 12), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };
            Label lblMatImpl = new Label() { Text = "Matière Impliquée", Font = new System.Drawing.Font("Microsoft Sans Serif", 15), ForeColor = System.Drawing.Color.FromArgb(0, 0, 64) };
            TableLayoutPanel panel = new TableLayoutPanel();
            TableLayoutPanel panel1 = new TableLayoutPanel();
            Button btnSupMat = new Button();
            ComboBox inputMatPrem = new ComboBox();
            NumericUpDown inputUpDownNumeric = new NumericUpDown();
            RowStyle rowOperation = new RowStyle(SizeType.Absolute, 62F);

            panel.Name = "panMatImp";
            panel1.Name = "panQuantiteMat";

            btnSupMat.BackColor = Color.Maroon;
            btnSupMat.Text = "-";
            btnSupMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
            btnSupMat.Size = new Size(32, 27);

            //Supprime la ligne d'ingrédient de l'opération en question
            btnSupMat.Click += (senderbtnSup, eventbtnSup) =>
            {


                tableLayoutOperation.Controls.Remove(btnSupMat);
                panel1.Controls.Remove(inputUpDownNumeric);
                panel1.Controls.Remove(lblQuantMatImp);
                tableLayoutOperation.Controls.Remove(panel1);

                panel.Controls.Remove(inputMatPrem);
                panel.Controls.Remove(lblMatImpl);
                tableLayoutOperation.Controls.Remove(panel);
                tableLayoutOperation.RowStyles.Remove(rowOperation);
                //tableLayoutOperation.RowCount -= 1;
                //supprimer la ligne à la position du btnSupMat plutot que enlever une ligne du tablLayoutPanel
            };


            inputMatPrem.DropDownStyle = ComboBoxStyle.DropDownList;
            inputMatPrem.SelectedIndexChanged += (s, ev) =>
            {

                if (!inputMatPrem.Text.Equals(""))
                {
                    Ingredients ingredient = listIngredients.Where(ing =>
                                                                 ing.nom_Ingredient.Equals(inputMatPrem.Text) && ing.etape == 0
                                                         )
                                                  .Select(ing => new Ingredients()
                                                  {
                                                      nom_Ingredient = ing.nom_Ingredient,
                                                      quantite = ing.quantite,
                                                      unite_Mesure = ing.unite_Mesure
                                                  }).First();

                    inputUpDownNumeric.Maximum = ingredient.quantite;
                }
                else
                {
                    inputUpDownNumeric.Maximum = 0;
                }

            };

            inputMatPrem.Items.Add("");

            foreach (Ingredients ing in listIngredients.Where(ing => ing.etape == 0))
            {
                inputMatPrem.Items.Add(ing.nom_Ingredient);
            }


            panel.RowCount = 2;
            panel1.RowCount = 2;

            tableLayoutOperation.RowCount = tableLayoutOperation.RowCount + 1;

            tableLayoutOperation.RowStyles.Add(rowOperation);

            tableLayoutOperation.Controls.Add(panel, 0, tableLayoutOperation.RowCount - 2);
            tableLayoutOperation.Controls.Add(panel1, 1, tableLayoutOperation.RowCount - 2);
            tableLayoutOperation.Controls.Add(btnSupMat, 2, tableLayoutOperation.RowCount - 2);

            panel.Controls.Add(lblMatImpl, 0, panel.RowCount - 1);
            panel.Controls.Add(inputMatPrem, 0, panel.RowCount);

            panel1.Controls.Add(lblQuantMatImp, 0, panel1.RowCount - 1);
            panel1.Controls.Add(inputUpDownNumeric, 0, panel1.RowCount);

            panel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            panel1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            //inputUpDownNumeric.Anchor = ( AnchorStyles.Right | AnchorStyles.Left);
            inputMatPrem.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            btnSupMat.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);

            inputUpDownNumeric.Size = new Size(76, 20);

            tableLayoutOperation.Controls.Add(btnAddMatImp, 0, tableLayoutOperation.RowCount - 1);

            if (sender is Button)
            {
                tableLayoutOperation.Controls.Add(btnAddMatImp, 0, tableLayoutOperation.RowCount - 1);
            }
            else if (btnAddMatImp != null)
            {
                tableLayoutOperation.Controls.Add(btnAddMatImp, 0, tableLayoutOperation.RowCount);
            }

        }

        private void SupprEtape_Click(object sender, EventArgs e)
        {

            //Si le controle n'est pas null et est sélectionné
            if (panEtapeCourante != null)
            {
                DialogResult dialogResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer l'étape sélectionnée ? \n Cette opération est irréversible.", "SUPPRIMER L'ETAPE SELECTIONNEE", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    panEtapeCourante.Controls.Clear();
                    flowLayoutEtapes.Controls.Remove(panEtapeCourante);

                    //reinitialise panEtapeCourante à null
                    panEtapeCourante = null;
                }

            }
            else
            {
                MessageBox.Show("Veuillez selectionner une étape à supprimer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //Quand on ajoute un ingrédient dans la recette met à jour les combobox des étapes
        private void ingredients_changed(object sender, DataGridViewCellEventArgs e)
        {

            foreach (TableLayoutPanel tblPanCour in flowLayoutEtapes.Controls.OfType<TableLayoutPanel>())
            {
                Console.WriteLine("TABLE LAYOUT COURANT : " + tblPanCour);

                foreach (TableLayoutPanel tblInTblPanCour in tblPanCour.Controls.OfType<TableLayoutPanel>())
                {
                    Console.WriteLine("ITEM COURANT : " + tblInTblPanCour);

                    if (!tblInTblPanCour.Name.Equals("tblPanOperation"))
                    {
                        foreach (ComboBox comboBoxCour in tblInTblPanCour.Controls.OfType<ComboBox>())
                        {
                            //sauvegarde la matière selectionnée par la combobox courante
                            String matImpSelect = comboBoxCour.Text;

                            comboBoxCour.Items.Clear();
                            //Initialise les matières premières dans la combobox
                            comboBoxCour.Items.Add("");

                            foreach (Ingredients ing in listIngredients.Where(ing => ing.etape == 0))
                            {
                                comboBoxCour.Items.Add(ing.nom_Ingredient);
                            }

                            comboBoxCour.SelectedIndex = comboBoxCour.FindStringExact(matImpSelect);

                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validerPhase();
        }

        [Obsolete]
        public void validerPhase()
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous sauvegarder la recette et passer à la phase suivante ? \n Toutes les informations concernant cette phase du produit seront sauvegardées", "PASSER A LA PHASE SUIVANTE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (SauvegarderRecette())
                {
                    DBConnection dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "r_d_valence";

                    //2 insert dans valider : le premier pour dire que l'étape précédente est validée, le second pour dire que la nouvelle étape est en cours de validation.
                    if (dbCon.IsConnect())
                    {
                        Console.WriteLine("DB CONNECTION FAITE !");

                        //validation de l'ancienne phase
                        string queryUpdateValider1 = "UPDATE valider set validation =1, commentaire= \"" + inputCommentairePhase.Text + "\" where idProduit = " + idProduit + " and idVersion = " + idVersionProduit + " and idPhase = " + idPhase;
                        MySqlCommand cmdInsertValider1 = new MySqlCommand(queryUpdateValider1, dbCon.Connection);
                        cmdInsertValider1.ExecuteNonQuery();

                        //incrément de l'id de phase courante
                        idPhase++;


                        string query = "SELECT idProduit, idVersion, idPhase " +
                                       "FROM valider v " +
                                       "where v.idPhase = " + idPhase + " " +
                                       "and v.idProduit = " + idProduit + " " +
                                       "and v.idVersion = " + idVersionProduit;

                        MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            //ouvre le produit trouvé dans la phase animal
                            TestsAnimaux testAnim = new TestsAnimaux(idProduit, idVersionProduit, idPhase);
                            this.Hide();
                            testAnim.StartPosition = FormStartPosition.CenterParent;
                            testAnim.Show();
                        }
                        else
                        {
                            //Si pas de validation de phase pour se produit 
                            reader.Close();

                            //maj de la date de validation du produit
                            dateValidation = DateTime.Today;

                            //Insertion de la nouvelle validation de phase
                            string queryInsertValider = "insert into valider values (@idPhase, @idVersionProduit, @idProduit, @dateInsertProd, @dateValidation, 0, \"\")";
                            Console.WriteLine("REQUETE D'INSERT NOUVEL PHASE : " + queryInsertValider);
                            using (MySqlCommand cmdInsertValider = new MySqlCommand(queryInsertValider, dbCon.Connection))
                            {
                                cmdInsertValider.Parameters.Add("@idPhase", MySqlDbType.Int32).Value = idPhase;
                                cmdInsertValider.Parameters.Add("@idVersionProduit", MySqlDbType.Int32).Value = idVersionProduit;
                                cmdInsertValider.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;
                                cmdInsertValider.Parameters.Add("@dateInsertProd", MySqlDbType.Datetime).Value = dateInsertProd;
                                cmdInsertValider.Parameters.Add("@dateValidation", MySqlDbType.Datetime).Value = dateValidation;
                                cmdInsertValider.ExecuteNonQuery();
                            }
                            reader.Close();

                            //ouvre le produit en phase test animal
                            TestsAnimaux testAnim = new TestsAnimaux(idProduit, idVersionProduit, idPhase);
                            this.Hide();
                            testAnim.StartPosition = FormStartPosition.CenterParent;
                            testAnim.Show();
                        }
                        

                    }
                    dbCon.Close();
                }
                else
                {
                    MessageBox.Show("Attention, La recette n'a pas été sauvegardée, la phase n'a pas pu être passée", "RECETTE NON SAUVEGARDEE", MessageBoxButtons.OK);
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            retourPhasePrecedente();
        }


        public void retourPhasePrecedente()
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous retourner à la phase précédente de la recette ? cette phase sera sauvegardée dans son état", "RETOUR PHASE PRECEDENTE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                //réinitialisation de la recette
                if (SauvegarderRecette())
                {
                    // Recherche du produit à la phase précédente ou proposition de réinitialisation si pas de phases

                    //décrément de l'id de phase courante
                    idPhase--;

                    DBConnection dbCon = DBConnection.Instance();
                    dbCon.DatabaseName = "r_d_valence";

                    if (dbCon.IsConnect())
                    {
                        string query = "SELECT produit.idProduit, version.idVersion, phase.idPhase " +
                                       "FROM produit " +
                                       "left outer join traiter on produit.idProduit = traiter.idProduit " +
                                       "left outer join traitement_symptome on traiter.idTraitementSymptome = traitement_Symptome.idTraitementSymptome " +
                                       "left outer join valider on produit.idProduit = valider.idProduit " +
                                       "left outer join version on valider.idVersion = version.idVersion " +
                                       "left outer join phase on valider.idPhase = phase.idPhase " +
                                       "where valider.idPhase = " + idPhase + " " +
                                       "and valider.idProduit = " + idProduit + " " +
                                       "and valider.idVersion = " + idVersionProduit;

                        MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        int version = -1;
                        int phase = -1;

                        if (reader.HasRows)
                        {
                            reader.Read();

                            int idProduit = reader.GetInt32(0);
                            version = reader.GetInt32(1);
                            phase = reader.GetInt32(2);



                            //ouvre le produit trouvé dans sa phase précédente
                            RechercheProduit rechProd = new RechercheProduit(idProduit, version, phase);
                            this.Hide();
                            rechProd.StartPosition = FormStartPosition.CenterParent;
                            rechProd.Show();

                        }
                        else
                        {
                            DialogResult dialogResult1 = MessageBox.Show("Il n'y a pas de phase précédente pour ce produit, souhaitez-vous réinitialiser la recette ?", "PHASE PRECEDENTE NON EXISTENTE", MessageBoxButtons.YesNo);

                            if (dialogResult1 == DialogResult.Yes)
                            {
                                //réinitialisation de la recette
                            }
                        }
                        reader.Close();

                    }
                    dbCon.Close();
                }
                else
                {
                    MessageBox.Show("Attention, La recette n'a pas été sauvegardée, la phase n'a pas pu être passée", "RECETTE NON SAUVEGARDEE", MessageBoxButtons.OK);
                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GererLesRessources gererRess = new GererLesRessources(idProduit, idPhase, idVersionProduit);
            gererRess.StartPosition = this.StartPosition;
            gererRess.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GestionPhase gestPhase = new GestionPhase(idProduit, idPhase, idVersionProduit);
            this.Hide();
            gestPhase.StartPosition = FormStartPosition.CenterParent;
            gestPhase.Show();
        }

        //Sauvegarder recette menu
        private void gérerLesRessourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous sauvegarder la recette ? \n Si vous avez supprimé/ajouté des ingrédients ou des étapes, les modifications seront prises en compte", "SAUVEGARDER LA RECETTE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                if (SauvegarderRecette())
                {
                    MessageBox.Show("Sauvegarde de la recette réalisée avec succès", "RECETTE SAUVEGARDEE", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("La sauvegarde de la recette a échouée", "PROBLEME DE SAUVEGARDE", MessageBoxButtons.OK);
                }
            }
        }

        //Generer PDF menu
        private void upgradeUnProduitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous générer un PDF de la recette à l'état actuel ?", "GENERER UN PDF DE LA RECETTE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter="PDF file|*.pdf", ValidateNames = true, FileName="Recette "+ lblNomProduit.Text+ " - v"+ idVersionProduit + " -p"+ idPhase + " - " + DateTime.Today.ToString("dd-MM-yyyy")})
                {
                    if (sfd.ShowDialog()==DialogResult.OK)
                    {
                        iTextSharp.text.Document doc = new Document(PageSize.A4);
                        try
                        {
                            PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                            doc.Open();

                            //définition de la police de text
                            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 40, iTextSharp.text.Font.NORMAL);
                            iTextSharp.text.Font fontSsTitre = new iTextSharp.text.Font(bf, 24, iTextSharp.text.Font.NORMAL);
                            iTextSharp.text.Font fontText = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                            iTextSharp.text.Font boldFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font fontCopyrights = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);


                            Paragraph sautDeLigne = new Paragraph("")
                            {
                                SpacingBefore = 10f,
                                SpacingAfter = 10f,
                            };
                            

                            PdfPTable tableTitre = new PdfPTable(new[] { 0.25f, 1f })
                            {
                                WidthPercentage = 100,
                                DefaultCell = { MinimumHeight = 22f }
                            };
                            tableTitre.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                            
                            //Ajout logo RD_Valence
                            Uri imagePath = new Uri(@"..\..\img\rdValence_logo.jpg", UriKind.Relative);
                            using (FileStream fs = new FileStream(imagePath.ToString(), FileMode.Open))
                            {
                                Image logoValence = Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
                                logoValence.ScalePercent(15f);
                                logoValence.SetAbsolutePosition(doc.Left - 36f, doc.PageSize.Height - logoValence.ScaledHeight);

                                tableTitre.AddCell(logoValence);
                               // doc.Add(logoValence);
                            }

                            PdfPTable tableNomProd = new PdfPTable(new[] { 1f })
                            {
                                WidthPercentage = 100,
                                DefaultCell = { MinimumHeight = 22f }
                            };
                            tableNomProd.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                            Paragraph textTitre = new Paragraph(new Chunk(lblNomProduit.Text, font));
                            Paragraph textVersionProd = new Paragraph(new Chunk(lblVersionProduit.Text, fontSsTitre));
                            textTitre.Alignment = Element.ALIGN_RIGHT;

                            tableNomProd.AddCell(textTitre);
                            tableNomProd.AddCell(textVersionProd);

                            tableTitre.AddCell(tableNomProd);

                            doc.Add(tableTitre);

                            //Ajout ligne de séparation
                            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                            doc.Add(p);

                            //Ajout Phase courante
                            doc.Add(sautDeLigne);
                            doc.Add(new Paragraph(new Chunk("Phase : "+ lblPhaseCour.Text, fontSsTitre)));

                            //Ajout commentaire
                            doc.Add(sautDeLigne);
                            doc.Add(new Paragraph(new Chunk("Commentaire : " +inputCommentairePhase.Text, fontText)));


                            //Ajout Symptome produit
                            doc.Add(sautDeLigne);
                            doc.Add(new Paragraph(new Chunk("Symptome Traité : " + lblSymptProd.Text, boldFont)));

                            //Ajout Effet Sec produit
                            doc.Add(sautDeLigne);
                            //doc.Add(new Paragraph(new Chunk("Effet Secondaire : " + lblEffetSecProd.Text, boldFont)));

                            doc.Add(sautDeLigne);
                            doc.Add(sautDeLigne);


                            doc.Add(new iTextSharp.text.Paragraph(new Chunk("Ressources", fontSsTitre)));
                            doc.Add(sautDeLigne);

                            PdfPTable tableRessource = new PdfPTable(new[] { 1f, 0.75f, 1f })
                            {
                                HorizontalAlignment = Left,
                                WidthPercentage = 75,
                                DefaultCell = { MinimumHeight = 22f }
                            };

                            tableRessource.AddCell(new iTextSharp.text.Paragraph(new Chunk("Noms des Ressources", boldFont)));
                            tableRessource.AddCell(new iTextSharp.text.Paragraph(new Chunk("Action Affectée", boldFont)));
                            tableRessource.AddCell(new iTextSharp.text.Paragraph(new Chunk("Charge de Travail", boldFont)));

                            foreach (Ressources ress in listRessources)
                            {
                                tableRessource.AddCell(ress.prenom.ToString() + " " + ress.nom.ToString());
                                tableRessource.AddCell(ress.textAction.ToString());
                                tableRessource.AddCell(ress.chargeTravail.ToString());
                            }

                            doc.Add(tableRessource);
                            doc.Add(sautDeLigne);

                            doc.Add(new iTextSharp.text.Paragraph(new Chunk("Recette", fontSsTitre)));
                            doc.Add(sautDeLigne);

                            //Ajout ingrédients tot recette

                            PdfPTable tableIngredient = new PdfPTable(new[] {1f, 0.50f })
                            {
                                HorizontalAlignment = Left,
                                WidthPercentage = 33,
                                DefaultCell = { MinimumHeight = 22f }
                            };

                            tableIngredient.AddCell(new iTextSharp.text.Paragraph(new Chunk("Nom Ingredient", boldFont)));
                            tableIngredient.AddCell(new iTextSharp.text.Paragraph(new Chunk("Quantité", boldFont)));

                            foreach (Ingredients ing in listIngredients.Where(ing => ing.etape ==0))
                            {
                                tableIngredient.AddCell(ing.nom_Ingredient.ToString());
                                tableIngredient.AddCell(ing.quantite.ToString()+ ing.unite_Mesure.ToString());
                            }

                            doc.Add(tableIngredient);
                            doc.Add(sautDeLigne);

                            //Ajout étapes et ingrédients de la recette

                            PdfPTable tableRecette = new PdfPTable(new[] { 0.12f, 0.33f, 1f})
                            {
                                HorizontalAlignment = Left,
                                WidthPercentage = 100,
                                DefaultCell = { MinimumHeight = 22f }
                            };

                            tableRecette.AddCell(new iTextSharp.text.Paragraph(new Chunk("Etapes", boldFont)));
                            tableRecette.AddCell(new iTextSharp.text.Paragraph(new Chunk("Opérations (durée)", boldFont)));
                            tableRecette.AddCell(new iTextSharp.text.Paragraph(new Chunk("Nomenclatures (quantité)", boldFont)));

                            int quantiteIngCour = 0;
                            string uniteMesureIngCour = "";
                            int nbEtape = 1;

                            //boucle sur les étapes de la recette
                            foreach (TableLayoutPanel tblPanCour in flowLayoutEtapes.Controls.OfType<TableLayoutPanel>())
                            {
                                string ingsEtape = "";
                                string matImpSelect = "";
                                string operationSelect = "";
                                
                                tableRecette.AddCell(nbEtape.ToString());

                                Console.WriteLine("ETAPE COURANTE : " + tblPanCour);

                                foreach (TableLayoutPanel tblInTblPanCour in tblPanCour.Controls.OfType<TableLayoutPanel>())
                                {
                                    //Récupération de l'opération courante
                                    if (tblInTblPanCour.Name.Equals("tblPanOperation"))
                                    {
                                        foreach (ComboBox comboBoxCour in tblInTblPanCour.Controls.OfType<ComboBox>())
                                        {
                                            operationSelect = comboBoxCour.Text;
                                        }
                                    }

                                    //Récupération de la durée de l'opération
                                    else if (tblInTblPanCour.Name.Equals("panDureeOp"))
                                    {
                                        TableLayoutPanel panMinDurOp = tblInTblPanCour.Controls.OfType<TableLayoutPanel>().First();
                                        TextBox txtBoxCour = panMinDurOp.Controls.OfType<TextBox>().First();

                                        tableRecette.AddCell(operationSelect + " (" + txtBoxCour.Text + " min)");
                                    }

                                    else if (tblInTblPanCour.Name.Equals("panMatImp"))
                                    {
                                        ComboBox comboBoxCour = tblInTblPanCour.Controls.OfType<ComboBox>().First();

                                        //Récupération de la matière selectionnée par la combobox courante
                                        matImpSelect = comboBoxCour.Text;


                                        //Récupération de l'unité de mesure de l'ingrédient
                                        for (int i = 0; i < listIngredients.Count; i++)
                                        {
                                            if (listIngredients[i].nom_Ingredient.Equals(matImpSelect))
                                            {
                                                uniteMesureIngCour = listIngredients[i].unite_Mesure;
                                            }
                                        }

                                    }//récupération de la quantité de cet ingrédient dans l'étape
                                    else if (tblInTblPanCour.Name.Equals("panQuantiteMat"))
                                    {
                                        NumericUpDown inputQuantite = tblInTblPanCour.Controls.OfType<NumericUpDown>().First();

                                        quantiteIngCour = int.Parse(inputQuantite.Text);
                                        Console.WriteLine("QUANTITE DE L'ingredient " + matImpSelect + " = " + quantiteIngCour);

                                        if (ingsEtape != "")
                                        {
                                            ingsEtape = ingsEtape + ", ";
                                        }

                                        ingsEtape = ingsEtape + matImpSelect + " ("+ quantiteIngCour + uniteMesureIngCour + ")";  

                                        matImpSelect = "";
                                        quantiteIngCour = 0;
                                        uniteMesureIngCour = "";
                                    }
                                }
                                tableRecette.AddCell(ingsEtape);
                                nbEtape++;
                            }

                            doc.Add(tableRecette);
                            doc.Add(sautDeLigne);

                            // Writer.PageEvent = new Footer();
                            doc.Add(new Paragraph(new Chunk("© 2020 Buena-Vista-Medical - All rights reserved", fontCopyrights)));

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            doc.Close();
                        }
                    }
                }
            }
        }

        //Gestion des phases menu
        private void gestionDesPhasesProduitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionPhase gestPhase = new GestionPhase(idProduit, idPhase, idVersionProduit);
            this.Hide();
            gestPhase.StartPosition = FormStartPosition.CenterParent;
            gestPhase.Show();
        }

        //Valider phase menu
        [Obsolete]
        private void validerLaPhaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            validerPhase();
        }

        private void retourÀLaPhasePrécédenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            retourPhasePrecedente();
        }
    }
}
