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
    public partial class AjoutMatiere : Form
    {
        private int idProduit;

        public AjoutMatiere()
        {
            InitializeComponent();
        }
        public AjoutMatiere(int _idProduit)
        {
            InitializeComponent();
            idProduit = _idProduit;
        }
    }
}
