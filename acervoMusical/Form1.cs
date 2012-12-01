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
        int ultimoIndice = 0;
        
        public void Principal_Load(object sender, EventArgs e)
        {
            comboBoxStatus.SelectedIndex = 0;
            comboBoxMidia.SelectedIndex = 0;
            CarregarListview();

          
        }
        public void CarregarListview()
        {
           try
            {
                // Verifica se a conexão está aberta
                if (conexao.State == ConnectionState.Open)
                {
                    // Fecha a conexão, limpa o leitor e limpa a lista, para o novo carregamento 
                    conexao.Close();
                    leitor = null;
                    listViewPesquisa.Items.Clear();
                }

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

        private bool Validacao()
        {
            // Limpa a lista para uma nova pesquisa
            OpcaoPesquisa.Clear();
            int erro = 0;

            if (checkBoxInterprete.Checked == true)
            {
                if (textBoxInterprete.Text.Trim() != "")
                    OpcaoPesquisa.Add("Interprete");
                else
                    erro++;
            }
            else
                textBoxInterprete.Text = "";

            if (checkBoxAutor.Checked == true)
            {
                if (textBoxAutor.Text.Trim() != "")
                    OpcaoPesquisa.Add("Autor");
                else
                    erro++;
            }
            else
                textBoxAutor.Text = "";

            if (checkBoxAlbum.Checked == true)
            {
                if (textBoxAlbum.Text.Trim() != "")
                    OpcaoPesquisa.Add("Album");
                else
                    erro++;
            }
            else
                textBoxAlbum.Text = "";

            if (checkBoxMidia.Checked == true)
            {
                if (comboBoxMidia.Text.Trim() != "")
                    OpcaoPesquisa.Add("Midia");
                else
                    erro++;
            }
            else
                comboBoxMidia.SelectedIndex = 0;



            if (checkBoxStatus.Checked == true)
            {
                if (comboBoxStatus.Text.Trim() != "")
                    OpcaoPesquisa.Add("Status");
                else
                    erro++;
            }
            else
                comboBoxStatus.SelectedIndex = 0;

            // Caso não houver nenhum erro no preenchimento do campo para pesquisa,
            // retorna true, caso contrario false
            if (erro == 0)
                return true;
            else
                return false;
        }
        private void Pesquisa(object sender, EventArgs e)
        {
            // Limpa o fundo das pesquisas efetuadas
            foreach (ListViewItem item in listViewPesquisa.Items)
                item.BackColor = Color.Empty;

            if (listViewPesquisa.Items.Count > 0)
                listViewPesquisa.TopItem = listViewPesquisa.Items[0];
            else
                listViewPesquisa.TopItem = null;

            bool validacao = Validacao();

            if (validacao == true)
            {
                if (OpcaoPesquisa.Count() == 1)
                {
                    if (OpcaoPesquisa[0] == "Interprete")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].Text.ToLower().IndexOf(textBoxInterprete.Text.ToLower()) > -1 || listViewPesquisa.Items[i].Text.ToUpper().IndexOf(textBoxInterprete.Text.ToUpper()) > -1)
                            {
                                listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Autor")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                            {
                                listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Album")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                            {
                                listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Midia")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                            {
                                listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Status")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[9].Text.IndexOf(comboBoxStatus.SelectedItem.ToString()) > -1)
                            {
                                listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                            }
                        }
                    }
                }
                if (OpcaoPesquisa.Count() == 2)
                {
                    if (OpcaoPesquisa[0] == "Interprete" && OpcaoPesquisa[1] == "Autor")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToLower()) > -1 || listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                                {
                                    listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                    listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Interprete" && OpcaoPesquisa[1] == "Album")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToLower()) > -1 || listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                                {
                                    listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                    listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Interprete" && OpcaoPesquisa[1] == "Midia")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToLower()) > -1 || listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                                {
                                    listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                    listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Interprete" && OpcaoPesquisa[1] == "Status")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToLower()) > -1 || listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[9].Text.IndexOf(comboBoxStatus.SelectedItem.ToString()) > -1)
                                {
                                    listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                    listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Autor" && OpcaoPesquisa[1] == "Album")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                                {
                                    listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                    listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Autor" && OpcaoPesquisa[1] == "Midia")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                                {
                                    listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                    listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                }
                            }
                        }
                    }

                    if (OpcaoPesquisa[0] == "Autor" && OpcaoPesquisa[1] == "Status")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[9].Text.IndexOf(comboBoxStatus.SelectedItem.ToString()) > -1)
                                {
                                    listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                    listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Album" && OpcaoPesquisa[1] == "Midia")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                                {
                                    listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                    listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Album" && OpcaoPesquisa[1] == "Status")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[9].Text.IndexOf(comboBoxStatus.SelectedItem.ToString()) > -1)
                                {
                                    listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                    listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Midia" && OpcaoPesquisa[1] == "Status")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {

                            if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[9].Text.IndexOf(comboBoxStatus.SelectedItem.ToString()) > -1)
                                {
                                    listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                    listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                }
                            }
                        }
                    }

                }
                if (OpcaoPesquisa.Count() == 3)
                {
                    if (OpcaoPesquisa[0] == "Interprete" && OpcaoPesquisa[1] == "Autor" && OpcaoPesquisa[2] == "Album")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToLower()) > -1 || listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                                {
                                    if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                                    {
                                        listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                        listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                    }
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Interprete" && OpcaoPesquisa[1] == "Album" && OpcaoPesquisa[2] == "Midia")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToLower()) > -1 || listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                                {
                                    if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                                    {
                                        listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                        listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                    }
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Interprete" && OpcaoPesquisa[1] == "Midia" && OpcaoPesquisa[2] == "Status")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToLower()) > -1 || listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                                {
                                    if (listViewPesquisa.Items[i].SubItems[9].Text.IndexOf(comboBoxStatus.SelectedItem.ToString()) > -1)
                                    {
                                        listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                        listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                    }
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Autor" && OpcaoPesquisa[1] == "Album" && OpcaoPesquisa[2] == "Midia")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                                {
                                    if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                                    {
                                        listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                        listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                    }
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Autor" && OpcaoPesquisa[1] == "Midia" && OpcaoPesquisa[2] == "Status")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                                {
                                    if (listViewPesquisa.Items[i].SubItems[9].Text.IndexOf(comboBoxStatus.SelectedItem.ToString()) > -1)
                                    {
                                        listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                        listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                    }
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Album" && OpcaoPesquisa[1] == "Midia" && OpcaoPesquisa[2] == "Status")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                                {
                                    if (listViewPesquisa.Items[i].SubItems[9].Text.IndexOf(comboBoxStatus.SelectedItem.ToString()) > -1)
                                    {
                                        listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                        listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                    }
                                }
                            }
                        }
                    }


                }
                if (OpcaoPesquisa.Count() == 4)
                {
                    if (OpcaoPesquisa[0] == "Interprete" && OpcaoPesquisa[1] == "Autor" && OpcaoPesquisa[2] == "Album" && OpcaoPesquisa[3] == "Midia")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToLower()) > -1 || listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                                {
                                    if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                                    {
                                        if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                                        {
                                            listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                            listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Interprete" && OpcaoPesquisa[1] == "Autor" && OpcaoPesquisa[2] == "Album" && OpcaoPesquisa[3] == "Status")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToLower()) > -1 || listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                                {
                                    if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                                    {
                                        if (listViewPesquisa.Items[i].SubItems[9].Text.IndexOf(comboBoxStatus.SelectedItem.ToString()) > -1)
                                        {
                                            listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                            listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (OpcaoPesquisa[0] == "Autor" && OpcaoPesquisa[1] == "Album" && OpcaoPesquisa[2] == "Midia" && OpcaoPesquisa[3] == "Status")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                                {
                                    if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                                    {
                                        if (listViewPesquisa.Items[i].SubItems[9].Text.IndexOf(comboBoxStatus.SelectedItem.ToString()) > -1)
                                        {
                                            listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                            listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (OpcaoPesquisa.Count() == 5)
                {
                    if (OpcaoPesquisa[0] == "Interprete" && OpcaoPesquisa[1] == "Autor" && OpcaoPesquisa[2] == "Album" && OpcaoPesquisa[3] == "Midia" && OpcaoPesquisa[4] == "Status")
                    {
                        for (int i = 0; i < listViewPesquisa.Items.Count; i++)
                        {
                            if (listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToLower()) > -1 || listViewPesquisa.Items[i].Text.IndexOf(textBoxInterprete.Text.ToUpper()) > -1)
                            {
                                if (listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[1].Text.IndexOf(textBoxAutor.Text.ToUpper()) > -1)
                                {
                                    if (listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToLower()) > -1 || listViewPesquisa.Items[i].SubItems[2].Text.IndexOf(textBoxAlbum.Text.ToUpper()) > -1)
                                    {
                                        if (listViewPesquisa.Items[i].SubItems[6].Text.IndexOf(comboBoxMidia.SelectedItem.ToString()) > -1)
                                        {
                                            if (listViewPesquisa.Items[i].SubItems[9].Text.IndexOf(comboBoxStatus.SelectedItem.ToString()) > -1)
                                            {
                                                listViewPesquisa.TopItem = listViewPesquisa.Items[i];
                                                listViewPesquisa.Items[i].BackColor = Color.AntiqueWhite;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }



            }
        }

        private void listViewPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBoxPesquisaRapida_Enter(object sender, EventArgs e)
        {

        }

        private void buttonAdicionarMidia_Click(object sender, EventArgs e)
        {
            Form3 cadastroMidia = new Form3();
            cadastroMidia.ShowDialog();
            CarregarListview();
        }

        private void buttonAlterararMidia_Click(object sender, EventArgs e)
        {
            Form3 cadastroMidia = new Form3();
            cadastroMidia.ShowDialog();
            CarregarListview();
        }

        private void editaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPesquisaPessoa formPessoa = new FormPesquisaPessoa();
            formPessoa.ShowDialog();
        }
         
    }
}
