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
    public partial class FormDevolver : Form
    {
        int id = 0;
        public FormDevolver(int idMidia)
        {
            id = idMidia;
            InitializeComponent();
        }
        SqlDataReader leitor = null;
        SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=AcervoMusical; Integrated Security=SSPI");

        private void FormDevolver_Load(object sender, EventArgs e)
        {

        }


        
        }
    }
