using AutoCrud.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoCrud
{
    public partial class FrmOpçõesAvancadas : Form
    {
        public FrmOpçõesAvancadas()
        {
            InitializeComponent();
        }

        private void FrmOpcoesAvancadas_Load(object sender, EventArgs e)
        {
            RecuperaArquivoXml();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRedefinir_Click(object sender, EventArgs e)
        {
            OpcoesAvancadasInfo info = new OpcoesAvancadasInfo();

            rdbScopeTransaction.Checked = true;
            rdbNenhumFrontEnd.Checked = true;
            rdbSeparaProjetos.Checked = true;
            rdbStoredProcedure.Checked = true;

            info.ScopTransaction = rdbScopeTransaction.Checked;
            info.DbTransaction = rdbDbTransaction.Checked;
            info.NenhumTransacao = rdbNenhumTransacao.Checked;
            
            info.GerarForms = rdbGerarForms.Checked;
            info.GerarPages = rdbGerarPages.Checked;
            info.NenhumFrontEnd = rdbNenhumFrontEnd.Checked;
            
            info.SepararProjetos = rdbSeparaProjetos.Checked;
            info.TabelaSolution = rdbTabelaSolution.Checked;

            info.UtilzarStoredProcedure = rdbStoredProcedure.Checked;
            info.UtilizarCommandText = rdbCommandText.Checked;
            

            SalvarXmlOpcoes(info);
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            OpcoesAvancadasInfo info = new OpcoesAvancadasInfo();

            info.ScopTransaction = rdbScopeTransaction.Checked;
            info.DbTransaction = rdbDbTransaction.Checked;
            info.NenhumTransacao = rdbNenhumTransacao.Checked;

            info.GerarForms = rdbGerarForms.Checked;
            info.GerarPages = rdbGerarPages.Checked;
            info.NenhumFrontEnd = rdbNenhumFrontEnd.Checked;

            info.SepararProjetos = rdbSeparaProjetos.Checked;
            info.TabelaSolution = rdbTabelaSolution.Checked;
            info.ApenasArquivos = rdbApenasArquivo.Checked;

            info.UtilzarStoredProcedure = rdbStoredProcedure.Checked;
            info.UtilizarCommandText = rdbCommandText.Checked;
            
            info.UtilizarNucleo = rdbUtilizarNucleo.Checked;
            info.NaoUtilizarNucleo = rdbNaoUtilizarNucleo.Checked;

            info.CriarCollectionPorFK = rdbCriarCollection.Checked;
            info.NaoCriarCollectionPorFK = rdbNaoCriarCollection.Checked;

            try
            {
                SalvarXmlOpcoes(info);
                MessageBox.Show("Configurações salvas com sucesso!");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao salvar as definições.");
                return;
            }
            finally
            {
                info = null;
            }
        }

        private void SalvarXmlOpcoes(OpcoesAvancadasInfo info)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!Directory.Exists(@"C:\ProgramData\AutoCrud"))
                Directory.CreateDirectory(@"C:\ProgramData\AutoCrud");
            if (!File.Exists(@"C:\ProgramData\AutoCrud\AutoCrudInformation.xml"))
                using (File.Create(@"C:\ProgramData\AutoCrud\AutoCrudInformation.xml"))
                { }

            using (StreamWriter sw = new StreamWriter(@"C:\ProgramData\AutoCrud\AutoCrudInformation.xml"))
            {
                var xml = new System.Xml.Serialization.XmlSerializer(typeof(OpcoesAvancadasInfo));
                xml.Serialize(sw, info);
            }
            Cursor.Current = Cursors.Default;
        }
        private void RecuperaArquivoXml()
        {
            Cursor.Current = Cursors.WaitCursor;

            OpcoesAvancadasInfo info = new OpcoesAvancadasInfo();

            if (File.Exists(@"C:\ProgramData\AutoCrud\AutoCrudInformation.xml"))
            {
                using (StreamReader sw = new StreamReader(@"C:\ProgramData\AutoCrud\AutoCrudInformation.xml"))
                {
                    var xml = new System.Xml.Serialization.XmlSerializer(typeof(OpcoesAvancadasInfo));
                    try
                    {
                        info = (OpcoesAvancadasInfo)xml.Deserialize(sw);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }

                if (info != null)
                {
                    rdbScopeTransaction.Checked = info.ScopTransaction;
                    rdbDbTransaction.Checked = info.DbTransaction;
                    rdbNenhumTransacao.Checked = info.NenhumTransacao;

                    rdbGerarForms.Checked = info.GerarForms;
                    rdbGerarPages.Checked = info.GerarPages;
                    rdbNenhumFrontEnd.Checked = info.NenhumFrontEnd;

                    rdbSeparaProjetos.Checked = info.SepararProjetos;
                    rdbTabelaSolution.Checked = info.TabelaSolution;
                    rdbApenasArquivo.Checked = info.ApenasArquivos;

                    rdbStoredProcedure.Checked = info.UtilzarStoredProcedure;
                    rdbCommandText.Checked = info.UtilizarCommandText;

                    rdbUtilizarNucleo.Checked = info.UtilizarNucleo;
                    rdbNaoUtilizarNucleo.Checked = info.NaoUtilizarNucleo;

                    rdbCriarCollection.Checked = info.CriarCollectionPorFK;
                    rdbNaoCriarCollection.Checked = info.NaoCriarCollectionPorFK;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
