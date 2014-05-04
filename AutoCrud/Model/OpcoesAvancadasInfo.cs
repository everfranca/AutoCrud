using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCrud.Model
{
    public class OpcoesAvancadasInfo
    {
        public bool ScopTransaction { get; set; }
        public bool DbTransaction { get; set; }
        public bool NenhumTransacao { get; set; }

        public bool GerarForms { get; set; }
        public bool GerarPages { get; set; }
        public bool NenhumFrontEnd { get; set; }

        public bool SepararProjetos { get; set; }
        public bool TabelaSolution { get; set; }
        public bool ApenasArquivos { get; set; }

        public bool UtilzarStoredProcedure { get; set; }
        public bool UtilizarCommandText { get; set; }

        public bool UtilizarNucleo { get; set; }
        public bool NaoUtilizarNucleo { get; set; }

        public bool CriarCollectionPorFK { get; set; }
        public bool NaoCriarCollectionPorFK { get; set; }
    }
}
