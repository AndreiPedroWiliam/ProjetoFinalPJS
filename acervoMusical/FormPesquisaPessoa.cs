using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace acervoMusical
{
    public partial class FormPesquisaPessoa : Form
    {
        public FormPesquisaPessoa()
        {
            InitializeComponent();
        }

        private void FormPesquisaMidia_Load(object sender, EventArgs e)
        {
            atualiza();
        }

        public void atualiza()
        {

            SqlDataReader leitor = null;
            SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");


            try
            {
                // Verifica se a conexão está aberta
                if (conexao.State == ConnectionState.Open)
                {
                    // Fecha a conexão, limpa o leitor e limpa a lista, para o novo carregamento 
                    conexao.Close();
                    leitor = null;
                    listViewPesquisaPessoa.Items.Clear();
                }

                conexao.Open();

                // Comando que retorna os campos para o carregamento do ListViewPesquisa
                SqlCommand cmdSelecao = new SqlCommand("SELECT Id_Pessoa, Nome, Telefone, Email FROM Pessoa", conexao);
                leitor = cmdSelecao.ExecuteReader();
                listViewPesquisaPessoa.Items.Clear();

                while (leitor.Read())
                {
                    ListViewItem Id_Pessoa = new ListViewItem(leitor["Id_Pessoa"].ToString());

                    ListViewItem.ListViewSubItem Nome = new ListViewItem.ListViewSubItem();

                    ListViewItem.ListViewSubItem Telefone = new ListViewItem.ListViewSubItem();

                    ListViewItem.ListViewSubItem Email = new ListViewItem.ListViewSubItem();


                    Nome.Text = leitor["Nome"].ToString();
                    Id_Pessoa.SubItems.Add(Nome);

                    Telefone.Text = leitor["Telefone"].ToString();
                    Id_Pessoa.SubItems.Add(Telefone);

                    Email.Text = leitor["Email"].ToString();
                    Id_Pessoa.SubItems.Add(Email);

                    listViewPesquisaPessoa.Items.Add(Id_Pessoa);
                }


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro " + erro);
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 cadastroPessoa = new Form4();
            cadastroPessoa.ShowDialog();
        }
        public void AlterarPessoa(int alterar)
        {
            if (alterar == 0)
            {
               
                if (listViewPesquisaPessoa.SelectedItems.Count == 1)
                {
                    int idPessoa = int.Parse(listViewPesquisaPessoa.SelectedItems[0].Text);
                    AlteraPessoa alterarPessoa = new AlteraPessoa(idPessoa, 0);

                    alterarPessoa.ShowDialog();
                }
            }
        }
        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            AlterarPessoa(0);
        }

        public void mostaRegistros()
        {
            SqlDataReader leitor = null;
            SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");

            try
            {
                // Verifica se a conexão está aberta
                if (conexao.State == ConnectionState.Open)
                {
                    // Fecha a conexão, limpa o leitor e limpa a lista, para o novo carregamento 
                    conexao.Close();
                    leitor = null;
                    listViewPesquisaPessoa.Items.Clear();
                }

                conexao.Open();

                // Comando que retorna os campos para o carregamento do ListViewPesquisa
                SqlCommand cmdSelecao = new SqlCommand("SELECT Id_Pessoa, Nome, Telefone, Email FROM Pessoa WHERE LOWER(Nome) LIKE @NomeLower OR UPPER(Nome) LIKE @NomeUpper ", conexao);
                SqlParameter nomeLower = new SqlParameter("@NomeLower", "%" + textBoxNome.Text.ToLower() + "%");
                SqlParameter nomeUpper = new SqlParameter("@NomeUpper", "%" + textBoxNome.Text.ToUpper() + "%");
                cmdSelecao.Parameters.Add(nomeLower);
                cmdSelecao.Parameters.Add(nomeUpper);


                leitor = cmdSelecao.ExecuteReader();
                listViewPesquisaPessoa.Items.Clear();

                while (leitor.Read())
                {
                    ListViewItem Id_Pessoa = new ListViewItem(leitor["Id_Pessoa"].ToString());

                    ListViewItem.ListViewSubItem Nome = new ListViewItem.ListViewSubItem();

                    ListViewItem.ListViewSubItem Telefone = new ListViewItem.ListViewSubItem();

                    ListViewItem.ListViewSubItem Email = new ListViewItem.ListViewSubItem();


                    Nome.Text = leitor["Nome"].ToString();
                    Id_Pessoa.SubItems.Add(Nome);

                    Telefone.Text = leitor["Telefone"].ToString();
                    Id_Pessoa.SubItems.Add(Telefone);

                    Email.Text = leitor["Email"].ToString();
                    Id_Pessoa.SubItems.Add(Email);

                    listViewPesquisaPessoa.Items.Add(Id_Pessoa);
                }
            }


            catch (Exception erro)
            {
                MessageBox.Show("Erro " + erro);
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();
            }
        }
        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            //atualiza//
            mostaRegistros();
        }
        private void pesquisaPessoa_Click(object sender, EventArgs e)
        {
            //atualiza
            mostaRegistros();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {

            SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");
            conexao.Open();
            //deleta da tabela emprestimo e da tabela amigos
            SqlCommand cmdDeletePessoa1 = new SqlCommand("DELETE FROM Pessoa WHERE Id_Pessoa = '" + listViewPesquisaPessoa.SelectedItems[0].Text + "'", conexao);
            SqlCommand cmdDeletePessoa2 = new SqlCommand("DELETE FROM Emprestimo WHERE Id_Pessoa = '" + listViewPesquisaPessoa.SelectedItems[0].Text + "'", conexao);
            cmdDeletePessoa2.ExecuteNonQuery();
            cmdDeletePessoa1.ExecuteNonQuery();
            //atualiza
            mostaRegistros();
            conexao.Close();
        }

        private void FormPesquisaPessoa_Activated(object sender, EventArgs e)
        {
            atualiza();
        }
    }
}
