using AutoCrud.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCrud.Model
{
    public class ColunaInfo
    {
        public ColunaInfo()
        { }

        public string Nome { get; set; }
        public string Tabela { get; set; }
        public string Tipo { get; set; }
        public int? Tamanho { get; set; }
        public int Posicao { get; set; }
        public bool Identidade { get; set; }
        public bool PermiteNulo { get; set; }
        public TipoChaveEnum TipoChave { get; set; }
    }
}
