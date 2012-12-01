﻿using System;
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
    public partial class FormPesquisaPessoa : Form
    {
        public FormPesquisaPessoa()
        {
            InitializeComponent();
        }

        private void FormPesquisaMidia_Load(object sender, EventArgs e)
        {

        }

        private void pesquisaPessoa_Click(object sender, EventArgs e)
        {
            SqlDataReader leitor = null;
            SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");


            try
            {
                // Verifica se a conexão está aberta
                if (conexao.State == ConnectionState.Open)
                {
                    // Fecha a conexão, limpa o leitor e limpa a lista, para o novo carregamento 
                    conexao.Close();
                    leitor = null;
                    listViewPesquisaPessoa.Items.Clear();
                }

                conexao.Open();

                // Comando que retorna os campos para o carregamento do ListViewPesquisa
                SqlCommand cmdSelecao = new SqlCommand("SELECT Id_Pessoa, Nome, Telefone, Email FROM Pessoa WHERE LOWER(Nome) LIKE @NomeLower OR UPPER(Nome) LIKE @NomeUpper ", conexao);
                SqlParameter nomeLower = new SqlParameter("@NomeLower", "%" + textBoxNome.Text.ToLower() + "%");
                SqlParameter nomeUpper = new SqlParameter("@NomeUpper", "%" + textBoxNome.Text.ToUpper() + "%");
                cmdSelecao.Parameters.Add(nomeLower);
                cmdSelecao.Parameters.Add(nomeUpper);

                
                leitor = cmdSelecao.ExecuteReader();
                listViewPesquisaPessoa.Items.Clear();
                
                while (leitor.Read())
                {
                    ListViewItem Id_Pessoa = new ListViewItem(leitor["Id_Pessoa"].ToString());

                    ListViewItem.ListViewSubItem Nome = new ListViewItem.ListViewSubItem();

                    ListViewItem.ListViewSubItem Telefone = new ListViewItem.ListViewSubItem();

                    ListViewItem.ListViewSubItem Email = new ListViewItem.ListViewSubItem();


                    Nome.Text = leitor["Nome"].ToString();
                    Id_Pessoa.SubItems.Add(Nome);

                    Telefone.Text = leitor["Telefone"].ToString();
                    Id_Pessoa.SubItems.Add(Telefone);

                    Email.Text = leitor["Email"].ToString();
                    Id_Pessoa.SubItems.Add(Email);

                    listViewPesquisaPessoa.Items.Add(Id_Pessoa);
                }


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro " + erro);
            }
            finally
            {
                if (leitor != null)
                    leitor.Close();  
            }
        }
    }
}