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
    public partial class FormAlteraPessoa : Form
    {
        //variaveis que recebem os parametros do outro form
        int id = 0;
        int alterar = 0;
        public FormAlteraPessoa(int idPessoa, int alterarPessoa)
        {
            id = idPessoa;
            alterar = alterarPessoa;
            InitializeComponent();
        }

        SqlDataReader leitor = null;
        SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");

        private void FormAlteraPessoa_Load(object sender, EventArgs e)
        {
            Atualiza();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (textBoxNomeAlt.Text.Trim() == "")
                errorProvider1.SetError(label1, "Nome Inválido");
            else if (maskedTextBoxTelefoneAlt.Text.Trim() == "")
                errorProvider2.SetError(label2, "Telefone Inválido");
            else if (textBoxEmailAlt.Text.Trim() == "")
                errorProvider3.SetError(label3, "Email Inválido");
            else if (textBoxLogradouroAlt.Text.Trim() == "")
                errorProvider4.SetError(label4, "Logradouro Inválido");
            else if (textBoxNumeroAlt.Text.Trim() == "")
                errorProvider5.SetError(label5, "Numero Inválido");
            else if (textBoxBairroAlt.Text.Trim() == "")
                errorProvider6.SetError(label6, "Bairro Inválido");
            else if (textBoxCidadeAlt.Text.Trim() == "")
                errorProvider7.SetError(label7, "Cidade Inválido");
            else if (comboBoxCadUFAlt.Text.Trim() == "")
                errorProvider8.SetError(label8, "UF Inválido");
            else
            {
                conexao.Open();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE Pessoa SET Nome = @NOME, Telefone = @TELEFONE, Email = @EMAIL, Logradouro = @LOGRADOURO, Numero = @NUMERO, Bairro = @BAIRRO, Cidade = @CIDADE, UF = @UF WHERE Id_Pessoa = @ID_PESSOA;", conexao);
                SqlParameter nome = new SqlParameter("@NOME", textBoxNomeAlt.Text);
                SqlParameter telefone = new SqlParameter("@TELEFONE", maskedTextBoxTelefoneAlt.Text);
                SqlParameter email = new SqlParameter("@EMAIL", textBoxEmailAlt.Text);
                SqlParameter logradouro = new SqlParameter("@LOGRADOURO", textBoxLogradouroAlt.Text);
                SqlParameter numero = new SqlParameter("@NUMERO", textBoxNumeroAlt.Text);
                SqlParameter bairro = new SqlParameter("@BAIRRO", textBoxBairroAlt.Text);
                SqlParameter cidade = new SqlParameter("@CIDADE", textBoxCidadeAlt.Text);
                SqlParameter uf = new SqlParameter("@UF", comboBoxCadUFAlt.Text);
                SqlParameter idPessoa = new SqlParameter("@ID_PESSOA", id);

                cmdUpdate.Parameters.Add(nome);
                cmdUpdate.Parameters.Add(telefone);
                cmdUpdate.Parameters.Add(email);
                cmdUpdate.Parameters.Add(logradouro);
                cmdUpdate.Parameters.Add(numero);
                cmdUpdate.Parameters.Add(bairro);
                cmdUpdate.Parameters.Add(cidade);
                cmdUpdate.Parameters.Add(uf);
                cmdUpdate.Parameters.Add(idPessoa);
                cmdUpdate.ExecuteNonQuery();
                conexao.Close();
                Close();
                Atualiza();
            }
        }

        public void Atualiza()
        {
            //da um select em tudo e manda para o listview
            conexao.Open();

            SqlCommand cmdSelecao = new SqlCommand("SELECT Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF FROM Pessoa WHERE Id_Pessoa = @ID_PESSOA;", conexao);
            SqlParameter idPessoa = new SqlParameter("@ID_PESSOA", id);

            cmdSelecao.Parameters.Add(idPessoa);

            leitor = cmdSelecao.ExecuteReader();

            leitor.Read();
            textBoxNomeAlt.Text = leitor["Nome"].ToString();
            maskedTextBoxTelefoneAlt.Text = leitor["Telefone"].ToString();
            textBoxEmailAlt.Text = leitor["Email"].ToString();
            textBoxLogradouroAlt.Text = leitor["Logradouro"].ToString();
            textBoxNumeroAlt.Text = leitor["Numero"].ToString();
            textBoxBairroAlt.Text = leitor["Bairro"].ToString();
            textBoxCidadeAlt.Text = leitor["Cidade"].ToString();
            comboBoxCadUFAlt.SelectedItem = leitor["UF"].ToString();
            conexao.Close(); 
        }
    }
}
