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

        // Cria um Leitor o qual percorrerá todas as linhas e colunas das tabelas do Banco
        SqlDataReader leitor = null;
        SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");
       

        public void Principal_Load(object sender, EventArgs e)
        {
            comboBoxStatus.SelectedIndex = 0;
            comboBoxMidia.SelectedIndex = 0;
            comboBoxNota.SelectedIndex = 0;
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

                // Chama a função para preenchimento do ListView
                PreencheListView();

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

        public void PreencheListView()
        {
            int i = 0;
            while (leitor.Read())
            {
                ListViewItem idAlbum = new ListViewItem();
                ListViewItem.ListViewSubItem Interprete = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem Autor = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem Album = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem Data = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem Compra = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem Origem = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem Midia = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem Nota = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem Observacao = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem Status = new ListViewItem.ListViewSubItem();

                idAlbum.Text = leitor["Id_Album"].ToString();

                Interprete.Text = leitor["Interprete"].ToString();
                idAlbum.SubItems.Add(Interprete);

                Autor.Text = leitor["Autor"].ToString();
                idAlbum.SubItems.Add(Autor);

                Album.Text = leitor["Album"].ToString();
                idAlbum.SubItems.Add(Album);

                Data.Text = leitor["Data"].ToString();
                string data = Data.Text;
                data = data.Remove(10);

                idAlbum.SubItems.Add(data);

                Compra.Text = leitor["DataCompra"].ToString();
                data = Compra.Text;
                data = data.Remove(10);

                idAlbum.SubItems.Add(data);

                Origem.Text = leitor["OrigemCompra"].ToString();
                idAlbum.SubItems.Add(Origem);

                Midia.Text = leitor["TipoMidia"].ToString();
                idAlbum.SubItems.Add(Midia);

                Nota.Text = leitor["Nota"].ToString();
                idAlbum.SubItems.Add(Nota);

                Observacao.Text = leitor["Observacao"].ToString();
                idAlbum.SubItems.Add(Observacao);


                Status.Text = leitor["Status"].ToString();
                idAlbum.SubItems.Add(Status);

                listViewPesquisa.Items.Add(idAlbum);


                // Verifica se o filme está ou não disponível
                if (Status.Text == "Emprestado")
                    listViewPesquisa.Items[i].ForeColor = Color.Gray;
                i++;
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

        private void amigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 cadPessoa = new Form4();
            cadPessoa.Show();
        }

        private void buttonEmprestar_Click(object sender, EventArgs e)
        {
            if (listViewPesquisa.SelectedItems.Count == 1)
            {
                int idAlbum = int.Parse(listViewPesquisa.SelectedItems[0].Text);
                Form2 Emprestar = new Form2(idAlbum);
                Emprestar.ShowDialog();

            }
        }

        private void midiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 cadastroPessoa = new Form4();
            cadastroPessoa.ShowDialog();
        }

        private void listViewPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se algum item foi selecionado
            // de acordo com o status do filme, muda o botão para 'emprestar' ou 'devolver'
            if (listViewPesquisa.SelectedItems.Count == 1)
            {
                if (listViewPesquisa.SelectedItems[0].ForeColor == Color.Gray)
                {
                    buttonEmprestar.Text = "Devolver";
                    labelErroRemover.Visible = false;
                }
                else
                {
                    buttonEmprestar.Text = "Emprestar"; 
                    labelErroRemover.Visible = false; 
                }

            }
        }
        private void buttonAdicionarMidia_Click(object sender, EventArgs e)
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

        private void buttonEmprestar_Click_1(object sender, EventArgs e)
        {
            // Verifica se algum item foi selecionado
            if (listViewPesquisa.SelectedItems.Count == 1)
            {
                // Verifica se o item é para devolver ou emprestar
                // Se for para devolver, chama o form de devolução 
                // senão chama o form de emprestimo
                if (buttonEmprestar.Text == "Devolver")
                {
                    string idMidia = listViewPesquisa.SelectedItems[0].ToString();

                    FormDevolver Devolver = new FormDevolver();
                    Devolver.ShowDialog();
                    CarregarListview();
                }
                else
                {
                    if (listViewPesquisa.SelectedItems.Count == 1)
                    {
                        int idAlbum = int.Parse(listViewPesquisa.SelectedItems[0].Text);
                        Form2 alterarMidia = new Form2(idAlbum);

                        alterarMidia.ShowDialog();
                        //Após alterar um album, atualiza o ListView principal com a função CarregarListView()
                        CarregarListview();
                        // Volta o botão de Emprestimo/Devolução para a configuração inicial
                        buttonEmprestar.Text = "Emprestar";
                    }
                }
            }

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica se algum item foi selecionado
            if (listViewPesquisa.SelectedItems.Count == 1)
            {
                // Verifica se a conexão está aberta, caso esteja fecha-a
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();

                conexao.Open();
                
                // Verifica se o item está emprestado
                // Se tiver mostra um aviso, no label
                // Caso o album não estiver emprestado, perguanta ao usuário se deseja realmente remover o album,
                // Se a resposta for sim, remove o item selecionado
                if (buttonEmprestar.Text == "Devolver")
                    labelErroRemover.Visible = true;
                else
                {
                    DialogResult resposta = MessageBox.Show("Deseja realmente remover esse album?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resposta == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Pega o id do album selecionado e o remove 
                        SqlCommand cmdDeleteAlbum = new SqlCommand("DELETE FROM Album WHERE Id_Album = @ID_ALBUM", conexao);
                        SqlParameter idAlbum = new SqlParameter("@ID_ALBUM", int.Parse(listViewPesquisa.SelectedItems[0].Text));

                        cmdDeleteAlbum.Parameters.Add(idAlbum);
                        cmdDeleteAlbum.ExecuteNonQuery();

                        // Fecha a conexão, limpa o ListView, e o atualiza
                        conexao.Close();
                        listViewPesquisa.Items.Clear();
                        CarregarListview();
                    }
                }
            }
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterarAlbum();
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 cadastroMidia = new Form3();
            cadastroMidia.ShowDialog();
            //Após adicionar um Album, atualiza o ListView principal, com a função CarregarListView()
            CarregarListview();
        }

       

        private void linkLabelRemoverFiltro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Limpa os último resultado da pesquisa
            // Carrega novamente o listview com todos os albuns
            listViewPesquisa.Items.Clear();
            CarregarListview();

            // Percorre os componentes do GroupBoxPesquisa
            // Verificando o tipo de cada um e assim limpando
            foreach (Object campo in groupBoxPesquisa.Controls)
            {
                if (campo is CheckBox)
                    ((CheckBox)campo).Checked = false;
                if (campo is TextBox)
                    ((TextBox)campo).Text = "";
                if (campo is ComboBox)
                    ((ComboBox)campo).SelectedIndex = 0;
            }
        }

        private void listViewPesquisa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AlterarAlbum();
        }

        public void AlterarAlbum()
        {
            // Verifica se foi selecionado algum item do ListViewPesquisa
            // Caso um item foi selecionado, passa para o formulario de Alteração de Mídia o Id do Album
            if (listViewPesquisa.SelectedItems.Count == 1)
            {
                int idAlbum = int.Parse(listViewPesquisa.SelectedItems[0].Text);
                Form5 alterarMidia = new Form5(idAlbum);

                alterarMidia.ShowDialog();
                //Após alterar um album, atualiza o ListView principal com a função CarregarListView()
                CarregarListview();
                // Volta o botão de Emprestimo/Devolução para a configuração inicial
                buttonEmprestar.Text = "Emprestar";
            }
        }




        // Pesquisa
        private void Pesquisa(object sender, EventArgs e)
        {

            int i = 0;
            string pesquisa = "";

            // Verifica qual checkBox foi selecionado, verifica se o campo foi preenchido, desta forma realiza a pesquisa

            if (checkBoxInterprete.Checked == true && textBoxInterprete.Text != "")
            {
                if (i > 0)
                    pesquisa += " AND Interprete like '%" + textBoxInterprete.Text + "%'";
                else
                    pesquisa = "Interprete like '%" + textBoxInterprete.Text + "%'";
                i++;
            }
            if (checkBoxAutor.Checked == true && textBoxAutor.Text != "")
            {
                if (i > 0)
                    pesquisa += "AND Autor like  '%" + textBoxAutor.Text + "%'";
                else
                    pesquisa = "Autor like '%" + textBoxAutor.Text + "%'";
                i++;
            }
            if (checkBoxAlbum.Checked == true && textBoxAlbum.Text != "")
            {
                if (i > 0)
                    pesquisa += " AND Album like '%" + textBoxAlbum.Text + "%'";
                else
                    pesquisa = "Album like '%" + textBoxAlbum.Text + "%'";
                i++;
            }
            if (checkBoxDataAlbum.Checked == true)
            {
                string DataInicio = dtDataAlbumInicio.Value.ToString().Remove(10);
                string DataFim = dtDataAlbumFim.Value.ToString().Remove(10);

                if (i > 0)
                    pesquisa += " AND Data >= '" + DataInicio + "' AND Data <= '" + DataFim + "'";
                else
                    pesquisa = " Data >= '" + DataInicio + "' AND Data <= '" + DataFim + "'";
                i++;
            }
            if (checkBoxDataCompra.Checked == true)
            {
                string DataInicio = dtDataCompraInicio.Value.ToString().Remove(10);
                string DataFim = dtDataCompraFim.Value.ToString().Remove(10);

                if (i > 0)
                    pesquisa += " AND DataCompra >= '" + DataInicio + "' AND DataCompra <= '" + DataFim + "'";
                else
                    pesquisa = " DataCompra >= '" + DataInicio + "' AND DataCompra <= '" + DataFim + "'";
                i++;
            }
            if (checkBoxOrigemCompra.Checked == true && textBoxOrigemCompra.Text != "")
            {
                if (i > 0)
                    pesquisa += " AND OrigemCompra like '%" + textBoxOrigemCompra.Text + "%'";
                else
                    pesquisa = " OrigemCompra like '%" + textBoxOrigemCompra.Text + "%'";
                i++;
            }

            if (checkBoxMidia.Checked == true && comboBoxMidia.SelectedIndex != 0)
            {
                if (i > 0)
                    pesquisa += " AND TipoMidia = '" + comboBoxMidia.SelectedItem.ToString() + "'";
                else
                    pesquisa = " TipoMidia = '" + comboBoxMidia.SelectedItem.ToString() + "'";
                i++;
            }
            if (checkBoxStatus.Checked == true && comboBoxStatus.SelectedIndex != 0)
            {
                if (i > 0)
                    pesquisa += " AND Status = '" + comboBoxStatus.SelectedItem.ToString() + "'";
                else
                    pesquisa = " Status ='" + comboBoxStatus.SelectedItem.ToString() + "'";
                i++;
            }
            if (checkBoxNota.Checked == true && comboBoxNota.SelectedIndex != 0)
            {
                if (i > 0)
                    pesquisa += " AND Nota = '" + comboBoxNota.SelectedItem.ToString() + "'";
                else
                    pesquisa = " Nota ='" + comboBoxNota.SelectedItem.ToString() + "'";
                i++;
            }
            if (i > 0)
            {
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();

                conexao.Open();

                try
                {
                    // Realiza a pesquisa seja com combinações ou não
                    SqlCommand cmdPesquisa = new SqlCommand("SELECT Id_Album, Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao, Status FROM Album WHERE " + pesquisa + " ;", conexao);
                    leitor = cmdPesquisa.ExecuteReader();

                    //Limpa o ListView para o novo resultado
                    listViewPesquisa.Items.Clear();
                    // Chama a função para carregar o resultado da pesquisa no ListView
                    PreencheListView();
                }
                finally
                {
                    i = 0;
                    conexao.Close();
                    leitor = null;
                }
            }
      
        }


    }
}
