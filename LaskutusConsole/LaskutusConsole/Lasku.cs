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
        float summa;
        float maksettava; // summa + maksulisät
        DateTime alkuPvm;
        DateTime eräpäivä;
        Vastaanottaja henkilö;
        bool laskuSuoritettu = false;
        DateTime maksuPäivä;
        // maksulisä lista

        public void AsetaLasku(float MääräEuroina, Vastaanottaja Henkilö)
        {
            DateTime päivämäärä = DateTime.Now;
            summa = MääräEuroina;
            henkilö = Henkilö;
            alkuPvm = päivämäärä;
            eräpäivä = päivämäärä.AddDays(14);
        }
        public string laskuInfo(Vastaanottaja henkilö)
        {
            return ($"Määrä euroina: {Maksulisä()}\nHenkilö: {henkilö.Nimi()}\n" +
                $"Laskun voimaan astumis päivämäärä: {alkuPvm}\nEräpäivämäärä: {eräpäivä}" +
                $"\nOnko maksettu: {OnkoSuoritettu(laskuSuoritettu)}");
        }
        private string OnkoSuoritettu(bool suoritettu)
        {
            string vastaus = (suoritettu) ? "On" : "Ei";
            return vastaus;
        }
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
