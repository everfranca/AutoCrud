using AutoCrud.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AutoCrud.Dao
{
    public class BancoDal
    {
        #region Query
        const string QueryBuscaBancoDeDados = @"select * from sys.databases";
        #endregion

        public List<BancoInfo> ListarBancos(AutenticacaoInfo info, bool windowsAuthentication)
        {
            List<BancoInfo> lstBancos = new List<BancoInfo>();
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
                cmd.CommandText = QueryBuscaBancoDeDados;
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    BancoInfo bancoInfo = new BancoInfo();
                    bancoInfo.Id = Convert.ToInt32(dr["database_id"]);
                    bancoInfo.Banco = dr["name"].ToString();
                    lstBancos.Add(bancoInfo);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstBancos;
        }
    }
}
