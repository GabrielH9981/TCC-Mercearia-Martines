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
    public partial class Form4 : Form
    {
        DataSet ds;
        MySqlDataAdapter da;
        MySqlConnection conexao;

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strConexao = "server=localhost;database=bdmercearia;uid=root;password=";
            conexao = new MySqlConnection(strConexao);
            if (comboBox1.Text != "")
            {
                string sql = "SELECT * FROM Vendas where FormaPagamento like '%" + comboBox1.Text + "%'";
                MySqlCommand cmdVendas = new MySqlCommand(sql, conexao);
                try
                {
                    conexao.Open();
                    cmdVendas.CommandType = CommandType.Text;
                    da = new MySqlDataAdapter(cmdVendas);
                    ds = new DataSet();
                    da.Fill(ds, "Ok");
                    dataGridView1.DataSource = ds.Tables[0];
                    MySqlDataReader dr = cmdVendas.ExecuteReader();
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
                MessageBox.Show("Digite a Forma de Pagamento !");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
