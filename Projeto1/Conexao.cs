using MySql.Data.MySqlClient;
using System;


namespace Projeto1
{
    class Conexao
    {
        MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=BDProjeto;user=root;pwd=12345678"); //String de conexão(caminho onde vc está se conectando //instancia/ criando apelido
        public static string msg; // variavel  estatica serve para poder mudar o valor da variavel sem armazenar um valor fixo.
        public MySqlConnection ConnectarBD()
        {
            try//tratamento de erros
            {
                con.Open();

            }
            catch (Exception erro)
            {

                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return con;
        }

        public MySqlConnection DesConnectarBD()
        {
            try
            {
                con.Close();

            }
            catch (Exception erro)
            {

                msg = "Ocorreu um erro ao se desconectar" + erro.Message;
            }
            return con;
        }
    }
}
