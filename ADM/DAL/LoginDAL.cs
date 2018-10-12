using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LoginDAL
    {
        public static LoginDTO BuscaLogin(LoginDTO obj)
        {
            try
            {
                String sql = "SELECT * FROM TB_LOGIN where USU_LOGIN=@usuario AND SENHA_LOGIN=@senha";
                SqlCommand cm = new SqlCommand(sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@usuario", obj.usuario);
                cm.Parameters.AddWithValue("@senha", obj.Senha);
                SqlDataReader ler = cm.ExecuteReader();
                while (ler.Read())
                {
                    if (ler.HasRows)
                    {
                        obj.id = int.Parse(ler["ID_LOGIN"].ToString());
                        obj.usuario = ler["USU_LOGIN"].ToString();
                        obj.Senha = ler["SENHA_LOGIN"].ToString();
                        return obj;
                    }                    
                    throw new Exception("Usuario não encontrado.");
                }
                throw new Exception("Usuario não encontrado.");
            }
            catch
            {
                throw new Exception("Usuario não encontrado.");
            }
        }
    }
}