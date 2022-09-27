using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektityö.Luokat
{
    internal class Maksumuistutus
    {
        private Lasku Isäntälasku;
        public DateTime? LähetysPvm { get; set; }
        public bool Lähetetty
        {
            get { return this.LähetysPvm != null; }
            set { /* throw new Exception("Aseta lähetysPvm"); */ }
        }


        public void AsetaIsäntälasku(Lasku Isäntälasku)
        {
            this.Isäntälasku = Isäntälasku;
        }

        public bool voikoLähettää()
        {
            if (this.Lähetetty || this.Isäntälasku.Maksettu)
            {
                return false;
            }

            bool olenkoMaksumuistutus1 = this.Isäntälasku.Maksumuistutus1 == this;

            //DateOnly pvmTänään = DateOnly.FromDateTime(DateTime.Now);
            DateTime pvmTänään = DateTime.Now;

            if (olenkoMaksumuistutus1 && pvmTänään > this.Isäntälasku.Eräpäivä.AddDays(14))
            {
                return true;
            }
            else
            {
                return pvmTänään > this.Isäntälasku.Eräpäivä.AddDays(28);
            }
        }

        public void Lähetä()
        {
            if (!this.voikoLähettää())
            {
                throw new Exception("Maksumuistutusta ei voi lähettää!");
            }
            //this.LähetysPvm = DateOnly.FromDateTime(DateTime.Now);
            this.LähetysPvm = DateTime.Now;
            this.Isäntälasku.lisääMaksulisä(new Maksulisä()); // TODO: aseta maksulisän tyyppi, hinta yms.
        }

        public Maksumuistutus()
        {

        }

        public Maksumuistutus(Lasku isäntälasku)
        {
            this.Isäntälasku = isäntälasku;
        }

        public Maksumuistutus(Lasku isäntälasku, DateTime? lähetysPvm, bool lähetetty) : this(isäntälasku)
        {
            LähetysPvm = lähetysPvm;
            Lähetetty = lähetetty;
        }
    }
}
