using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Form1 = new Form2();
            Form1.Show();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 Form1 = new Form3();
            Form1.Show();
        }

        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 Form1 = new Form4();
            Form1.Show();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 Form1 = new Form5();
            Form1.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblData.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
            lblHora.Text = (DateTime.Now.ToString("HH:mm:ss"));
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
