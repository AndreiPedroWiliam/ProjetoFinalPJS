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
                // Verifica se a conexão está aberta. Fecha a conexão, limpa o leitor e limpa a lista, para o novo carregamento 
                if (conexao.State == ConnectionState.Open)
                {
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

                // Comando que retorna a quantidade de Pessoas e passa para o label esta informação
                SqlCommand cmdCountPessoa = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Pessoa;", conexao);
                leitor = cmdCountPessoa.ExecuteReader();
                
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


                // Verifica se a mídia está ou não disponível
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
            // Comandos que retornam a quantidade conforme a mídia, passando esta informação para os respectivos labels
            SqlCommand cmdCountMidias = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album;", conexao);
            leitor = cmdCountMidias.ExecuteReader();
            
            if (leitor.Read())
                qtdeMidia.Text = leitor["QTD"].ToString();

            FechaLeitor();
            
            SqlCommand cmdCountDigital = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'Digital';", conexao);
            leitor = cmdCountDigital.ExecuteReader();
            
            if (leitor.Read())
                qtdeDigital.Text = leitor["QTD"].ToString();

            FechaLeitor();
            
            SqlCommand cmdCountDVD = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'DVD';", conexao);
            leitor = cmdCountDVD.ExecuteReader();
            
            if (leitor.Read())
                qtdeDVD.Text = leitor["QTD"].ToString();

            FechaLeitor();
            
            SqlCommand cmdCountCD = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'CD';", conexao);
            leitor = cmdCountCD.ExecuteReader();
            
            if (leitor.Read())
                qtdeCD.Text = leitor["QTD"].ToString();

            FechaLeitor();
            
            SqlCommand cmdCountK7 = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'K7';", conexao);
            leitor = cmdCountK7.ExecuteReader();
            
            if (leitor.Read())
                qtdeK7.Text = leitor["QTD"].ToString();

            FechaLeitor();
            
            SqlCommand cmdCountVinil = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE TipoMidia = 'Vinil';", conexao);
            leitor = cmdCountVinil.ExecuteReader();
            
            if (leitor.Read())
                qtdeVinil.Text = leitor["QTD"].ToString();
        }

        public void CountStatus()
        {
            FechaLeitor();
            // Comando que retorna a quantidade de Albuns Emprestados
            SqlCommand cmdCountAlbumEmprestado = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE Status = 'Emprestado';", conexao);
            leitor = cmdCountAlbumEmprestado.ExecuteReader();
            
            if (leitor.Read())
                qtdeEmprestado.Text = leitor["QTD"].ToString();

            FechaLeitor();
            // Comando que retorna a quantidade de Albuns Disponíveis
            SqlCommand cmdCountAlbumDisponivel = new SqlCommand("SELECT COUNT(*) AS 'QTD' FROM Album WHERE Status = 'Disponível' AND TipoMidia!= 'Digital';", conexao);
            leitor = cmdCountAlbumDisponivel.ExecuteReader();
            
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
            // Verifica se algum item foi selecionado, conforme status, muda o botão para 'emprestar' ou 'devolver'

            if (listViewPesquisa.SelectedItems.Count == 1)
            {
                
                if (listViewPesquisa.SelectedItems[0].ForeColor == Color.Gray)
                {
                    buttonEmprestar.Text = "Devolver";
                    labelErroRemover.Visible = false;
                    labelErroEmprestimo.Visible = false;
                }
                else
                {
                    buttonEmprestar.Text = "Emprestar"; 
                    labelErroRemover.Visible = false;
                    labelErroEmprestimo.Visible = false;
                }

                if (listViewPesquisa.SelectedItems[0].SubItems[8].Text == "")
                    buttonAtribuirNota.Visible = true;
                else
                    buttonAtribuirNota.Visible = false;

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
            FormPesquisaPessoa Pessoa = new FormPesquisaPessoa();
            Pessoa.ShowDialog();
        }

        private void buttonEmprestar_Click_1(object sender, EventArgs e)
        {
            // Verifica se algum item foi selecionado
            if (listViewPesquisa.SelectedItems.Count == 1)
            {
                // Verifica se o item é para devolver ou emprestar. Se for para devolver, chama o form de devolução. Senão, chama o form para empréstimo

                if (buttonEmprestar.Text == "Devolver")
                {
                    string idMidia = listViewPesquisa.SelectedItems[0].Text;

                    if (conexao.State == ConnectionState.Open)
                        conexao.Close();
                    conexao.Open();

                    try
                    {
                        // Executa o comando para obter o id do Emprestimo
                        SqlCommand selectIdEmprestimo = new SqlCommand("SELECT Id_Emprestimo from Emprestimo where Id_Album = @ID_ALBUM AND DataDevolucao is null", conexao);
                        SqlParameter idAlbum = new SqlParameter("@ID_ALBUM", idMidia);
                        selectIdEmprestimo.Parameters.Add(idAlbum);
                        leitor = selectIdEmprestimo.ExecuteReader();

                        leitor.Read();
                        // Pega o id do emprestimo
                        int idEmprestimo = int.Parse(leitor["Id_Emprestimo"].ToString());
                        leitor.Close();

                        // Pega a data atual do sistema, no formato dia-mês-ano
                        string dataDevolucao = DateTime.Now.ToString("dd-MM-yyyy");

                        // Altera a data de devolução para data atual
                        SqlCommand cmdUpdateEmprestimo = new SqlCommand("UPDATE Emprestimo SET DataDevolucao ='" + dataDevolucao + "' WHERE Id_Emprestimo = @ID_EMPRESTIMO", conexao);
                        SqlParameter IdEmprestimo = new SqlParameter("@ID_EMPRESTIMO", idEmprestimo);
                        cmdUpdateEmprestimo.Parameters.Add(IdEmprestimo);
                        cmdUpdateEmprestimo.ExecuteNonQuery();

                        // Altera o status do album para disponível
                        SqlCommand cmdUpdateAlbum = new SqlCommand("UPDATE Album SET Status = 'Disponível' WHERE Id_Album = @ID_ALBUM;", conexao);
                        SqlParameter idAlbum2 = new SqlParameter("@ID_ALBUM", idMidia);
                        cmdUpdateAlbum.Parameters.Add(idAlbum2);
                        cmdUpdateAlbum.ExecuteNonQuery();
                        // Atualiza o listView principal

                    }
                    finally
                    {
                        conexao.Close();

                        listViewPesquisa.Items.Clear();
                        CarregarListview();
                        buttonEmprestar.Text = "Emprestar";
                    }
                }
                else
                {
                    if (listViewPesquisa.SelectedItems.Count == 1)
                    {

                        int idAlbum = int.Parse(listViewPesquisa.SelectedItems[0].Text);

                        if (listViewPesquisa.SelectedItems[0].SubItems[7].Text != "Digital")
                        {
                            Form2 emprestarMidia = new Form2(idAlbum);

                            emprestarMidia.ShowDialog();
                            //Após alterar um album, atualiza o ListView principal com a função CarregarListView()
                            CarregarListview();
                            // Volta o botão de Emprestimo/Devolução para a configuração inicial
                            buttonEmprestar.Text = "Emprestar";
                        }
                        else
                            labelErroEmprestimo.Visible = true;

                    }
                }
            }

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica se algum item foi selecionado
            if (listViewPesquisa.SelectedItems.Count == 1)
            {
                // Verifica se a conexão está aberta, se necessário será fechada
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();

                conexao.Open();

                // Verifica se o item está emprestado. Será apresentada mensagem personalizada para finalização de exclusão do item selecionado
                
                if (buttonEmprestar.Text == "Devolver")
                    labelErroRemover.Visible = true;
                else
                {
                    int idALBUM = int.Parse(listViewPesquisa.SelectedItems[0].Text);

                    // Executa o comando verificando se o album está presente no histórico
                    SqlCommand cmdSelectAlbumFromEmprestimo = new SqlCommand("SELECT Id_Album FROM Emprestimo WHERE Id_Album = @ID_ALBUM", conexao);
                    SqlParameter IDAlbum = new SqlParameter("@ID_ALBUM", idALBUM);
                    cmdSelectAlbumFromEmprestimo.Parameters.Add(IDAlbum);
                    leitor = cmdSelectAlbumFromEmprestimo.ExecuteReader();

                    // Verifica se o comando resultou em algum valor
                    if (leitor.Read())
                    {
                        DialogResult resposta = MessageBox.Show("Ao excluir este album seu histório também será removido.\nDeseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        // Se o album estiver no histórico mostra uma mensagem
                        if (resposta == System.Windows.Forms.DialogResult.Yes)
                        {
                            // Remove o album do histórico e depois remove o album
                            conexao.Close();
                            conexao.Open();
                            // Removendo o album do histórico
                            SqlCommand cmdDeleteAlbumEmprestimo = new SqlCommand("DELETE FROM Emprestimo WHERE Id_Album = @ID_ALBUM", conexao);
                            SqlParameter id = new SqlParameter("@ID_ALBUM", idALBUM);
                            cmdDeleteAlbumEmprestimo.Parameters.Add(id);
                            cmdDeleteAlbumEmprestimo.ExecuteNonQuery();

                            // Removendo o album
                            SqlCommand cmdDeleteAlbum = new SqlCommand("DELETE FROM Album WHERE Id_Album = @ID_ALBUM", conexao);
                            SqlParameter ID = new SqlParameter("@ID_ALBUM", idALBUM);
                            cmdDeleteAlbum.Parameters.Add(ID);
                            cmdDeleteAlbum.ExecuteNonQuery();
                            // fecha a conexão e atualiza o listView
                            conexao.Close();
                            leitor = null;
                            listViewPesquisa.Items.Clear();
                            CarregarListview();
                        }
                    }
                    else
                    {
                        DialogResult resposta = MessageBox.Show("Deseja realmente remover este album?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resposta == System.Windows.Forms.DialogResult.Yes)
                        {
                            conexao.Close();
                            conexao.Open();
                            int idAlbum = int.Parse(listViewPesquisa.SelectedItems[0].Text);

                            // Pega o id do album selecionado e remove 
                            SqlCommand cmdDeleteAlbum = new SqlCommand("DELETE FROM Album WHERE Id_Album = @ID_ALBUM", conexao);
                            SqlParameter id_Album = new SqlParameter("@ID_ALBUM", idAlbum);
                            cmdDeleteAlbum.Parameters.Add(id_Album);
                            cmdDeleteAlbum.ExecuteNonQuery();

                            // Fecha a conexão, limpa o ListView e atualiza
                            conexao.Close();
                            listViewPesquisa.Items.Clear();
                            CarregarListview();
                        }
                    }
                }
            }
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterarAlbum(0);
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
            // Limpa o último resultado da pesquisa. Carrega novamente o listview com todos os albuns
            listViewPesquisa.Items.Clear();
            CarregarListview();

            // Percorre os componentes do GroupBoxPesquisa, verificando o tipo de cada um e limpa
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
            AlterarAlbum(0);
        }

        public void AlterarAlbum(int alterar)
        {
            // Se alterar for 0, altera o todos os dados do album, caso contrario altera somente a nota
            if (alterar == 0)
            {
                // Verifica se foi selecionado algum item do ListViewPesquisa. Caso um item seja selecionado, passa para o formulario de Alteração de Mídia, o Id do Album
                if (listViewPesquisa.SelectedItems.Count == 1)
                {
                    int idAlbum = int.Parse(listViewPesquisa.SelectedItems[0].Text);
                    Form5 alterarMidia = new Form5(idAlbum, 0);

                    alterarMidia.ShowDialog();
                    //Após alterar um album, atualiza o ListView principal com a função CarregarListView()
                    CarregarListview();
                    // Volta o botão de Emprestimo/Devolução para a configuração inicial
                    buttonEmprestar.Text = "Emprestar";
                }
            }
            else
            {
                if (listViewPesquisa.SelectedItems.Count == 1)
                {
                    int idAlbum = int.Parse(listViewPesquisa.SelectedItems[0].Text);
                    Form5 alterarMidia = new Form5(idAlbum, 1);

                    alterarMidia.ShowDialog();
                    //Após alterar um album, atualiza o ListView principal com a função CarregarListView()
                    CarregarListview();
                    // Volta o botão de Emprestimo/Devolução para a configuração inicial
                    buttonEmprestar.Text = "Emprestar";
                    buttonAtribuirNota.Visible = false;
                }
            }
        }




        // trecho para efetuar a pesquisa por filtros
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

        private void Principal_Enter(object sender, EventArgs e)
        {
            comboBoxStatus.SelectedIndex = 0;
            comboBoxMidia.SelectedIndex = 0;
            comboBoxNota.SelectedIndex = 0;
            CarregarListview();
        }

        private void checkBoxInterprete_CheckedChanged(object sender, EventArgs e)
        {
            textBoxInterprete.Enabled = checkBoxInterprete.Checked;

            
            if(!checkBoxInterprete.Checked)
                textBoxInterprete.Text= "";
        }

        private void checkBoxAutor_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAutor.Enabled = checkBoxAutor.Checked;
            if (!checkBoxAutor.Checked)
                textBoxAutor.Text = "";
        }

        private void checkBoxAlbum_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAlbum.Enabled = checkBoxAlbum.Checked;
            if (!checkBoxAlbum.Checked)
                textBoxAlbum.Text = "";
        }

        private void checkBoxDataAlbum_CheckedChanged(object sender, EventArgs e)
        {
            dtDataAlbumInicio.Enabled = checkBoxDataAlbum.Checked;
            dtDataAlbumFim.Enabled = checkBoxDataAlbum.Checked;

            if (!checkBoxDataAlbum.Checked)
            {
                dtDataAlbumInicio.Value = DateTime.Now;
                dtDataAlbumFim.Value = DateTime.Now;
            }
        }

        private void checkBoxDataCompra_CheckedChanged(object sender, EventArgs e)
        {
            dtDataCompraInicio.Enabled = checkBoxDataCompra.Checked;
            dtDataCompraFim.Enabled = checkBoxDataCompra.Checked;

            if (!checkBoxDataCompra.Checked)
            {
                dtDataCompraInicio.Value = DateTime.Now;
                dtDataCompraFim.Value = DateTime.Now;
            }
        }

        private void checkBoxOrigemCompra_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOrigemCompra.Enabled = checkBoxOrigemCompra.Checked;
            if (!checkBoxOrigemCompra.Checked)
                textBoxOrigemCompra.Text = "";
        }

        private void checkBoxMidia_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxMidia.Enabled = checkBoxMidia.Checked;
            if (!checkBoxMidia.Checked)
                comboBoxMidia.SelectedIndex = 0;
        }

        private void checkBoxStatus_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxStatus.Enabled = checkBoxStatus.Checked;
            if (!checkBoxStatus.Checked)
                comboBoxStatus.SelectedIndex = 0;
        }

        private void checkBoxNota_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxNota.Enabled = checkBoxNota.Checked;
            if (!checkBoxNota.Checked)
                comboBoxNota.SelectedIndex = 0;
        }

        private void históricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHistorico Historico = new FormHistorico();
            Historico.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void buttonAtribuirNota_Click(object sender, EventArgs e)
        {
            AlterarAlbum(1);
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSobre sobre = new FormSobre();
            sobre.ShowDialog();
        }

 
    }
}
