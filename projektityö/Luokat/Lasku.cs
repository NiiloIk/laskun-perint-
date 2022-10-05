using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * class Lasku
 -summa:float
 -maksettava:float => summa + ..maksulisät.summa
 -maksulisät:List<MaksuLisä>
 -eräpäivä:DateOnly 
 -maksupäivä:DateOnly 
 -suoritettu:bool -> maksuPäivä != null
 -maksumuistutus1:Maksumuistutus
 -maksumuistutus2:Maksumuistutus
 -vastaanottaja:Vastaanottaja

 +asetaMaksetuksi() : void {
  maksupäivä = pvmTänään;
 }

 +onkoSuoritettu() : true {
   return suoritettu;
 }
*/
namespace projektityö.Luokat
{
    public class Lasku
    {
  

        public float summa { get; set; }
        public DateTime Eräpäivä { get; set; }
        public DateTime? Maksupäivä { get; set; }
        public DateTime Luontipäivämäärä { get; set; }

        public Maksumuistutus Maksumuistutus1 { get; set; }
        public Maksumuistutus Maksumuistutus2 { get; set; }
        public Vastaanottaja Vastaanottaja { get; set; }

        //public List<Maksulisä> Maksulisät = new();
        public List<Maksulisä> Maksulisät { get; set; } = new();

        public Lasku(float summa, DateTime erapaiva, DateTime? maksupäivä, Maksumuistutus maksumuistutus1, Maksumuistutus maksumuistutus2, Vastaanottaja vastaanottaja, List<Maksulisä> maksulisät)
        {
            this.summa = summa;
            Eräpäivä = erapaiva;
            Maksupäivä = maksupäivä;
            Maksumuistutus1 = maksumuistutus1;
            Maksumuistutus2 = maksumuistutus2;
            Vastaanottaja = vastaanottaja;
            Maksulisät = maksulisät;
        }
        
        public Lasku()
        {
            this.Maksumuistutus1 = new Maksumuistutus(this);
            this.Maksumuistutus2 = new Maksumuistutus(this);
            //this.Vastaanottaja = new Vastaanottaja();
        }
        public void lisääMaksulisä(Maksulisä maksulisä)
        {
            this.Maksulisät.Add(maksulisä);
        }
        public float MaksulisienSumma()
        {
            float maksulisät = 0;
            
            for (var i = 0; i < Maksulisät.Count; i++)
            {
                maksulisät += Maksulisät[i].Lisä;
            }
            return maksulisät;
        }
        public float LaskeKokonaissumma()
        {
            float Kokonaissumma = 0;
            Kokonaissumma += this.summa;
            Kokonaissumma += this.MaksulisienSumma();
            return Kokonaissumma;
        }

        public Boolean OnkoMaksettu()
        {
            return this.Maksupäivä != null;
        }


        // Asettaa Maksupäivän annetusta paremetristä, mikäli se on asetettu.
        // Mikäli ei ole asetettu, maksupäiväksi annetaan nykyinen päivä.
        public void AsetaMaksupäivä(DateTime? maksupäivä)
        {
            if (maksupäivä == null)
            {
                //maksupäivä = DateTime.FromDateTime(DateTime.Now);
                maksupäivä = DateTime.Now;
            }
            this.Maksupäivä = maksupäivä;
        }

        public string Tietotuloste()
        {
            string tuloste = "";

            tuloste += "Summa: " + this.summa + "\n";
            tuloste += "Kokonaissumma: " + this.LaskeKokonaissumma() + "\n";
            
            if (this.OnkoMaksettu())
            {
                tuloste += "Maksu suoritettu: " + this.Maksupäivä.ToString() + "\n";
            }

            for (var i = 0; i < this.Maksulisät.Count; i++)
            {
                Maksulisä maksulisä = this.Maksulisät[i];
                tuloste += "Maksulisä: " + i + 1 + ": " + maksulisä.Lisä;
                if (maksulisä.Tyyppi != null)
                {
                    tuloste += " (" + maksulisä.Tyyppi + ")";
                }
                tuloste += "\n";
            }


            if (this.Maksumuistutus1.OnkoLähetetty() == true)
            {
                tuloste += "Maksumuistutus1 lähetetty: " + this.Maksumuistutus1.LähetysPvm + "\n";
            }
            if (this.Maksumuistutus2.OnkoLähetetty() == true)
            {
                tuloste += "Maksumuistutus2 lähetetty: " + this.Maksumuistutus2.LähetysPvm + "\n";
            }


            if (this.Vastaanottaja != null)
            {
                tuloste += "Vastaanottaja: " + this.Vastaanottaja.Etunimi + " " + this.Vastaanottaja.Sukunimi + "\n";
                tuloste += this.Vastaanottaja.Osoite + "\n";
            }

            return tuloste;
        }
    }
}

