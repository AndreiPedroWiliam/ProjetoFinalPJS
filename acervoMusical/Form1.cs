using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace acervoMusical
{
    public partial class Principal : Form
    {
        // Cria um leitor cujo qual percorrerá todas as linhas e colunas das tabelas do banco
        SqlDataReader leitor = null;
        SqlConnection conexao = new SqlConnection("Data Source=PC16LAB3\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");

        public Principal()
        {
            InitializeComponent();
        }

        public void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();

                // Comando que retorna os campos para o carregamento do ListViewPesquisa
                SqlCommand cmdSelecao = new SqlCommand(" SELECT Interprete.Nome AS 'Interprete', Autor.Nome AS 'Autor', Album.Nome AS 'Album', Album.Data, Compra.Data AS 'Data Compra', Compra.Origem, Tipo_Midia.Descricao AS 'Midia', Album.Nota, Album.Observacao, Album.Id_Status AS 'Status' FROM Album INNER JOIN Compra ON Album.Id_Compra = Compra.Id_Compra INNER JOIN Tipo_Midia ON Album.Id_Tipo_Midia = Tipo_Midia.Id_Tipo_Midia INNER JOIN Autor ON Album.Id_Autor = Autor.Id_Autor INNER JOIN Interprete ON Album.Id_Interprete = Interprete.Id_Interprete;", conexao);
                leitor = cmdSelecao.ExecuteReader();

                int i = 0;

                while (leitor.Read())
                {
                    ListViewItem Interprete = new ListViewItem();
                    ListViewItem.ListViewSubItem Autor = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem Album = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem Data = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem Compra = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem Origem = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem Midia = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem Nota = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem Observacao = new ListViewItem.ListViewSubItem();

                    Interprete.Text = leitor["Interprete"].ToString();

                    Autor.Text = leitor["Autor"].ToString();
                    Interprete.SubItems.Add(Autor);

                    Album.Text = leitor["Album"].ToString();
                    Interprete.SubItems.Add(Album);

                    Data.Text = leitor["Data"].ToString();
                    string data = Data.Text;
                    data = data.Remove(10); 

                    Interprete.SubItems.Add(data);

                    Compra.Text = leitor["Data Compra"].ToString();
                    data = Compra.Text;
                    data = data.Remove(10);

                    Interprete.SubItems.Add(data);

                    Origem.Text = leitor["Origem"].ToString();
                    Interprete.SubItems.Add(Origem);

                    Midia.Text = leitor["Midia"].ToString();
                    Interprete.SubItems.Add(Midia);

                    Nota.Text = leitor["Nota"].ToString();
                    Interprete.SubItems.Add(Nota);

                    Observacao.Text = leitor["Observacao"].ToString();
                    Interprete.SubItems.Add(Observacao);
                    listViewPesquisa.Items.Add(Interprete);

                    string status = leitor["Status"].ToString();

                    // Verifica se o filme está disponível (status = 1) ou emprestado (status = 2)
                    if (status == "1")
                    {
                        listViewPesquisa.Items[i].ForeColor = Color.Green;
                    }
                    else
                    {
                        listViewPesquisa.Items[i].ForeColor = Color.Red;
                    }
                    i++;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro " + erro);
            }
            finally
            {
                FechaLeitor();
            }
        }

        public void FechaLeitor()
        {
            // Fecha o leitor caso utilizado
            if (leitor != null)
                leitor.Close();
        }

        private void mídiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
        }

        private void emprestarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emprestimo a = new Emprestimo();
            a.Show();
        }

        private void amigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            a.Show();
        }

        private void buttonEmprestar_Click(object sender, EventArgs e)
        {
            ListViewItem a = new ListViewItem();
        }
    }
}
