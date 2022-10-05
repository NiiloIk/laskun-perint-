using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektityö.Luokat
{
    public class Vastaanottaja
    {
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Osoite { get; set; }
        public string kokoNimi { get; }
        public Vastaanottaja(string Etunimi, string Sukunimi, string Osoite)
        {
            this.Etunimi = Etunimi;
            this.Sukunimi = Sukunimi;
            this.Osoite = Osoite;
            this.kokoNimi = Etunimi + " " + Sukunimi;
        }
        public Vastaanottaja() { }
    }


    
}
