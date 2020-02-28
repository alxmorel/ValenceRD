using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ValenceRD
{
    public partial class RechercheProduit : Form
    {

        public List<Ingredients> listIngredients { get; set; }
        private int idProduit;
        private int idEtape;
        private int idPhaseCour;
        private int idVersionProduit;
        private string lblVersion;

        //Constructeurs
        public RechercheProduit() // Si nouveau produit
        {
            listIngredients = GetIngredients();
            InitializeComponent();
            initializeInputRecette("Recherche et développement");
        }

        public RechercheProduit(int _idProd, String _nomScien, String _version, String _symptome, String _phaseCour, DateTime _dateInsertProd, DateTime _dateDerVers)
        {

            idProduit = _idProd;
            lblVersion = _version;
            InitializeComponent();
            listIngredients = GetIngredients();
            initializeInputRecette(_phaseCour);

            //initialise les variables d'affichages
            lblNomProduit.Text = _nomScien;
            lblVersionProduit.Text = _version;
            lblSymptProd.Text = _symptome;

            progressBar1.Maximum = 5;
            progressBar1.Value = idPhaseCour;
        }


        private void initializeInputRecette(String _phase)
        {
            Console.WriteLine("initializeInputRecette");
            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                Console.WriteLine("DB CONNECTION FAITE !");

                //recupération de l'id de la version du produit 
                string queryIdVersion = "select idVersion from version where commentaire =\"" + lblVersion + "\"";
                MySqlCommand cmdIdVersion = new MySqlCommand(queryIdVersion, dbCon.Connection);
                MySqlDataReader readerIdVersion = cmdIdVersion.ExecuteReader();

                while (readerIdVersion.Read())
                {
                    idVersionProduit = Int32.Parse(readerIdVersion.GetString(0));
                }
                readerIdVersion.Close();

                //initialise l'identifiant de la phase courante à partir du libelle de la phase courante du produit
                String queryPhaseCour = "Select idPhase from phase where libelle = \""+_phase+"\"";
                MySqlCommand cmdPhase = new MySqlCommand(queryPhaseCour, dbCon.Connection);
                MySqlDataReader readerPhase = cmdPhase.ExecuteReader();

                while (readerPhase.Read())
                {
                    idPhaseCour = Int32.Parse(readerPhase.GetString(0));
                }
                readerPhase.Close();

                //ajoute les opérations dans le formulaire de recette
                string queryEtapes = "SELECT libelle FROM etape";
                MySqlCommand cmdEtape = new MySqlCommand(queryEtapes, dbCon.Connection);
                MySqlDataReader readerEtape = cmdEtape.ExecuteReader();

                while (readerEtape.Read())
                {
                    inputOperation.Items.Add(readerEtape.GetString(0));
                }
                readerEtape.Close();

                //ajoute le commentaire de phase dans la page de recherche
                string queryCommentairePhase = "SELECT commentaire FROM valider where idPhase = " + idPhaseCour + " AND idVersion = " + idVersionProduit + " AND idProduit = " + idProduit + "";
                MySqlCommand cmdCommentairePhase = new MySqlCommand(queryCommentairePhase, dbCon.Connection);
                MySqlDataReader readerCommentairePhase = cmdCommentairePhase.ExecuteReader();

                while (readerCommentairePhase.Read())
                {
                  inputCommentairePhase.Text = readerCommentairePhase.GetString(0);
                }
                readerCommentairePhase.Close();

            }
            dbCon.Close();
        }

        private List<Ingredients> GetIngredients()
        {
            List<Ingredients> list = new List<Ingredients>();

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                String query = "SELECT n.libelle, m.quantite, m.uniteMesure from manipuler m LEFT JOIN nomenclature n on m.idNomenclature = n.idNomenclature where idProduit=" + idProduit;
                MySqlCommand cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                String libelleIngredient = "";
                int quantiteIng = 0;
                String uniteMesure = "";
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


                    //Console.WriteLine(libelleIngredient + "," + quantiteIng + " " + uniteMesure);
                    if (!libelleIngredient.Equals(""))
                    {
                        list.Add(new Ingredients()
                        {
                            nom_Ingredient = libelleIngredient,
                            quantite = quantiteIng,
                            unite_Mesure = uniteMesure
                        });

                        //ajoute les marières impliquées dans l'input du formulaire de recette
                        inputMatiereImp.Items.Add(libelleIngredient.ToString());
                    }
                   

                }
                reader.Close();
                dbCon.Close();
            }
            return list;
        }


        private void btnRetourMenu_Click(object sender, EventArgs e)
        {
            MainPageRDValence mainPage = new MainPageRDValence();
            mainPage.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void RechercheProduit_Load(object sender, EventArgs e)
        {
            List<Ingredients> ingredients = this.listIngredients;
            dataGridView1.DataSource = ingredients;
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
            source.DataSource = ingredients;
            dataGridView1.DataSource = source;

        }

        private void SauvegarderRecette_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Souhaitez-vous sauvegarder la recette ? \n Si vous avez supprimé/ajouté des ingrédients ou des étapes, les modifications seront prises en compte", "SAUVEGARDER LA RECETTE", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                    Boolean dupli = false;
                    Boolean estLblIngVide = false;
                    string libelleCourant = "";
                    int count = 0;

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
                if (dupli == false)
                    {
                        //Connection Base de données r_d_valence
                        var dbCon = DBConnection.Instance();
                        dbCon.DatabaseName = "r_d_valence";

                        if (dbCon.IsConnect())
                        {

                            //Supprime les ingrédients existant pour ce produit
                            string queryDeleteIngredients = "DELETE FROM manipuler WHERE idProduit=" + idProduit;
                            var cmdDeleteIngredients = new MySqlCommand(queryDeleteIngredients, dbCon.Connection);
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
                                    var cmdselectIdIng = new MySqlCommand(querySelectIdIng, dbCon.Connection);
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
                                        var cmdIngredient = new MySqlCommand(queryIngredient, dbCon.Connection);
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

                                        //ajout de l'ingrédient dans la liste des ingrédients utilisables pour une opération de la recette
                                        inputMatiereImp.Items.Add(libelleIngredient);
                                    }


                                    quantiteIng = Int32.Parse(row.Cells["quantite"].Value.ToString());
                                    uniteIng = row.Cells["unite_Mesure"].Value.ToString();

                                    //insertion des produits à l'étape initiale
                                    queryInsertIngredients = "insert into manipuler values (" + idProduit + ", 0, " + idIngredient + ", \"" + quantiteIng + "\", \"" + uniteIng + "\")";

                                    Console.WriteLine(" C'EST LA REQUETE d'INSERTION DES INGREDIENTS : " + queryInsertIngredients);

                                    MySqlCommand cmdInsertIngredients = new MySqlCommand(queryInsertIngredients, dbCon.Connection);
                                    cmdInsertIngredients.ExecuteNonQuery();
                                }

                            }//fin loop dataGridView

                        //Sauvegarde du commentaire de la phase courante

                        string querySaveComPhase = "UPDATE valider set commentaire = \""+inputCommentairePhase.Text+"\" WHERE idPhase = "+idPhaseCour+" AND idVersion = "+idVersionProduit+" AND idProduit = "+idProduit+"";
                        MySqlCommand cmdSaveComPhase = new MySqlCommand(querySaveComPhase, dbCon.Connection);
                        cmdSaveComPhase.ExecuteNonQuery();


                        dbCon.Close();
                        }//fin connexion

                    MessageBox.Show("Sauvegarde de la recette réalisée avec succès", "RECETTE SAUVEGARDEE", MessageBoxButtons.OK);

                }//fin if dupli == false

                //Si dupli == true on affiche un message d'erreur
                if (dupli==true){
                        DialogResult dialogResult1 = MessageBox.Show("Attention, vous ne pouvez pas avoir 2 fois le même ingrédient dans votre recette !", "Duplicata", MessageBoxButtons.OK);
                    }

                    

        }
    }//fin sauvegarder Recette click

        private void retireMatiere_Click(object sender, EventArgs e)
        {
            //recharge le datagridView
            List<Ingredients> ingredients = this.listIngredients;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected || row.Cells[0].Selected || row.Cells[1].Selected || row.Cells[1].Selected)
                {
                    for( int i=0; i< ingredients.Count; i++)
                    {
                        if (ingredients[i].nom_Ingredient.Equals(row.Cells[0].Value.ToString()))
                        {
                            ingredients.Remove(ingredients[i]);
                        }
                    }
                        
                }
            }
           
            BindingSource source = new BindingSource();
            source.DataSource = ingredients;
            dataGridView1.DataSource = source;

            /*
            //Connection Base de données r_d_valence
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";
            
            if (dbCon.IsConnect())
            {
                //Supprime les ingrédients existant pour ce produit
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected || row.Cells[0].Selected || row.Cells[1].Selected || row.Cells[1].Selected)
                    {
                        //récupère l'id du produit selectionné
                        int idIngCourant = -1;

                        string queryIdIngSelect = "Select idNomenclature from nomenclature where libelle= \"" + row.Cells[0].Value.ToString() + "\"";
                        MySqlCommand cmdSelectIdIng = new MySqlCommand(queryIdIngSelect, dbCon.Connection);
                        MySqlDataReader reader = cmdSelectIdIng.ExecuteReader();

                        if (reader.Read())
                        {
                            Console.WriteLine("Lecture du reader");
                            
                            idIngCourant =Int32.Parse(reader.GetString(0));

                            Console.WriteLine("idIngredient a supprimer : " +idIngCourant);

                           
                        }
                        reader.Close();

                        if (idIngCourant!=-1)
                        {
                            string queryRetireIng = "DELETE FROM manipuler WHERE idProduit = " + idProduit + " AND idNomenclature = " + idIngCourant;
                            var cmdRetireIng = new MySqlCommand(queryRetireIng, dbCon.Connection);
                            cmdRetireIng.ExecuteNonQuery();
                        }

                    }
                }
                //recharge le datagridView
                List<Ingredients> ingredients = GetIngredients();
                BindingSource source = new BindingSource();
                source.DataSource = ingredients;
                dataGridView1.DataSource = source;
            }
            dbCon.Close();
            */
        }

        private void lblSymptome_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutOperation_Paint(object sender, PaintEventArgs e)
        {

        }

        //sur modif d'un ingredient dans une opération, on affect la quantité maximum au input quantité de l'opération
        private void inputMatiereImp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ingredients ingredient = listIngredients.Where(ing =>
                                                             ing.nom_Ingredient.Equals(inputMatiereImp.Text)
                                                     )
                                              .Select(ing => new Ingredients()
                                              {
                                                  nom_Ingredient = ing.nom_Ingredient,
                                                  quantite = ing.quantite,
                                                  unite_Mesure = ing.unite_Mesure
                                              }).First();

            inputQuantiteMat.Maximum = ingredient.quantite;
        }
    }
}
