using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ProdutoBLL
    {
        public static void validaProduto(ProdutoDTO obj)
        {
            if (String.IsNullOrWhiteSpace(obj.Nome))
            {
                throw new Exception("Preencha o campo Nome.");
            }
            if (String.IsNullOrWhiteSpace(obj.UnidadeMedida))
            {
                throw new Exception("Selecione uma Unidade de Medida.");
            }
            if (String.IsNullOrWhiteSpace(obj.Qtd.ToString()))
            {
                throw new Exception("Preencha o campo Quantidade.");
            }
            try
            {
                Convert.ToInt32(obj.Qtd);
            }
            catch
            {
                throw new Exception("A quantidade deve ser um número inteiro.");
            }
            try
            {
                Convert.ToDouble(obj.Preco);
            }
            catch
            {
                throw new Exception("O preço deve ser um número Decimal");
            }
            if (String.IsNullOrWhiteSpace(obj.Tipo))
            {
                throw new Exception("Preencha o campo Tipo.");
            }
        }
        public static string cadastraProduto(ProdutoDTO obj)
        {

            validaProduto(obj);
            return ProdutoDAL.CadastraProduto(obj);
        }

        public static ProdutoDTO buscaProduto(String nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("Preencha o campo Produto para realizar uma busca.");
            }
            return ProdutoDAL.BuscaProduto(nome);
        }

        public static string atualizaProduto(ProdutoDTO obj)
        {
            //Chama o método de validação
            validaProduto(obj);
            string nome = obj.Nome;
            ProdutoDTO DTO = new ProdutoDTO();
            DTO = ProdutoDAL.BuscaProduto(nome);
            if (obj.Nome != DTO.Nome)
            {
                bool testaNome = ProdutoDAL.TestaNome(nome);
                if (testaNome)
                {
                    throw new Exception("Já existe um produto cadastrado com esse nome.");
                }
            }            

            return ProdutoDAL.AtualizaProduto(obj);
        }

    }
}
