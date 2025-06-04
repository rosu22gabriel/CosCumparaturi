namespace CosCumparaturi
{
    public partial class Form1 : Form
    {
        private Cos cos;
        public Form1(Cos cos)
        {
            InitializeComponent();
            this.cos = cos;
            dataGridViewProduse.DataSource = new BindingSource { DataSource = cos.GetProduse() };
            dataGridViewProduse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
