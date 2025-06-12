namespace CosCumparaturi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridViewProduse = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            stergeProdusToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            statusLabelNumar = new ToolStripStatusLabel();
            statusLabelValoare = new ToolStripStatusLabel();
            menuItemAdaugProdus_Click = new MenuStrip();
            adauToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            fisierToolStripMenuItem = new ToolStripMenuItem();
            exportaCosToolStripMenuItem = new ToolStripMenuItem();
            importaCoslToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).BeginInit();
            contextMenuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuItemAdaugProdus_Click.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewProduse
            // 
            dataGridViewProduse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProduse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduse.ContextMenuStrip = contextMenuStrip1;
            dataGridViewProduse.Dock = DockStyle.Top;
            dataGridViewProduse.Location = new Point(0, 0);
            dataGridViewProduse.Name = "dataGridViewProduse";
            dataGridViewProduse.Size = new Size(800, 150);
            dataGridViewProduse.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { stergeProdusToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(158, 26);
            // 
            // stergeProdusToolStripMenuItem
            // 
            stergeProdusToolStripMenuItem.Name = "stergeProdusToolStripMenuItem";
            stergeProdusToolStripMenuItem.Size = new Size(157, 22);
            stergeProdusToolStripMenuItem.Text = "Șterge produsul";
            stergeProdusToolStripMenuItem.Click += stergeProdusToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel2, statusLabelNumar, statusLabelValoare });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(0, 17);
            // 
            // statusLabelNumar
            // 
            statusLabelNumar.Name = "statusLabelNumar";
            statusLabelNumar.Size = new Size(102, 17);
            statusLabelNumar.Text = "Număr produse: 0";
            statusLabelNumar.Click += toolStripStatusLabel1_Click;
            // 
            // statusLabelValoare
            // 
            statusLabelValoare.Name = "statusLabelValoare";
            statusLabelValoare.Size = new Size(133, 17);
            statusLabelValoare.Text = "Valoare totală: 0.00 RON";
            // 
            // menuItemAdaugProdus_Click
            // 
            menuItemAdaugProdus_Click.Anchor = AnchorStyles.None;
            menuItemAdaugProdus_Click.Dock = DockStyle.None;
            menuItemAdaugProdus_Click.Items.AddRange(new ToolStripItem[] { adauToolStripMenuItem });
            menuItemAdaugProdus_Click.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuItemAdaugProdus_Click.Location = new Point(0, 258);
            menuItemAdaugProdus_Click.Name = "menuItemAdaugProdus_Click";
            menuItemAdaugProdus_Click.Size = new Size(108, 24);
            menuItemAdaugProdus_Click.TabIndex = 2;
            menuItemAdaugProdus_Click.Text = "menuStrip1";
            menuItemAdaugProdus_Click.Click += MenuItemAdaugaProdus_Click;
            // 
            // adauToolStripMenuItem
            // 
            adauToolStripMenuItem.Name = "adauToolStripMenuItem";
            adauToolStripMenuItem.Size = new Size(100, 20);
            adauToolStripMenuItem.Text = "Adaugă produs";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fisierToolStripMenuItem });
            menuStrip1.Location = new Point(0, 150);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fisierToolStripMenuItem
            // 
            fisierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportaCosToolStripMenuItem, importaCoslToolStripMenuItem });
            fisierToolStripMenuItem.Name = "fisierToolStripMenuItem";
            fisierToolStripMenuItem.Size = new Size(46, 20);
            fisierToolStripMenuItem.Text = "Fișier";
            fisierToolStripMenuItem.Click += fisierToolStripMenuItem_Click;
            // 
            // exportaCosToolStripMenuItem
            // 
            exportaCosToolStripMenuItem.Name = "exportaCosToolStripMenuItem";
            exportaCosToolStripMenuItem.Size = new Size(180, 22);
            exportaCosToolStripMenuItem.Text = "Exportă coșul...";
            exportaCosToolStripMenuItem.Click += exportaCosToolStripMenuItem_Click;
            // 
            // importaCoslToolStripMenuItem
            // 
            importaCoslToolStripMenuItem.Name = "importaCoslToolStripMenuItem";
            importaCoslToolStripMenuItem.Size = new Size(180, 22);
            importaCoslToolStripMenuItem.Text = "Importă coșul...";
            importaCoslToolStripMenuItem.Click += importaCosToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuItemAdaugProdus_Click);
            Controls.Add(menuStrip1);
            Controls.Add(dataGridViewProduse);
            MainMenuStrip = menuItemAdaugProdus_Click;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuItemAdaugProdus_Click.ResumeLayout(false);
            menuItemAdaugProdus_Click.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewProduse;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel statusLabelNumar;
        private ToolStripStatusLabel statusLabelValoare;
        private MenuStrip menuItemAdaugProdus_Click;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem stergeProdusToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fisierToolStripMenuItem;
        private ToolStripMenuItem adauToolStripMenuItem;
        private ToolStripMenuItem exportaCosToolStripMenuItem;
        private ToolStripMenuItem importaCoslToolStripMenuItem;
    }
}
