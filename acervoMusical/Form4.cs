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
            SqlConnection conexao = new SqlConnection();

            conexao.ConnectionString = "Data Source=(local);Initial Catalog=SistemaFinanceiro;Integrated Security=SSPI";

            SqlCommand selecaoPessoa = new SqlCommand("select Nome, Telefone, Logradouro, Numero, Bairro, Cidade, Email", conexao);

            //Comando para Inserção
            SqlCommand InsercaoPessoa = new SqlCommand("Insert into Tabela (Nome, Telefone, Logradouro, Numero, Bairro, Cidade, Email) values (@Nome, @Telefone, @Logradouro, @Numero, @Bairro, @Cidade, @Email)", conexao);

            SqlParameter Nome = new SqlParameter("@Nome", SqlDbType.VarChar, 40);
            Nome.SourceColumn = "Nome";
            InsercaoPessoa.Parameters.Add(Nome);

            SqlParameter Telefone = new SqlParameter("@Telefone", SqlDbType.Decimal);
            Telefone.SourceColumn = "Telefone";
            Telefone.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Telefone);

            SqlParameter Logradouro = new SqlParameter("@Logradouro", SqlDbType.VarChar, 40);
            Logradouro.SourceColumn = "Logradouro";
            Logradouro.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Logradouro);

            SqlParameter Numero = new SqlParameter("@Numero", SqlDbType.Decimal);
            Numero.SourceColumn = "Numero";
            Numero.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Numero);

            SqlParameter Bairro = new SqlParameter("@Bairro", SqlDbType.VarChar, 40);
            Bairro.SourceColumn = "Bairro";
            Bairro.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Bairro);

            SqlParameter Cidade = new SqlParameter("@Cidade", SqlDbType.VarChar, 40);
            Cidade.SourceColumn = "Cidade";
            Cidade.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Cidade);

            SqlParameter Email = new SqlParameter("@Email", SqlDbType.VarChar, 40);
            Email.SourceColumn = "Email";
            Email.SourceVersion = DataRowVersion.Current;
            InsercaoPessoa.Parameters.Add(Email);

            //Comandos para Atualização
            SqlCommand AtualizacaoPessoa = new SqlCommand("Update Tabela set Nome = @Nome, Telefone = @Telefone, Logradouro = @logradouro, Numero = @Numero, Bairro = @Bairro, Cidade = @Cidade, Email = @Email", conexao);

            Nome = new SqlParameter("@Nome", SqlDbType.VarChar, 40);
            Nome.SourceColumn = "Nome";
            Nome.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Nome);

            Telefone = new SqlParameter("@Telefone", SqlDbType.Decimal);
            Telefone.SourceColumn = "Telefone";
            Telefone.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Telefone);

            Logradouro = new SqlParameter("@Logradouro", SqlDbType.VarChar, 40);
            Logradouro.SourceColumn = "Logradouro";
            Logradouro.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Logradouro);

            Numero = new SqlParameter("@Numero", SqlDbType.Decimal);
            Numero.SourceColumn = "Numero";
            Numero.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Numero);

            Bairro = new SqlParameter("@Bairro", SqlDbType.VarChar, 40);
            Bairro.SourceColumn = "Bairro";
            Bairro.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Bairro);

            Cidade = new SqlParameter("@Cidade", SqlDbType.VarChar, 40);
            Cidade.SourceColumn = "Cidade";
            Cidade.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Cidade);

            Email = new SqlParameter("@Email", SqlDbType.VarChar, 40);
            Email.SourceColumn = "Email";
            Email.SourceVersion = DataRowVersion.Current;
            AtualizacaoPessoa.Parameters.Add(Email);


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
