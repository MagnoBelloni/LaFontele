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
    public class FuncionarioDAL
    {
        public static String CadastrarFuncionario(FuncionarioDTO obj)
        {
            try
            {
                String sucesso = "";
                String sql = "INSERT INTO TB_FUNCIONARIO(NM_FUNCIONARIO, TEL_FUNCIONARIO, CEL_FUNCIONARIO, RG_FUNCIONARIO,"
                + " CPF_FUNCIONARIO, CIDADE_FUNCINARIO, BAIRRO_FUNCIONARIO, LOGRADOURO_FUNCIONARIO, N_FUNCIONARIO, COMPLEMENTO_FUNCIONARIO,"
                + " IDENTIFICADOR_FUNCIONARIO, BANCO_FUNCIONARIO, CONTA_FUNCIONARIO, AGENCIA_FUNCIONARIO)"
                + " VALUES (@nome,@tel,@cel,@rg,@cpf,@cidade,@bairro,@logradouro,@n,@complemento,@id,@banco,@conta,@agencia)";
                SqlCommand cm = new SqlCommand(sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@nome", obj.Nome);
                cm.Parameters.AddWithValue("@tel", obj.Telefone);
                cm.Parameters.AddWithValue("@cel", obj.Celular);
                cm.Parameters.AddWithValue("@rg", obj.RG);
                cm.Parameters.AddWithValue("@cpf", obj.CPF);
                cm.Parameters.AddWithValue("@cidade", obj.Cidade);
                cm.Parameters.AddWithValue("@bairro", obj.Bairro);
                cm.Parameters.AddWithValue("@logradouro", obj.Logradouro);
                cm.Parameters.AddWithValue("@n", obj.N);
                cm.Parameters.AddWithValue("@complemento", obj.Complemento);
                cm.Parameters.AddWithValue("@id", obj.Identificacao);
                cm.Parameters.AddWithValue("@banco", obj.Banco);
                cm.Parameters.AddWithValue("@conta", obj.Conta);
                cm.Parameters.AddWithValue("@agencia", obj.Agencia);
                cm.ExecuteNonQuery();
                sucesso = "Funcionario cadastrado com sucesso!!";
                return sucesso;
            }
            catch
            {
                throw new Exception("Problema na Conexão");
            }
            finally
            {
                Conexao.Fechar();
            }
        }

        public static FuncionarioDTO BuscaFuncionario(String cpf)
        {
            try
            {
                FuncionarioDTO obj = new FuncionarioDTO();
                String sql = "SELECT  * FROM TB_FUNCIONARIO WHERE CPF_FUNCIONARIO = @cpf";
                SqlCommand cm = new SqlCommand(sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@cpf", cpf);
                SqlDataReader ler = cm.ExecuteReader();
                while (ler.Read())
                {
                    if (ler.HasRows)
                    {
                        obj.id = int.Parse(ler["ID_FUNCIONARIO"].ToString());
                        obj.Nome = ler["NM_FUNCIONARIO"].ToString();
                        obj.Telefone = ler["TEL_FUNCIONARIO"].ToString();
                        obj.Celular = ler["CEL_FUNCIONARIO"].ToString();
                        obj.RG = ler["RG_FUNCIONARIO"].ToString();
                        obj.CPF = ler["CPF_FUNCIONARIO"].ToString();
                        obj.Cidade = ler["CIDADE_FUNCINARIO"].ToString();
                        obj.Bairro = ler["BAIRRO_FUNCIONARIO"].ToString();
                        obj.Logradouro = ler["LOGRADOURO_FUNCIONARIO"].ToString();
                        obj.N = ler["N_FUNCIONARIO"].ToString();
                        obj.Complemento = ler["COMPLEMENTO_FUNCIONARIO"].ToString();
                        obj.Identificacao = ler["IDENTIFICADOR_FUNCIONARIO"].ToString();
                        obj.Banco = ler["BANCO_FUNCIONARIO"].ToString();
                        obj.Conta = ler["CONTA_FUNCIONARIO"].ToString();
                        obj.Agencia = ler["AGENCIA_FUNCIONARIO"].ToString();
                        return obj;
                    }                    
                    throw new Exception("CPF não encontrado.");
                }
                throw new Exception("CPF não encontrado.");
            }
            catch
            {
                throw new Exception("Usuario não encontrado.");
            }
            finally
            {
                Conexao.Fechar();
            }
        }

        public static string AtualizaFuncionario(FuncionarioDTO obj)
        {
            try
            {
                String sucesso = "";
                String sql = "UPDATE TB_FUNCIONARIO"
                + " SET NM_FUNCIONARIO=@nome, TEL_FUNCIONARIO=@tel, CEL_FUNCIONARIO=@cel, RG_FUNCIONARIO=@rg,"
                + " CPF_FUNCIONARIO=@cpf, CIDADE_FUNCINARIO=@cidade, BAIRRO_FUNCIONARIO=@bairro, "
                + " LOGRADOURO_FUNCIONARIO=@logradouro, N_FUNCIONARIO=@n, COMPLEMENTO_FUNCIONARIO=@complemento,"
                + " IDENTIFICADOR_FUNCIONARIO=@ide, BANCO_FUNCIONARIO=@banco, CONTA_FUNCIONARIO=@conta," 
                + " AGENCIA_FUNCIONARIO=@agencia"
                + " WHERE ID_FUNCIONARIO=@id";
                
                SqlCommand cm = new SqlCommand(sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@id", obj.id);
                cm.Parameters.AddWithValue("@nome", obj.Nome);
                cm.Parameters.AddWithValue("@tel", obj.Telefone);
                cm.Parameters.AddWithValue("@cel", obj.Celular);
                cm.Parameters.AddWithValue("@rg", obj.RG);
                cm.Parameters.AddWithValue("@cpf", obj.CPF);
                cm.Parameters.AddWithValue("@cidade", obj.Cidade);
                cm.Parameters.AddWithValue("@bairro", obj.Bairro);
                cm.Parameters.AddWithValue("@logradouro", obj.Logradouro);
                cm.Parameters.AddWithValue("@n", obj.N);
                cm.Parameters.AddWithValue("@complemento", obj.Complemento);
                cm.Parameters.AddWithValue("@ide", obj.Identificacao);
                cm.Parameters.AddWithValue("@banco", obj.Banco);
                cm.Parameters.AddWithValue("@conta", obj.Conta);
                cm.Parameters.AddWithValue("@agencia", obj.Agencia);
                cm.ExecuteNonQuery();
                sucesso = "Funcionario atualizado com sucesso!!";
                return sucesso;
            }
            catch
            {
                throw new Exception("Problema na Conexão");
            }
            finally
            {
                Conexao.Fechar();
            }
        }

        /*public static FuncionarioDTO Testa(FuncionarioDTO obj)
        {
            try            {
                string Sql = "SELECT * FROM TB_FUNCIONARIO WHERE ID_FUNCIONARIO = @id";
                SqlCommand cm = new SqlCommand(Sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@id", obj.id);
                SqlDataReader ler = cm.ExecuteReader();
                while (ler.Read())
                {
                    if (ler.HasRows)
                    {
                        obj.RG = ler["RG_FUNCIONARIO"].ToString();
                        obj.CPF = ler["CPF_FUNCIONARIO"].ToString();
                        obj.Identificacao = ler["IDENTIFICADOR_FUNCIONARIO"].ToString();
                        return obj;
                    }
                }
                throw new Exception("Não encontrado");
            }            
            catch
            {
                throw new Exception("Problema na Conexão.");
            }
            finally
            {
                Conexao.Fechar();
            }

        }*/

        public static bool TestaCpf(FuncionarioDTO obj)
        {
            try
            {                
                String sql = "SELECT  * FROM TB_FUNCIONARIO WHERE CPF_FUNCIONARIO = @cpf";
                SqlCommand cm = new SqlCommand(sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@cpf", obj.CPF);
                SqlDataReader ler = cm.ExecuteReader();
                while (ler.Read())
                {
                    if (ler.HasRows)
                    {                        
                        return true;
                    }                    
                }
                return false;
            }
            catch
            {
                throw new Exception("Problema na Conexão.");
            }
            finally
            {
                Conexao.Fechar();
            }
        }

        public static bool TestaRg(FuncionarioDTO obj)
        {
            try
            {
                String sql = "SELECT  * FROM TB_FUNCIONARIO WHERE RG_FUNCIONARIO = @rg";
                SqlCommand cm = new SqlCommand(sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@rg", obj.RG);
                SqlDataReader ler = cm.ExecuteReader();
                while (ler.Read())
                {
                    if (ler.HasRows)
                    {
                        return true;
                    }                
                }
                return false;
            }
            catch
            {
                throw new Exception("Problema na Conexão.");
            }
            finally
            {
                Conexao.Fechar();
            }
        }

        public static bool TestaIdentificador(FuncionarioDTO obj)
        {
            try
            {
                String sql = "SELECT  * FROM TB_FUNCIONARIO WHERE IDENTIFICADOR_FUNCIONARIO = @id";
                SqlCommand cm = new SqlCommand(sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@id", obj.Identificacao);
                SqlDataReader ler = cm.ExecuteReader();
                while (ler.Read())
                {
                    if (ler.HasRows)
                    {
                        return true;
                    }                    
                }
                return false;
            }
            catch
            {
                throw new Exception("Problema na Conexão.");
            }
            finally
            {
                Conexao.Fechar();
            }
        }


    }
}
