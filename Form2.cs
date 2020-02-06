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
    public partial class PageCreaProduit : Form
    {
        public PageCreaProduit()
        {
            InitializeComponent();
        }

        internal static void show()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPageRDValence mainPage = new MainPageRDValence();
            this.Hide();
            mainPage.Show();
            
        }

        private void btnCreerProduit_Click(object sender, EventArgs e)
        {
            RechercheProduit rechProd = new RechercheProduit();
            rechProd.Show();
            this.Hide();
        }
    }
}
