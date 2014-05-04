using AutoCrud.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoCrud.Processamento
{
    public class ProcessarInfo
    {
        const string arquivoInfo = "..\\..\\Arquivos\\Info.txt";
        const string arquivoInfoCollection = "..\\..\\Arquivos\\InfoCollection.txt";
        const string caminhoPastaArquivo = @"C:\ProgramData\AutoCrud";
        const string caminhoArquivoXml = @"C:\ProgramData\AutoCrud\AutoCrudInformation.xm";

        public static void ProcessarClasseInfo(TabelaInfo tabelaInfo)
        {
            string arquivo = string.Empty;
            OpcoesAvancadasInfo opcoesAvancadasInfo = new OpcoesAvancadasInfo();

            //Recuperar informações das configurações avançadas
            opcoesAvancadasInfo = RecuperarOpcoesAvancadas();
            if (opcoesAvancadasInfo != null)
            {
                arquivo = CriarAquivo(tabelaInfo, opcoesAvancadasInfo);

            }
        }

        public static string CriarAquivo(TabelaInfo tabelaInfo, OpcoesAvancadasInfo opcoesAvancadasInfo)
        {
            //Recuperar arquivo pré-definido
            StringBuilder sb = new StringBuilder();
            StringBuilder sbAux = new StringBuilder();

            using (StreamReader sr = new StreamReader(arquivoInfoCollection))
            {
                string linha = string.Empty;
                while ((linha = sr.ReadLine()) != null)
                {
                    sb.AppendLine(linha);
                }
            }

            if (opcoesAvancadasInfo.UtilizarNucleo)
            {
                sbAux = sb.Replace("<#UsingNucleo#>", "using Nucleo;");
                sbAux = sb.Replace("<#TabelaConstrutor#>", tabelaInfo.Nome + ": BaseInfo");
            }
            else
            {
                sbAux = sb.Replace("<#UsingNucleo#>", string.Empty);
                sbAux = sb.Replace("<#TabelaConstrutor#>", tabelaInfo.Nome);
            }

            sbAux = sb.Replace("<#NameSpace#>", "");
            sbAux = sb.Replace("<#Tabela#>", tabelaInfo.Nome);

            var propriedadesPrivadas = RetornaAtributosPrivados(tabelaInfo, opcoesAvancadasInfo.CriarCollectionPorFK);
            var propriedadesPublicas = "";

            return sbAux.ToString();
        }

        private static string RetornaAtributosPrivados(TabelaInfo tabelaInfo, bool criarCollection)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\t\t");
            foreach (ColunaInfo colunaInfo in tabelaInfo.ColunaInfo)
            {
                if (colunaInfo.Tabela.Equals(tabelaInfo.Nome))
                {
                    sb.Append("private ");
                    sb.Append(Utils.RetornaTipo(colunaInfo.Tipo) + " ");
                    sb.Append("_" + colunaInfo.Nome);
                }
                else
                {
                    if(criarCollection)
                    sb.Append("private ");
                    sb.Append(colunaInfo.Tabela + "InfoCollection ");
                    sb.Append("_" + (colunaInfo.Tabela + "S").ToUpper());
                }
            }
            return sb.ToString();
        }

        public static OpcoesAvancadasInfo RecuperarOpcoesAvancadas()
        {
            OpcoesAvancadasInfo opcoesAvancadasInfo = new OpcoesAvancadasInfo();

            if (Directory.Exists(caminhoPastaArquivo))
            {
                if (File.Exists(caminhoArquivoXml))
                {
                    using (StreamReader sw = new StreamReader(caminhoArquivoXml))
                    {
                        var xml = new System.Xml.Serialization.XmlSerializer(typeof(OpcoesAvancadasInfo));
                        try
                        {
                            opcoesAvancadasInfo = (OpcoesAvancadasInfo)xml.Deserialize(sw);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            return opcoesAvancadasInfo;
        }
    }
}
