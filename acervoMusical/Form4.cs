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
        DataRow registro;
        DataSet dados;
        SqlDataAdapter adaptadorReg = new SqlDataAdapter();
        bool atualiza = false;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection();

            conexao.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=AcervoMusical;Integrated Security=SSPI";

            SqlCommand selecaoPessoa = new SqlCommand("select Nome, Telefone, Logradouro, Numero, Bairro, Cidade, Email", conexao);

            //Comando para Inserção
            SqlCommand InsercaoPessoa = new SqlCommand("Insert into Pessoas (Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF) values (@Nome, @Telefone,@Email, @Logradouro, @Numero, @Bairro, @Cidade, @UF)", conexao);

            SqlParameter Nome = new SqlParameter("@Nome", SqlDbType.VarChar, 60);
            Nome.SourceColumn = "Nome";
            InsercaoPessoa.Parameters.Add(Nome);

            SqlParameter Telefone = new SqlParameter("@Telefone", SqlDbType.VarChar, 13);
            Telefone.SourceColumn = "Telefone";
            Telefone.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Telefone);

            SqlParameter Email = new SqlParameter("@Email", SqlDbType.VarChar, 60);
            Email.SourceColumn = "Email";
            Email.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Email);

            SqlParameter Logradouro = new SqlParameter("@Logradouro", SqlDbType.VarChar, 60);
            Logradouro.SourceColumn = "Logradouro";
            Logradouro.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Logradouro);

            SqlParameter Numero = new SqlParameter("@Numero", SqlDbType.VarChar, 5);
            Numero.SourceColumn = "Numero";
            Numero.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Numero);

            SqlParameter Bairro = new SqlParameter("@Bairro", SqlDbType.VarChar, 60);
            Bairro.SourceColumn = "Bairro";
            Bairro.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Bairro);

            SqlParameter Cidade = new SqlParameter("@Cidade", SqlDbType.VarChar, 60);
            Cidade.SourceColumn = "Cidade";
            Cidade.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Cidade);

            SqlParameter UF = new SqlParameter("@UF", SqlDbType.VarChar, 2);
            UF.SourceColumn = "UF";
            UF.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(UF);

            //Nome, Telefone, Email, Logradouro, Numero, Bairro, Cidade, UF
            //Comandos para Atualização
            SqlCommand AtualizacaoPessoa = new SqlCommand("Update Tabela set Nome = @Nome, Telefone = @Telefone, Email = @Email, Logradouro = @logradouro, Numero = @Numero, Bairro = @Bairro, Cidade = @Cidade,UF = @UF ", conexao);

            Nome = new SqlParameter("@Nome", SqlDbType.VarChar, 60);
            Nome.SourceColumn = "Nome";
            Nome.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Nome);

            Telefone = new SqlParameter("@Telefone", SqlDbType.VarChar, 13);
            Telefone.SourceColumn = "Telefone";
            Telefone.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Telefone);

            Email = new SqlParameter("@Email", SqlDbType.VarChar, 60);
            Email.SourceColumn = "Email";
            Email.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Email);

            Logradouro = new SqlParameter("@Logradouro", SqlDbType.VarChar, 60);
            Logradouro.SourceColumn = "Logradouro";
            Logradouro.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Logradouro);

            Numero = new SqlParameter("@Numero", SqlDbType.VarChar, 5);
            Numero.SourceColumn = "Numero";
            Numero.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Numero);

            Bairro = new SqlParameter("@Bairro", SqlDbType.VarChar, 60);
            Bairro.SourceColumn = "Bairro";
            Bairro.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Bairro);

            Cidade = new SqlParameter("@Cidade", SqlDbType.VarChar, 60);
            Cidade.SourceColumn = "Cidade";
            Cidade.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Cidade);

            UF = new SqlParameter("@UF", SqlDbType.VarChar, 2);
            UF.SourceColumn = "UF";
            UF.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(UF);
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (textBoxNomeCad.Text == "")
            {
                errorProvider1.SetError(label1, "Nome Inválido");
              
            }

            else if (maskedTextBoxTelefoneCad.Text == "")
            {
                errorProvider2.SetError(label2, "Telefone Inválido");
            }

            else if (textBoxEmailCad.Text == "")
            {
                errorProvider3.SetError(label3, "Email Inválido");
            }

            else if (textBoxLogradouroCad.Text == "")
            {
                errorProvider4.SetError(label4, "Logradouro Inválido");
            }

            else if (textBoxNumeroCad.Text == "")
            {
                errorProvider5.SetError(label5, "Numero Inválido");
            }

            else if (textBoxBairroCad.Text == "")
            {
                errorProvider6.SetError(label6, "Bairro Inválido");
            }

            else if (textBoxCidadeCad.Text == "")
            {
                errorProvider7.SetError(label7, "Cidade Inválido");
            }

            else if (comboBoxCadUF.Text == "")
            {
                errorProvider8.SetError(label8, "UF Inválido");
            }
            else
            {
                foreach (DataRow registro in dados.Tables["Pessoa"].Rows)
                    if (textBoxNomeCad.Text == registro["Nome"].ToString())
                        //categoria = int.Parse(registro["CodigoCat"].ToString());
                        if (atualiza)
                        {
                            registro["Telefone"] = maskedTextBoxTelefoneCad.Text;
                            registro["Email"] = textBoxEmailCad.Text;
                            registro["Logradouro"] = textBoxLogradouroCad.Text;
                            registro["Numero"] = textBoxNumeroCad.Text;
                            registro["Bairro"] = textBoxBairroCad.Text;
                            registro["Cidade"] = textBoxCidadeCad.Text;
                            registro["UF"] = comboBoxCadUF.Text;
                            adaptadorReg.Update(dados, "Pessoa");
                        }
                        else
                        {
                            //labelCampoPreenchimento.Visible = false;
                            DataRow novoRegistroPessoa = dados.Tables["Pessoa"].NewRow();
                            novoRegistroPessoa["Telefone"] = maskedTextBoxTelefoneCad.Text;
                            novoRegistroPessoa["Email"] = textBoxEmailCad.Text;
                            novoRegistroPessoa["Logradouro"] = textBoxLogradouroCad.Text;
                            novoRegistroPessoa["Numero"] = textBoxNumeroCad.Text;
                            novoRegistroPessoa["Bairro"] = textBoxBairroCad.Text;
                            novoRegistroPessoa["Cidade"] = textBoxCidadeCad.Text;
                            novoRegistroPessoa["UF"] = comboBoxCadUF.Text;
                            dados.Tables["Pessoa"].Rows.Add(novoRegistroPessoa);
                            adaptadorReg.Update(dados, "Pessoa");
                        }
                Close();
            }
        }
    }
}
