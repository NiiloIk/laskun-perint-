using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektityö.Luokat
{
    internal class Maksulisä
    {
        public float Lisä { get; set; } = 5;

        private string? _tyyppi = "MAKSUMUISTUTUS";
        public string? Tyyppi
        {
            get { return this._tyyppi; }
            set
            {
                if (value != "MAKSUMUISTUTUS" && value != "KARHUKIRJE")
                {
                    throw new Exception("Maksulisän tyyppi on virheellinen");
                }
                this._tyyppi = value;
            }
        }

        public Maksulisä(float lisä, string? tyyppi)
        {
            Lisä = lisä;
            Tyyppi = tyyppi;
        }

        public Maksulisä()
        {

        }
    }
}
