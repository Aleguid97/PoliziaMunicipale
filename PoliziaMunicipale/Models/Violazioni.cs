namespace PoliziaMunicipale.Models
{
    public class Violazioni
    {
        public int IDviolazione { get; set; }
        public string Descrizione_Verbale { get; set; }
        public int IDverbale { get; set; }
        public string Text { get; set; }

        public string Value { get; set; }
    }
}