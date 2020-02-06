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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label lblListeProduits;
            System.Windows.Forms.Label LblIdProduitForm;
            System.Windows.Forms.Label lblNomProduitForm;
            System.Windows.Forms.Label lblNumVersionForm;
            System.Windows.Forms.Label lblPhaseCourForm;
            System.Windows.Forms.Label lblSymptomeForm;
            System.Windows.Forms.Label lblDateInsertProdForm;
            System.Windows.Forms.Label lblDateDerValidForm;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label12;
            this.tblDataProduits = new System.Windows.Forms.TableLayoutPanel();
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
            label1 = new System.Windows.Forms.Label();
            lblListeProduits = new System.Windows.Forms.Label();
            LblIdProduitForm = new System.Windows.Forms.Label();
            lblNomProduitForm = new System.Windows.Forms.Label();
            lblNumVersionForm = new System.Windows.Forms.Label();
            lblPhaseCourForm = new System.Windows.Forms.Label();
            lblSymptomeForm = new System.Windows.Forms.Label();
            lblDateInsertProdForm = new System.Windows.Forms.Label();
            lblDateDerValidForm = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            this.tblDataProduits.SuspendLayout();
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
            // label8
            // 
            label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.ForeColor = System.Drawing.Color.MidnightBlue;
            label8.Location = new System.Drawing.Point(979, 2);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(163, 50);
            label8.TabIndex = 28;
            label8.Text = "Date Insertion Produit";
            label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.ForeColor = System.Drawing.Color.MidnightBlue;
            label9.Location = new System.Drawing.Point(543, 9);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(173, 36);
            label9.TabIndex = 26;
            label9.Text = "Symptome";
            label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.ForeColor = System.Drawing.Color.MidnightBlue;
            label10.Location = new System.Drawing.Point(406, 10);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(109, 34);
            label10.TabIndex = 25;
            label10.Text = "N° Version";
            label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.ForeColor = System.Drawing.Color.MidnightBlue;
            label11.Location = new System.Drawing.Point(206, 11);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(163, 31);
            label11.TabIndex = 24;
            label11.Text = "Nom Produit";
            label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.ForeColor = System.Drawing.Color.MidnightBlue;
            label13.Location = new System.Drawing.Point(764, 10);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(163, 33);
            label13.TabIndex = 27;
            label13.Text = "Phase Courante";
            label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label14.ForeColor = System.Drawing.Color.MidnightBlue;
            label14.Location = new System.Drawing.Point(5, 9);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(163, 36);
            label14.TabIndex = 23;
            label14.Text = "Identifiant Produit";
            label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.ForeColor = System.Drawing.Color.MidnightBlue;
            label12.Location = new System.Drawing.Point(1197, 2);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(163, 50);
            label12.TabIndex = 29;
            label12.Text = "Date Dernière Validation";
            label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tblDataProduits
            // 
            this.tblDataProduits.AccessibleName = "tblDataProduits";
            this.tblDataProduits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tblDataProduits.AutoScroll = true;
            this.tblDataProduits.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tblDataProduits.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblDataProduits.ColumnCount = 7;
            this.tblDataProduits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblDataProduits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.59514F));
            this.tblDataProduits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.369099F));
            this.tblDataProduits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.16595F));
            this.tblDataProduits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.02146F));
            this.tblDataProduits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.09442F));
            this.tblDataProduits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.16452F));
            this.tblDataProduits.Controls.Add(label8, 5, 0);
            this.tblDataProduits.Controls.Add(label9, 3, 0);
            this.tblDataProduits.Controls.Add(label10, 2, 0);
            this.tblDataProduits.Controls.Add(label11, 1, 0);
            this.tblDataProduits.Controls.Add(label13, 4, 0);
            this.tblDataProduits.Controls.Add(label14, 0, 0);
            this.tblDataProduits.Controls.Add(label12, 6, 0);
            this.tblDataProduits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tblDataProduits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblDataProduits.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tblDataProduits.Location = new System.Drawing.Point(43, 526);
            this.tblDataProduits.Name = "tblDataProduits";
            this.tblDataProduits.RowCount = 2;
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDataProduits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblDataProduits.Size = new System.Drawing.Size(1386, 271);
            this.tblDataProduits.TabIndex = 23;
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
            // MainPageRDValence
            // 
            this.AccessibleName = "MainPageRDValence";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1468, 837);
            this.Controls.Add(this.tblDataProduits);
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
            this.tblDataProduits.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tblDataProduits;
    }
}

