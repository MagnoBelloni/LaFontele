using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LoginBLL
    {
        public static LoginDTO ValidaLogin(LoginDTO obj){
            if (String.IsNullOrWhiteSpace(obj.usuario))
            {
                throw new Exception("Campo Usuário vazio.");
            }
            if(String.IsNullOrWhiteSpace(obj.Senha)){
                throw new Exception("Campo Senha vazio.");
            }
            return LoginDAL.BuscaLogin(obj);
        }
    }
}
