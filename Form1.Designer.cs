namespace ValenceRD
{
    partial class MainPageRDValence
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label lblListeProduits;
            System.Windows.Forms.Label LblIdProduitForm;
            System.Windows.Forms.Label lblNomProduitForm;
            System.Windows.Forms.Label lblNumVersionForm;
            System.Windows.Forms.Label lblPhaseCourForm;
            System.Windows.Forms.Label lblSymptomeForm;
            System.Windows.Forms.Label lblDateInsertProdForm;
            System.Windows.Forms.Label lblDateDerValidForm;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TitreAppli = new System.Windows.Forms.Label();
            this.btnCreerProduit = new System.Windows.Forms.Button();
            this.btnUpgradeProduit = new System.Windows.Forms.Button();
            this.btnFiltreProduits = new System.Windows.Forms.Button();
            this.InputSymptomeForm = new System.Windows.Forms.ComboBox();
            this.inputPhaseForm = new System.Windows.Forms.ComboBox();
            this.inputIdentifiantForm = new System.Windows.Forms.TextBox();
            this.inputNomProdForm = new System.Windows.Forms.TextBox();
            this.inputNumVersionForm = new System.Windows.Forms.TextBox();
            this.inputDateInsertProdForm = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.r_d_valenceDataSet = new ValenceRD.r_d_valenceDataSet();
            this.rdvalenceDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            label1 = new System.Windows.Forms.Label();
            lblListeProduits = new System.Windows.Forms.Label();
            LblIdProduitForm = new System.Windows.Forms.Label();
            lblNomProduitForm = new System.Windows.Forms.Label();
            lblNumVersionForm = new System.Windows.Forms.Label();
            lblPhaseCourForm = new System.Windows.Forms.Label();
            lblSymptomeForm = new System.Windows.Forms.Label();
            lblDateInsertProdForm = new System.Windows.Forms.Label();
            lblDateDerValidForm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.r_d_valenceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdvalenceDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            label1.Location = new System.Drawing.Point(365, 78);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(767, 82);
            label1.TabIndex = 1;
            label1.Text = "Recherche et Dev Valence";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblListeProduits
            // 
            lblListeProduits.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblListeProduits.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblListeProduits.ForeColor = System.Drawing.Color.MidnightBlue;
            lblListeProduits.Location = new System.Drawing.Point(36, 287);
            lblListeProduits.Name = "lblListeProduits";
            lblListeProduits.Size = new System.Drawing.Size(211, 47);
            lblListeProduits.TabIndex = 4;
            lblListeProduits.Text = "Liste Produits";
            lblListeProduits.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lblListeProduits.Click += new System.EventHandler(this.label2_Click);
            // 
            // LblIdProduitForm
            // 
            LblIdProduitForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            LblIdProduitForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblIdProduitForm.ForeColor = System.Drawing.Color.Indigo;
            LblIdProduitForm.Location = new System.Drawing.Point(57, 360);
            LblIdProduitForm.Name = "LblIdProduitForm";
            LblIdProduitForm.Size = new System.Drawing.Size(176, 41);
            LblIdProduitForm.TabIndex = 6;
            LblIdProduitForm.Text = "Identifiant";
            LblIdProduitForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            LblIdProduitForm.Click += new System.EventHandler(this.LblIdProduitForm_Click);
            // 
            // lblNomProduitForm
            // 
            lblNomProduitForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblNomProduitForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblNomProduitForm.ForeColor = System.Drawing.Color.Indigo;
            lblNomProduitForm.Location = new System.Drawing.Point(225, 360);
            lblNomProduitForm.Name = "lblNomProduitForm";
            lblNomProduitForm.Size = new System.Drawing.Size(176, 41);
            lblNomProduitForm.TabIndex = 7;
            lblNomProduitForm.Text = "Nom Produit";
            lblNomProduitForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNumVersionForm
            // 
            lblNumVersionForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblNumVersionForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblNumVersionForm.ForeColor = System.Drawing.Color.Indigo;
            lblNumVersionForm.Location = new System.Drawing.Point(398, 360);
            lblNumVersionForm.Name = "lblNumVersionForm";
            lblNumVersionForm.Size = new System.Drawing.Size(176, 41);
            lblNumVersionForm.TabIndex = 8;
            lblNumVersionForm.Text = "N° Version";
            lblNumVersionForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPhaseCourForm
            // 
            lblPhaseCourForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblPhaseCourForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPhaseCourForm.ForeColor = System.Drawing.Color.Indigo;
            lblPhaseCourForm.Location = new System.Drawing.Point(716, 360);
            lblPhaseCourForm.Name = "lblPhaseCourForm";
            lblPhaseCourForm.Size = new System.Drawing.Size(217, 41);
            lblPhaseCourForm.TabIndex = 10;
            lblPhaseCourForm.Text = "Phase Courante";
            lblPhaseCourForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSymptomeForm
            // 
            lblSymptomeForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblSymptomeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSymptomeForm.ForeColor = System.Drawing.Color.Indigo;
            lblSymptomeForm.Location = new System.Drawing.Point(553, 360);
            lblSymptomeForm.Name = "lblSymptomeForm";
            lblSymptomeForm.Size = new System.Drawing.Size(176, 41);
            lblSymptomeForm.TabIndex = 11;
            lblSymptomeForm.Text = "Symptome";
            lblSymptomeForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDateInsertProdForm
            // 
            lblDateInsertProdForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblDateInsertProdForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDateInsertProdForm.ForeColor = System.Drawing.Color.Indigo;
            lblDateInsertProdForm.Location = new System.Drawing.Point(911, 360);
            lblDateInsertProdForm.Name = "lblDateInsertProdForm";
            lblDateInsertProdForm.Size = new System.Drawing.Size(256, 41);
            lblDateInsertProdForm.TabIndex = 12;
            lblDateInsertProdForm.Text = "Date Insertion Produit";
            lblDateInsertProdForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDateDerValidForm
            // 
            lblDateDerValidForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblDateDerValidForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDateDerValidForm.ForeColor = System.Drawing.Color.Indigo;
            lblDateDerValidForm.Location = new System.Drawing.Point(1154, 360);
            lblDateDerValidForm.Name = "lblDateDerValidForm";
            lblDateDerValidForm.Size = new System.Drawing.Size(256, 41);
            lblDateDerValidForm.TabIndex = 13;
            lblDateDerValidForm.Text = "Date Dernière Validation";
            lblDateDerValidForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TitreAppli
            // 
            this.TitreAppli.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TitreAppli.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitreAppli.Location = new System.Drawing.Point(333, 64);
            this.TitreAppli.Name = "TitreAppli";
            this.TitreAppli.Size = new System.Drawing.Size(35, 13);
            this.TitreAppli.TabIndex = 0;
            this.TitreAppli.Text = "label1";
            this.TitreAppli.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCreerProduit
            // 
            this.btnCreerProduit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreerProduit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCreerProduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreerProduit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCreerProduit.Location = new System.Drawing.Point(526, 205);
            this.btnCreerProduit.Name = "btnCreerProduit";
            this.btnCreerProduit.Size = new System.Drawing.Size(195, 61);
            this.btnCreerProduit.TabIndex = 2;
            this.btnCreerProduit.Text = "Créer un Produit";
            this.btnCreerProduit.UseVisualStyleBackColor = false;
            this.btnCreerProduit.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpgradeProduit
            // 
            this.btnUpgradeProduit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpgradeProduit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUpgradeProduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpgradeProduit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpgradeProduit.Location = new System.Drawing.Point(786, 205);
            this.btnUpgradeProduit.Name = "btnUpgradeProduit";
            this.btnUpgradeProduit.Size = new System.Drawing.Size(195, 61);
            this.btnUpgradeProduit.TabIndex = 3;
            this.btnUpgradeProduit.Text = "Upgrade un Produit";
            this.btnUpgradeProduit.UseVisualStyleBackColor = false;
            this.btnUpgradeProduit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFiltreProduits
            // 
            this.btnFiltreProduits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFiltreProduits.BackColor = System.Drawing.Color.Teal;
            this.btnFiltreProduits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltreProduits.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFiltreProduits.Location = new System.Drawing.Point(640, 448);
            this.btnFiltreProduits.Name = "btnFiltreProduits";
            this.btnFiltreProduits.Size = new System.Drawing.Size(195, 38);
            this.btnFiltreProduits.TabIndex = 5;
            this.btnFiltreProduits.Text = "Filtrer les produits";
            this.btnFiltreProduits.UseVisualStyleBackColor = false;
            this.btnFiltreProduits.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // InputSymptomeForm
            // 
            this.InputSymptomeForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InputSymptomeForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputSymptomeForm.FormattingEnabled = true;
            this.InputSymptomeForm.Items.AddRange(new object[] {
            "Symtpome 1",
            "Symtpome 2",
            "Symptome 3"});
            this.InputSymptomeForm.Location = new System.Drawing.Point(580, 395);
            this.InputSymptomeForm.Name = "InputSymptomeForm";
            this.InputSymptomeForm.Size = new System.Drawing.Size(130, 21);
            this.InputSymptomeForm.TabIndex = 14;
            // 
            // inputPhaseForm
            // 
            this.inputPhaseForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputPhaseForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputPhaseForm.FormattingEnabled = true;
            this.inputPhaseForm.Items.AddRange(new object[] {
            "Symtpome 1",
            "Symtpome 2",
            "Symptome 3"});
            this.inputPhaseForm.Location = new System.Drawing.Point(752, 395);
            this.inputPhaseForm.Name = "inputPhaseForm";
            this.inputPhaseForm.Size = new System.Drawing.Size(153, 21);
            this.inputPhaseForm.TabIndex = 15;
            // 
            // inputIdentifiantForm
            // 
            this.inputIdentifiantForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputIdentifiantForm.Location = new System.Drawing.Point(96, 395);
            this.inputIdentifiantForm.Name = "inputIdentifiantForm";
            this.inputIdentifiantForm.Size = new System.Drawing.Size(137, 20);
            this.inputIdentifiantForm.TabIndex = 16;
            // 
            // inputNomProdForm
            // 
            this.inputNomProdForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputNomProdForm.Location = new System.Drawing.Point(255, 395);
            this.inputNomProdForm.Name = "inputNomProdForm";
            this.inputNomProdForm.Size = new System.Drawing.Size(137, 20);
            this.inputNomProdForm.TabIndex = 17;
            // 
            // inputNumVersionForm
            // 
            this.inputNumVersionForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputNumVersionForm.Location = new System.Drawing.Point(433, 395);
            this.inputNumVersionForm.Name = "inputNumVersionForm";
            this.inputNumVersionForm.Size = new System.Drawing.Size(53, 20);
            this.inputNumVersionForm.TabIndex = 18;
            // 
            // inputDateInsertProdForm
            // 
            this.inputDateInsertProdForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputDateInsertProdForm.Location = new System.Drawing.Point(948, 395);
            this.inputDateInsertProdForm.Name = "inputDateInsertProdForm";
            this.inputDateInsertProdForm.Size = new System.Drawing.Size(184, 20);
            this.inputDateInsertProdForm.TabIndex = 20;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker2.Location = new System.Drawing.Point(1183, 396);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(184, 20);
            this.dateTimePicker2.TabIndex = 21;
            // 
            // r_d_valenceDataSet
            // 
            this.r_d_valenceDataSet.DataSetName = "r_d_valenceDataSet";
            this.r_d_valenceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rdvalenceDataSetBindingSource
            // 
            this.rdvalenceDataSetBindingSource.DataSource = this.r_d_valenceDataSet;
            this.rdvalenceDataSetBindingSource.Position = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(34, 503);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1393, 277);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // MainPageRDValence
            // 
            this.AccessibleName = "MainPageRDValence";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1468, 837);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.inputDateInsertProdForm);
            this.Controls.Add(this.inputNumVersionForm);
            this.Controls.Add(this.inputNomProdForm);
            this.Controls.Add(this.inputIdentifiantForm);
            this.Controls.Add(this.inputPhaseForm);
            this.Controls.Add(this.InputSymptomeForm);
            this.Controls.Add(lblDateDerValidForm);
            this.Controls.Add(lblDateInsertProdForm);
            this.Controls.Add(lblSymptomeForm);
            this.Controls.Add(lblPhaseCourForm);
            this.Controls.Add(lblNumVersionForm);
            this.Controls.Add(lblNomProduitForm);
            this.Controls.Add(LblIdProduitForm);
            this.Controls.Add(this.btnFiltreProduits);
            this.Controls.Add(lblListeProduits);
            this.Controls.Add(this.btnUpgradeProduit);
            this.Controls.Add(this.btnCreerProduit);
            this.Controls.Add(label1);
            this.Controls.Add(this.TitreAppli);
            this.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Name = "MainPageRDValence";
            this.Text = "R&D Valence";
            this.Load += new System.EventHandler(this.MainPageRDValence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.r_d_valenceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdvalenceDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitreAppli;
        private System.Windows.Forms.Button btnCreerProduit;
        private System.Windows.Forms.Button btnUpgradeProduit;
        private System.Windows.Forms.Button btnFiltreProduits;
        private System.Windows.Forms.ComboBox InputSymptomeForm;
        private System.Windows.Forms.ComboBox inputPhaseForm;
        private System.Windows.Forms.TextBox inputIdentifiantForm;
        private System.Windows.Forms.TextBox inputNomProdForm;
        private System.Windows.Forms.TextBox inputNumVersionForm;
        private System.Windows.Forms.DateTimePicker inputDateInsertProdForm;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.BindingSource rdvalenceDataSetBindingSource;
        private r_d_valenceDataSet r_d_valenceDataSet;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

