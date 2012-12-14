using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

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
                // Verifica se a conexão está aberta e fecha se necessário
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();


                conexao.Open();
                // Executa o comando de listagem dos históricos da movimentação empréstimos
                SqlCommand cmdSelecao = new SqlCommand("SELECT Pessoa.Nome,Album.Interprete ,Album.Album, Emprestimo.DataEmprestimo, Emprestimo.DataDevolucao FROM Emprestimo INNER JOIN Pessoa ON Emprestimo.Id_Pessoa = Pessoa.Id_Pessoa INNER JOIN Album ON Emprestimo.Id_Album = Album.Id_Album", conexao);
                leitor = cmdSelecao.ExecuteReader();

                // Carrega os resultados no listview
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
                    
                    // a variavel dataEmprestimo vem com o formato do banco de dados (mês-dia-ano). 
                    // Aproveita-se somente do trecho que interessa (mês --- dia --- ano)
                    
                    string dia = dataEmprestimo.Remove(2);
                    string mes = dataEmprestimo.Substring(3, 2); 
                    string ano = dataEmprestimo.Substring(6, 4); 

                    DataEmprestimo.Text = dia+"/"+mes+"/"+ano;

                    Pessoa.SubItems.Add(DataEmprestimo);

                    string dataDevulocao = leitor["DataDevolucao"].ToString();

                    if (dataDevulocao == "")
                        DataDevolucao.Text = "- - / - - / - - - -";
                    else
                    {
                        dia = dataDevulocao.Remove(2); 
                        mes = dataDevulocao.Substring(3, 2);  
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

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            //Salva os arquivos gerados para relatorio 
            SaveFileDialog SFD = new SaveFileDialog();

            //Extensões possíveis de salvar o relatório
            SFD.Filter = "Texto|*.txt|Word|*.doc|planilha|*.ods|html|*.html|PDF|*.pdf|Todos os Arquivos|*.*";
            SFD.FilterIndex = 2;
            SFD.FileName = "Historico1";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(SFD.FileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(fs);
                writer.WriteLine("\tHistorico");
                writer.WriteLine();
                int i = 0;
                while (i < listViewHistorico.Items.Count)
                {
                    //salva os dados que estão no listview
                    writer.Write(listViewHistorico.Items[i].Text + " - ");
                    writer.Write(listViewHistorico.Items[i].SubItems[1].Text + " - ");
                    writer.Write(listViewHistorico.Items[i].SubItems[2].Text + " - ");
                    writer.Write(listViewHistorico.Items[i].SubItems[3].Text + " - ");
                    writer.Write(listViewHistorico.Items[i].SubItems[4].Text);
                    writer.WriteLine();
                    writer.WriteLine();
                    i++;
                }
                writer.Close();
                SFD.Dispose();
            }
        }
    }
}
