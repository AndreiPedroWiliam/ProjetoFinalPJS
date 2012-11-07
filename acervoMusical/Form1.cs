using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace acervoMusical
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void mídiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem a = new ListViewItem();
            //a = listViewPesquisa;
        }

        private void emprestarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emprestimo a = new Emprestimo();
            a.Show();
        }

        private void amigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            a.Show();
        }

    }
}
