namespace acervoMusical
{
    partial class FormHistorico
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
            this.DataEmprestimo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewHistorico = new System.Windows.Forms.ListView();
            this.Pessoa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Interprete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataDevolucao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DataEmprestimo
            // 
            this.DataEmprestimo.Text = "Data de emprestimo";
            this.DataEmprestimo.Width = 114;
            // 
            // listViewHistorico
            // 
            this.listViewHistorico.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Pessoa,
            this.Interprete,
            this.Album,
            this.DataEmprestimo,
            this.DataDevolucao});
            this.listViewHistorico.FullRowSelect = true;
            this.listViewHistorico.GridLines = true;
            this.listViewHistorico.Location = new System.Drawing.Point(13, 12);
            this.listViewHistorico.Name = "listViewHistorico";
            this.listViewHistorico.Size = new System.Drawing.Size(841, 467);
            this.listViewHistorico.TabIndex = 1;
            this.listViewHistorico.UseCompatibleStateImageBehavior = false;
            this.listViewHistorico.View = System.Windows.Forms.View.Details;
            // 
            // Pessoa
            // 
            this.Pessoa.Text = "Pessoa";
            this.Pessoa.Width = 170;
            // 
            // Interprete
            // 
            this.Interprete.Text = "Interprete";
            this.Interprete.Width = 134;
            // 
            // Album
            // 
            this.Album.Text = "Album";
            this.Album.Width = 305;
            // 
            // DataDevolucao
            // 
            this.DataDevolucao.Text = "Data de devolução";
            this.DataDevolucao.Width = 114;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(754, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Salvar em arquivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 518);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewHistorico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historico";
            this.Load += new System.EventHandler(this.FormHistorico_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader DataEmprestimo;
        private System.Windows.Forms.ListView listViewHistorico;
        private System.Windows.Forms.ColumnHeader Pessoa;
        private System.Windows.Forms.ColumnHeader Album;
        private System.Windows.Forms.ColumnHeader DataDevolucao;
        private System.Windows.Forms.ColumnHeader Interprete;
        private System.Windows.Forms.Button button1;
    }
}