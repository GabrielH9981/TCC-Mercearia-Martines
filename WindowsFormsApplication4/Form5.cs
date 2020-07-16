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
    public partial class Form5 : Form
    {
        MySqlConnection conexao;
           double total=0, a;
         
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            lblData.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
            lblHora.Text = (DateTime.Now.ToString("HH:mm:ss"));

            String strConexao = "server=localhost;database=bdmercearia;uid=root;password=;";
            conexao = new MySqlConnection(strConexao);
            try
            {
                conexao.Open();
                MySqlCommand cmdVendas = new MySqlCommand("SELECT * FROM Vendas ORDER BY CodigoVenda", conexao);
                MySqlDataAdapter da1 = new MySqlDataAdapter();
                da1.SelectCommand = cmdVendas;
                DataTable tbVendas = new DataTable();
                da1.Fill(tbVendas);

                MySqlCommand cmdVendaDetalhes = new MySqlCommand("SELECT * FROM Venda_detalhes ORDER BY CodigoVenda", conexao);
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                da2.SelectCommand = cmdVendaDetalhes;
                DataTable tbVendaDetalhes = new DataTable();
                da2.Fill(tbVendaDetalhes);
               

                MySqlCommand cmdProdutos = new MySqlCommand("SELECT * FROM Produtos ORDER BY CodigoProduto", conexao);
                MySqlDataAdapter da3 = new MySqlDataAdapter();
                da3.SelectCommand = cmdProdutos;
                DataTable tbProdutos = new DataTable();
                da3.Fill(tbProdutos);
                comboBox1.DataSource = tbProdutos;
                comboBox1.DisplayMember = "NomeProduto";
                comboBox1.ValueMember = "CodigoProduto";
                lblPreco.DataBindings.Add("Text", tbProdutos, "Preco");
                txtCodProd.DataBindings.Add("Text", tbProdutos, "CodigoProduto");


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

        private void button4_Click(object sender, EventArgs e)
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

                    MySqlDataAdapter adpVendas = new MySqlDataAdapter();
                    DataTable tbVendas = new DataTable();

                    MySqlCommand exclui = new MySqlCommand("DELETE FROM Vendas WHERE CodigoVenda =" + Convert.ToInt16(txtCodVenda.Text), conexao);
                    adpVendas.SelectCommand = exclui;
                    adpVendas.Fill(tbVendas);
                  

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

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCodProd.Text = "";
            txtCodVenda.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            txtCodVenda.Focus();
            comboBox1.Text = "";
            comboBox2.Text = "";
            dataGridView1.Rows.Clear();
            lblSubTotal.Text = "0";
            lblPreco.Text = "0";
            label5.Text = "0";
            txtQuant.Text = "";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strConexao = "server=localhost;database=bdmercearia;uid=root;password=;";
            conexao = new MySqlConnection(strConexao);
            try
            {
                conexao.Open();
                MySqlDataAdapter adpVendas = new MySqlDataAdapter();
                DataTable tbVendas = new DataTable();
                double PrecoTotal;
                String FormaPagamento;
                String DataVenda;
                int CodigoVenda = Convert.ToInt32(txtCodVenda.Text);
                PrecoTotal = Convert.ToDouble(textBox2.Text);
                FormaPagamento = comboBox2.Text;
                DataVenda = maskedTextBox1.Text;
                String sql = "INSERT INTO Vendas(CodigoVenda, PreçoTotal,FormaPagamento, DataVenda) VALUES (" + CodigoVenda + ", " + PrecoTotal + ",' " + FormaPagamento + "','" + DataVenda +"')";
                MySqlCommand adiciona = new MySqlCommand(sql, conexao);

                adpVendas.SelectCommand = adiciona;
                adpVendas.Fill(tbVendas);

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

        private void button1_Click(object sender, EventArgs e)
        {


         

            a = Convert.ToDouble(lblPreco.Text) * Convert.ToDouble(txtQuant.Text);
                
            
            lblSubTotal.Text = a.ToString();
            total = total + a;
     
            label5.Text = total.ToString();

                dataGridView1.Rows.Add(txtCodProd.Text, comboBox1.Text, lblPreco.Text, a);

      
           
            
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void txtCodVenda_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = label5.Text;
        }
    }
}

        
    

