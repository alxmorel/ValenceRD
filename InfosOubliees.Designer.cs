namespace ValenceRD
{
    partial class InfosOubliees
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label1;
            this.inputAdresse = new System.Windows.Forms.TextBox();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            label4.Location = new System.Drawing.Point(12, 9);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(785, 34);
            label4.TabIndex = 8;
            label4.Text = "Retrouvez votre compte";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            label1.Location = new System.Drawing.Point(0, 88);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(797, 48);
            label1.TabIndex = 9;
            label1.Text = "Veuillez saisir votre adresse e-mail pour rechercher votre compte.";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // inputAdresse
            // 
            this.inputAdresse.ForeColor = System.Drawing.SystemColors.GrayText;
            this.inputAdresse.Location = new System.Drawing.Point(143, 129);
            this.inputAdresse.Name = "inputAdresse";
            this.inputAdresse.Size = new System.Drawing.Size(315, 20);
            this.inputAdresse.TabIndex = 10;
            this.inputAdresse.Text = "Adresse e-mail";
            this.inputAdresse.Enter += new System.EventHandler(this.inputAdresse_Enter);
            this.inputAdresse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.press_Enter);
            this.inputAdresse.Leave += new System.EventHandler(this.inputAdresse_Leave);
            // 
            // btnRechercher
            // 
            this.btnRechercher.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRechercher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechercher.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRechercher.Location = new System.Drawing.Point(533, 222);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(144, 35);
            this.btnRechercher.TabIndex = 11;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = false;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(683, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 35);
            this.button1.TabIndex = 12;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InfosOubliees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 259);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.inputAdresse);
            this.Controls.Add(label1);
            this.Controls.Add(label4);
            this.Name = "InfosOubliees";
            this.Text = "InfosOubliees";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputAdresse;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.Button button1;
    }
}