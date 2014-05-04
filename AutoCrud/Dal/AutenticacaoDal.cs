using AutoCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AutoCrud.Dao
{
    public class AutenticacaoDal
    {
        #region Querys
        const string sp_Tables = "sp_tables";

        #endregion

        public List<TabelaInfo> ListarTabelas(AutenticacaoInfo info, bool windowsAuthentication)
        {
            List<TabelaInfo> lstTabelas = new List<TabelaInfo>();
            try
            {
                SqlConnection conn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;

                if (!windowsAuthentication)
                    conn.ConnectionString = "Data Source = " + info.Servidor + ";Initial Catalog= " + info.Banco + ";Persist Security Info=True; User ID=" + info.Usuario + ";Password=" + info.Senha;
                else
                    conn.ConnectionString = "Data Source = " + info.Servidor + ";Initial Catalog= " + info.Banco + ";Integrated Security=True;";

                cmd.Connection = conn;
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp_Tables;
                cmd.Parameters.Clear();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TabelaInfo tabelaInfo = new TabelaInfo();
                    if (dr["TABLE_OWNER"].ToString() == "dbo")
                    {
                        tabelaInfo.Nome = dr["TABLE_NAME"].ToString();

                        lstTabelas.Add(tabelaInfo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstTabelas;
        }
    }
}
