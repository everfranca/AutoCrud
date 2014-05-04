using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCrud.Model
{
    public class TabelaInfo
    {
        public TabelaInfo()
        {

        }

        public string Banco { get; set; }
        public string Schema { get; set; }
        public string Observacoes { get; set; }
        public string NomeBanco { get; set; }
        public string Nome { get; set; }
        public string Arquivo { get; set; }
        public bool LazyColunas { get; set; }
        public int QuantidadeForeignKey { get; set; }

        public List<ColunaInfo> ColunaInfo { get; set; }

    }
}
