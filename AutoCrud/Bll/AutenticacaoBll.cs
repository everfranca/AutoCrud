using AutoCrud.Dao;
using AutoCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCrud.Bll
{
    public class AutenticacaoBll
    {
        public List<TabelaInfo> ListarTabelas(AutenticacaoInfo info, bool windowsAuthentication)
        {
            AutenticacaoDal autenticacaoDao = new AutenticacaoDal();
            try
            {
                return autenticacaoDao.ListarTabelas(info, windowsAuthentication);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                autenticacaoDao = null;
            }

        }
    }
}
