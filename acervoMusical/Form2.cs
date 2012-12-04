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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");

        private void pesquisaPessoa_Click(object sender, EventArgs e)
        {
            conexao.Open();
            listBox1.Items.Clear();
            SqlDataReader leitor = null;
            SqlCommand cmdSelecao = new SqlCommand("SELECT Nome FROM Pessoa WHERE Nome LIKE '%"+textBox1.Text+"%';", conexao);
            leitor = cmdSelecao.ExecuteReader();
            while (leitor.Read())
            {
                listBox1.Items.Add(leitor["Nome"].ToString());
            }
            conexao.Close();
        }

        private void pesquisaAlbum_Click(object sender, EventArgs e)
        {
            conexao.Open();
            listBox2.Items.Clear();
            SqlDataReader leitor = null;
            SqlCommand cmdSelecao = new SqlCommand("SELECT Album FROM Album WHERE Album LIKE '%" + textBox2.Text + "%' AND TipoMidia!= 'Digital' AND Status= 'Disponível';", conexao);
            leitor = cmdSelecao.ExecuteReader();
            
            while (leitor.Read())
            {
                listBox2.Items.Add(leitor["Album"].ToString());
            }
            conexao.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() != "" && listBox2.SelectedItem.ToString() != "")
            {
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
                conexao.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.ToString() != "")
            {
                listView1.FocusedItem.Remove();
            }
        }
    }
}
