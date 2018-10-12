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
    public class ProdutoDAL
    {
        public static string CadastraProduto(ProdutoDTO obj)
        {
            try
            {
                String sucesso = "";
                String sql = "INSERT INTO TB_PRODUTO (NM_PRODUTO, UM_PRODUTO, QTD_PRODUTO, VL_PRODUTO, TP_PRODUTO) "
                + "VALUES(@nome,@um,@qtd,@vl,@tp)";
                SqlCommand cm = new SqlCommand(sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@nome", obj.Nome);
                cm.Parameters.AddWithValue("@um", obj.UnidadeMedida);
                cm.Parameters.AddWithValue("@qtd", Convert.ToInt32(obj.Qtd));
                cm.Parameters.AddWithValue("@vl", Convert.ToDouble(obj.Preco));
                cm.Parameters.AddWithValue("@tp", obj.Tipo);
                cm.ExecuteNonQuery();
                sucesso = "Produto cadastrado com sucesso";
                return sucesso;
            }
            catch
            {                
                throw new Exception("Problemas na conexão.");
            }
            finally
            {
                Conexao.Fechar();
            }
        }

        public static ProdutoDTO BuscaProduto(String nome)
        {
            try
            {
                ProdutoDTO obj = new ProdutoDTO();
                String sql = "SELECT  * FROM TB_PRODUTO WHERE NM_PRODUTO = @nome";
                SqlCommand cm = new SqlCommand(sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@nome", nome);
                SqlDataReader ler = cm.ExecuteReader();
                while (ler.Read())
                {
                    if (ler.HasRows)
                    {
                        obj.Id = int.Parse(ler["ID_PRODUTO"].ToString());
                        obj.Nome = ler["NM_PRODUTO"].ToString();
                        obj.UnidadeMedida = ler["UM_PRODUTO"].ToString();
                        obj.Qtd = int.Parse(ler["QTD_PRODUTO"].ToString());
                        obj.Preco = double.Parse(ler["VL_PRODUTO"].ToString());
                        obj.Tipo = ler["TP_PRODUTO"].ToString();
                        return obj;
                    }
                    throw new Exception("Produto não encontrado.");
                }
                throw new Exception("Produto não encontrado.");
            }
            catch
            {
                throw new Exception("Produto não encontrado.");
            }
            finally
            {
                Conexao.Fechar();
            }
        }

        public static string AtualizaProduto(ProdutoDTO obj)
        {
            try
            {    
                String sucesso = "";
                String sql = "UPDATE TB_PRODUTO"
                + " SET NM_PRODUTO=@nome, UM_PRODUTO=@um, QTD_PRODUTO=@qtd, VL_PRODUTO=@vl,"
                + " TP_PRODUTO=@tp"
                + " WHERE ID_PRODUTO=@id";

                SqlCommand cm = new SqlCommand(sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@id", obj.Id);
                cm.Parameters.AddWithValue("@nome", obj.Nome);
                cm.Parameters.AddWithValue("@um", obj.UnidadeMedida);
                cm.Parameters.AddWithValue("@qtd", Convert.ToInt32(obj.Qtd));
                cm.Parameters.AddWithValue("@vl", Convert.ToDouble(obj.Preco));
                cm.Parameters.AddWithValue("@tp", obj.Tipo);
                cm.ExecuteNonQuery();
                sucesso = "Produto atualizado com sucesso!!";
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

        public static bool TestaNome(string nome)
        {
            try
            {
                String sql = "SELECT  * FROM TB_PRODUTO WHERE NM_PRODUTO = @nome";
                SqlCommand cm = new SqlCommand(sql, Conexao.Abrir());
                cm.Parameters.AddWithValue("@nome", nome);
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
