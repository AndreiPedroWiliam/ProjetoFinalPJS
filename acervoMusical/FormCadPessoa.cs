using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace acervoMusical
{
    public partial class FormCadPessoa : Form
    {
        public FormCadPessoa()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            maskedTextBoxTelefoneCad.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            comboBoxCadUFCad.SelectedIndex = 0;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            bool []verifica = new bool[8];

            if (textBoxNomeCad.Text.Trim() == "")
            {
                errorProvider1.SetError(label1, "Nome Inválido");
                verifica[0] = false;
            }
            else
            {
                errorProvider1.Clear();
                verifica[0] = true;
            }
            if (maskedTextBoxTelefoneCad.Text.Trim() == "")
            {
                errorProvider2.SetError(label2, "Telefone Inválido");
                verifica[1] = false;
            }
            else
            {
                errorProvider2.Clear();
                verifica[1] = true;
            }
            if (textBoxEmailCad.Text.Trim() == "")
            {
                errorProvider3.SetError(label3, "Email Inválido");
                verifica[2] = false;
            }
            else
            {
                errorProvider3.Clear();
                verifica[2] = true;
            }
            if (textBoxLogradouroCad.Text.Trim() == "")
            {
                errorProvider4.SetError(label4, "Logradouro Inválido");
                verifica[3] = false;
            }
            else
            {
                errorProvider4.Clear();
                verifica[3] = true;
            }
            if (textBoxNumeroCad.Text.Trim() == "")
            {
                errorProvider5.SetError(label5, "Numero Inválido");
                verifica[4] = false;
            }
            else
            {
                errorProvider5.Clear();
                verifica[4] = true;
            }
            if (textBoxBairroCad.Text.Trim() == "")
            {
                errorProvider6.SetError(label6, "Bairro Inválido");
                verifica[5] = false;
            }
            else
            {
                errorProvider6.Clear();
                verifica[5] = true;
            }
            if (textBoxCidadeCad.Text.Trim() == "")
            {
                errorProvider7.SetError(label7, "Cidade Inválido");
                verifica[6] = false;
            }
            else
            {
                errorProvider7.Clear();
                verifica[6] = true;
            }
            if (comboBoxCadUFCad.Text.Trim() == "")
            {
                errorProvider8.SetError(label8, "UF Inválido");
                verifica[7] = false;
            }
            else
            {
                errorProvider8.Clear();
                verifica[7] = true;
            }
            if (verifica[0] == true && verifica[1] == true && verifica[2] == true && verifica[3] == true && verifica[4] == true && verifica[5] == true && verifica[6] == true && verifica[7] == true) 
            {
                SqlConnection conexao = new SqlConnection();

                conexao.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=AcervoMusical;Integrated Security=SSPI";


                conexao.Open();

                if (conexao != null && conexao.State == ConnectionState.Open)
                {
                    SqlCommand inserirPessoa = new SqlCommand();
                    inserirPessoa.CommandText = "INSERT INTO Pessoa (Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF) VALUES('" + textBoxNomeCad.Text + "','" + maskedTextBoxTelefoneCad.Text + "','" + textBoxEmailCad.Text + "','" + textBoxLogradouroCad.Text + "','" + textBoxNumeroCad.Text + "','" + textBoxBairroCad.Text + "','" + textBoxCidadeCad.Text + "','" + comboBoxCadUFCad.Text + "')";
                    inserirPessoa.Connection = conexao;
                    inserirPessoa.ExecuteNonQuery();
                }
                Close();
            }
        }
    }
}
