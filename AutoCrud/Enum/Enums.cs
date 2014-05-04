using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AutoCrud.Enum
{
    public enum TipoChaveEnum
    {
        [Description("")]
        None=0,

        [Description("Chave Primaria")]
        ChavePrimaria = 1,

        [Description("Chave Estrangeira")]
        ChaveEstrangeira = 2
    }
}
