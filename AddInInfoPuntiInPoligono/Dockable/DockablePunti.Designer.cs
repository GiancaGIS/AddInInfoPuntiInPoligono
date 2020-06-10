namespace AddInInfoPuntiInPoligono
{
    partial class DockablePunti
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
            this.listViewFormSTAT = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxLayerPoligonale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFeatureLayerSelezionato = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxZoommaDinamicamente = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonPulisci = new System.Windows.Forms.Button();
            this.buttonSeleziona = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewFormSTAT
            // 
            this.listViewFormSTAT.AutoArrange = false;
            this.listViewFormSTAT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewFormSTAT.FullRowSelect = true;
            this.listViewFormSTAT.GridLines = true;
            this.listViewFormSTAT.HideSelection = false;
            this.listViewFormSTAT.HoverSelection = true;
            this.listViewFormSTAT.Location = new System.Drawing.Point(35, 228);
            this.listViewFormSTAT.MultiSelect = false;
            this.listViewFormSTAT.Name = "listViewFormSTAT";
            this.listViewFormSTAT.Size = new System.Drawing.Size(444, 236);
            this.listViewFormSTAT.TabIndex = 3;
            this.listViewFormSTAT.UseCompatibleStateImageBehavior = false;
            this.listViewFormSTAT.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Feature Layer";
            this.columnHeader2.Width = 122;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Numero oggetti che ricadono nel poligono";
            this.columnHeader3.Width = 213;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Numero posizionale Feature Layer";
            this.columnHeader4.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxFeatureLayerSelezionato);
            this.groupBox1.Controls.Add(this.listViewFormSTAT);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(7, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 549);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info spaziali";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxLayerPoligonale);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(35, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(444, 49);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Poligono";
            // 
            // textBoxLayerPoligonale
            // 
            this.textBoxLayerPoligonale.Location = new System.Drawing.Point(243, 21);
            this.textBoxLayerPoligonale.Name = "textBoxLayerPoligonale";
            this.textBoxLayerPoligonale.Size = new System.Drawing.Size(175, 26);
            this.textBoxLayerPoligonale.TabIndex = 7;
            this.textBoxLayerPoligonale.TextChanged += new System.EventHandler(this.textBoxLayerPoligonale_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Layer poligonale selezionato:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 491);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Feature Layer in selezione:";
            // 
            // textBoxFeatureLayerSelezionato
            // 
            this.textBoxFeatureLayerSelezionato.Location = new System.Drawing.Point(251, 488);
            this.textBoxFeatureLayerSelezionato.Name = "textBoxFeatureLayerSelezionato";
            this.textBoxFeatureLayerSelezionato.Size = new System.Drawing.Size(219, 26);
            this.textBoxFeatureLayerSelezionato.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxZoommaDinamicamente);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.buttonPulisci);
            this.groupBox2.Controls.Add(this.buttonSeleziona);
            this.groupBox2.Location = new System.Drawing.Point(36, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 123);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selezione";
            // 
            // checkBoxZoommaDinamicamente
            // 
            this.checkBoxZoommaDinamicamente.AutoSize = true;
            this.checkBoxZoommaDinamicamente.Location = new System.Drawing.Point(26, 93);
            this.checkBoxZoommaDinamicamente.Name = "checkBoxZoommaDinamicamente";
            this.checkBoxZoommaDinamicamente.Size = new System.Drawing.Size(300, 24);
            this.checkBoxZoommaDinamicamente.TabIndex = 3;
            this.checkBoxZoommaDinamicamente.Text = "centra in mappa gli oggetti selezionati";
            this.checkBoxZoommaDinamicamente.UseVisualStyleBackColor = true;
            this.checkBoxZoommaDinamicamente.CheckedChanged += new System.EventHandler(this.checkBoxZoommaDinamicamente_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 51);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancella selezione in Mappa\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonCancellaSelezioneMappa);
            // 
            // buttonPulisci
            // 
            this.buttonPulisci.Location = new System.Drawing.Point(329, 21);
            this.buttonPulisci.Name = "buttonPulisci";
            this.buttonPulisci.Size = new System.Drawing.Size(114, 32);
            this.buttonPulisci.TabIndex = 1;
            this.buttonPulisci.Text = "Pulisci Lista";
            this.buttonPulisci.UseVisualStyleBackColor = true;
            this.buttonPulisci.Click += new System.EventHandler(this.buttonPulisci_Click);
            // 
            // buttonSeleziona
            // 
            this.buttonSeleziona.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSeleziona.Location = new System.Drawing.Point(27, 35);
            this.buttonSeleziona.Name = "buttonSeleziona";
            this.buttonSeleziona.Size = new System.Drawing.Size(252, 43);
            this.buttonSeleziona.TabIndex = 0;
            this.buttonSeleziona.Text = "Seleziona in mappa";
            this.buttonSeleziona.UseVisualStyleBackColor = true;
            this.buttonSeleziona.Click += new System.EventHandler(this.buttonSeleziona_Click);
            // 
            // DockablePunti
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.groupBox1);
            this.Name = "DockablePunti";
            this.Size = new System.Drawing.Size(567, 586);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFormSTAT;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSeleziona;
        private System.Windows.Forms.Button buttonPulisci;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFeatureLayerSelezionato;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxLayerPoligonale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxZoommaDinamicamente;


    }
}
