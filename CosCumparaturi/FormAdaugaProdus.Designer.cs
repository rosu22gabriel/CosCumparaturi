
namespace CosCumparaturi
{
    partial class FormAdaugaProdus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxProduse = new ComboBox();
            numericCantitate = new NumericUpDown();
            buttonAdauga = new Button();
            ((System.ComponentModel.ISupportInitialize)numericCantitate).BeginInit();
            SuspendLayout();
            // 
            // comboBoxProduse
            // 
            comboBoxProduse.DisplayMember = "Denumire";
            comboBoxProduse.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProduse.FormattingEnabled = true;
            comboBoxProduse.Location = new Point(270, 134);
            comboBoxProduse.Name = "comboBoxProduse";
            comboBoxProduse.Size = new Size(121, 23);
            comboBoxProduse.TabIndex = 0;
            // 
            // numericCantitate
            // 
            numericCantitate.Location = new Point(271, 202);
            numericCantitate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericCantitate.Name = "numericCantitate";
            numericCantitate.Size = new Size(120, 23);
            numericCantitate.TabIndex = 1;
            numericCantitate.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonAdauga
            // 
            buttonAdauga.Location = new Point(270, 258);
            buttonAdauga.Name = "buttonAdauga";
            buttonAdauga.Size = new Size(121, 23);
            buttonAdauga.TabIndex = 2;
            buttonAdauga.Text = "Adaugă în coș";
            buttonAdauga.UseVisualStyleBackColor = true;
            buttonAdauga.Click += buttonAdauga_Click;
            // 
            // FormAdaugaProdus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonAdauga);
            Controls.Add(numericCantitate);
            Controls.Add(comboBoxProduse);
            Name = "FormAdaugaProdus";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)numericCantitate).EndInit();
            ResumeLayout(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ComboBox comboBoxProduse;
        private NumericUpDown numericCantitate;
        private Button buttonAdauga;
    }
}