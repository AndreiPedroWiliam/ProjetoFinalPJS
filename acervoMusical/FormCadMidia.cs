﻿using System;
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
            if (comboBoxMidia.Text == "")
                errorProvider2.SetError(label20, "Mídia inválida");
            else if (comboBoxMidia.Text != "")
                errorProvider2.Clear();
            if (comboBoxMidia.Text != "")
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
    }
}