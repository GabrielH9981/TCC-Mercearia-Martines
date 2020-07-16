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
    public partial class login : Form
    {
        MySqlConnection conexao;
        DataSet ds;
        MySqlDataAdapter da;
        public login()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }

        private void login_Load(object sender, EventArgs e)
        {
            lblData.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
            lblHora.Text = (DateTime.Now.ToString("HH:mm:ss"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strConexao = "server=localhost;database=bdmercearia;uid=root;password=;";
            conexao = new MySqlConnection(strConexao);
            if (txtUsuario.Text != "" || txtSenha.Text != "")
            {
                string sql = "SELECT * FROM login where login = '" + txtUsuario.Text + " ' ";

                MySqlCommand cmdLogin = new MySqlCommand(sql, conexao);
                try
                {
                    conexao.Open();
                    cmdLogin.CommandType = CommandType.Text;
                    da = new MySqlDataAdapter(cmdLogin);
                    ds = new DataSet();
                    da.Fill(ds, "Ok");

                    MySqlDataReader dr = cmdLogin.ExecuteReader();
                    while (dr.Read())
                    {
                        if ((txtUsuario.Text == dr["login"].ToString()) && (txtSenha.Text == dr["senha"].ToString()))
                        {
                            Form fp = new Form1();
                            fp.Show();
                            Hide();
                        }
                    }
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Usuário não cadastro!");
                        txtSenha.Clear();
                        txtUsuario.Clear();
                        txtUsuario.Focus();
                    }
                }
                catch (Exception E)
                { MessageBox.Show(E.Message); }
                finally
                { conexao.Close(); }
            }
            else
            {
                MessageBox.Show("Digite login e senha!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSenha.Text = "";
            txtUsuario.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
