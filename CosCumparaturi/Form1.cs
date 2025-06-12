namespace CosCumparaturi
{
    public partial class Form1 : Form
    {
        private readonly Cos cos;
        public Form1(Cos cos)
        {
            InitializeComponent();
            this.cos = cos;
            this.KeyPreview = true;

            dataGridViewProduse.KeyDown += DataGridViewProduse_KeyDown;

            dataGridViewProduse.DataSource = new BindingSource { DataSource = cos.GetProduse() };
            dataGridViewProduse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProduse.AllowUserToAddRows = false;

            Produs? produsSelectat = dataGridViewProduse.CurrentRow?.DataBoundItem as Produs;

            cos.AdaugareProdus += OnCosModificat;
            cos.StergereProdus += OnCosModificat;
            cos.ModificareProdus += OnCosModificat;

            RefreshStatusBar();
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

        private void DataGridViewProduse_KeyDown(object sender,  KeyEventArgs e)
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
    }
}
