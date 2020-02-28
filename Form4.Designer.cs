namespace ValenceRD
{
    partial class RechercheProduit
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label lblSymptome;
            System.Windows.Forms.Label lblEffetSec;
            System.Windows.Forms.Label lblRecette;
            System.Windows.Forms.Label lblNomenclat;
            System.Windows.Forms.Label lblEtapes;
            System.Windows.Forms.Label lblPhase;
            System.Windows.Forms.Label lblCheckList;
            System.Windows.Forms.Label lblCommentPhase;
            System.Windows.Forms.Label lblOperEtape1;
            System.Windows.Forms.Label lblDureeEtape1;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNomProduit = new System.Windows.Forms.Label();
            this.lblVersionProduit = new System.Windows.Forms.Label();
            this.lblSymptProd = new System.Windows.Forms.Label();
            this.lblEffetSecProd = new System.Windows.Forms.Label();
            this.btnRetourMenu = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.inputCommentairePhase = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.inputQuantiteMat = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblmin = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.inputOperation = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.inputMatiereImp = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.button9 = new System.Windows.Forms.Button();
            this.r_d_valenceDataSet = new ValenceRD.r_d_valenceDataSet();
            this.rdvalenceDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRetireMatiere = new System.Windows.Forms.Button();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutOperation = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutOperation = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            lblSymptome = new System.Windows.Forms.Label();
            lblEffetSec = new System.Windows.Forms.Label();
            lblRecette = new System.Windows.Forms.Label();
            lblNomenclat = new System.Windows.Forms.Label();
            lblEtapes = new System.Windows.Forms.Label();
            lblPhase = new System.Windows.Forms.Label();
            lblCheckList = new System.Windows.Forms.Label();
            lblCommentPhase = new System.Windows.Forms.Label();
            lblOperEtape1 = new System.Windows.Forms.Label();
            lblDureeEtape1 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputQuantiteMat)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.r_d_valenceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdvalenceDataSetBindingSource)).BeginInit();
            this.tableLayoutPanel19.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutOperation.SuspendLayout();
            this.tableLayoutOperation.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel22.SuspendLayout();
            this.tableLayoutPanel21.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSymptome
            // 
            lblSymptome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblSymptome.BackColor = System.Drawing.Color.Transparent;
            lblSymptome.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            lblSymptome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            lblSymptome.Location = new System.Drawing.Point(3, 0);
            lblSymptome.Name = "lblSymptome";
            lblSymptome.Size = new System.Drawing.Size(264, 52);
            lblSymptome.TabIndex = 29;
            lblSymptome.Text = "Symptome";
            lblSymptome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lblSymptome.Click += new System.EventHandler(this.lblSymptome_Click);
            // 
            // lblEffetSec
            // 
            lblEffetSec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblEffetSec.BackColor = System.Drawing.Color.Transparent;
            lblEffetSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            lblEffetSec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            lblEffetSec.Location = new System.Drawing.Point(3, 52);
            lblEffetSec.Name = "lblEffetSec";
            lblEffetSec.Size = new System.Drawing.Size(264, 52);
            lblEffetSec.TabIndex = 30;
            lblEffetSec.Text = "Effets Secondaires";
            lblEffetSec.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRecette
            // 
            lblRecette.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblRecette.BackColor = System.Drawing.Color.Transparent;
            lblRecette.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            lblRecette.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            lblRecette.Location = new System.Drawing.Point(3, 115);
            lblRecette.Name = "lblRecette";
            lblRecette.Size = new System.Drawing.Size(171, 45);
            lblRecette.TabIndex = 32;
            lblRecette.Text = "Recette";
            lblRecette.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNomenclat
            // 
            lblNomenclat.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblNomenclat.BackColor = System.Drawing.Color.Transparent;
            lblNomenclat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            lblNomenclat.ForeColor = System.Drawing.Color.DarkCyan;
            lblNomenclat.Location = new System.Drawing.Point(15, 178);
            lblNomenclat.Name = "lblNomenclat";
            lblNomenclat.Size = new System.Drawing.Size(191, 45);
            lblNomenclat.TabIndex = 33;
            lblNomenclat.Text = "Nomenclature";
            lblNomenclat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEtapes
            // 
            lblEtapes.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblEtapes.BackColor = System.Drawing.Color.Transparent;
            lblEtapes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            lblEtapes.ForeColor = System.Drawing.Color.DarkCyan;
            lblEtapes.Location = new System.Drawing.Point(417, 176);
            lblEtapes.Name = "lblEtapes";
            lblEtapes.Size = new System.Drawing.Size(102, 45);
            lblEtapes.TabIndex = 34;
            lblEtapes.Text = "Etapes";
            lblEtapes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPhase
            // 
            lblPhase.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblPhase.BackColor = System.Drawing.Color.Transparent;
            lblPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            lblPhase.ForeColor = System.Drawing.Color.DarkCyan;
            lblPhase.Location = new System.Drawing.Point(14, 675);
            lblPhase.Name = "lblPhase";
            lblPhase.Size = new System.Drawing.Size(112, 32);
            lblPhase.TabIndex = 35;
            lblPhase.Text = "Phases";
            lblPhase.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCheckList
            // 
            lblCheckList.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblCheckList.BackColor = System.Drawing.Color.Transparent;
            lblCheckList.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            lblCheckList.ForeColor = System.Drawing.Color.DarkCyan;
            lblCheckList.Location = new System.Drawing.Point(12, 528);
            lblCheckList.Name = "lblCheckList";
            lblCheckList.Size = new System.Drawing.Size(160, 30);
            lblCheckList.TabIndex = 36;
            lblCheckList.Text = "Check Liste";
            lblCheckList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCommentPhase
            // 
            lblCommentPhase.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblCommentPhase.BackColor = System.Drawing.Color.Transparent;
            lblCommentPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            lblCommentPhase.ForeColor = System.Drawing.Color.DarkCyan;
            lblCommentPhase.Location = new System.Drawing.Point(695, 583);
            lblCommentPhase.Name = "lblCommentPhase";
            lblCommentPhase.Size = new System.Drawing.Size(271, 31);
            lblCommentPhase.TabIndex = 37;
            lblCommentPhase.Text = "Commentaire de Phase";
            lblCommentPhase.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOperEtape1
            // 
            lblOperEtape1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblOperEtape1.BackColor = System.Drawing.Color.Transparent;
            lblOperEtape1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            lblOperEtape1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            lblOperEtape1.Location = new System.Drawing.Point(3, 0);
            lblOperEtape1.Name = "lblOperEtape1";
            lblOperEtape1.Size = new System.Drawing.Size(180, 26);
            lblOperEtape1.TabIndex = 48;
            lblOperEtape1.Text = "Opération";
            lblOperEtape1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDureeEtape1
            // 
            lblDureeEtape1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblDureeEtape1.BackColor = System.Drawing.Color.Transparent;
            lblDureeEtape1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            lblDureeEtape1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            lblDureeEtape1.Location = new System.Drawing.Point(3, 0);
            lblDureeEtape1.Name = "lblDureeEtape1";
            lblDureeEtape1.Size = new System.Drawing.Size(76, 24);
            lblDureeEtape1.TabIndex = 48;
            lblDureeEtape1.Text = "Durée";
            lblDureeEtape1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(76, 31);
            label1.TabIndex = 48;
            label1.Text = "Quantité";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            label3.Location = new System.Drawing.Point(3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(180, 31);
            label3.TabIndex = 48;
            label3.Text = "Matière Impliqué";
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNomProduit
            // 
            this.lblNomProduit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNomProduit.AutoSize = true;
            this.lblNomProduit.BackColor = System.Drawing.Color.Transparent;
            this.lblNomProduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomProduit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblNomProduit.Location = new System.Drawing.Point(4, 7);
            this.lblNomProduit.Name = "lblNomProduit";
            this.lblNomProduit.Size = new System.Drawing.Size(422, 76);
            this.lblNomProduit.TabIndex = 26;
            this.lblNomProduit.Text = "Nom_Produit";
            this.lblNomProduit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblVersionProduit
            // 
            this.lblVersionProduit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVersionProduit.AutoSize = true;
            this.lblVersionProduit.BackColor = System.Drawing.Color.Transparent;
            this.lblVersionProduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lblVersionProduit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblVersionProduit.Location = new System.Drawing.Point(432, 33);
            this.lblVersionProduit.Name = "lblVersionProduit";
            this.lblVersionProduit.Size = new System.Drawing.Size(220, 39);
            this.lblVersionProduit.TabIndex = 27;
            this.lblVersionProduit.Text = "Version_prod";
            this.lblVersionProduit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSymptProd
            // 
            this.lblSymptProd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSymptProd.AutoSize = true;
            this.lblSymptProd.BackColor = System.Drawing.Color.Transparent;
            this.lblSymptProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblSymptProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblSymptProd.Location = new System.Drawing.Point(3, 15);
            this.lblSymptProd.Name = "lblSymptProd";
            this.lblSymptProd.Size = new System.Drawing.Size(192, 31);
            this.lblSymptProd.TabIndex = 28;
            this.lblSymptProd.Text = "Symptome_Prod";
            this.lblSymptProd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEffetSecProd
            // 
            this.lblEffetSecProd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEffetSecProd.AutoSize = true;
            this.lblEffetSecProd.BackColor = System.Drawing.Color.Transparent;
            this.lblEffetSecProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblEffetSecProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblEffetSecProd.Location = new System.Drawing.Point(3, 15);
            this.lblEffetSecProd.Name = "lblEffetSecProd";
            this.lblEffetSecProd.Size = new System.Drawing.Size(192, 31);
            this.lblEffetSecProd.TabIndex = 31;
            this.lblEffetSecProd.Text = "Effets_Sec_Prod";
            this.lblEffetSecProd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRetourMenu
            // 
            this.btnRetourMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetourMenu.BackColor = System.Drawing.Color.Teal;
            this.btnRetourMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetourMenu.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRetourMenu.Location = new System.Drawing.Point(1287, 764);
            this.btnRetourMenu.Name = "btnRetourMenu";
            this.btnRetourMenu.Size = new System.Drawing.Size(169, 61);
            this.btnRetourMenu.TabIndex = 39;
            this.btnRetourMenu.Text = "Retour Menu";
            this.btnRetourMenu.UseVisualStyleBackColor = false;
            this.btnRetourMenu.Click += new System.EventHandler(this.btnRetourMenu_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(1192, 617);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 43);
            this.button1.TabIndex = 40;
            this.button1.Text = "Valider la Phase";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(1192, 664);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 43);
            this.button2.TabIndex = 41;
            this.button2.Text = "Retour à la Phase Précédente";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // inputCommentairePhase
            // 
            this.inputCommentairePhase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputCommentairePhase.Location = new System.Drawing.Point(798, 617);
            this.inputCommentairePhase.Name = "inputCommentairePhase";
            this.inputCommentairePhase.Size = new System.Drawing.Size(361, 90);
            this.inputCommentairePhase.TabIndex = 42;
            this.inputCommentairePhase.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(3, 45);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(336, 167);
            this.dataGridView1.TabIndex = 46;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.Color.Gray;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(336, 36);
            this.button3.TabIndex = 44;
            this.button3.Text = "Ajouter une Matière";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.AjouterMatiere_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.inputQuantiteMat, 0, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(197, 63);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(82, 63);
            this.tableLayoutPanel7.TabIndex = 55;
            // 
            // inputQuantiteMat
            // 
            this.inputQuantiteMat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputQuantiteMat.Location = new System.Drawing.Point(3, 37);
            this.inputQuantiteMat.Name = "inputQuantiteMat";
            this.inputQuantiteMat.Size = new System.Drawing.Size(76, 20);
            this.inputQuantiteMat.TabIndex = 53;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(lblDureeEtape1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel17, 0, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(197, 4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.2963F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.7037F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(82, 52);
            this.tableLayoutPanel6.TabIndex = 54;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel17.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.lblmin, 1, 0);
            this.tableLayoutPanel17.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 1;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(76, 22);
            this.tableLayoutPanel17.TabIndex = 59;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(26, 20);
            this.textBox1.TabIndex = 49;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblmin
            // 
            this.lblmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblmin.AutoSize = true;
            this.lblmin.Location = new System.Drawing.Point(35, 9);
            this.lblmin.Name = "lblmin";
            this.lblmin.Size = new System.Drawing.Size(23, 13);
            this.lblmin.TabIndex = 50;
            this.lblmin.Text = "min";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.inputOperation, 0, 1);
            this.tableLayoutPanel5.Controls.Add(lblOperEtape1, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(186, 52);
            this.tableLayoutPanel5.TabIndex = 47;
            // 
            // inputOperation
            // 
            this.inputOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputOperation.DisplayMember = "Opération";
            this.inputOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputOperation.FormattingEnabled = true;
            this.inputOperation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.inputOperation.Items.AddRange(new object[] {
            "Opération"});
            this.inputOperation.Location = new System.Drawing.Point(3, 29);
            this.inputOperation.Name = "inputOperation";
            this.inputOperation.Size = new System.Drawing.Size(180, 21);
            this.inputOperation.TabIndex = 47;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.inputMatiereImp, 0, 1);
            this.tableLayoutPanel9.Controls.Add(label3, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(4, 63);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(186, 63);
            this.tableLayoutPanel9.TabIndex = 55;
            // 
            // inputMatiereImp
            // 
            this.inputMatiereImp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputMatiereImp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputMatiereImp.FormattingEnabled = true;
            this.inputMatiereImp.Location = new System.Drawing.Point(3, 36);
            this.inputMatiereImp.Name = "inputMatiereImp";
            this.inputMatiereImp.Size = new System.Drawing.Size(180, 21);
            this.inputMatiereImp.TabIndex = 52;
            this.inputMatiereImp.SelectedIndexChanged += new System.EventHandler(this.inputMatiereImp_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.BackColor = System.Drawing.Color.Maroon;
            this.button4.Font = new System.Drawing.Font("Marlett", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(286, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 27);
            this.button4.TabIndex = 57;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Font = new System.Drawing.Font("Marlett", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button8.Location = new System.Drawing.Point(432, 492);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(344, 36);
            this.button8.TabIndex = 58;
            this.button8.Text = "Ajouter une étape";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel1.Location = new System.Drawing.Point(128, 515);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 48;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Modifier";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel2.Location = new System.Drawing.Point(92, 662);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(44, 13);
            this.linkLabel2.TabIndex = 49;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Modifier";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel4.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel4.Location = new System.Drawing.Point(3, 0);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(44, 13);
            this.linkLabel4.TabIndex = 51;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Modifier";
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button9.BackColor = System.Drawing.Color.DarkKhaki;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.Control;
            this.button9.Location = new System.Drawing.Point(1113, 530);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(339, 43);
            this.button9.TabIndex = 52;
            this.button9.Text = "Sauvegarder la recette";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.SauvegarderRecette_Click);
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
            // btnRetireMatiere
            // 
            this.btnRetireMatiere.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRetireMatiere.BackColor = System.Drawing.Color.LightCoral;
            this.btnRetireMatiere.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnRetireMatiere.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRetireMatiere.Location = new System.Drawing.Point(3, 218);
            this.btnRetireMatiere.Name = "btnRetireMatiere";
            this.btnRetireMatiere.Size = new System.Drawing.Size(336, 43);
            this.btnRetireMatiere.TabIndex = 53;
            this.btnRetireMatiere.Text = "Retiré une Matière";
            this.btnRetireMatiere.UseVisualStyleBackColor = false;
            this.btnRetireMatiere.Click += new System.EventHandler(this.retireMatiere_Click);
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel19.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel19.ColumnCount = 2;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.43732F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.56268F));
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel20, 0, 0);
            this.tableLayoutPanel19.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel19.Location = new System.Drawing.Point(74, 218);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 1;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(1373, 272);
            this.tableLayoutPanel19.TabIndex = 54;
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel20.ColumnCount = 1;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74184F));
            this.tableLayoutPanel20.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel20.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.btnRetireMatiere, 0, 2);
            this.tableLayoutPanel20.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 3;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(342, 264);
            this.tableLayoutPanel20.TabIndex = 55;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutOperation);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(353, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1016, 264);
            this.flowLayoutPanel1.TabIndex = 56;
            // 
            // flowLayoutOperation
            // 
            this.flowLayoutOperation.AutoScroll = true;
            this.flowLayoutOperation.Controls.Add(this.tableLayoutOperation);
            this.flowLayoutOperation.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutOperation.Name = "flowLayoutOperation";
            this.flowLayoutOperation.Size = new System.Drawing.Size(350, 258);
            this.flowLayoutOperation.TabIndex = 0;
            this.flowLayoutOperation.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutOperation_Paint);
            // 
            // tableLayoutOperation
            // 
            this.tableLayoutOperation.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutOperation.ColumnCount = 3;
            this.tableLayoutOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.59206F));
            this.tableLayoutOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.40794F));
            this.tableLayoutOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutOperation.Controls.Add(this.tableLayoutPanel7, 1, 1);
            this.tableLayoutOperation.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutOperation.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutOperation.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutOperation.Controls.Add(this.button4, 2, 1);
            this.tableLayoutOperation.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutOperation.Name = "tableLayoutOperation";
            this.tableLayoutOperation.RowCount = 3;
            this.tableLayoutOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.68966F));
            this.tableLayoutOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.31034F));
            this.tableLayoutOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutOperation.Size = new System.Drawing.Size(326, 255);
            this.tableLayoutOperation.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.Info;
            this.progressBar1.Location = new System.Drawing.Point(34, 797);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1134, 17);
            this.progressBar1.TabIndex = 55;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.14286F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel22, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel21, 1, 0);
            this.tableLayoutPanel1.Controls.Add(lblSymptome, 0, 0);
            this.tableLayoutPanel1.Controls.Add(lblEffetSec, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(969, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(474, 104);
            this.tableLayoutPanel1.TabIndex = 56;
            // 
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel22.ColumnCount = 1;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel22.Controls.Add(this.linkLabel3, 0, 0);
            this.tableLayoutPanel22.Controls.Add(this.lblEffetSecProd, 0, 1);
            this.tableLayoutPanel22.Location = new System.Drawing.Point(273, 55);
            this.tableLayoutPanel22.Name = "tableLayoutPanel22";
            this.tableLayoutPanel22.RowCount = 2;
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.6087F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.3913F));
            this.tableLayoutPanel22.Size = new System.Drawing.Size(198, 46);
            this.tableLayoutPanel22.TabIndex = 58;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel3.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel3.Location = new System.Drawing.Point(3, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(44, 13);
            this.linkLabel3.TabIndex = 51;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Modifier";
            // 
            // tableLayoutPanel21
            // 
            this.tableLayoutPanel21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel21.ColumnCount = 1;
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel21.Controls.Add(this.lblSymptProd, 0, 1);
            this.tableLayoutPanel21.Controls.Add(this.linkLabel4, 0, 0);
            this.tableLayoutPanel21.Location = new System.Drawing.Point(273, 3);
            this.tableLayoutPanel21.Name = "tableLayoutPanel21";
            this.tableLayoutPanel21.RowCount = 2;
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.6087F));
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.3913F));
            this.tableLayoutPanel21.Size = new System.Drawing.Size(198, 46);
            this.tableLayoutPanel21.TabIndex = 57;
            // 
            // RechercheProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1468, 837);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tableLayoutPanel19);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.inputCommentairePhase);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRetourMenu);
            this.Controls.Add(lblCommentPhase);
            this.Controls.Add(lblCheckList);
            this.Controls.Add(lblPhase);
            this.Controls.Add(lblEtapes);
            this.Controls.Add(lblNomenclat);
            this.Controls.Add(lblRecette);
            this.Controls.Add(this.lblVersionProduit);
            this.Controls.Add(this.lblNomProduit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "RechercheProduit";
            this.Text = "Recherche Produit";
            this.Load += new System.EventHandler(this.RechercheProduit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inputQuantiteMat)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.r_d_valenceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdvalenceDataSetBindingSource)).EndInit();
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel20.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutOperation.ResumeLayout(false);
            this.tableLayoutOperation.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel22.ResumeLayout(false);
            this.tableLayoutPanel22.PerformLayout();
            this.tableLayoutPanel21.ResumeLayout(false);
            this.tableLayoutPanel21.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRetourMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox inputCommentairePhase;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox inputOperation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.NumericUpDown inputQuantiteMat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.ComboBox inputMatiereImp;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblmin;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.Label lblNomProduit;
        private System.Windows.Forms.Label lblVersionProduit;
        private System.Windows.Forms.Label lblSymptProd;
        private System.Windows.Forms.Label lblEffetSecProd;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private r_d_valenceDataSet r_d_valenceDataSet;
        private System.Windows.Forms.BindingSource rdvalenceDataSetBindingSource;
        private System.Windows.Forms.Button btnRetireMatiere;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel22;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel21;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutOperation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutOperation;
    }
}