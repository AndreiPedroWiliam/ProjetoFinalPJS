namespace acervoMusical
{
    partial class FormPesquisaMidia
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAdicionarPessoa = new System.Windows.Forms.Button();
            this.buttonAlterarPessoa = new System.Windows.Forms.Button();
            this.buttonExcluirPessoa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(12, 47);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(995, 368);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nome:";
            this.columnHeader1.Width = 193;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Telefone:";
            this.columnHeader2.Width = 89;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "E-mail:";
            this.columnHeader3.Width = 136;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Logradouro:";
            this.columnHeader4.Width = 174;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Número:";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Bairro:";
            this.columnHeader6.Width = 153;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Cidade:";
            this.columnHeader7.Width = 144;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "UF:";
            this.columnHeader8.Width = 40;
            // 
            // buttonAdicionarPessoa
            // 
            this.buttonAdicionarPessoa.Location = new System.Drawing.Point(1013, 45);
            this.buttonAdicionarPessoa.Name = "buttonAdicionarPessoa";
            this.buttonAdicionarPessoa.Size = new System.Drawing.Size(133, 23);
            this.buttonAdicionarPessoa.TabIndex = 1;
            this.buttonAdicionarPessoa.Text = "Adicionar";
            this.buttonAdicionarPessoa.UseVisualStyleBackColor = true;
            // 
            // buttonAlterarPessoa
            // 
            this.buttonAlterarPessoa.Location = new System.Drawing.Point(1013, 75);
            this.buttonAlterarPessoa.Name = "buttonAlterarPessoa";
            this.buttonAlterarPessoa.Size = new System.Drawing.Size(133, 23);
            this.buttonAlterarPessoa.TabIndex = 2;
            this.buttonAlterarPessoa.Text = "Alterar";
            this.buttonAlterarPessoa.UseVisualStyleBackColor = true;
            // 
            // buttonExcluirPessoa
            // 
            this.buttonExcluirPessoa.Location = new System.Drawing.Point(1013, 105);
            this.buttonExcluirPessoa.Name = "buttonExcluirPessoa";
            this.buttonExcluirPessoa.Size = new System.Drawing.Size(133, 23);
            this.buttonExcluirPessoa.TabIndex = 3;
            this.buttonExcluirPessoa.Text = "Excluir";
            this.buttonExcluirPessoa.UseVisualStyleBackColor = true;
            // 
            // FormPesquisaMidia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 431);
            this.Controls.Add(this.buttonExcluirPessoa);
            this.Controls.Add(this.buttonAlterarPessoa);
            this.Controls.Add(this.buttonAdicionarPessoa);
            this.Controls.Add(this.listView1);
            this.Name = "FormPesquisaMidia";
            this.Text = "FormPesquisaMidia";
            this.Load += new System.EventHandler(this.FormPesquisaMidia_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button buttonAdicionarPessoa;
        private System.Windows.Forms.Button buttonAlterarPessoa;
        private System.Windows.Forms.Button buttonExcluirPessoa;


    }
}