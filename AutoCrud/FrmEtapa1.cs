using AutoCrud.Bll;
using AutoCrud.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace AutoCrud
{
    public partial class FrmEtapa1 : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        private void FrmEtapa1_Load(object sender, EventArgs e)
        {
            button1.Focus();
            SendMessage(txtLogin.Handle, EM_SETCUEBANNER, 0, "Login");
            SendMessage(txtSenha.Handle, EM_SETCUEBANNER, 0, "Senha");
            SendMessage(cmbAutenticacao.Handle, EM_SETCUEBANNER, 0, "Autenticação");
            SendMessage(txtBanco.Handle, EM_SETCUEBANNER, 0, "Banco de Dados");
            SendMessage(txtServidor.Handle, EM_SETCUEBANNER, 0, "Servidor");

            cmbAutenticacao.SelectedIndex = 1;
            toolTip1.Show("Servidor", txtServidor);


            txtServidor.Text = @"RAOVMSERV44\DESENVOLVIMENTO";
            txtBanco.Text = "Gerenciador5.0";
            txtLogin.Text = "userGerenciador50H";
            txtSenha.Text = "userGerenciador#50H";
        }

        public FrmEtapa1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutenticacaoBll autenticacaoBll = new AutenticacaoBll();
            AutenticacaoInfo autenticacaoInfo = new AutenticacaoInfo();
            List<TabelaInfo> lstTabelas = new List<TabelaInfo>();
            bool windowsAutentication = true;
            try
            {
                autenticacaoInfo.Servidor = txtServidor.Text;
                autenticacaoInfo.Banco = txtBanco.Text;
                if (cmbAutenticacao.SelectedIndex == 1)
                {
                    autenticacaoInfo.Usuario = txtLogin.Text;
                    autenticacaoInfo.Senha = txtSenha.Text;
                    windowsAutentication = false;
                }

                lstTabelas = autenticacaoBll.ListarTabelas(autenticacaoInfo, windowsAutentication);

                FrmEtapa2 frmEtapa2 = new FrmEtapa2(lstTabelas, autenticacaoInfo, windowsAutentication );
                frmEtapa2.Show();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void cmbAutenticacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            BancoBll bancoBll = new BancoBll();
            AutenticacaoInfo autenticacaoInfo = new AutenticacaoInfo();

            if (cmbAutenticacao.SelectedIndex == 0)
            {
                txtLogin.Enabled = false;
                txtSenha.Enabled = false;

                txtLogin.Text = WindowsIdentity.GetCurrent().Name.ToString().Replace(@"\\", @"\");
            }
            else if (cmbAutenticacao.SelectedIndex == 1)
            {
                txtLogin.Enabled = true;
                txtSenha.Enabled = true;
                txtLogin.Text = string.Empty;
                txtSenha.Text = string.Empty;
            }
        }

        private void txtServidor_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Servidor", txtServidor);
        }

        private void txtServidor_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Servidor", txtServidor);
        }
    }
}
