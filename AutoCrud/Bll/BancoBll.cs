using AutoCrud.Dao;
using AutoCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCrud.Bll
{
    public class BancoBll
    {
        public List<BancoInfo> ListarBancos(AutenticacaoInfo info, bool windowsAuthentication)
        {
            BancoDal bancoDao = new BancoDal();
            try
            {
                return bancoDao.ListarBancos(info, windowsAuthentication);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bancoDao = null;
            }
        }
    }
}
