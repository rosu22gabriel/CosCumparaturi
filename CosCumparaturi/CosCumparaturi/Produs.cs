using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CosCumparaturi
{
    public class Produs : INotifyPropertyChanged, IComparable<Produs>
    {
        private int cod;
        private string denumire = string.Empty;
        private decimal pret;
        private int cantitate;

        public int Cod
        {
            get => cod;
            set
            {
                if (cod != value)
                {
                    cod = value;
                    OnPropertyChanged(nameof(Cod));
                }
            }
        }

        public string Denumire
        {
            get => denumire;
            set
            {
                if (denumire != value)
                {
                    denumire = value;
                    OnPropertyChanged(nameof(Denumire));
                }
            }
        }


        public decimal Pret
        {
            get => pret;
            set
            {
                if (pret != value)
                {
                    pret = value;
                    OnPropertyChanged(nameof(Pret));
                }
            }
        }


        public int Cantitate
        {
            get => cantitate;
            set
            {
                if (cantitate != value)
                {
                    cantitate = value;
                    OnPropertyChanged(nameof(Cantitate));
                }

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(String numeProprietate)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(numeProprietate));
        }

        public int CompareTo(Produs? other)
        {
            if (other == null) return 1;
            return this.Denumire.CompareTo(other.Denumire);
        }

    }
}
