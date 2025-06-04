using System;
using System.Windows.Forms;

namespace CosCumparaturi
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var cos = new Cos();
            cos.AdaugaProdus(new Produs { Cod = 1, Denumire = "Lapte", Pret = 5.5m, Cantitate = 2 });
            cos.AdaugaProdus(new Produs { Cod = 2, Denumire = "Paine", Pret = 2.3m, Cantitate = 3 });

            Application.Run(new Form1(cos));
        }
    }
}