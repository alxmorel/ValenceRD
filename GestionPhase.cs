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
    public partial class GestionPhase : Form
    {

        public List<Phases> ListPhases { get; set; }
        DataGridViewCheckBoxColumn checkBoxColumnValidee = new DataGridViewCheckBoxColumn();
        private int idProduit;
        private int idPhase;
        private int idVersion;

        public GestionPhase(int _idProduit, int _idPhase, int _idVersion)
        {
            InitializeComponent();
            idProduit = _idProduit;
            idPhase = _idPhase;
            idVersion = _idVersion;
            ListPhases = getListPhases();
        }

        private void GestionPhase_Load(object sender, EventArgs e)
        {
            //Ressources totales
            List<Phases> phases = this.ListPhases;

            BindingSource source1 = new BindingSource();
            source1.DataSource = phases;

            dataGridView1.DataSource = source1;

            dataGridView1.Columns["validee"].Visible = false;

            dataGridView1.Columns.Add(checkBoxColumnValidee);

            majCheckBoxDataGrid();
        }


        private List<Phases> getListPhases()
        {
            List<Phases> list = new List<Phases>();
            checkBoxColumnValidee.Name = "EstValidee";
            checkBoxColumnValidee.HeaderText = "EstValidee";
            

            //Connection Base de données r_d_valence
            DBConnection dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "r_d_valence";

            if (dbCon.IsConnect())
            {
                //initialise la liste des ressources total
                string queryselectPhase = "select p.idPhase, libelle, commentaire, validation from phase p left join valider v on p.idPhase = v.idPhase where idVersion = @idVersion and idProduit = @idProduit order by p.idPhase";
                using (MySqlCommand cmdselectPhase = new MySqlCommand(queryselectPhase, dbCon.Connection))
                {
                    cmdselectPhase.Parameters.Add("@idVersion", MySqlDbType.Int32).Value = idVersion;
                    cmdselectPhase.Parameters.Add("@idProduit", MySqlDbType.Int32).Value = idProduit;

                    MySqlDataReader rdselectPhase = cmdselectPhase.ExecuteReader();

                    while (rdselectPhase.Read())
                    {
                        list.Add(new Phases()
                        {
                            id_Phase = rdselectPhase.GetInt32(0),
                            libelle = rdselectPhase.GetString(1),
                            commentaire = rdselectPhase.GetString(2),
                            validee = rdselectPhase.GetInt32(3)
                        });
                    }
                    rdselectPhase.Close();
                }
                   
            }
            dbCon.Close();

            return list;
        }


        private void majCheckBoxDataGrid()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Console.WriteLine("row : "+ row.Cells["id_Phase"].Value.ToString());
                foreach (Phases res in ListPhases)
                {
                    Console.WriteLine("phase : " + res.id_Phase.ToString());

                    if (res.id_Phase.ToString().Equals(row.Cells["id_Phase"].Value.ToString()))
                    {
                        DataGridViewCheckBoxCell checkBoxCell = (row.Cells["EstValidee"] as DataGridViewCheckBoxCell);

                        Console.WriteLine("Validee : " + res.validee);

                        if (res.validee == 1)
                        {
                            Console.WriteLine("Case a cocher");
                            checkBoxCell.Value = checkBoxCell.TrueValue;
                            checkBoxCell.Value = checkBoxCell.Selected;
                        }
                        else if (res.validee == 0)
                        {
                            Console.WriteLine("Case a ne pas cocher");
                            checkBoxCell.Value = checkBoxCell.FalseValue;
                        }
                    }
                }
            }
        }

        private void boutonRetourRecette_Click(object sender, EventArgs e)
        {
            RechercheProduit rechProd = new RechercheProduit(idProduit, idPhase, idVersion);
            rechProd.StartPosition = FormStartPosition.CenterParent;
            rechProd.Show();
            this.Hide();
        }
    }
    
}
