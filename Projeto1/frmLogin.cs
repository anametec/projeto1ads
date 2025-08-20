using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Projeto1
{
    public partial class frmLogin : Form
    {
        // Instanciando a string de conexão
        Conexao con = new Conexao();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" && txtSenha.Text == "") // Caso deixar espaço em branco, aparecer inválido
            {
                MessageBox.Show("Usuário e senha inválidos");
            }

            try
            {
                string sql = "select * from tbLogin where usuario=@user and senha=@senha "; // Buscar no Banco de Dados usuário e senha
                MySqlCommand cmd = new MySqlCommand(sql, con.ConnectarBD()); // Conectando os dados
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = txtUsuario.Text;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = txtSenha.Text;
                MySqlDataReader dados;
                dados = cmd.ExecuteReader();

                if(dados.HasRows)
                {
                    MessageBox.Show("Seja bem-vindo ao sistema");
                    frmMenu menu = new frmMenu(); // Troca dos menus
                    this.Hide();
                    menu.Show();
                }
                else // Apagar os campos usuário e senha
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
                con.DesConnectarBD(); // Desconectando os dados
            }

        }
    }
}
