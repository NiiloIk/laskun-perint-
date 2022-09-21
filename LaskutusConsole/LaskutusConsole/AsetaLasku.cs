using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaskutusConsole
{
    internal class AsetaLasku
    {
        Vastaanottaja henkilö;
        float lasku;
        DateTime alkuPvm;
        DateTime eräpäivä;

        public AsetaLasku(float MääräEuroina, Vastaanottaja Henkilö)
        {
            DateTime päivämäärä = DateTime.Now;
            lasku = MääräEuroina;
            henkilö = Henkilö;
            alkuPvm = päivämäärä;
            eräpäivä = päivämäärä.AddDays(14);
        }
        public string laskuInfo()
        {
            return ($"Määrä euroina: {lasku}\nHenkilö: {henkilö.Nimi()}\n" +
                $"Laskun voimaan astumis päivämäärä: {alkuPvm}\nEräpäivämäärä: {eräpäivä}");
        }
    }
}
