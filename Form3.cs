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
    public partial class UpgradeProduit : Form
    {
        public UpgradeProduit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPageRDValence mainPage = new MainPageRDValence();
            this.Hide();
            mainPage.Show();
        }

        private void btnValidUpgrade_Click(object sender, EventArgs e)
        {
            RechercheProduit rechProd = new RechercheProduit();
            rechProd.Show();
            this.Hide();
        }

        private void inputIdUpgrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIdSelectFromInput.Text = inputIdUpgrade.Text;
        }
    }
}
