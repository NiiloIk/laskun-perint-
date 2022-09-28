using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.Authentication;

namespace LaskutusConsole
{
    internal class Tallentaminen
    {
        public List<Lasku> Laskut { get; set; }
        private string tiedostoNimi = "laskutiedot.Json";

        public Tallentaminen()
        {
            Laskut = new List<Lasku>();
        }
        
        public void Init()
        {
            try
            {
                var raakaJson = File.ReadAllText(tiedostoNimi);
                if (raakaJson.Length > 5)
                {
                    var henkilöt = JsonSerializer.Deserialize<Tallentaminen>(raakaJson);
                    if (henkilöt != null)
                    {
                        this.Laskut = henkilöt.Laskut;
                    }
                }
                Console.WriteLine("Tietokannan luku onnistui");
            }
            catch
            {
                Console.WriteLine("Tietokanta tiedostoa ei voitu lukea");
            }
        }
        public void LisääLasku(Lasku uusiLasku)
        {
            Laskut.Add(uusiLasku);
            
            TallennaKanta();
        }
        public void TallennaKanta()
        {
            string json = JsonSerializer.Serialize<Tallentaminen>(this);
            File.WriteAllText(tiedostoNimi, json);
        }
        public void ListaaLaskut()

        {

            foreach (var lasku in Laskut)
            {
                string maksettu = (lasku.laskuSuoritettu) ? "On" : "Ei";
                string text = $"Määrä euroina: {lasku.summa}\nHenkilö: {lasku.henkilö.etunimi} {lasku.henkilö.sukunimi}\n" +
                    $"Voimaan astumis päivämäärä: {lasku.alkuPvm}\nEräpäivämäärä: {lasku.eräpäivä}\n" +
                    $"Onko maksettu: {maksettu}";
                
                Console.WriteLine(text);
                Console.WriteLine();
            }

        }

    }
}
