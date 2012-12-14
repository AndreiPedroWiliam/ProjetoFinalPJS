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
    public partial class FormCadMidia : Form
    {
        public FormCadMidia()
        {
            InitializeComponent();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            bool[] verifica = new bool[6];
            if (comboBoxMidia.Text == "Selecione...")
            {
                errorProvider1.SetError(label20, "Mídia inválida");
                verifica[0] = false;
            }
            else
            {
                errorProvider1.Clear();
                verifica[0] = true;
            }
            if (textBoxInterprete.Text == "")
            {
                errorProvider2.SetError(label14, "Digite o interprete");
                verifica[1] = false;
            }
            else
            {
                errorProvider2.Clear();
                verifica[1]=true;
            }
            if (textBoxAutor.Text == "")
            {
                errorProvider3.SetError(label15, "Digite o Autor");
                verifica[2] = false;
            }
            else
            {
                errorProvider3.Clear();
                verifica[2]=true;
            }
            if (textBoxAlbum.Text == "")
            {
                errorProvider4.SetError(label16, "Digite o Album");
                verifica[3] = false;
            }
            else
            {
                errorProvider4.Clear();
                verifica[3]=true;
            }
            if (textBoxCompra.Text == "")
            {
                errorProvider5.SetError(label17, "Digite onde comprou");
                verifica[4] = false;
            }
            else
            {
                errorProvider5.Clear();
                verifica[4]=true;
            }
            if (dateTimePickerAlbum.Text == dateTimePickerCompra.Text)
            {
                errorProvider6.SetError(label19, "A data da compra e menor que a data do Album");
                verifica[5] = false;
            }
            else
            {
                errorProvider6.Clear();
                verifica[5]=true;
            }
            if (verifica[0] == true && verifica[1] == true && verifica[2] == true && verifica[3] == true && verifica[4] == true && verifica[5] == true)
            {
                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = "Data Source=.\\SQLEXPRESS;initial Catalog=acervoMusical;Integrated Security=SSPI";
                conexao.Open();
                try
                {
                    if (conexao != null && conexao.State == ConnectionState.Open)
                    {
                        //se estiver tudo correto cria o comando e insere no banco
                        if (comboBoxMidia.Text == "Digital")
                        {
                            SqlCommand insertMidiaDigital = new SqlCommand("INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Observacao, Status) VALUES('" + textBoxInterprete.Text + "','" + textBoxAutor.Text + "','" + textBoxAlbum.Text + "','" + dateTimePickerAlbum.Value.ToString("yyyy-MM-dd") + "','" + dateTimePickerCompra.Value.ToString("yyyy-MM-dd") + "','" + textBoxCompra.Text + "','" + comboBoxMidia.Text + "','" + textBoxObservacao.Text + "','Disponível')");
                            insertMidiaDigital.Connection = conexao;
                            insertMidiaDigital.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand insertMidia = new SqlCommand();
                            insertMidia.CommandText = "INSERT INTO Album (Interprete, Autor, Album, Data, DataCompra, OrigemCompra, TipoMidia, Observacao, Status) VALUES('" + textBoxInterprete.Text + "','" + textBoxAutor.Text + "','" + textBoxAlbum.Text + "','" + dateTimePickerAlbum.Value.ToString("yyyy-MM-dd") + "','" + dateTimePickerCompra.Value.ToString("yyyy-MM-dd") + "','" + textBoxCompra.Text + "','" + comboBoxMidia.Text + "','" + textBoxObservacao.Text + "', 'Disponível')";
                            insertMidia.Connection = conexao;
                            insertMidia.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException excecao)
                {

                    MessageBox.Show("Falha na conexao "+excecao);
                }
                finally
                {
                    if (conexao != null)
                        conexao.Close();
                }
                Close();
            }
        }
        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            //limpa tudo
            textBoxInterprete.Text = "";
            textBoxAutor.Text = "";
            textBoxAlbum.Text = "";
            dateTimePickerAlbum.Text = "";
            textBoxCompra.Text = "";
            dateTimePickerCompra.Text = "";
            comboBoxMidia.Text = "";
            textBoxObservacao.Text = "";
        }

        private void FormCadMidia_Load(object sender, EventArgs e)
        {
            comboBoxMidia.SelectedIndex = 0;
        }
    }
}
