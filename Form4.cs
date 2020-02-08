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
    public partial class RechercheProduit : Form
    {
        public RechercheProduit()
        {
            InitializeComponent();
        }

        public RechercheProduit(int _idProd, String _nomScien, String _symptome, String _version, String _phaseCour, String _dateInsertProd, String _dateDerVers)
        {
            InitializeComponent();

            //initialise les variables d'affichages
            lblNomProduit.Text = _nomScien;
            lblVersionProduit.Text = _version;
            lblSymptProd.Text = _symptome;
        }

        private void btnRetourMenu_Click(object sender, EventArgs e)
        {
            MainPageRDValence mainPage = new MainPageRDValence();
            mainPage.Show();
            this.Hide();
        }
    }
}
