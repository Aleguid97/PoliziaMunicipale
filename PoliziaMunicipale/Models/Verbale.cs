using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoliziaMunicipale.Models
{
    public class Verbale
    {
        public int IDverbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string Nominativo_Agente { get; set; }
        public DateTime DataVerbale { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        public int IDviolazione { get; set; }
        public int IDanagrafica { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }

        public string Descrizione_Verbale { get; set; }

    }
}