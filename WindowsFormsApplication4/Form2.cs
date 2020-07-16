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
    public partial class Form2 : Form
    {
        MySqlConnection conexao;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblData.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
            lblHora.Text = (DateTime.Now.ToString("HH:mm:ss"));

            String strConexao = "server=localhost;database=bdmercearia;uid=root;password=;";
            conexao = new MySqlConnection(strConexao);
            try
            {
                conexao.Open();
                MySqlCommand cmdProdutos = new MySqlCommand("SELECT * FROM Produtos ORDER BY CodigoProduto", conexao);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdProdutos;
                DataTable tbProdutos = new DataTable();
                da.Fill(tbProdutos);

                txtCodigo.DataBindings.Add("Text", tbProdutos, "CodigoProduto");
                txtNome.DataBindings.Add("Text", tbProdutos, "NomeProduto");
                txtPreco.DataBindings.Add("Text", tbProdutos, "Preco");


                dataGridView1.DataSource = tbProdutos;

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strConexao = "server=localhost;database=bdmercearia;uid=root;password=;";
            conexao = new MySqlConnection(strConexao);
            try
            {
                conexao.Open();
                MySqlDataAdapter adpProdutos = new MySqlDataAdapter();
                DataTable tbProdutos = new DataTable();
                int CodigoProduto;
                String NomeProduto;
                double Preco;
                CodigoProduto = Convert.ToInt32(txtCodigo.Text);
                NomeProduto = txtNome.Text;
                Preco = Convert.ToDouble(txtPreco.Text);
                String sql = "INSERT INTO Produtos(CodigoProduto, NomeProduto, Preco)VALUES (" + CodigoProduto + ",' " + NomeProduto + "', '" + Preco + "')";
                MySqlCommand adiciona = new MySqlCommand(sql, conexao);

                adpProdutos.SelectCommand = adiciona;
                adpProdutos.Fill(tbProdutos);

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strConexao = "server=localhost;database=bdmercearia;uid=root;password=;";
            conexao = new MySqlConnection(strConexao);

            if (MessageBox.Show("Tem certeza que deseja excluir esse registro?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                MessageBox.Show("Operação Cancelada");
            }
            else
            {
                try
                {
                    conexao.Open();

                    MySqlDataAdapter adpProdutos = new MySqlDataAdapter();
                    DataTable tbProdutos = new DataTable();

                    MySqlCommand exclui = new MySqlCommand("DELETE FROM produtos WHERE CodigoProduto =" + Convert.ToInt16(txtCodigo.Text), conexao);
                    adpProdutos.SelectCommand = exclui;
                    adpProdutos.Fill(tbProdutos);
                    dataGridView1.DataSource = tbProdutos;

                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private void Limpar()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtPreco.Clear();
            txtCodigo.Focus();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            lblData.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
            lblHora.Text = (DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
        
   

