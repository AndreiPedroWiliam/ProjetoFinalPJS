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

        // Cria um Leitor, no qual percorrerá todas as linhas e colunas das tebelas do Banco
        SqlDataReader leitor = null;
        SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");

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
                    data = data.Remove(10); // Remove a Hora da data, assim deixando dd/mm/YY

                    Interprete.SubItems.Add(data);

                    Compra.Text = leitor["Data Compra"].ToString();
                    data = Compra.Text;
                    data = data.Remove(10); // Remove a Hora da data, assim deixando dd/mm/YY

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

                    // Verifica se o filme está ou não disponível
                    // Caso estaja "status" = 1, caso contrario "status" = 2
                    if (status == "1")
                    {
                        // Como o status = 1, ou seja disponível, coloca a cor da fonte com Verde
                        listViewPesquisa.Items[i].ForeColor = Color.Green;
                    }
                    else
                    {
                        // Como o status = 2, ou seja disponível, coloca a cor da fonte com Vermelho
                        listViewPesquisa.Items[i].ForeColor = Color.Red;
                    }
                    i++;

                }

                CountTipoDeMidias(); // Metodo que carrega a quantidad de Midia, Albuns que tem como tipo de midia: Digital, DVD, CD, K7 e Vinil
                CountLocacao(); // Metodo que carrega a quantidade de Albuns Emprestados e Disponíveis

                FechaLeitor(); // Metodo que Fecha o leitor

                // Comando que retorna a quantidade de Pessoas
                SqlCommand cmdCountPessoas = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Pessoas;", conexao);
                leitor = cmdCountPessoas.ExecuteReader();
                // Passa para o label a quantidade de Pessoas
                if (leitor.Read())
                    qtdePessoas.Text = leitor["QTD"].ToString();


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
            // Fecha a Leitor, caso se ele foi usado
            if (leitor != null)
                leitor.Close();
        }

        public void CountTipoDeMidias()
        {
            FechaLeitor();
            // Comando que retorna a quantidade de mídias
            SqlCommand cmdCountMidias = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album INNER JOIN Tipo_Midia ON Album.Id_Tipo_Midia = Tipo_Midia.Id_Tipo_Midia;", conexao);
            leitor = cmdCountMidias.ExecuteReader();
            // Passa para o label a quantidade de mídias
            if (leitor.Read())
                qtdeMidia.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns do tipo Digital
            SqlCommand cmdCountDigital = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album INNER JOIN Tipo_Midia ON Album.Id_Tipo_Midia = Tipo_Midia.Id_Tipo_Midia WHERE Tipo_Midia.Descricao = 'Digital';", conexao);
            leitor = cmdCountDigital.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo Digital
            if (leitor.Read())
                qtdeDigital.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns do tipo DVD
            SqlCommand cmdCountDVD = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album INNER JOIN Tipo_Midia ON Album.Id_Tipo_Midia = Tipo_Midia.Id_Tipo_Midia WHERE Tipo_Midia.Descricao = 'DVD';", conexao);
            leitor = cmdCountDVD.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo DVD
            if (leitor.Read())
                qtdeDVD.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns do tipo CD
            SqlCommand cmdCountCD = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album INNER JOIN Tipo_Midia ON Album.Id_Tipo_Midia = Tipo_Midia.Id_Tipo_Midia WHERE Tipo_Midia.Descricao = 'CD';", conexao);
            leitor = cmdCountCD.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo CD
            if (leitor.Read())
                qtdeCD.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns do tipo K7
            SqlCommand cmdCountK7 = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album INNER JOIN Tipo_Midia ON Album.Id_Tipo_Midia = Tipo_Midia.Id_Tipo_Midia WHERE Tipo_Midia.Descricao = 'K7';", conexao);
            leitor = cmdCountK7.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo K7
            if (leitor.Read())
                qtdeK7.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns do tipo Vinil
            SqlCommand cmdCountVinil = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album INNER JOIN Tipo_Midia ON Album.Id_Tipo_Midia = Tipo_Midia.Id_Tipo_Midia WHERE Tipo_Midia.Descricao = 'Vinil';", conexao);
            leitor = cmdCountVinil.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo Vinil
            if (leitor.Read())
                qtdeVinil.Text = leitor["QTD"].ToString();
        }

        public void CountLocacao()
        {
            FechaLeitor();
            // Comando que retorna a quantidade de Albuns Emprestados
            SqlCommand cmdCountAlbumEmprestado = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album INNER JOIN Status ON Album.Id_Status = Status.Id_Status WHERE Status.Id_Status = 2;", conexao);
            leitor = cmdCountAlbumEmprestado.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo Vinil
            if (leitor.Read())
                qtdeEmprestado.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns Disponíveis
            SqlCommand cmdCountAlbumDisponivel = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album INNER JOIN Status ON Album.Id_Status = Status.Id_Status WHERE Status.Id_Status = 1;", conexao);
            leitor = cmdCountAlbumDisponivel.ExecuteReader();
            // Passa para o label a quantidade de Albuns do tipo Vinil
            if (leitor.Read())
                qtdeDisponivel.Text = leitor["QTD"].ToString();
        }

        private void mídiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        }

    }
}
