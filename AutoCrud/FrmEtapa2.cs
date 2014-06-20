using AutoCrud.Bll;
using AutoCrud.Model;
using AutoCrud.Processamento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace AutoCrud
{
    public partial class FrmEtapa2 : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public List<TabelaInfo> lstTabelaInfo;
        public AutenticacaoInfo AutenticacaoInfo;
        public bool WindowsAuthentication;

        public FrmEtapa2(List<TabelaInfo> lstTabelas, AutenticacaoInfo autenticacaoInfo, bool windowsAuthentication)
        {
            this.lstTabelaInfo = lstTabelas;
            this.AutenticacaoInfo = autenticacaoInfo;
            this.WindowsAuthentication = windowsAuthentication;

            InitializeComponent();
            SendMessage(txtNameSpace.Handle, EM_SETCUEBANNER, 0, "Informe a NameSpace do Projeto");
        }

        private void FrmEtapa2_Load(object sender, EventArgs e)
        {
            var lst = lstTabelaInfo;

            foreach (var item in lst)
            {
                string[] row = new string[] { item.Nome };
                dgTabelas.Rows.Add(row);
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {

            //Cria Pasta projeto
            Utils.CriarPastaProjeto(txtNameSpace.Text);

            //Recuperar tabelas selecionadas

            if (!chkInfo.Checked && !chkDal.Checked && !chkBll.Checked)
            {
                MessageBox.Show("Selecione ao menos uma opção de geração");
                groupBox1.Focus();
                return;
            }
            if (txtNameSpace.Text == string.Empty)
            {
                MessageBox.Show("Informe a NameSpace do Projeto");
                txtNameSpace.Focus();
                return;
            }

            List<TabelaInfo> lstTabelas = new List<TabelaInfo>();
            ColunaBll colunaBll = new ColunaBll();

            foreach (DataGridViewRow row in dgTabelas.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Selecionar"].Value) == true)
                {
                    TabelaInfo tabelaInfo = new TabelaInfo();
                    tabelaInfo.Nome = row.Cells["Tabela"].Value.ToString();
                    
                    var colunas = colunaBll.ListarColunasPorTabela(this.AutenticacaoInfo, tabelaInfo.Nome, this.WindowsAuthentication);
                    tabelaInfo.ColunaInfo = colunas;

                    lstTabelas.Add(tabelaInfo);
                }
            }

            if (lstTabelas.Count > 0)
            {
                //Classificar
                var listaClassificada = ClassificarTabelas(lstTabelas);

                foreach (TabelaInfo tabelaInfo in listaClassificada)
                {
                    //checar Geração de componentes
                    if (chkInfo.Checked)
                    {
                        ProcessarInfo.ProcessarClasseInfo(tabelaInfo);
                        //Gerar Info
                    }
                    if (chkDal.Checked)
                    {
                        ProcessarDal.ProcessarClasseDal(tabelaInfo);
                        //Gerar Dal
                    }
                    if (chkBll.Checked)
                    {
                        //Gerar Bll
                    }
                }

                MessageBox.Show("Processamento Concluído!");
            }
        }
        private void btnOpcoesAvancadas_Click(object sender, EventArgs e)
        {
            FrmOpçõesAvancadas frmOpcoesAvancadas = new FrmOpçõesAvancadas();
            frmOpcoesAvancadas.Show();
        }

        public List<TabelaInfo> ClassificarTabelas(List<TabelaInfo> lstTabelas)
        {
            List<TabelaInfo> lstTabelaInfo = new List<TabelaInfo>();

            try
            {
                foreach (TabelaInfo tabelaInfo in lstTabelas)
                {
                    int contadorFk = 0;
                    foreach (ColunaInfo colunaInfo in tabelaInfo.ColunaInfo)
                    {
                        if (colunaInfo.TipoChave == Enum.TipoChaveEnum.ChaveEstrangeira)
                        {
                            contadorFk += 1;
                        }
                    }
                    tabelaInfo.QuantidadeForeignKey = contadorFk;
                }

                return lstTabelaInfo = lstTabelas.OrderBy(t => t.QuantidadeForeignKey).ToList<TabelaInfo>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
