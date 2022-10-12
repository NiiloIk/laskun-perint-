using System;


namespace projektityö.Luokat
{
    public class Maksumuistutus
    {
        private Lasku Isäntälasku;
        public DateTime? LähetysPvm { get; set; }

        public bool OnkoLähetetty()
        {
            return this.LähetysPvm != null;
        }

        public void AsetaIsäntälasku(Lasku Isäntälasku)
        {
            this.Isäntälasku = Isäntälasku;
        }

        public bool voikoLähettää()
        {
            if (this.Isäntälasku == null)
            {
                throw new Exception("Maksumuistutuksen isäntälaskua ei ole asetettu!");
            }

            if (this.OnkoLähetetty() || this.Isäntälasku.OnkoMaksettu())
            {
                return false;
            }

            bool olenkoMaksumuistutus1 = this.Isäntälasku.Maksumuistutus1 == this;

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

        public Maksumuistutus(Lasku isäntälasku, DateTime? lähetysPvm) : this(isäntälasku)
        {
            LähetysPvm = lähetysPvm;
        }
    }
}
