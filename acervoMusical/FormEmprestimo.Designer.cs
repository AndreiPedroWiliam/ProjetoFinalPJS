﻿namespace acervoMusical
{
    partial class FormEmprestimo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmprestimo));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEmprestar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.nomepessoa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.interprete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.midia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.pesquisaPessoa = new System.Windows.Forms.PictureBox();
            this.pesquisaAlbum = new System.Windows.Forms.PictureBox();
            this.labelMensagem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pesquisaPessoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pesquisaAlbum)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(285, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 52);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(307, 199);
            this.listBox1.TabIndex = 1;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(328, 52);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(316, 199);
            this.listBox2.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Álbum:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Pessoas:";
            // 
            // buttonEmprestar
            // 
            this.buttonEmprestar.Location = new System.Drawing.Point(569, 340);
            this.buttonEmprestar.Name = "buttonEmprestar";
            this.buttonEmprestar.Size = new System.Drawing.Size(75, 23);
            this.buttonEmprestar.TabIndex = 3;
            this.buttonEmprestar.Text = "Emprestar";
            this.buttonEmprestar.UseVisualStyleBackColor = true;
            this.buttonEmprestar.Visible = false;
            this.buttonEmprestar.Click += new System.EventHandler(this.buttonEmprestar_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(328, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(285, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nomepessoa,
            this.album,
            this.interprete,
            this.midia});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 286);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(632, 37);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // nomepessoa
            // 
            this.nomepessoa.Text = "Pessoa";
            this.nomepessoa.Width = 193;
            // 
            // album
            // 
            this.album.Text = "Álbum";
            this.album.Width = 178;
            // 
            // interprete
            // 
            this.interprete.Text = "Intérprete";
            this.interprete.Width = 166;
            // 
            // midia
            // 
            this.midia.Text = "Mídia";
            this.midia.Width = 91;
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(569, 257);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(75, 23);
            this.buttonAdicionar.TabIndex = 2;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(12, 340);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 4;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Visible = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // pesquisaPessoa
            // 
            this.pesquisaPessoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pesquisaPessoa.Image = ((System.Drawing.Image)(resources.GetObject("pesquisaPessoa.Image")));
            this.pesquisaPessoa.Location = new System.Drawing.Point(306, 26);
            this.pesquisaPessoa.Name = "pesquisaPessoa";
            this.pesquisaPessoa.Size = new System.Drawing.Size(16, 16);
            this.pesquisaPessoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pesquisaPessoa.TabIndex = 16;
            this.pesquisaPessoa.TabStop = false;
            // 
            // pesquisaAlbum
            // 
            this.pesquisaAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pesquisaAlbum.Image = ((System.Drawing.Image)(resources.GetObject("pesquisaAlbum.Image")));
            this.pesquisaAlbum.Location = new System.Drawing.Point(619, 26);
            this.pesquisaAlbum.Name = "pesquisaAlbum";
            this.pesquisaAlbum.Size = new System.Drawing.Size(16, 16);
            this.pesquisaAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pesquisaAlbum.TabIndex = 16;
            this.pesquisaAlbum.TabStop = false;
            // 
            // labelMensagem
            // 
            this.labelMensagem.AutoSize = true;
            this.labelMensagem.Location = new System.Drawing.Point(12, 254);
            this.labelMensagem.Name = "labelMensagem";
            this.labelMensagem.Size = new System.Drawing.Size(171, 13);
            this.labelMensagem.TabIndex = 17;
            this.labelMensagem.Text = "Selecione uma pessoa e um álbum";
            // 
            // FormEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 375);
            this.Controls.Add(this.labelMensagem);
            this.Controls.Add(this.pesquisaAlbum);
            this.Controls.Add(this.pesquisaPessoa);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonEmprestar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormEmprestimo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empréstimo de Mídias";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pesquisaPessoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pesquisaAlbum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button buttonEmprestar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.ColumnHeader nomepessoa;
        private System.Windows.Forms.ColumnHeader interprete;
        private System.Windows.Forms.ColumnHeader album;
        private System.Windows.Forms.ColumnHeader midia;
        private System.Windows.Forms.PictureBox pesquisaPessoa;
        private System.Windows.Forms.PictureBox pesquisaAlbum;
        private System.Windows.Forms.Label labelMensagem;
    }
}