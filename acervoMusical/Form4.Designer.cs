namespace acervoMusical
{
    partial class Form4
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
            this.textBoxNomeCad = new System.Windows.Forms.TextBox();
            this.textBoxLogradouroCad = new System.Windows.Forms.TextBox();
            this.maskedTextBoxTelefoneCad = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCidadeCad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBairroCad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNumeoCad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxEmailCad = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNomeCad
            // 
            this.textBoxNomeCad.Location = new System.Drawing.Point(12, 28);
            this.textBoxNomeCad.Name = "textBoxNomeCad";
            this.textBoxNomeCad.Size = new System.Drawing.Size(283, 20);
            this.textBoxNomeCad.TabIndex = 0;
            // 
            // textBoxLogradouroCad
            // 
            this.textBoxLogradouroCad.Location = new System.Drawing.Point(9, 32);
            this.textBoxLogradouroCad.Name = "textBoxLogradouroCad";
            this.textBoxLogradouroCad.Size = new System.Drawing.Size(358, 20);
            this.textBoxLogradouroCad.TabIndex = 1;
            // 
            // maskedTextBoxTelefoneCad
            // 
            this.maskedTextBoxTelefoneCad.Location = new System.Drawing.Point(301, 28);
            this.maskedTextBoxTelefoneCad.Mask = "(00)0000-0000";
            this.maskedTextBoxTelefoneCad.Name = "maskedTextBoxTelefoneCad";
            this.maskedTextBoxTelefoneCad.Size = new System.Drawing.Size(81, 20);
            this.maskedTextBoxTelefoneCad.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Telefone:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Logradouro:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxCidadeCad);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxBairroCad);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxNumeoCad);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxLogradouroCad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 132);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Endereço";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(373, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(47, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(373, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "UF:";
            // 
            // textBoxCidadeCad
            // 
            this.textBoxCidadeCad.Location = new System.Drawing.Point(221, 74);
            this.textBoxCidadeCad.Name = "textBoxCidadeCad";
            this.textBoxCidadeCad.Size = new System.Drawing.Size(146, 20);
            this.textBoxCidadeCad.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cidade:";
            // 
            // textBoxBairroCad
            // 
            this.textBoxBairroCad.Location = new System.Drawing.Point(6, 74);
            this.textBoxBairroCad.Name = "textBoxBairroCad";
            this.textBoxBairroCad.Size = new System.Drawing.Size(209, 20);
            this.textBoxBairroCad.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Bairro:";
            // 
            // textBoxNumeoCad
            // 
            this.textBoxNumeoCad.Location = new System.Drawing.Point(373, 32);
            this.textBoxNumeoCad.Name = "textBoxNumeoCad";
            this.textBoxNumeoCad.Size = new System.Drawing.Size(47, 20);
            this.textBoxNumeoCad.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nº";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "E - mail:";
            // 
            // textBoxEmailCad
            // 
            this.textBoxEmailCad.Location = new System.Drawing.Point(388, 28);
            this.textBoxEmailCad.Name = "textBoxEmailCad";
            this.textBoxEmailCad.Size = new System.Drawing.Size(148, 20);
            this.textBoxEmailCad.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(483, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Adicionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 263);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxEmailCad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBoxTelefoneCad);
            this.Controls.Add(this.textBoxNomeCad);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de pessoas";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNomeCad;
        private System.Windows.Forms.TextBox textBoxLogradouroCad;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefoneCad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCidadeCad;
        private System.Windows.Forms.TextBox textBoxEmailCad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBairroCad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNumeoCad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
    }
}