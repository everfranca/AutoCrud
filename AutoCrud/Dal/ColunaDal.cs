using AutoCrud.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AutoCrud.Dao
{
    public class ColunaDal
    {
        #region Query
        const string queryColunas = @"SELECT DISTINCT 
                    INFORMATION_SCHEMA.TABLES.TABLE_NAME                AS TABLE_NAME,
                    INFORMATION_SCHEMA.TABLES.TABLE_TYPE                AS TABLE_TYPE,
                    INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME              AS COLUMN_NAME, 
                    INFORMATION_SCHEMA.COLUMNS.DATA_TYPE                AS DATA_TYPE, 
                    INFORMATION_SCHEMA.COLUMNS.ORDINAL_POSITION         AS ORDINAL_POSITION, 
                    INFORMATION_SCHEMA.COLUMNS.CHARACTER_MAXIMUM_LENGTH AS CHARACTER_MAXIMUM_LENGTH, 
                    INFORMATION_SCHEMA.COLUMNS.NUMERIC_PRECISION        AS NUMERIC_PRECISION, 
                    INFORMATION_SCHEMA.COLUMNS.NUMERIC_SCALE            AS NUMERIC_SCALE, 
                    INFORMATION_SCHEMA.COLUMNS.IS_NULLABLE              AS IS_NULLABLE, 
                    CASE WHEN 
		                ISNULL(ColumnProperty(Object_ID(QuoteName(KEY_COLUMN_USAGE.TABLE_SCHEMA) + '.' + QuoteName(KEY_COLUMN_USAGE.TABLE_NAME)), 
												                  KEY_COLUMN_USAGE.COLUMN_NAME, 'IsIdentity'), 0) = 1 THEN 
		                1
	                ELSE 
		                (SELECT TOP 1 
			                C.IS_IDENTITY 
		                 FROM 
			                SYS.OBJECTS O 
		                 INNER JOIN 
			                SYS.COLUMNS C ON O.OBJECT_ID = C.OBJECT_ID 
		                 WHERE 
			                O.TYPE = 'U' 
		                 AND 
			                O.NAME = INFORMATION_SCHEMA.COLUMNS.TABLE_NAME
		                AND
			                C.NAME = INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME)
	                END 
                                                                        AS IS_IDENTITY, 
                    (SELECT TOP 1 INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE 
                     FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                     INNER JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ON INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.TABLE_NAME = INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME 
                     AND INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.CONSTRAINT_NAME = INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME 
                     WHERE INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME = INFORMATION_SCHEMA.COLUMNS.TABLE_NAME 
                     AND INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.COLUMN_NAME = INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME
                     AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE IN ('PRIMARY KEY', 'FOREIGN KEY')) 
                                                                        AS CONSTRAINT_TYPE 
                FROM 
                    INFORMATION_SCHEMA.TABLES 
                LEFT JOIN 
                    INFORMATION_SCHEMA.COLUMNS ON INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = INFORMATION_SCHEMA.TABLES.TABLE_NAME
                LEFT JOIN 
                    INFORMATION_SCHEMA.KEY_COLUMN_USAGE ON INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_NAME = INFORMATION_SCHEMA.COLUMNS.TABLE_NAME 
                    AND 
                    INFORMATION_SCHEMA.KEY_COLUMN_USAGE.COLUMN_NAME = INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME 
                WHERE 
                    INFORMATION_SCHEMA.TABLES.TABLE_NAME <> 'sysdiagrams' 
                AND 
                    INFORMATION_SCHEMA.TABLES.TABLE_NAME <> 'sysmessages' 
                AND 
                    INFORMATION_SCHEMA.TABLES.TABLE_NAME <> 'sysobjects'
                AND INFORMATION_SCHEMA.TABLES.TABLE_NAME = @Tabela
                ORDER BY 
                    INFORMATION_SCHEMA.TABLES.TABLE_NAME, 
                    INFORMATION_SCHEMA.COLUMNS.ORDINAL_POSITION";

        #endregion

        public List<ColunaInfo> ListarColunasPorTabela(AutenticacaoInfo info, string Tabela, bool windowsAuthentication)
        {
            List<ColunaInfo> lstColnas = new List<ColunaInfo>();

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
                cmd.CommandText = queryColunas;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Tabela", Tabela);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ColunaInfo colunaInfo = new ColunaInfo();
                    colunaInfo.Tabela = dr["TABLE_NAME"].ToString();
                    colunaInfo.Nome = dr["COLUMN_NAME"].ToString();
                    colunaInfo.Tipo = dr["DATA_TYPE"].ToString();
                    colunaInfo.Posicao = Convert.ToInt32(dr["ORDINAL_POSITION"]);

                    var nullable = dr["IS_NULLABLE"].ToString();
                    if (nullable == "NO")
                        colunaInfo.PermiteNulo = false;
                    else if (nullable == "YES")
                        colunaInfo.PermiteNulo = true;
                    colunaInfo.Identidade = Convert.ToBoolean(dr["IS_IDENTITY"]);
                    if (dr["CONSTRAINT_TYPE"].ToString() == "PRIMARY KEY")
                        colunaInfo.TipoChave = Enum.TipoChaveEnum.ChavePrimaria;
                    else if (dr["CONSTRAINT_TYPE"].ToString() == "FOREIGN KEY")
                        colunaInfo.TipoChave = Enum.TipoChaveEnum.ChaveEstrangeira;
                    else if (dr["CONSTRAINT_TYPE"].ToString() == null)
                        colunaInfo.TipoChave = Enum.TipoChaveEnum.None;

                    if (!DBNull.Value.Equals(dr["CHARACTER_MAXIMUM_LENGTH"]))
                        colunaInfo.Tamanho = Convert.ToInt32(dr["CHARACTER_MAXIMUM_LENGTH"]);

                    lstColnas.Add(colunaInfo);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { }
            return lstColnas;
        }

    }
}
