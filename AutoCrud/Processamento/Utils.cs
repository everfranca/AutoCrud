using System;
using System.Collections.Generic;
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
    }
}
