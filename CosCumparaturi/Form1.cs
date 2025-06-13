using System.ComponentModel;
using System.Drawing.Printing;

namespace CosCumparaturi
{
    public partial class Form1 : Form
    {
        private readonly Cos cos;
        private CosContext? db;
        private PrintDocument printDocument = new();
        private string continutDePrintat = "";

        public Form1(Cos cos)
        {
            InitializeComponent();
            this.cos = cos;
            this.KeyPreview = true;

            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;


            dataGridViewProduse.KeyDown += DataGridViewProduse_KeyDown;

            dataGridViewProduse.DataSource = new BindingSource { DataSource = cos.Produse };
            dataGridViewProduse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProduse.AllowUserToAddRows = false;

            Produs? produsSelectat = dataGridViewProduse.CurrentRow?.DataBoundItem as Produs;

            cos.AdaugareProdus += OnCosModificat;
            cos.StergereProdus += OnCosModificat;
            cos.ModificareProdus += OnCosModificat;

            cos.ModificareProdus += (s, e) => DeseneazaGrafic();

            RefreshStatusBar();
        }

        public Form1() : this(new Cos())
        {

        }

        private void OnCosModificat(object? sender, Produs produs)
        {
            dataGridViewProduse.Refresh();
            RefreshStatusBar();
        }

        private void RefreshStatusBar()
        {
            statusLabelNumar.Text = $"Număr produse: {cos.NumarProduse}";
            statusLabelValoare.Text = $"Valoare totală: {cos.ValoareTotala:0.00} RON";
        }


        private void MenuItemAdaugaProdus_Click(object sender, EventArgs e)
        {
            var formAdaugare = new FormAdaugaProdus();

            formAdaugare.ProdusAdaugat += (s, args) =>
            {
                try
                {
                    cos.AdaugaProdus(args.Produs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare in handler: " + ex.Message);
                }
            };

            formAdaugare.ShowDialog();
        }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void stergeProdusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produs? produsSelectat = dataGridViewProduse.CurrentRow?.DataBoundItem as Produs;
            if (produsSelectat != null)
            {
                cos.StergeProdus(produsSelectat);
            }
        }

        private void DataGridViewProduse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Produs? produsSelectat = dataGridViewProduse.CurrentRow?.DataBoundItem as Produs;
                if (produsSelectat != null)
                {
                    cos.StergeProdus(produsSelectat);
                    e.Handled = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new CosContext();
            db.Database.EnsureCreated();

            cos.Produse.Clear();

            var produseInDB = db.Produse.ToList();
            foreach (var produs in produseInDB)
            {
                cos.AdaugaProdus(produs);
            }

            dataGridViewProduse.DataSource = cos.Produse;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (db == null) return;

            try
            {
                db.Produse.RemoveRange(db.Produse);
                db.SaveChanges();

                foreach (var p in cos.Produse)
                {
                    db.Produse.Add(new Produs
                    {
                        Cod = p.Cod,
                        Denumire = p.Denumire,
                        Pret = p.Pret,
                        Cantitate = p.Cantitate,
                    });
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la salvarea in baza de date: " + ex.Message);
            }
            finally
            {
                db.Dispose();
            }
        }

        private void fisierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportaCosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new()
            {
                Filter = "Fișiere text (*.txt)|*.txt",
                Title = "Selectează locația pentru export"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using StreamWriter writer = new StreamWriter(sfd.FileName);

                    foreach (var produs in cos.Produse)
                    {
                        writer.WriteLine($"{produs.Cod}, {produs.Denumire}, {produs.Pret}, {produs.Cantitate}");
                    }

                    MessageBox.Show("Export realizat cu suscces", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la export: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void importaCosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new()
            {
                Filter = "Fișiere text (*.txt)|*.txt",
                Title = "Selectează locația pentru export"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using StreamReader reader = new StreamReader(ofd.FileName);
                    string? line;
                    int produseImportate = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');

                        if (parts.Length == 4 &&
                            int.TryParse(parts[0], out int cod) &&
                            decimal.TryParse(parts[2], out decimal pret) &&
                            int.TryParse(parts[3], out int cantitate))
                        {
                            string denumire = parts[1];
                            var produsExistent = cos.Produse.FirstOrDefault(p => p.Denumire == denumire);
                            if (produsExistent != null)
                            {
                                produsExistent.Cantitate = cantitate;
                                produsExistent.Pret = pret;
                            }
                            else
                            {
                                cos.AdaugaProdus(new Produs { Denumire = denumire, Cod = cod, Cantitate = cantitate, Pret = pret });
                            }
                            produseImportate++;
                        }
                    }
                    MessageBox.Show($"Import realizat cu succes: {produseImportate} produse adăugate.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la import: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DeseneazaGrafic()
        {
            var produse = cos.Produse;
            if (produse.Count == 0) return;

            panelGrafic.Refresh();

            Graphics g = panelGrafic.CreateGraphics();
            int latimeBara = 40;
            int spatiu = 20;
            int x = 10;

            decimal valoareMax = produse.Max(p => p.Cantitate * p.Pret);
            int hPanel = panelGrafic.Height;

            using Pen contur = new Pen(Color.Black);
            using Brush umplere = new SolidBrush(Color.SkyBlue);
            using Font font = new Font("Arial", 8);

            foreach (var produs in produse)
            {
                decimal valoare = produs.Cantitate * produs.Pret;
                int inaltime = (int)((valoare / valoareMax) * (hPanel - 40));

                g.FillRectangle(umplere, x, hPanel - inaltime - 20, latimeBara, inaltime);
                g.DrawRectangle(contur, x, hPanel - inaltime - 20, latimeBara, inaltime);

                g.DrawString(produs.Denumire, font, Brushes.Black, x, hPanel - 15);

                x += latimeBara + spatiu;
            }
        }

        private void panelGrafic_Paint(object sender, PaintEventArgs e)
        {
            DeseneazaGrafic();
        }
        private void tiparesteCosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            continutDePrintat = "Cosul de cumparaturi: \n\n";
            foreach (var produs in cos.Produse)
            {
                continutDePrintat += $"Cod: {produs.Cod} | Denumire: {produs.Denumire} | Cantitate: {produs.Cantitate} | Pret: {produs.Pret: 0.00} RON\n";
            }

            PrintDialog dlg = new PrintDialog();
            dlg.Document = printDocument;
            printDocument.PrintPage += PrintDocument_PrintPage;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }

            printDocument.PrintPage -= PrintDocument_PrintPage;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;
            float x = 50, y = 50;
            e.Graphics.DrawString(continutDePrintat, font, brush, x, y);
        }
    }
}
