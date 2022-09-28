using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LaskutusConsole
{
    internal class Lasku
    {
        // Tarpeelliset tiedot public:ina jotta tiedot tallentuvat.
        public float summa { get; set; }
        public Vastaanottaja henkilö { get; set; }
        public DateTime alkuPvm { get; set; }
        public DateTime eräpäivä { get; set; }
        public bool laskuSuoritettu;

        // nämä pitää vielä lisätä jos haluaa.

        float maksettava; // summa + maksulisät
        DateTime maksuPäivä;
        //maksulisä lista

        // Tässä constructori joka luo laskun.
        // ei tarvitse erikseen tehdä AsetaLasku funktiota.
        public Lasku(float summa, Vastaanottaja henkilö)
        {
            this.summa = summa;
            this.henkilö = henkilö;
            alkuPvm = DateTime.Now;
            eräpäivä = alkuPvm.AddDays(14);
            laskuSuoritettu = false;
        }
        // !!Tämän voi käytännössä poistaa!!
        //public void AsetaLasku(float MääräEuroina, Vastaanottaja Henkilö)
        //{
        //    DateTime päivämäärä = DateTime.Now;
        //    summa = MääräEuroina;
        //    henkilö = Henkilö;
        //    alkuPvm = päivämäärä;
        //    eräpäivä = päivämäärä.AddDays(14);
        //}

        // Tätäkään ei käytännössä tarvitse tulevaisuudessa
        //public string laskuTiedot(Vastaanottaja henkilö)
        //{
        //    return ($"Määrä euroina: {Maksulisä()}\nHenkilö: {henkilö.etunimi} {henkilö.sukunimi}\n" +
        //        $"Laskun voimaan astumis päivämäärä: {alkuPvm}\nEräpäivämäärä: {eräpäivä}" +
        //        $"\nOnko maksettu: {OnkoSuoritettu(laskuSuoritettu)}");
        //}

        // tämänkin voisi ehkä viedä johonkin toiseen paikkaan jotta tämä
        // Lasku osio pysyisi yksinkertaisempana ja selkeämpänä
        private float Maksulisä()
        {
            DateTime nyt = DateTime.Now;
            if (nyt > eräpäivä)
            {
                return summa + summa * 0.05F;
            }
            else
            {
                return summa;
            }
        }
    }
}
