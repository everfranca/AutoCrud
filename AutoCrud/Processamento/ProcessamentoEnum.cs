using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AutoCrud.Processamento
{
    public enum TipoProcessamento
    {
        [Description("Info")]
        Info = 1,

        [Description("Dal")]
        Dal = 2,

        [Description("Bll")]
        Bll = 3
    }
}
