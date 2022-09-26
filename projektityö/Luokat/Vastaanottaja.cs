using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektityö.Luokat
{
    internal class Vastaanottaja
    {
        public Vastaanottaja(string Etunimi, string Sukunimi, string Osoite)
        {
            this.Etunimi = Etunimi;
            this.Sukunimi = Sukunimi;
            this.Osoite = Osoite;
        }

        public string? Etunimi;
        public string? Sukunimi;
        public string? Osoite;
    }


    
}
