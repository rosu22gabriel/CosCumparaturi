using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CosCumparaturi
{
    public class Cos
    {
        private List<Produs> produse = [];

        public int NumarProduse => produse.Count;

        public Produs this[int index]
        {
            get => produse[index];
            set
            {
                if (index >= 0 && index < produse.Count)
                {
                    produse[index].PropertyChanged -= Produs_PropertyChanged;
                    produse[index] = value;
                    produse[index].PropertyChanged += Produs_PropertyChanged;
                    ModificareProdus?.Invoke(this, produse[index]);
                }
            }
        }

        public decimal ValoareTotala => produse.Sum(p => p.Pret * p.Cantitate);

        public void AdaugaProdus(Produs produs)
        {
            produse.Add(produs);
            produs.PropertyChanged += Produs_PropertyChanged;
            AdaugareProdus?.Invoke(this, produs);
        }

        public void StergeProdus(Produs produs)
        {
            if (produse.Remove(produs))
            {
                produs.PropertyChanged -= Produs_PropertyChanged;
                StergereProdus?.Invoke(this, produs);
            }

        }

        public IList<Produs> GetProduse()
        {
            return produse;
        }


        private void Produs_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is Produs produs)
            {
                ModificareProdus?.Invoke(this, produs);
            }

        }

        public event EventHandler<Produs>? AdaugareProdus;
        public event EventHandler<Produs>? StergereProdus;
        public event EventHandler<Produs>? ModificareProdus;

    }
}

