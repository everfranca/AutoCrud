using AutoCrud.Dao;
using AutoCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCrud.Bll
{
    public class ColunaBll
    {
        public List<ColunaInfo> ListarColunasPorTabela(AutenticacaoInfo info, string Tabela, bool windowsAuthentication)
        {
            ColunaDal colunaDal = new ColunaDal();
            try
            {
               return colunaDal.ListarColunasPorTabela(info, Tabela, windowsAuthentication);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                colunaDal = null;
            }

        }
    }
}
