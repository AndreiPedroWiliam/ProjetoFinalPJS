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
    public partial class FormHistorico : Form
    {
        public FormHistorico()
        {
            InitializeComponent();
        }
        SqlDataReader leitor = null;
        SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");

        private void FormHistorico_Load(object sender, EventArgs e)
        {
            try
            {
                // Verifica se a conexão está aberta, caso esteja fecha-a
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();


                conexao.Open();
                // Executa o comado de listagem dos historicos da movimentação (emprestimos)
                SqlCommand cmdSelecao = new SqlCommand("SELECT Pessoa.Nome,Album.Interprete ,Album.Album, Emprestimo.DataEmprestimo, Emprestimo.DataDevolucao FROM Emprestimo INNER JOIN Pessoa ON Emprestimo.Id_Pessoa = Pessoa.Id_Pessoa INNER JOIN Album ON Emprestimo.Id_Album = Album.Id_Album", conexao);
                leitor = cmdSelecao.ExecuteReader();

                // Carrega os resltados no listview
                while (leitor.Read())
                {
                    ListViewItem Pessoa = new ListViewItem();
                    ListViewItem.ListViewSubItem Interprete = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem Album = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem DataEmprestimo = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem DataDevolucao = new ListViewItem.ListViewSubItem();

                    Pessoa.Text = leitor["Nome"].ToString();
                    
                    Interprete.Text = leitor["Interprete"].ToString();
                    Pessoa.SubItems.Add(Interprete);
                    
                    Album.Text = leitor["Album"].ToString();
                    Pessoa.SubItems.Add(Album);

                    string dataEmprestimo = leitor["DataEmprestimo"].ToString();
                    
                    // a variavel daraEmpretimo vem com o formato do banco de dados
                    // que é: mês-dia-ano
                    // separando a data para dia-mês-ano
                    string mes = dataEmprestimo.Remove(2); // pega só o mês, removendo apartir do 2º caracter
                    string dia = dataEmprestimo.Substring(3, 2); // pega o dia, que está apartir do 3º caracter, pegando 2 digitos 
                    string ano = dataEmprestimo.Substring(6, 4); // pega o ano, que está apartir do 6º caracter, pegando 4 digitos

                    DataEmprestimo.Text = dia+"/"+mes+"/"+ano;

                    Pessoa.SubItems.Add(DataEmprestimo);

                    string dataDevulocao = leitor["DataDevolucao"].ToString();

                    if (dataDevulocao == "")
                        DataDevolucao.Text = "- - / - - / - - - -";
                    else
                    {
                        mes = dataDevulocao.Remove(2); 
                        dia = dataDevulocao.Substring(3, 2);  
                        ano = dataDevulocao.Substring(6, 4); 
                        DataDevolucao.Text = dia + "/" + mes + "/" + ano;
                        
                    }
                    Pessoa.SubItems.Add(DataDevolucao);
                    listViewHistorico.Items.Add(Pessoa);

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro " + erro);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
