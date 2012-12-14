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
            maskedTextBoxTelefoneAlt.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            bool []verifica = new bool[8];
            if (textBoxNomeAlt.Text.Trim() == "")
            {
                errorProvider1.SetError(label1, "Nome Inválido");
                verifica[0] = false;
            }
            else
            {
                errorProvider1.Clear();
                verifica[0] = true;
            }
            if (maskedTextBoxTelefoneAlt.Text.Trim() == "")
            {
                errorProvider2.SetError(label2, "Telefone Inválido");
                verifica[1] = false;
            }
            else
            {
                errorProvider2.Clear();
                verifica[1] = true;
            }
            if (textBoxEmailAlt.Text.Trim() == "")
            {
                errorProvider3.SetError(label3, "Email Inválido");
                verifica[2] = false;
            }
            else
            {
                errorProvider3.Clear();
                verifica[2] = true;
            }
            if (textBoxLogradouroAlt.Text.Trim() == "")
            {
                errorProvider4.SetError(label4, "Logradouro Inválido");
                verifica[3] = false;
            }
            else
            {
                errorProvider4.Clear();
                verifica[3] = true;
            }
            if (textBoxNumeroAlt.Text.Trim() == "")
            {
                errorProvider5.SetError(label5, "Numero Inválido");
                verifica[4] = false;
            }
            else
            {
                errorProvider5.Clear();
                verifica[4] = true;
            }
            if (textBoxBairroAlt.Text.Trim() == "")
            {
                errorProvider6.SetError(label6, "Bairro Inválido");
                verifica[5] = false;
            }
            else
            {
                errorProvider6.Clear();
                verifica[5] = true;
            }
            if (textBoxCidadeAlt.Text.Trim() == "")
            {
                errorProvider7.SetError(label7, "Cidade Inválido");
                verifica[6] = false;
            }
            else
            {
                errorProvider7.Clear();
                verifica[6] = true;
            }
            if (comboBoxCadUFAlt.Text.Trim() == "")
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
