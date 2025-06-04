using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosCumparaturi
{
    public partial class FormAdaugaProdus : Form
    {
        public FormAdaugaProdus()
        {
            InitializeComponent();
        }

        private class ProdusDisponibl
        {
            public int Cod { get; set; }

            public string Denumire { get; set; } = string.Empty;

            public decimal Pret { get; set; }

            public override string ToString()
            {
                return $"{Denumire} - {Pret:0.00} RON";
            }

        }
    }
}
