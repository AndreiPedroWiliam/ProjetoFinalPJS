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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxNomeCad.Text.Trim() == "")
                errorProvider1.SetError(label1, "Nome Inválido");
            else if (maskedTextBoxTelefoneCad.Text.Trim() == "")
                errorProvider2.SetError(label2, "Telefone Inválido");
            else if (textBoxEmailCad.Text.Trim() == "")
                errorProvider3.SetError(label3, "Email Inválido");
            else if (textBoxLogradouroCad.Text.Trim() == "")
                errorProvider4.SetError(label4, "Logradouro Inválido");
            else if (textBoxNumeroCad.Text.Trim() == "")
                errorProvider5.SetError(label5, "Numero Inválido");
            else if (textBoxBairroCad.Text.Trim() == "")
                errorProvider6.SetError(label6, "Bairro Inválido");
            else if (textBoxCidadeCad.Text.Trim() == "")
                errorProvider7.SetError(label7, "Cidade Inválido");
            else if (comboBoxCadUFCad.Text.Trim() == "")
                errorProvider8.SetError(label8, "UF Inválido");
            else
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
