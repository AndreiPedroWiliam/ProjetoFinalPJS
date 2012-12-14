using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;

namespace acervoMusical
{
    public partial class FormEmprestimo : Form
    {
        int id = 0;
        public FormEmprestimo(int idMidia)
        {
            id = idMidia;
            InitializeComponent();
        }

        SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            //string para mensagem
            string mensagem = "*Selecione um";
            if (listBox1.SelectedItem != null && listBox2.SelectedItem != null)
            {
                labelMensagem.Text = "";
                conexao.Open();
                SqlCommand dados = new SqlCommand("SELECT Interprete,TipoMidia FROM Album WHERE Album = '"+listBox2.SelectedItem.ToString()+"';",conexao);
                SqlDataReader leitor = null;
                leitor = dados.ExecuteReader();
                ListViewItem a = new ListViewItem();
                a.Text = listBox1.SelectedItem.ToString();
                a.SubItems.Add(listBox2.SelectedItem.ToString());
                leitor.Read();
                a.SubItems.Add(leitor["Interprete"].ToString());
                a.SubItems.Add(leitor["TipoMidia"].ToString());
                listView1.Items.Add(a);
                listBox1.Enabled = false;
                listBox2.Enabled = false;
                buttonAdicionar.Enabled = false;
                buttonEmprestar.Visible = true;
                buttonCancelar.Visible = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                conexao.Close();
            }
            else if (listBox1.SelectedItem == null)
            {
                mensagem += " amigo";
                labelMensagem.Text = mensagem;
                labelMensagem.ForeColor = Color.DarkRed;
            }
            if (listBox2.SelectedItem == null)
            {
                if (listBox1.SelectedItem == null)
                {
                    mensagem += " e um álbum";
                }
                else
                {
                    mensagem = "*Selecione um álbum";
                }
                labelMensagem.ForeColor = Color.DarkRed;
                labelMensagem.Text = mensagem;
            }
            
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            //cancela e limpa
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            listView1.Items.Clear();
            listBox1.Enabled = true;
            listBox2.Enabled = true;
            buttonEmprestar.Visible = false;
            buttonCancelar.Visible = false;
            buttonAdicionar.Enabled = true;
        }

        private void buttonEmprestar_Click(object sender, EventArgs e)
        {
            conexao.Open();
            string idamigo;
            string idalbum;
            SqlDataReader leitor = null;
            if (conexao != null && conexao.State == ConnectionState.Open)
            {
                //pesquisa amigo
                SqlCommand idpessoa = new SqlCommand("SELECT Id_Pessoa FROM Pessoa where Nome = '" + listBox1.SelectedItem + "';", conexao);
                leitor = idpessoa.ExecuteReader();
                leitor.Read();
                idamigo = leitor["Id_Pessoa"].ToString();
                leitor.Close();
                //pesquisa album
                SqlCommand idmusica = new SqlCommand("SELECT * FROM Album where Album = '" + listBox2.SelectedItem + "';", conexao);
                leitor = idmusica.ExecuteReader();
                leitor.Read();
                idalbum = leitor["Id_Album"].ToString();
                leitor.Close();
                SqlCommand muda = new SqlCommand("UPDATE Album SET Status = 'Emprestado' WHERE Id_Album = '" + idalbum + "';",conexao);
                muda.ExecuteNonQuery();

                string data = DateTime.Now.ToString("yyyy-MM-dd");
      SqlCommand empresta = new SqlCommand("INSERT INTO Emprestimo (DataEmprestimo, DataDevolucao, Id_Pessoa, Id_Album) VALUES ('"+data+"', null , '"+idamigo+"', '"+idalbum+"');",conexao);
                empresta.Connection = conexao;
                empresta.ExecuteNonQuery();
            }
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conexao.Open();
            listBox1.Items.Clear();
            SqlDataReader leitor = null;
            SqlCommand cmdSelecao = new SqlCommand("SELECT Nome FROM Pessoa WHERE Nome LIKE '%" + textBox1.Text + "%';", conexao);
            leitor = cmdSelecao.ExecuteReader();
            while (leitor.Read())
            {
                listBox1.Items.Add(leitor["Nome"].ToString());
            }
            conexao.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            conexao.Open();
            listBox2.Items.Clear();
            SqlDataReader leitor = null;
            SqlCommand cmdSelecao = new SqlCommand("SELECT Album FROM Album WHERE Album LIKE '%" + textBox2.Text + "%' AND TipoMidia!= 'Digital' AND Status = 'Disponível';", conexao);
            leitor = cmdSelecao.ExecuteReader();
            while (leitor.Read())
            {
                listBox2.Items.Add(leitor["Album"].ToString());
            }
            conexao.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conexao.Open();
            SqlDataReader leitor = null;
            SqlCommand leitorlist = new SqlCommand("SELECT Album FROM Album WHERE Id_Album = '" + id + "';", conexao);
            leitor = leitorlist.ExecuteReader();
            while (leitor.Read())
            {
                listBox2.Items.Add(leitor["Album"].ToString());
            }
            listBox2.SelectedItem = listBox2.Items[0];
            conexao.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal a = new Principal();
            
        }
    }
}
