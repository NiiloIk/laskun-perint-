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
    internal class Lasku
    {
  

        public float summa { get; set; }
        public float kokonaissumma
        {
            get {
                float yhteensä = 0;
                yhteensä += this.summa;
                for (var i = 0; i < Maksulisät.Count; i++)
                {
                    yhteensä += Maksulisät[i].Lisä;
                }
                return yhteensä;
            }
            set{
                //throw new Exception("Kokonaissumman asetus ei ole sallittua, muuta joko summaa tai maksulisiä");
            }
        }
        // DateOnly sisältää vain päivämäärät, ei tunteja tai minuutteja.
        //public DateOnly lähetyspäivä = DateOnly.FromDateTime(DateTime.Now);
        public DateTime Eräpäivä { get; set; }
        public DateTime? Maksupäivä { get; set; }
        public Boolean Maksettu
        {
            get
            {
                return this.Maksupäivä != null;
            }
            set { /* throw new Exception("Aseta maksupäivä!"); */ }
        }

        public Maksumuistutus Maksumuistutus1 { get; set; }
        public Maksumuistutus Maksumuistutus2 { get; set; }
        public Vastaanottaja Vastaanottaja { get; set; }

        //public List<Maksulisä> Maksulisät = new();
        public List<Maksulisä> Maksulisät { get; set; } = new();

        public Lasku(float summa, float kokonaissumma, DateTime eräpäivä, DateTime? maksupäivä, bool maksettu, Maksumuistutus maksumuistutus1, Maksumuistutus maksumuistutus2, Vastaanottaja vastaanottaja, List<Maksulisä> maksulisät)
        {
            this.summa = summa;
            this.kokonaissumma = kokonaissumma;
            Eräpäivä = eräpäivä;
            Maksupäivä = maksupäivä;
            Maksettu = maksettu;
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
            tuloste += "Kokonaissumma: " + this.kokonaissumma + "\n";
            
            if (this.Maksettu)
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


            if (this.Maksumuistutus1.Lähetetty == true)
            {
                tuloste += "Maksumuistutus1 lähetetty: " + this.Maksumuistutus1.LähetysPvm + "\n";
            }
            if (this.Maksumuistutus2.Lähetetty == true)
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

