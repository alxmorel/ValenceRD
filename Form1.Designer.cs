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
            System.Windows.Forms.Label lblDatInsAPartirDe;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TitreAppli = new System.Windows.Forms.Label();
            this.btnCreerProduit = new System.Windows.Forms.Button();
            this.btnUpgradeProduit = new System.Windows.Forms.Button();
            this.InputSymptomeForm = new System.Windows.Forms.ComboBox();
            this.traitementsymptomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rdvalenceDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.r_d_valenceDataSet = new ValenceRD.r_d_valenceDataSet();
            this.inputPhaseForm = new System.Windows.Forms.ComboBox();
            this.phaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inputIdentifiantForm = new System.Windows.Forms.TextBox();
            this.inputNomProdForm = new System.Windows.Forms.TextBox();
            this.inputNumVersionForm = new System.Windows.Forms.TextBox();
            this.inputDateInsertProdFormDeb = new System.Windows.Forms.DateTimePicker();
            this.inputDateValidFormDeb = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.inputDateValidFormFin = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.inputDateInsertProdFormFin = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.traitement_symptomeTableAdapter = new ValenceRD.r_d_valenceDataSetTableAdapters.traitement_symptomeTableAdapter();
            this.traitementsymptomeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.traitementsymptomeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.traitementsymptomeBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.phaseTableAdapter = new ValenceRD.r_d_valenceDataSetTableAdapters.phaseTableAdapter();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            lblListeProduits = new System.Windows.Forms.Label();
            LblIdProduitForm = new System.Windows.Forms.Label();
            lblNomProduitForm = new System.Windows.Forms.Label();
            lblNumVersionForm = new System.Windows.Forms.Label();
            lblPhaseCourForm = new System.Windows.Forms.Label();
            lblSymptomeForm = new System.Windows.Forms.Label();
            lblDateInsertProdForm = new System.Windows.Forms.Label();
            lblDateDerValidForm = new System.Windows.Forms.Label();
            lblDatInsAPartirDe = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.traitementsymptomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdvalenceDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_d_valenceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.traitementsymptomeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traitementsymptomeBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traitementsymptomeBindingSource3)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            label1.Location = new System.Drawing.Point(374, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(767, 83);
            label1.TabIndex = 1;
            label1.Text = "Recherche et Dev Valence";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblListeProduits
            // 
            lblListeProduits.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblListeProduits.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblListeProduits.ForeColor = System.Drawing.Color.MidnightBlue;
            lblListeProduits.Location = new System.Drawing.Point(41, 201);
            lblListeProduits.Name = "lblListeProduits";
            lblListeProduits.Size = new System.Drawing.Size(211, 47);
            lblListeProduits.TabIndex = 4;
            lblListeProduits.Text = "Liste Produits";
            lblListeProduits.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lblListeProduits.Click += new System.EventHandler(this.label2_Click);
            // 
            // LblIdProduitForm
            // 
            LblIdProduitForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            LblIdProduitForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LblIdProduitForm.ForeColor = System.Drawing.Color.Indigo;
            LblIdProduitForm.Location = new System.Drawing.Point(3, 0);
            LblIdProduitForm.Name = "LblIdProduitForm";
            LblIdProduitForm.Size = new System.Drawing.Size(189, 52);
            LblIdProduitForm.TabIndex = 6;
            LblIdProduitForm.Text = "Identifiant";
            LblIdProduitForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            LblIdProduitForm.Click += new System.EventHandler(this.LblIdProduitForm_Click);
            // 
            // lblNomProduitForm
            // 
            lblNomProduitForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblNomProduitForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblNomProduitForm.ForeColor = System.Drawing.Color.Indigo;
            lblNomProduitForm.Location = new System.Drawing.Point(198, 0);
            lblNomProduitForm.Name = "lblNomProduitForm";
            lblNomProduitForm.Size = new System.Drawing.Size(189, 52);
            lblNomProduitForm.TabIndex = 7;
            lblNomProduitForm.Text = "Nom Produit";
            lblNomProduitForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNumVersionForm
            // 
            lblNumVersionForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblNumVersionForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblNumVersionForm.ForeColor = System.Drawing.Color.Indigo;
            lblNumVersionForm.Location = new System.Drawing.Point(393, 0);
            lblNumVersionForm.Name = "lblNumVersionForm";
            lblNumVersionForm.Size = new System.Drawing.Size(189, 52);
            lblNumVersionForm.TabIndex = 8;
            lblNumVersionForm.Text = "N° Version";
            lblNumVersionForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPhaseCourForm
            // 
            lblPhaseCourForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblPhaseCourForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPhaseCourForm.ForeColor = System.Drawing.Color.Indigo;
            lblPhaseCourForm.Location = new System.Drawing.Point(783, 0);
            lblPhaseCourForm.Name = "lblPhaseCourForm";
            lblPhaseCourForm.Size = new System.Drawing.Size(189, 52);
            lblPhaseCourForm.TabIndex = 10;
            lblPhaseCourForm.Text = "Phase Courante";
            lblPhaseCourForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSymptomeForm
            // 
            lblSymptomeForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblSymptomeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSymptomeForm.ForeColor = System.Drawing.Color.Indigo;
            lblSymptomeForm.Location = new System.Drawing.Point(588, 0);
            lblSymptomeForm.Name = "lblSymptomeForm";
            lblSymptomeForm.Size = new System.Drawing.Size(189, 52);
            lblSymptomeForm.TabIndex = 11;
            lblSymptomeForm.Text = "Symptome";
            lblSymptomeForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDateInsertProdForm
            // 
            lblDateInsertProdForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblDateInsertProdForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDateInsertProdForm.ForeColor = System.Drawing.Color.Indigo;
            lblDateInsertProdForm.Location = new System.Drawing.Point(978, 0);
            lblDateInsertProdForm.Name = "lblDateInsertProdForm";
            lblDateInsertProdForm.Size = new System.Drawing.Size(189, 52);
            lblDateInsertProdForm.TabIndex = 12;
            lblDateInsertProdForm.Text = "Date Insertion Produit";
            lblDateInsertProdForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDateDerValidForm
            // 
            lblDateDerValidForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblDateDerValidForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDateDerValidForm.ForeColor = System.Drawing.Color.Indigo;
            lblDateDerValidForm.Location = new System.Drawing.Point(1173, 0);
            lblDateDerValidForm.Name = "lblDateDerValidForm";
            lblDateDerValidForm.Size = new System.Drawing.Size(195, 52);
            lblDateDerValidForm.TabIndex = 13;
            lblDateDerValidForm.Text = "Date Dernière Validation";
            lblDateDerValidForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDatInsAPartirDe
            // 
            lblDatInsAPartirDe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblDatInsAPartirDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDatInsAPartirDe.ForeColor = System.Drawing.Color.Purple;
            lblDatInsAPartirDe.Location = new System.Drawing.Point(3, 0);
            lblDatInsAPartirDe.Name = "lblDatInsAPartirDe";
            lblDatInsAPartirDe.Size = new System.Drawing.Size(177, 16);
            lblDatInsAPartirDe.TabIndex = 32;
            lblDatInsAPartirDe.Text = "A partir du";
            lblDatInsAPartirDe.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.Purple;
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(177, 14);
            label2.TabIndex = 33;
            label2.Text = "Jusqu\'au";
            label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ForeColor = System.Drawing.Color.Purple;
            label3.Location = new System.Drawing.Point(3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(183, 14);
            label3.TabIndex = 33;
            label3.Text = "Jusqu\'au";
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = System.Drawing.Color.Purple;
            label4.Location = new System.Drawing.Point(3, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(183, 16);
            label4.TabIndex = 32;
            label4.Text = "A partir du";
            label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TitreAppli
            // 
            this.TitreAppli.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TitreAppli.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitreAppli.Location = new System.Drawing.Point(333, 24);
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
            this.btnCreerProduit.Location = new System.Drawing.Point(494, 136);
            this.btnCreerProduit.Name = "btnCreerProduit";
            this.btnCreerProduit.Size = new System.Drawing.Size(220, 61);
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
            this.btnUpgradeProduit.Location = new System.Drawing.Point(787, 136);
            this.btnUpgradeProduit.Name = "btnUpgradeProduit";
            this.btnUpgradeProduit.Size = new System.Drawing.Size(233, 61);
            this.btnUpgradeProduit.TabIndex = 3;
            this.btnUpgradeProduit.Text = "Upgrade un Produit";
            this.btnUpgradeProduit.UseVisualStyleBackColor = false;
            this.btnUpgradeProduit.Click += new System.EventHandler(this.button2_Click);
            // 
            // InputSymptomeForm
            // 
            this.InputSymptomeForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.InputSymptomeForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputSymptomeForm.FormattingEnabled = true;
            this.InputSymptomeForm.Location = new System.Drawing.Point(588, 55);
            this.InputSymptomeForm.Name = "InputSymptomeForm";
            this.InputSymptomeForm.Size = new System.Drawing.Size(188, 21);
            this.InputSymptomeForm.TabIndex = 14;
            this.InputSymptomeForm.SelectedIndexChanged += new System.EventHandler(this.InputSymptomeForm_SelectedIndexChanged);
            // 
            // traitementsymptomeBindingSource
            // 
            this.traitementsymptomeBindingSource.DataMember = "traitement_symptome";
            this.traitementsymptomeBindingSource.DataSource = this.rdvalenceDataSetBindingSource;
            // 
            // rdvalenceDataSetBindingSource
            // 
            this.rdvalenceDataSetBindingSource.DataSource = this.r_d_valenceDataSet;
            this.rdvalenceDataSetBindingSource.Position = 0;
            // 
            // r_d_valenceDataSet
            // 
            this.r_d_valenceDataSet.DataSetName = "r_d_valenceDataSet";
            this.r_d_valenceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inputPhaseForm
            // 
            this.inputPhaseForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inputPhaseForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputPhaseForm.FormattingEnabled = true;
            this.inputPhaseForm.Location = new System.Drawing.Point(783, 55);
            this.inputPhaseForm.Name = "inputPhaseForm";
            this.inputPhaseForm.Size = new System.Drawing.Size(188, 21);
            this.inputPhaseForm.TabIndex = 15;
            this.inputPhaseForm.SelectedIndexChanged += new System.EventHandler(this.inputPhaseForm_SelectedIndexChanged);
            // 
            // phaseBindingSource
            // 
            this.phaseBindingSource.DataMember = "phase";
            this.phaseBindingSource.DataSource = this.r_d_valenceDataSet;
            // 
            // inputIdentifiantForm
            // 
            this.inputIdentifiantForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inputIdentifiantForm.Location = new System.Drawing.Point(9, 55);
            this.inputIdentifiantForm.Name = "inputIdentifiantForm";
            this.inputIdentifiantForm.Size = new System.Drawing.Size(176, 20);
            this.inputIdentifiantForm.TabIndex = 16;
            this.inputIdentifiantForm.TextChanged += new System.EventHandler(this.inputIdentifiantForm_TextChanged);
            // 
            // inputNomProdForm
            // 
            this.inputNomProdForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inputNomProdForm.Location = new System.Drawing.Point(198, 55);
            this.inputNomProdForm.Name = "inputNomProdForm";
            this.inputNomProdForm.Size = new System.Drawing.Size(188, 20);
            this.inputNomProdForm.TabIndex = 17;
            this.inputNomProdForm.TextChanged += new System.EventHandler(this.inputNomProdForm_TextChanged);
            // 
            // inputNumVersionForm
            // 
            this.inputNumVersionForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inputNumVersionForm.Location = new System.Drawing.Point(393, 55);
            this.inputNumVersionForm.Name = "inputNumVersionForm";
            this.inputNumVersionForm.Size = new System.Drawing.Size(188, 20);
            this.inputNumVersionForm.TabIndex = 18;
            this.inputNumVersionForm.TextChanged += new System.EventHandler(this.inputNumVersionForm_TextChanged);
            // 
            // inputDateInsertProdFormDeb
            // 
            this.inputDateInsertProdFormDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDateInsertProdFormDeb.Location = new System.Drawing.Point(3, 19);
            this.inputDateInsertProdFormDeb.Name = "inputDateInsertProdFormDeb";
            this.inputDateInsertProdFormDeb.Size = new System.Drawing.Size(177, 20);
            this.inputDateInsertProdFormDeb.TabIndex = 20;
            this.inputDateInsertProdFormDeb.Value = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.inputDateInsertProdFormDeb.ValueChanged += new System.EventHandler(this.inputDateInsertProdForm_ValueChanged);
            // 
            // inputDateValidFormDeb
            // 
            this.inputDateValidFormDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDateValidFormDeb.Location = new System.Drawing.Point(3, 19);
            this.inputDateValidFormDeb.Name = "inputDateValidFormDeb";
            this.inputDateValidFormDeb.Size = new System.Drawing.Size(183, 20);
            this.inputDateValidFormDeb.TabIndex = 21;
            this.inputDateValidFormDeb.Value = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.inputDateValidFormDeb.ValueChanged += new System.EventHandler(this.inputDateValidForm_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 169);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1371, 327);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 5, 1);
            this.tableLayoutPanel1.Controls.Add(LblIdProduitForm, 0, 0);
            this.tableLayoutPanel1.Controls.Add(lblDateDerValidForm, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputNomProdForm, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputPhaseForm, 4, 1);
            this.tableLayoutPanel1.Controls.Add(lblDateInsertProdForm, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputNumVersionForm, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.InputSymptomeForm, 3, 1);
            this.tableLayoutPanel1.Controls.Add(lblNumVersionForm, 2, 0);
            this.tableLayoutPanel1.Controls.Add(lblPhaseCourForm, 4, 0);
            this.tableLayoutPanel1.Controls.Add(lblNomProduitForm, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputIdentifiantForm, 0, 1);
            this.tableLayoutPanel1.Controls.Add(lblSymptomeForm, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1371, 160);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(1173, 55);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(195, 102);
            this.tableLayoutPanel5.TabIndex = 33;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(label3, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.inputDateValidFormFin, 0, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 55);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(189, 44);
            this.tableLayoutPanel6.TabIndex = 34;
            // 
            // inputDateValidFormFin
            // 
            this.inputDateValidFormFin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDateValidFormFin.Location = new System.Drawing.Point(3, 17);
            this.inputDateValidFormFin.Name = "inputDateValidFormFin";
            this.inputDateValidFormFin.Size = new System.Drawing.Size(183, 20);
            this.inputDateValidFormFin.TabIndex = 20;
            this.inputDateValidFormFin.ValueChanged += new System.EventHandler(this.inputDateValidFormFin_ValueChanged);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(label4, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.inputDateValidFormDeb, 0, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(189, 46);
            this.tableLayoutPanel7.TabIndex = 33;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(978, 55);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(189, 102);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.inputDateInsertProdFormFin, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 55);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(183, 44);
            this.tableLayoutPanel4.TabIndex = 34;
            // 
            // inputDateInsertProdFormFin
            // 
            this.inputDateInsertProdFormFin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDateInsertProdFormFin.Location = new System.Drawing.Point(3, 17);
            this.inputDateInsertProdFormFin.Name = "inputDateInsertProdFormFin";
            this.inputDateInsertProdFormFin.Size = new System.Drawing.Size(177, 20);
            this.inputDateInsertProdFormFin.TabIndex = 20;
            this.inputDateInsertProdFormFin.ValueChanged += new System.EventHandler(this.inputDateInsertProdFormFin_ValueChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(lblDatInsAPartirDe, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.inputDateInsertProdFormDeb, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(183, 46);
            this.tableLayoutPanel3.TabIndex = 33;
            // 
            // traitement_symptomeTableAdapter
            // 
            this.traitement_symptomeTableAdapter.ClearBeforeFill = true;
            // 
            // traitementsymptomeBindingSource1
            // 
            this.traitementsymptomeBindingSource1.DataMember = "traitement_symptome";
            this.traitementsymptomeBindingSource1.DataSource = this.rdvalenceDataSetBindingSource;
            // 
            // traitementsymptomeBindingSource2
            // 
            this.traitementsymptomeBindingSource2.DataMember = "traitement_symptome";
            this.traitementsymptomeBindingSource2.DataSource = this.rdvalenceDataSetBindingSource;
            // 
            // traitementsymptomeBindingSource3
            // 
            this.traitementsymptomeBindingSource3.DataMember = "traitement_symptome";
            this.traitementsymptomeBindingSource3.DataSource = this.r_d_valenceDataSet;
            // 
            // phaseTableAdapter
            // 
            this.phaseTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(45, 245);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.26733F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.73267F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1377, 499);
            this.tableLayoutPanel8.TabIndex = 32;
            // 
            // MainPageRDValence
            // 
            this.AccessibleName = "MainPageRDValence";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1468, 756);
            this.Controls.Add(this.tableLayoutPanel8);
            this.Controls.Add(lblListeProduits);
            this.Controls.Add(this.btnUpgradeProduit);
            this.Controls.Add(this.btnCreerProduit);
            this.Controls.Add(label1);
            this.Controls.Add(this.TitreAppli);
            this.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Name = "MainPageRDValence";
            this.Text = "R&D Valence";
            this.Load += new System.EventHandler(this.MainPageRDValence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.traitementsymptomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdvalenceDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_d_valenceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.traitementsymptomeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traitementsymptomeBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traitementsymptomeBindingSource3)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitreAppli;
        private System.Windows.Forms.Button btnCreerProduit;
        private System.Windows.Forms.Button btnUpgradeProduit;
        private System.Windows.Forms.ComboBox InputSymptomeForm;
        private System.Windows.Forms.ComboBox inputPhaseForm;
        private System.Windows.Forms.TextBox inputIdentifiantForm;
        private System.Windows.Forms.TextBox inputNomProdForm;
        private System.Windows.Forms.TextBox inputNumVersionForm;
        private System.Windows.Forms.DateTimePicker inputDateInsertProdFormDeb;
        private System.Windows.Forms.DateTimePicker inputDateValidFormDeb;
        private System.Windows.Forms.BindingSource rdvalenceDataSetBindingSource;
        private r_d_valenceDataSet r_d_valenceDataSet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource traitementsymptomeBindingSource;
        private r_d_valenceDataSetTableAdapters.traitement_symptomeTableAdapter traitement_symptomeTableAdapter;
        private System.Windows.Forms.BindingSource traitementsymptomeBindingSource3;
        private System.Windows.Forms.BindingSource traitementsymptomeBindingSource1;
        private System.Windows.Forms.BindingSource traitementsymptomeBindingSource2;
        private System.Windows.Forms.BindingSource phaseBindingSource;
        private r_d_valenceDataSetTableAdapters.phaseTableAdapter phaseTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.DateTimePicker inputDateValidFormFin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DateTimePicker inputDateInsertProdFormFin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
    }
}

