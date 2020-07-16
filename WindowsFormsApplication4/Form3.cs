using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication4
{
    public partial class Form3 : Form
    {
        DataSet ds;
        MySqlDataAdapter da;
        MySqlConnection conexao;

    
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strConexao = "server=localhost;database=bdmercearia;uid=root;password=";
            conexao = new MySqlConnection(strConexao);
            if (textBox1.Text != "")
            {
                string sql = "SELECT * FROM Produtos where CodigoProduto like '%" + textBox1.Text + "%'";
                MySqlCommand cmdProduto = new MySqlCommand(sql, conexao);
                try
                {
                    conexao.Open();
                    cmdProduto.CommandType = CommandType.Text;
                    da = new MySqlDataAdapter(cmdProduto);
                    ds = new DataSet();
                    da.Fill(ds, "Ok");
                    dataGridView1.DataSource = ds.Tables[0];
                    MySqlDataReader dr = cmdProduto.ExecuteReader();
                    if (dr.HasRows == false)
                    { throw new Exception("Não há registro !"); }
                    else
                    { dr.Read(); }
                }
                catch (Exception E)
                { MessageBox.Show(E.Message); }
                finally
                { conexao.Close(); }
            }
            else
            {
                MessageBox.Show("Digite o código do produto !");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
