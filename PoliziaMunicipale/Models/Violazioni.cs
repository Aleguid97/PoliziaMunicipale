using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoliziaMunicipale.Models
{
    public class Violazioni
    {
        public int IDviolazione { get; set; }
        public string Descrizione_Verbale { get; set; }
        public int IDverbale { get; set; }
      
    }
}