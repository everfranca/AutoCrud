using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoCrud.Processamento
{
    public static class Utils
    {
        public static string RetornaTipo(string tipoBanco)
        {
            if (tipoBanco.Contains("identity"))
            {
                tipoBanco = tipoBanco.Replace(" identity", "");
                tipoBanco = tipoBanco.Trim();
            }

            string tipo = "";

            switch (tipoBanco)
            {
                case "int":
                    {
                        tipo = "int";
                        break;
                    }
                case "bigint":
                    {
                        tipo = "long";
                        break;
                    }
                case "bit":
                    {
                        tipo = "bool";
                        break;
                    }
                case "char":
                    {
                        tipo = "char";
                        break;
                    }
                case "date":
                    {
                        tipo = "DateTime";
                        break;
                    }
                case "datetime":
                    {
                        tipo = "DateTime";
                        break;
                    }
                case "datetime2":
                    {
                        tipo = "DateTime";
                        break;
                    }
                case "datetimeoffset":
                    {
                        tipo = "DateTime";
                        break;
                    }
                case "decimal":
                    {
                        tipo = "decimal";
                        break;
                    }
                case "float":
                    {
                        tipo = "double";
                        break;
                    }
                case "image":
                    {
                        tipo = "System.Drawing.Image";
                        break;
                    }
                case "money":
                    {
                        tipo = "decimal";
                        break;
                    }
                case "ntext":
                    {
                        tipo = "string";
                        break;
                    }
                case "nchar":
                    {
                        tipo = "string";
                        break;
                    }
                case "numeric":
                    {
                        tipo = "double";
                        break;
                    }
                case "nvarchar":
                    {
                        tipo = "string";
                        break;
                    }
                case "smalldatetime":
                    {
                        tipo = "DateTime";
                        break;
                    }
                case "smallint":
                    {
                        tipo = "int";
                        break;
                    }
                case "smallmoney":
                    {
                        tipo = "decimal";
                        break;
                    }
                case "sql_variant":
                    {
                        tipo = "var";
                        break;
                    }
                case "text":
                    {
                        tipo = "string";
                        break;
                    }
                case "time":
                    {
                        tipo = "DateTime";
                        break;
                    }
                case "timestamp":
                    {
                        tipo = "DateTime";
                        break;
                    }
                case "tinyint":
                    {
                        tipo = "int";
                        break;
                    }
                case "uniqueidentifier":
                    {
                        tipo = "Guid";
                        break;
                    }
                case "varchar":
                    {
                        tipo = "string";
                        break;
                    }

                default:
                    break;
            }

            return tipo;
        }

        public static void CriarPastaProjeto(string nameSpace)
        {
            string diretorioProjeto = ConfigurationManager.AppSettings["DiretorioRaiz"].ToString() + @"\" + nameSpace;
            try
            {
                if (!Directory.Exists(diretorioProjeto))
                    Directory.CreateDirectory(diretorioProjeto);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void CriarPasta(string nomeTabela, TipoProcessamento TipoProcessamento)
        {
            string diretorio = string.Empty;
            string tipo = string.Empty;

            try
            {
                switch (TipoProcessamento)
                {
                    case TipoProcessamento.Info:
                        tipo = "Info";
                        break;
                    case TipoProcessamento.Dal:
                        tipo = "Dal";
                        break;
                    case TipoProcessamento.Bll:
                        tipo = "Bll";
                        break;
                }
                if (nomeTabela != null)
                    diretorio = ConfigurationManager.AppSettings["DiretorioRaiz"].ToString() + @"\" + ConfigurationManager.AppSettings["NomeDiretorio" + tipo].ToString();
                else
                    diretorio = ConfigurationManager.AppSettings["DiretorioRaiz"].ToString() + @"\" + nomeTabela + "." + ConfigurationManager.AppSettings["NomeDiretorio" + tipo].ToString();

                if (!Directory.Exists(diretorio))
                    Directory.CreateDirectory(diretorio);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static string CriarPastaComRetorno(string nomeTabela, TipoProcessamento TipoProcessamento, string nomeClasse)
        {
            string diretorio = string.Empty;
            string tipo = string.Empty;

            try
            {
                switch (TipoProcessamento)
                {
                    case TipoProcessamento.Info:
                        tipo = "Info";
                        break;
                    case TipoProcessamento.Dal:
                        tipo = "Dal";
                        break;
                    case TipoProcessamento.Bll:
                        tipo = "Bll";
                        break;
                }
                if (nomeTabela != null)
                    diretorio = ConfigurationManager.AppSettings["DiretorioRaiz"].ToString() + @"\" + ConfigurationManager.AppSettings["NomeDiretorio" + tipo].ToString();
                else
                    diretorio = ConfigurationManager.AppSettings["DiretorioRaiz"].ToString() + @"\" + nomeClasse + ConfigurationManager.AppSettings["NomeDiretorio" + tipo].ToString();

                if (!Directory.Exists(diretorio))
                    Directory.CreateDirectory(diretorio);
                return diretorio;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
