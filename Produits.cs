using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValenceRD
{
    public class Produits
    {
        public int id_Produit { get; set; }
        public String nom_Scientifique { get; set; }
        public String symptome { get; set; }

        public String version { get; set; }

        public String phase_Courante { get; set; }

        public String date_insertion_produit { get; set; }

        public String date_derniere_validation { get; set; }

    }
}
