using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace acervoMusical
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMidia.Text == "Digital")
            {
                //se for midia digital pede o nome da musica
                label2.Visible = true;
                textBoxMusica.Visible = true;
            }
            else
            {
                //se não, não pede
                label2.Visible = false;
                textBoxMusica.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxNota.Text != comboBoxNota.Items.ToString())
                errorProvider1.SetError(label21, "Nota inválida");
            else if (comboBoxNota.Text == comboBoxNota.Items.ToString())
                errorProvider1.Clear();
            else if (comboBoxMidia.Text != comboBoxMidia.Items.ToString())
                errorProvider2.SetError(label20, "Mídia inválida");
            else if (comboBoxMidia.Text == comboBoxMidia.Items.ToString())
                errorProvider2.Clear();
            else
            {
                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = "Data Source=PC17LAB3;initial Catalog=acervoMusical;Integrated Security=SSPI";
                conexao.Open();

                try
                {
                    if (conexao != null && conexao.State == ConnectionState.Open)
                    {
                        //se estiver tudo correto cria o comando e insere no banco
                        SqlCommand insertMidia = new SqlCommand("insert into midia values (" + textBoxInterprete.Text + "," + textBoxAutor.Text + "," + textBoxAlbum.Text + "," + dateTimePickerAlbum.Text + "," + textBoxCompra.Text + "," + dateTimePickerCompra.Text + "," + comboBoxMidia.Text + "," + comboBoxNota.Text + "," + textBoxMusica.Text + "," + textBoxObservacao.Text + ")");
                        insertMidia.ExecuteNonQuery();
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Falha na conexao");
                }
                finally
                {
                    if (conexao != null)
                        conexao.Close();
                }
                conexao.Close();
                Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //limpa tudo
            textBoxInterprete.Text = "";
            textBoxAutor.Text = "";
            textBoxAlbum.Text = "";
            dateTimePickerAlbum.Text = "";
            textBoxCompra.Text = "";
            dateTimePickerCompra.Text = "";
            comboBoxMidia.Text = "";
            comboBoxNota.Text = "";
            textBoxMusica.Text = "";
            textBoxObservacao.Text = "";
        }
    }
}
