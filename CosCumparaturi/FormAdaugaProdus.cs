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


            var produse = new List<ProdusDisponibil>
            {
                new ProdusDisponibil { Cod = 1, Denumire = "Lapte", Pret = 5.5m},
                new ProdusDisponibil { Cod = 2, Denumire = "Paine", Pret = 2.2m},
                new ProdusDisponibil { Cod = 3, Denumire = "Oua", Pret = 12.0m},
                new ProdusDisponibil { Cod = 4, Denumire = "Zahar", Pret = 4.0m},
            };

            comboBoxProduse.DataSource = produse;
            comboBoxProduse.DisplayMember = nameof(ProdusDisponibil.Denumire);
            comboBoxProduse.SelectedIndex = 0;
        }

        private class ProdusDisponibil
        {
            public int Cod { get; set; }

            public string Denumire { get; set; } = string.Empty;

            public decimal Pret { get; set; }

            public override string ToString()
            {
                return $"{Denumire} - {Pret:0.00} RON";
            }
        }

        public class ProdusAdaugatEventArgs : EventArgs
        {
            public Produs Produs { get; set; } = null!;
            public int Cantitate { get; set; }
        }

        public event EventHandler<ProdusAdaugatEventArgs>? ProdusAdaugat;

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            if (comboBoxProduse.SelectedItem is ProdusDisponibil selectie)
            {
                var produs = new Produs
                {
                    Cod = selectie.Cod,
                    Denumire = selectie.Denumire,
                    Pret = selectie.Pret,
                    Cantitate = (int)numericCantitate.Value
                };

                ProdusAdaugat?.Invoke(this, new ProdusAdaugatEventArgs
                {
                    Produs = produs,
                    Cantitate = produs.Cantitate
                });

                this.Close();
            }
        }
    }
}
