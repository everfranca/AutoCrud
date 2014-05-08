using AutoCrud.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            string caminhoDiretorio = string.Empty;
            StringBuilder sbArquivo = new StringBuilder();
            OpcoesAvancadasInfo opcoesAvancadasInfo = new OpcoesAvancadasInfo();

            //Recuperar informações das configurações avançadas
            opcoesAvancadasInfo = RecuperarOpcoesAvancadas();
            if (opcoesAvancadasInfo != null)
            {
                sbArquivo.Append(CriarAquivo(tabelaInfo, opcoesAvancadasInfo));
                
                if (opcoesAvancadasInfo.ApenasArquivos)
                {
                    caminhoDiretorio = Utils.CriarPastaComRetorno(null, TipoProcessamento.Info) + @"\" + tabelaInfo.Nome + ".Info.cs";
                    using (StreamWriter sw = new StreamWriter(caminhoDiretorio))
                    {
                        sw.Write(sbArquivo);
                    }
                }

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

            var propriedadesPrivadas = RetornaPropriedadesPrivadas(tabelaInfo, opcoesAvancadasInfo.CriarCollectionPorFK);
            var propriedadesPublicas = RetornaPropriedadesPublicas(tabelaInfo, opcoesAvancadasInfo.CriarCollectionPorFK);

            return sbAux.ToString();
        }

        private static string RetornaPropriedadesPrivadas(TabelaInfo tabelaInfo, bool criarCollection)
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
                    if (criarCollection)
                        sb.Append("private ");
                    sb.Append(colunaInfo.Tabela + "InfoCollection ");
                    sb.Append("_" + (colunaInfo.Tabela + "S").ToUpper());
                }
            }
            return sb.ToString();
        }
        private static string RetornaPropriedadesPublicas(TabelaInfo tabelaInfo, bool criarCollection)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\t\t");

            int cont = 0;
            foreach (ColunaInfo coluna in tabelaInfo.ColunaInfo)
            {
                sb.Append("\t");
                sb.Append("\t");

                if (coluna.Tabela.Equals(tabelaInfo.Nome))
                {
                    if (coluna.TipoChave == Enum.TipoChaveEnum.ChavePrimaria)
                        sb.Append("[AtributoCampo(" + coluna.TipoChave.ToString().ToLower() + ", " + @"""" + coluna.Nome + @"""" + ", " + coluna.Tamanho + ", " + coluna.PermiteNulo.ToString().ToLower() + ")]");
                    else
                        sb.Append(@"[AtributoCampo(""" + coluna.Nome + @"""" + ", " + coluna.Tamanho + ", " + coluna.PermiteNulo.ToString().ToLower() + ")]");

                    sb.Append("\n\t\t");
                    sb.Append("public ");
                    string tipo = Utils.RetornaTipo(coluna.Tipo);
                    sb.Append(tipo);
                    sb.Append(" " + coluna.Nome);
                    sb.Append("\n\t\t");
                    sb.Append("{");
                    sb.Append("\n\t\t\t");
                    sb.Append("get { return _" + coluna.Nome + "; }");
                    sb.Append("\n\t\t\t");
                    sb.Append("set");
                    sb.Append("\n\t\t\t");
                    sb.Append("{");
                    sb.Append("\n\t\t\t\t");
                    sb.Append("if(_" + coluna.Nome + " != value)");
                    sb.Append("\n\t\t\t\t\t");
                    sb.Append("IsDirty = true;");
                    sb.Append("\n\t\t\t\t");
                    sb.Append("_" + coluna.Nome + " = value;");
                    sb.Append("\n\t\t\t");
                    sb.Append("}");
                    sb.Append("\n\t\t");
                    sb.Append("}");
                    cont++;
                    if (cont != tabelaInfo.ColunaInfo.Count())
                        sb.Append("\n\n");
                }
                else
                {
                    sb.Append("\n\t\t");
                    sb.Append("public ");
                    sb.Append(coluna.Tabela + "InfoCollection ");
                    sb.Append((coluna.Tabela + "S").ToUpper());
                    sb.Append("\n\t\t");
                    sb.Append("{");
                    sb.Append("\n\t\t\t");
                    sb.Append("get { return _" + (coluna.Tabela + "S").ToUpper() + "; }");
                    sb.Append("\n\t\t\t");
                    sb.Append("set { _" + (coluna.Tabela + "S").ToUpper() + " = value; }");
                    sb.Append("\n\t\t");
                    sb.Append("}");
                    cont++;
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
