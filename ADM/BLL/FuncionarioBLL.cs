using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class FuncionarioBLL
    {
        //Método de validação dos campos
        public static void validaFuncionario(FuncionarioDTO obj)
        {
            //Nome
            if (string.IsNullOrWhiteSpace(obj.Nome))
            {
                throw new Exception("Preencha o campo Nome.");
            }
            //RG
            if (obj.RG.Length != 9)
            {
                throw new Exception("Preencha o campo RG.");
            }
            //CPF
            if (obj.CPF.Length != 11)
            {
                throw new Exception("Preencha o campo CPF.");
            }
            //Telefone
            if (obj.Telefone.Length != 10)
            {
                throw new Exception("Preencha o campo telefone.");
            }
            //Celular
            if (obj.Celular.Length != 11)
            {
                throw new Exception("Preencha o campo Celular.");
            }
            //Cidade
            if (String.IsNullOrWhiteSpace(obj.Cidade))
            {
                throw new Exception("Campo Cidade vazio.");
            }
            //Bairro
            if (String.IsNullOrWhiteSpace(obj.Bairro))
            {
                throw new Exception("Campo Bairro vazio.");
            }
            //Logradouro
            if (String.IsNullOrWhiteSpace(obj.Logradouro))
            {
                throw new Exception("Campo Logradouro vazio.");
            }
            //Número da casa
            try
            {
                int.Parse(obj.N).ToString();
            }
            catch
            {
                throw new Exception("Campo Nº deve ser um número inteiro.");
            }
            //Identificação do funcionário
            if (obj.Identificacao.Length != 10)
            {
                throw new Exception("A identificação deve ser de 10 digitos");
            }
            //Número do banco
            try
            {
                int.Parse(obj.Banco).ToString();
            }
            catch
            {
                throw new Exception("O banco deve ser um número inteiro");
            }
            //Conta
            if (String.IsNullOrWhiteSpace(obj.Conta))
            {
                throw new Exception("Preencha o campo Conta");
            }
            //Agência
            if (String.IsNullOrWhiteSpace(obj.Agencia))
            {
                throw new Exception("Preencha o campo Agência");
            }
        }

        public static String CadastraFuncionario(FuncionarioDTO obj)
        {
            //Chama o método de validação
            validaFuncionario(obj);
            bool testaRG = FuncionarioDAL.TestaRg(obj);
            if (testaRG)
            {
                throw new Exception("RG já cadastrado.");
            }
            bool testeCpf = FuncionarioDAL.TestaCpf(obj);
            if (testeCpf)
            {
                throw new Exception("Cpf já cadastrado.");
            }
            bool testaId = FuncionarioDAL.TestaIdentificador(obj);
            if (testaId)
            {
                throw new Exception("Já existe um funcionário com esse Identificador.");
            }
            return FuncionarioDAL.CadastrarFuncionario(obj);
                        
        }

        public static FuncionarioDTO buscaFuncionario(String cpf)
        {
            if (cpf.Length != 11)
            {
                throw new Exception("Preencha o campo cpf.");
            }
            return FuncionarioDAL.BuscaFuncionario(cpf);
        }

        public static string atualizaFuncionario(FuncionarioDTO obj)
        {
            //Chama o método de validação
            validaFuncionario(obj);
            string cpf = obj.CPF;
            FuncionarioDTO DTO = new FuncionarioDTO();
            DTO = FuncionarioDAL.BuscaFuncionario(cpf);
            if (obj.RG != DTO.RG) 
            {
                bool testaRG = FuncionarioDAL.TestaRg(obj);
                if (testaRG)
                {
                    throw new Exception("RG já cadastrado.");
                }
            }
            if (obj.CPF != DTO.CPF)
            {
                bool testeCpf = FuncionarioDAL.TestaCpf(obj);
                if (testeCpf)
                {
                    throw new Exception("Cpf já cadastrado.");
                }
            }
            if (obj.Identificacao != DTO.Identificacao)
            {
                bool testaId = FuncionarioDAL.TestaIdentificador(obj);
                if (testaId)
                {
                    throw new Exception("Já existe um funcionário com esse Identificador.");
                }
            }

            return FuncionarioDAL.AtualizaFuncionario(obj);
        }
    }
}
