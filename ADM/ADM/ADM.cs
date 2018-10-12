using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace UI
{
    public partial class ADM : MetroFramework.Forms.MetroForm
    {
        int idFuncionario;
        int idProduto;
        public ADM(String usuario)
        {
            InitializeComponent();
            this.Text += " "+usuario;
            txtNome.Focus();
            btnAltera.Enabled = false;
            btnAlterar.Enabled = false;
        }

        public void LimpaFuncionario()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //Limpa todos os campos
                txtNome.Clear();
                txtTelefone.Clear();
                txtCelular.Clear();
                txtRg.Clear();
                txtCpf.Clear();
                txtCidade.Clear();
                txtBairro.Clear();
                txtLogradouro.Clear();
                txtN.Clear();
                txtComplemento.Clear();
                txtIdentificador.Clear();
                txtConta.Clear();
                txtBanco.Clear();
                txtAgencia.Clear();
                btnAltera.Enabled = false;
                btnCadastra.Enabled = true;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void LimpaProdutos()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //Limpa todos os campos
                txtProduto.Clear();
                cbbUnidade.SelectedIndex = -1;
                txtQtd.Clear();
                txtPreco.Clear();
                cbbTipo.SelectedIndex = -1;
                btnCadastrar.Enabled = true;
                btnAlterar.Enabled = false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaFuncionario();
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            LimpaProdutos();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //Armazena retorno
                String retorno="";

                //Instancia do objeto
                FuncionarioDTO obj = new FuncionarioDTO();

                //Atribui valores ao objeto
                obj.Nome = txtNome.Text;
                obj.Telefone = txtTelefone.Text;
                obj.Celular = txtCelular.Text;
                obj.RG = txtRg.Text;
                obj.CPF = txtCpf.Text;
                obj.Cidade = txtCidade.Text;
                obj.Bairro = txtBairro.Text;
                obj.Logradouro = txtLogradouro.Text;
                obj.N = txtN.Text;
                obj.Complemento = txtComplemento.Text;
                obj.Identificacao = txtIdentificador.Text;
                obj.Banco = txtBanco.Text;
                obj.Conta = txtConta.Text;
                obj.Agencia = txtAgencia.Text;

                //Envia o objeto para a BLL e armazena o retorno em uma String
                retorno = FuncionarioBLL.CadastraFuncionario(obj);

                //Mostra a mensagem na tela
                MetroFramework.MetroMessageBox.Show(this, retorno, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Limpa todos os campos
                LimpaFuncionario();
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this,ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //Armazena retorno
                String retorno = "";

                //Instancia do objeto
                ProdutoDTO dto = new ProdutoDTO();

                //Atribui valores ao objeto
                dto.Nome = txtProduto.Text;
                dto.UnidadeMedida = cbbUnidade.Text;
                dto.Tipo = cbbTipo.Text;
                dto.Qtd = int.Parse(txtQtd.Text);
                dto.Preco = Convert.ToDouble(txtPreco.Text);
                
                //Envia o objeto para a BLL e armazena o retorno em uma String
                retorno = ProdutoBLL.cadastraProduto(dto);

                //Mostra a mensagem na tela
                MetroFramework.MetroMessageBox.Show(this, retorno, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Limpa Campos
                LimpaProdutos();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void pcbBusca_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //Pega o campo cpf
                String cpf = txtCpf.Text;

                //Instancia objeto FuncionarioDTO
                FuncionarioDTO obj = new FuncionarioDTO();

                //Manda cpf para BLL e recebe o retorno
                obj = FuncionarioBLL.buscaFuncionario(cpf);

                //Atribui valores aos campos de textos
                idFuncionario = obj.id;
                txtNome.Text =  obj.Nome;
                txtTelefone.Text = obj.Telefone;
                txtCelular.Text = obj.Celular;
                txtRg.Text = obj.RG;
                txtCpf.Text = obj.CPF;
                txtCidade.Text = obj.Cidade;
                txtBairro.Text = obj.Bairro;
                txtLogradouro.Text = obj.Logradouro;
                txtN.Text = obj.N;
                txtComplemento.Text = obj.Complemento;
                txtIdentificador.Text = obj.Identificacao;
                txtBanco.Text = obj.Banco;
                txtConta.Text = obj.Conta;
                txtAgencia.Text = obj.Agencia;
                btnAltera.Enabled = true;
                btnCadastra.Enabled = false;
                
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpf.Focus();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void txtCpf_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pcbBusca_Click(sender, e);
            }
        }

        private void pcbBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;                
                string Nome = txtProduto.Text;
                ProdutoDTO dto = new ProdutoDTO();
                dto = ProdutoBLL.buscaProduto(Nome);

                idProduto = dto.Id;
                txtProduto.Text = dto.Nome;
                txtPreco.Text = dto.Preco.ToString();
                txtQtd.Text = dto.Qtd.ToString();
                cbbTipo.Text = dto.Tipo;
                cbbUnidade.Text = dto.UnidadeMedida;

                btnCadastrar.Enabled = false;
                btnAlterar.Enabled = true;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void txtProduto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pcbBuscar_Click(sender, e);
            }            
        }

        

        private void btnAltera_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //Armazena retorno
                string retorno = "";

                //Instancia do objeto
                FuncionarioDTO obj = new FuncionarioDTO();

                //Atribui valores ao objeto
                obj.id = idFuncionario;
                obj.Nome = txtNome.Text;
                obj.Telefone = txtTelefone.Text;
                obj.Celular = txtCelular.Text;
                obj.RG = txtRg.Text;
                obj.CPF = txtCpf.Text;
                obj.Cidade = txtCidade.Text;
                obj.Bairro = txtBairro.Text;
                obj.Logradouro = txtLogradouro.Text;
                obj.N = txtN.Text;
                obj.Complemento = txtComplemento.Text;
                obj.Identificacao = txtIdentificador.Text;
                obj.Banco = txtBanco.Text;
                obj.Conta = txtConta.Text;
                obj.Agencia = txtAgencia.Text;

                //Envia o objeto para a BLL e armazena o retorno em uma String
                retorno = FuncionarioBLL.atualizaFuncionario(obj);

                //Mostra a mensagem na tela
                MetroFramework.MetroMessageBox.Show(this, retorno, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Limpa todos os campos
                LimpaFuncionario();
                btnCadastra.Enabled = true;
                btnAltera.Enabled = false;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //Armazena retorno
                String retorno = "";

                //Instancia do objeto
                ProdutoDTO dto = new ProdutoDTO();

                //Atribui valores ao objeto
                dto.Id = idProduto;
                dto.Nome = txtProduto.Text;
                dto.UnidadeMedida = cbbUnidade.Text;
                dto.Tipo = cbbTipo.Text;
                dto.Qtd = int.Parse(txtQtd.Text);
                dto.Preco = Convert.ToDouble(txtPreco.Text);

                //Envia o objeto para a BLL e armazena o retorno em uma String
                retorno = ProdutoBLL.atualizaProduto(dto);

                //Mostra a mensagem na tela
                MetroFramework.MetroMessageBox.Show(this, retorno, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Limpa Campos
                LimpaProdutos();
                btnCadastrar.Enabled = true;
                btnAlterar.Enabled = false;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
