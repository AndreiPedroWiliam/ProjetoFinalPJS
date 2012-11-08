namespace acervoMusical
{
    partial class Form3
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
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePickerCompra = new System.Windows.Forms.DateTimePicker();
            this.comboBoxNota = new System.Windows.Forms.ComboBox();
            this.dateTimePickerAlbum = new System.Windows.Forms.DateTimePicker();
            this.comboBoxMidia = new System.Windows.Forms.ComboBox();
            this.textBoxCompra = new System.Windows.Forms.TextBox();
            this.textBoxAlbum = new System.Windows.Forms.TextBox();
            this.textBoxAutor = new System.Windows.Forms.TextBox();
            this.textBoxInterprete = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxObservacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMusica = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(160, 214);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 13);
            this.label21.TabIndex = 44;
            this.label21.Text = "Nota:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(33, 216);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 13);
            this.label20.TabIndex = 43;
            this.label20.Text = "Mídia:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(324, 151);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 13);
            this.label19.TabIndex = 42;
            this.label19.Text = "Compra do álbum:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(327, 93);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Data do álbum:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(33, 151);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Origem da compra:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 93);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 39;
            this.label16.Text = "Álbum:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(324, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Autor:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Intérprete:";
            // 
            // dateTimePickerCompra
            // 
            this.dateTimePickerCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCompra.Location = new System.Drawing.Point(327, 166);
            this.dateTimePickerCompra.Name = "dateTimePickerCompra";
            this.dateTimePickerCompra.Size = new System.Drawing.Size(112, 20);
            this.dateTimePickerCompra.TabIndex = 35;
            // 
            // comboBoxNota
            // 
            this.comboBoxNota.FormattingEnabled = true;
            this.comboBoxNota.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxNota.Location = new System.Drawing.Point(163, 231);
            this.comboBoxNota.Name = "comboBoxNota";
            this.comboBoxNota.Size = new System.Drawing.Size(63, 21);
            this.comboBoxNota.TabIndex = 33;
            // 
            // dateTimePickerAlbum
            // 
            this.dateTimePickerAlbum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerAlbum.Location = new System.Drawing.Point(327, 109);
            this.dateTimePickerAlbum.Name = "dateTimePickerAlbum";
            this.dateTimePickerAlbum.Size = new System.Drawing.Size(112, 20);
            this.dateTimePickerAlbum.TabIndex = 34;
            // 
            // comboBoxMidia
            // 
            this.comboBoxMidia.FormattingEnabled = true;
            this.comboBoxMidia.Items.AddRange(new object[] {
            "digital",
            "DVD",
            "CD",
            "K7",
            "Vinil"});
            this.comboBoxMidia.Location = new System.Drawing.Point(36, 231);
            this.comboBoxMidia.Name = "comboBoxMidia";
            this.comboBoxMidia.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMidia.TabIndex = 32;
            this.comboBoxMidia.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // textBoxCompra
            // 
            this.textBoxCompra.Location = new System.Drawing.Point(36, 168);
            this.textBoxCompra.Name = "textBoxCompra";
            this.textBoxCompra.Size = new System.Drawing.Size(251, 20);
            this.textBoxCompra.TabIndex = 31;
            // 
            // textBoxAlbum
            // 
            this.textBoxAlbum.Location = new System.Drawing.Point(36, 109);
            this.textBoxAlbum.Name = "textBoxAlbum";
            this.textBoxAlbum.Size = new System.Drawing.Size(251, 20);
            this.textBoxAlbum.TabIndex = 30;
            // 
            // textBoxAutor
            // 
            this.textBoxAutor.Location = new System.Drawing.Point(327, 61);
            this.textBoxAutor.Name = "textBoxAutor";
            this.textBoxAutor.Size = new System.Drawing.Size(251, 20);
            this.textBoxAutor.TabIndex = 29;
            // 
            // textBoxInterprete
            // 
            this.textBoxInterprete.Location = new System.Drawing.Point(36, 62);
            this.textBoxInterprete.Name = "textBoxInterprete";
            this.textBoxInterprete.Size = new System.Drawing.Size(251, 20);
            this.textBoxInterprete.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Observações:";
            // 
            // textBoxObservacao
            // 
            this.textBoxObservacao.Location = new System.Drawing.Point(327, 231);
            this.textBoxObservacao.Multiline = true;
            this.textBoxObservacao.Name = "textBoxObservacao";
            this.textBoxObservacao.Size = new System.Drawing.Size(251, 94);
            this.textBoxObservacao.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Nome da música:";
            this.label2.Visible = false;
            // 
            // textBoxMusica
            // 
            this.textBoxMusica.Location = new System.Drawing.Point(36, 288);
            this.textBoxMusica.Name = "textBoxMusica";
            this.textBoxMusica.Size = new System.Drawing.Size(251, 20);
            this.textBoxMusica.TabIndex = 47;
            this.textBoxMusica.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(503, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Adicionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 397);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMusica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxObservacao);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dateTimePickerCompra);
            this.Controls.Add(this.comboBoxNota);
            this.Controls.Add(this.dateTimePickerAlbum);
            this.Controls.Add(this.comboBoxMidia);
            this.Controls.Add(this.textBoxCompra);
            this.Controls.Add(this.textBoxAlbum);
            this.Controls.Add(this.textBoxAutor);
            this.Controls.Add(this.textBoxInterprete);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de mídias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePickerCompra;
        private System.Windows.Forms.ComboBox comboBoxNota;
        private System.Windows.Forms.DateTimePicker dateTimePickerAlbum;
        private System.Windows.Forms.ComboBox comboBoxMidia;
        private System.Windows.Forms.TextBox textBoxCompra;
        private System.Windows.Forms.TextBox textBoxAlbum;
        private System.Windows.Forms.TextBox textBoxAutor;
        private System.Windows.Forms.TextBox textBoxInterprete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxObservacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMusica;
        private System.Windows.Forms.Button button1;

    }
}