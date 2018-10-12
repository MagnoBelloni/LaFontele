using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace DAL
{
    class Conexao
    {
        public static SqlConnection Abrir()
        {            
            try
            {
                //String de Conexão está na App.config da UI
                string con = System.Configuration.ConfigurationManager.ConnectionStrings["StringConn"].ConnectionString;
                //Deve usar o 'SslMode = none' pelo fato do mysql.data n suportar esse tipo de conexão
                //MySqlConnection conn = new MySqlConnection("server=localhost; user=root; password='';SslMode = none;database=DB_Bar");
                SqlConnection conn = new SqlConnection(con);
                conn.Open();
                return conn;                
            }
            catch
            {
                throw new Exception("Não foi possivel conectar ao Banco de Dados.");
            }
        }

        public static void Fechar()
        {
            if (Conexao.Abrir().State != ConnectionState.Closed)
            {
                Conexao.Abrir().Close();
            }
        }
    }
}