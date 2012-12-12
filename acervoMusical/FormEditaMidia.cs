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
    public partial class FormEditaMidia : Form
    {
        int id = 0;
        int alterar = 0;

        public FormEditaMidia(int idMidia, int alterarMidia)
        {
            id = idMidia;
            alterar = alterarMidia;
            InitializeComponent();
        }  
        
        SqlDataReader leitor = null;
        SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");


        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            bool erro = false;

            if (textBoxInterpreteEdit.Text.Trim() == "")
            {
                erro = true;
                errorProvider.SetError(labelInterprete, "Favor preencher o campo Interprete corretamente");
            }
            if (textBoxAutorEdit.Text.Trim() == "")
            {
                erro = true;
                errorProvider.SetError(labelAutor, "Favor preencher o campo Autor corretamente");
            }
            if (textBoxAlbumEdit.Text.Trim() == "")
            {
                erro = true;
                errorProvider.SetError(labelAlbum, "Favor preencher o campo Album corretamente");
            }
            if (textBoxCompraEdit.Text.Trim() == "")
            {
                erro = true;
                errorProvider.SetError(labelOrigemCompra, "Favor preemcher o campo Origem da Compra corretamente");
            }

            if (erro == false)
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmdUpdate = new SqlCommand("UPDATE Album SET Interprete = @INTERPRETE, Autor = @AUTOR, Album = @ALBUM, Data = @DATA, DataCompra = @DATA_COMPRA, OrigemCompra = @ORIGEM_COMPRA, TipoMidia = @TIPO_MIDIA, Nota = @NOTA, Observacao = @OBSERVACAO WHERE Id_Album = @ID_ALBUM;", conexao);
                    SqlParameter interprete = new SqlParameter("@INTERPRETE", textBoxInterpreteEdit.Text);
                    SqlParameter autor = new SqlParameter("@AUTOR", textBoxAutorEdit.Text);
                    SqlParameter album = new SqlParameter("@ALBUM", textBoxAlbumEdit.Text);
                    SqlParameter data = new SqlParameter("@DATA", dateTimePickerAlbumEdit.Value);
                    SqlParameter dataCompra = new SqlParameter("@DATA_COMPRA", dateTimePickerCompraEdit.Value);
                    SqlParameter origemCompra = new SqlParameter("@ORIGEM_COMPRA", textBoxCompraEdit.Text);
                    SqlParameter tipoMidia = new SqlParameter("@TIPO_MIDIA", comboBoxMidiaEdit.SelectedItem.ToString());
                    SqlParameter nota = new SqlParameter("@NOTA", comboBoxNotaEdit.SelectedItem.ToString());
                    SqlParameter observacao = new SqlParameter("@OBSERVACAO", textBoxObservacaoEdit.Text);
                    SqlParameter idAlbum = new SqlParameter("@ID_ALBUM", id);

                    cmdUpdate.Parameters.Add(interprete);
                    cmdUpdate.Parameters.Add(autor);
                    cmdUpdate.Parameters.Add(album);
                    cmdUpdate.Parameters.Add(data);
                    cmdUpdate.Parameters.Add(dataCompra);
                    cmdUpdate.Parameters.Add(origemCompra);
                    cmdUpdate.Parameters.Add(tipoMidia);
                    cmdUpdate.Parameters.Add(nota);
                    cmdUpdate.Parameters.Add(observacao);
                    cmdUpdate.Parameters.Add(idAlbum);
                    cmdUpdate.ExecuteNonQuery();
                }
                finally
                {
                    conexao.Close();
                    this.Close();
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            try
            {
                conexao.Open();

                SqlCommand cmdSelecao = new SqlCommand("SELECT Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Nota, Observacao FROM Album WHERE Id_Album = @ID_ALBUM;", conexao);
                SqlParameter idAlbum = new SqlParameter("@ID_ALBUM", id);

                cmdSelecao.Parameters.Add(idAlbum);

                leitor = cmdSelecao.ExecuteReader();

                leitor.Read();
                textBoxInterpreteEdit.Text = leitor["Interprete"].ToString();
                textBoxAutorEdit.Text = leitor["Autor"].ToString();
                textBoxAlbumEdit.Text = leitor["Album"].ToString();
                dateTimePickerAlbumEdit.Value = DateTime.Parse(leitor["Data"].ToString());
                dateTimePickerCompraEdit.Value = DateTime.Parse(leitor["DataCompra"].ToString());
                textBoxCompraEdit.Text = leitor["OrigemCompra"].ToString();
                comboBoxMidiaEdit.SelectedItem = leitor["TipoMidia"].ToString();
                comboBoxNotaEdit.SelectedItem = leitor["Nota"].ToString();
                textBoxObservacaoEdit.Text = leitor["Observacao"].ToString();
            }
            catch (Exception erro)
            {
                MessageBox.Show("O" + erro);
            }
            finally
            {
                conexao.Close();
                leitor = null;
            }

            if (alterar == 1)
            {
                foreach (object componente in this.Controls)
                {
                    if (componente is TextBox)
                        ((TextBox)componente).Enabled = false;

                    if (componente is ComboBox)
                    {
                        ((ComboBox)componente).Enabled = false;
                    }
                    if (componente is DateTimePicker)
                        ((DateTimePicker)componente).Enabled = false;

                }

                comboBoxNotaEdit.Enabled = true;
            }
        }

    }
}
