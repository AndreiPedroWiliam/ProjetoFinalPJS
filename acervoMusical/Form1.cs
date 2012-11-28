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

        
        public Principal()
        {
            InitializeComponent();
        }

        // Cria um Leitor, no qual percorrerá todas as linhas e colunas das tebelas do Banco
        SqlDataReader leitor = null;
        SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");
        List<string> OpcaoPesquisa = new List<string>();
        
        public void Principal_Load(object sender, EventArgs e)
        {
            comboBoxStatus.SelectedIndex = 0;
            try
            {
                conexao.Open();

                // Comando que retorna os campos para o carregamento do ListViewPesquisa
                SqlCommand cmdSelecao = new SqlCommand("SELECT Id_Album, Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status FROM Album;", conexao);
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
                    ListViewItem.ListViewSubItem Status = new ListViewItem.ListViewSubItem();
                    

                    Interprete.Text = leitor["Interprete"].ToString();

                    Autor.Text = leitor["Autor"].ToString();
                    Interprete.SubItems.Add(Autor);

                    Album.Text = leitor["Album"].ToString();
                    Interprete.SubItems.Add(Album);

                    Data.Text = leitor["Data"].ToString();
                    string data = Data.Text;
                    data = data.Remove(10);

                    Interprete.SubItems.Add(data);

                    Compra.Text = leitor["DataCompra"].ToString();
                    data = Compra.Text;
                    data = data.Remove(10); 

                    Interprete.SubItems.Add(data);

                    Origem.Text = leitor["OrigemCompra"].ToString();
                    Interprete.SubItems.Add(Origem);

                    Midia.Text = leitor["TipoMidia"].ToString();
                    Interprete.SubItems.Add(Midia);

                    Nota.Text = leitor["Nota"].ToString();
                    Interprete.SubItems.Add(Nota);

                    Observacao.Text = leitor["Observacao"].ToString();
                    Interprete.SubItems.Add(Observacao);

                    
                    Status.Text = leitor["Status"].ToString();
                    Interprete.SubItems.Add(Status);
                    
                    listViewPesquisa.Items.Add(Interprete);
                    

                    // Verifica se o filme está ou não disponível
                    if (Status.Text == "Emprestado")
                        listViewPesquisa.Items[i].ForeColor = Color.Gray;
                    i++;

                }

                CountTipoDeMidias(); // Metodo que carrega a quantidade de Midias (Digital, DVD, CD, K7 e Vinil)
                CountStatus(); // Metodo que carrega a quantidade de Albuns Emprestados e Disponíveis

                FechaLeitor(); // Metodo que Fecha o leitor

                // Comando que retorna a quantidade de Pessoas
                SqlCommand cmdCountPessoa = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Pessoa;", conexao);
                leitor = cmdCountPessoa.ExecuteReader();
                // Passa para o label a quantidade de Pessoas
                if (leitor.Read())
                    qtdePessoa.Text = leitor["QTD"].ToString();


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
            // Fecha o Leitor, se usado.
            if (leitor != null)
                leitor.Close();
        }

        public void CountTipoDeMidias()
        {
            FechaLeitor();
            // Comando que retorna a quantidade de mídias
            SqlCommand cmdCountMidias = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album;", conexao);
            leitor = cmdCountMidias.ExecuteReader();
            // Passa para o label a quantidade de mídias
            if (leitor.Read())
                qtdeMidia.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns do tipo Digital
            SqlCommand cmdCountDigital = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'Digital';", conexao);
            leitor = cmdCountDigital.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo Digital
            if (leitor.Read())
                qtdeDigital.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns do tipo DVD
            SqlCommand cmdCountDVD = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'DVD';", conexao);
            leitor = cmdCountDVD.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo DVD
            if (leitor.Read())
                qtdeDVD.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns do tipo CD
            SqlCommand cmdCountCD = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'CD';", conexao);
            leitor = cmdCountCD.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo CD
            if (leitor.Read())
                qtdeCD.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns do tipo K7
            SqlCommand cmdCountK7 = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'K7';", conexao);
            leitor = cmdCountK7.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo K7
            if (leitor.Read())
                qtdeK7.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns do tipo Vinil
            SqlCommand cmdCountVinil = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'Vinil';", conexao);
            leitor = cmdCountVinil.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo Vinil
            if (leitor.Read())
                qtdeVinil.Text = leitor["QTD"].ToString();
        }

        public void CountStatus()
        {
            FechaLeitor();
            // Comando que retorna a quantidade de Albuns Emprestados
            SqlCommand cmdCountAlbumEmprestado = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE Status = 'Emprestado';", conexao);
            leitor = cmdCountAlbumEmprestado.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo Vinil
            if (leitor.Read())
                qtdeEmprestado.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns Disponíveis
            SqlCommand cmdCountAlbumDisponivel = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE Status = 'Disponível' AND TipoMidia!= 'Digital';", conexao);
            leitor = cmdCountAlbumDisponivel.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo Vinil
            if (leitor.Read())
                qtdeDisponivel.Text = leitor["QTD"].ToString();
        }

        private void mídiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 cadastroMidia = new Form3();
            cadastroMidia.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem a = new ListViewItem();
            

        }

        private void emprestarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void amigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 cadPessoa = new Form4();
            cadPessoa.Show();
        }

        private void buttonEmprestar_Click(object sender, EventArgs e)
        {
            
            Form2 Emprestar = new Form2();
            Emprestar.ShowDialog();

        }

        private void midiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 cadastroPessoa = new Form4();
            cadastroPessoa.ShowDialog();
        }

        private void PesquisaRapida(object sender, EventArgs e)
        {
           
        }
		
        private void PesquisaDetalhada(object sender, EventArgs e)
        {

        }

    }
}
