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
        const string fileInfo = "..\\..\\Arquivos\\Info.txt";
        const string fileInfoCollection = "..\\..\\Arquivos\\InfoCollection.txt";
        const string fileInfoPrivateFields = "..\\..\\Arquivos\\InfoPrivateProperty.txt";
        const string fileInfoPublicFields = "..\\..\\Arquivos\\InfoPublicProperty.txt";
        const string filePastaArquivo = @"C:\ProgramData\AutoCrud";
        const string pathArquivoXml = @"C:\ProgramData\AutoCrud\AutoCrudInformation.xml";

        public static void ProcessarClasseInfo(TabelaInfo tabelaInfo)
        {
            string caminhoDiretorio = string.Empty;
            StringBuilder sbArquivo = new StringBuilder();
            OpcoesAvancadasInfo opcoesAvancadasInfo = new OpcoesAvancadasInfo();

            //Recuperar informações das configurações avançadas
            opcoesAvancadasInfo = Utils.RecuperarOpcoesAvancadas();
            if (opcoesAvancadasInfo != null)
            {
                sbArquivo.Append(CriarAquivo(tabelaInfo, opcoesAvancadasInfo));

                if (opcoesAvancadasInfo.ApenasArquivos)
                {
                    caminhoDiretorio = Utils.CriarPastaComRetorno(null, TipoProcessamento.Info, tabelaInfo.Nome) + @"\" + tabelaInfo.Nome + "Info.cs";
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

            using (StreamReader sr = new StreamReader(fileInfoCollection))
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
                sbAux = sb.Replace("<#TabelaConstrutor#>", tabelaInfo.Nome + " : BaseInfo");
            }
            else
            {
                sbAux = sb.Replace("<#UsingNucleo#>", string.Empty);
                sbAux = sb.Replace("<#TabelaConstrutor#>", tabelaInfo.Nome);
            }

            sbAux = sb.Replace("<#NameSpace#>", string.Empty);
            sbAux = sb.Replace("<#Tabela#>", tabelaInfo.Nome);

            var propriedadesPrivadas = RetornaPropriedadesPrivadas(tabelaInfo, opcoesAvancadasInfo.CriarCollectionPorFK);
            var propriedadesPublicas = RetornaPropriedadesPublicas(tabelaInfo, opcoesAvancadasInfo.CriarCollectionPorFK, opcoesAvancadasInfo.UtilizarNucleo);

            sbAux = sb.Replace("<#PrivateFields#>", propriedadesPrivadas);
            sbAux = sb.Replace("<#PublicFields#>", propriedadesPublicas);

            return sbAux.ToString();
        }

        private static string RetornaPropriedadesPrivadas(TabelaInfo tabelaInfo, bool criarCollection)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbAux = new StringBuilder();

            using (StreamReader sr = new StreamReader(fileInfoPrivateFields))
            {
                string linha = string.Empty;
                while ((linha = sr.ReadLine()) != null)
                    sbAux.AppendLine(linha);
            }

            //sb.Append("\t\t");

            foreach (ColunaInfo colunaInfo in tabelaInfo.ColunaInfo)
            {
                string privateField = colunaInfo.Nome.Substring(0, 1).ToLower() + colunaInfo.Nome.Substring(1, colunaInfo.Nome.Length - 1);
                string privateFieldCollection = colunaInfo.Nome.Substring(0, 1).ToLower() + colunaInfo.Nome.Substring(1, colunaInfo.Nome.Length - 1) + "InfoCollection ";

                if (colunaInfo.Tabela.Equals(tabelaInfo.Nome))
                    sb.Append(sbAux.ToString().Replace("<#type#>", Utils.RetornaTipo(colunaInfo.Tipo)).Replace("<#field#>", privateField));

                else
                {
                    if (criarCollection)
                        sb.Append(sbAux.ToString().Replace("<#type#>", Utils.RetornaTipo(colunaInfo.Tipo)).Replace("<#field#>", privateFieldCollection));
                }
            }
            return sb.ToString();
        }
        private static string RetornaPropriedadesPublicas(TabelaInfo tabelaInfo, bool criarCollection, bool utilizarNucleo)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbAux = new StringBuilder();
            using (StreamReader sr = new StreamReader(fileInfoPublicFields))
            {
                string linha = string.Empty;
                while ((linha = sr.ReadLine()) != null)
                    sbAux.AppendLine(linha);
            }

            //sb.Append("\t\t");
            int cont = 0;
            foreach (ColunaInfo coluna in tabelaInfo.ColunaInfo)
            {
                //sb.Append("\t");
                //sb.Append("\t");

                string privateField = coluna.Nome.Substring(0, 1).ToLower() + coluna.Nome.Substring(1, coluna.Nome.Length - 1);

                if (coluna.Tabela.Equals(tabelaInfo.Nome))
                {
                    if (!utilizarNucleo)
                        sb.Append(sbAux.ToString().Replace("<#type#>", Utils.RetornaTipo(coluna.Tipo)).Replace("<#PublicField#>", coluna.Nome.ToUpper()).Replace("<#field#>", privateField));

                    else
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

        
    }
}
