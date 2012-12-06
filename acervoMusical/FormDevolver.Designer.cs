namespace acervoMusical
{
    partial class FormDevolver
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
            this.listViewHistorico = new System.Windows.Forms.ListView();
            this.Pessoa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataEmprestimo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataDevolucao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewHistorico
            // 
            this.listViewHistorico.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Pessoa,
            this.Album,
            this.DataEmprestimo,
            this.DataDevolucao});
            this.listViewHistorico.GridLines = true;
            this.listViewHistorico.Location = new System.Drawing.Point(12, 12);
            this.listViewHistorico.Name = "listViewHistorico";
            this.listViewHistorico.Size = new System.Drawing.Size(699, 455);
            this.listViewHistorico.TabIndex = 0;
            this.listViewHistorico.UseCompatibleStateImageBehavior = false;
            this.listViewHistorico.View = System.Windows.Forms.View.Details;
            // 
            // Pessoa
            // 
            this.Pessoa.Text = "Pessoa";
            this.Pessoa.Width = 170;
            // 
            // Album
            // 
            this.Album.Text = "Album";
            this.Album.Width = 305;
            // 
            // DataEmprestimo
            // 
            this.DataEmprestimo.Text = "Data de emprestimo";
            this.DataEmprestimo.Width = 114;
            // 
            // DataDevolucao
            // 
            this.DataDevolucao.Text = "Data de devolução";
            this.DataDevolucao.Width = 105;
            // 
            // FormDevolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 479);
            this.Controls.Add(this.listViewHistorico);
            this.Name = "FormDevolver";
            this.Text = "Devolver";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewHistorico;
        private System.Windows.Forms.ColumnHeader Pessoa;
        private System.Windows.Forms.ColumnHeader Album;
        private System.Windows.Forms.ColumnHeader DataEmprestimo;
        private System.Windows.Forms.ColumnHeader DataDevolucao;
    }
}