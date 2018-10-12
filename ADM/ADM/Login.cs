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
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                LoginDTO obj = new LoginDTO();
                obj.usuario = txtUsuario.Text;
                obj.Senha = txtSenha.Text;
                obj=LoginBLL.ValidaLogin(obj);
                ADM tela = new ADM(obj.usuario);
                this.Hide();
                tela.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n"+ex.Message,"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnEntrar_Click(sender, e);
            }
        }
        
    }
}
