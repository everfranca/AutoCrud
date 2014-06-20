using AutoCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCrud.Processamento
{
    public static class ProcessarDal
    {
        const string fileDal = "..\\..\\Arquivos\\Dal.txt";
        const string fileInfoCollection = "..\\..\\Arquivos\\InfoCollection.txt";
        const string fileInfoPrivateFields = "..\\..\\Arquivos\\InfoPrivateProperty.txt";
        const string fileInfoPublicFields = "..\\..\\Arquivos\\InfoPublicProperty.txt";
        const string filePastaArquivo = @"C:\ProgramData\AutoCrud";
        const string pathArquivoXml = @"C:\ProgramData\AutoCrud\AutoCrudInformation.xml";

        public static void ProcessarClasseDal(TabelaInfo tabelaInfo)
        {
            string caminhoDiretorio = string.Empty;
            StringBuilder sbArquivo = new StringBuilder();
            OpcoesAvancadasInfo opcoesAvancadasInfo = new OpcoesAvancadasInfo();

            //Recuperar informações das configurações avançadas
            opcoesAvancadasInfo = Utils.RecuperarOpcoesAvancadas();
            if (opcoesAvancadasInfo != null)
            {

                if (opcoesAvancadasInfo.NenhumTransacao)
                { 
                    
                }
            }
        }
    }
}
