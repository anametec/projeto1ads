using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace Projeto1
{
    public partial class frmLogin : Form
    {
        // INSTANCIANDO A STRING DE CONEXÃO
        Conexao con = new Conexao(); 

        public frmLogin()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" && txtSenha.Text == "")
            {
                MessageBox.Show("Usuário e Senha Invalido");
            }
            try
            {
                string sql = "select * from tbLogin where usuario =@user and senha = @senha"; //ele está dando o tipo de variavel (string) colocando o nome de sql e depois atribui = " "
                MySqlCommand cmd = new MySqlCommand(sql, con.ConnectarBD()); // Instanciando o mysqlcommand no cmd = 
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = txtUsuario.Text;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = txtSenha.Text;
                MySqlDataReader dados;
                dados = cmd.ExecuteReader();

                if (dados.HasRows)
                {
                    MessageBox.Show("Seja bem-vindo ao sistema");
                    frmMenu menu = new frmMenu();
                    this.Hide();
                    menu.Show();
                }
                else
                {
                    txtUsuario.Clear();
                    txtSenha.Clear();
                    txtUsuario.Focus();
                }
            }

            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                con.DesConnectarBD();
            }

        }

    }
    }
