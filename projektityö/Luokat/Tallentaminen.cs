using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace projektityö.Luokat
{
    public class Tallentaminen
    {
        // laskutiedot menevät kansiossa ositteeseen:
        // .\Olio-ohjelmointi-projekti\projektityö\bin\Debug\net6.0-windows
        
        public List<Lasku> Laskut { get; set; }
        private string tiedostoNimi = "laskutiedot.Json";

        public Tallentaminen()
        {
            Laskut = new List<Lasku>();
        }

        // Init osio hakee tiedot laskutiedot.Json
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
        
        // TÄLLÄ TOIMINNOLLA TALLENNETAAN UUDET LASKUT MUISTIIN!!!!!!!
        // Tallentaa myös henkilötiedot samalla
        public void LisääLasku(Lasku uusiLasku)
        {
            Laskut.Add(uusiLasku);

            TallennaKanta();
        }
        public void PoistaLasku(Lasku poistettava)
        {
            Laskut.Remove(poistettava);

            TallennaKanta();
        }
        public void TallennaKanta()
        {
            string json = JsonSerializer.Serialize<Tallentaminen>(this);
            File.WriteAllText(tiedostoNimi, json);
        }

        // listaa aiempien laskujen tiedot consoleen
        public string ListaaLaskut()

        {

            foreach (var lasku in Laskut)
            {
                //henkilötietoihin pääsee käsiksi jos kirjoittaa.
                //lasku.Vastaanottaja.[tieto]
                // Näitä voi hyödyntää kun lähettää tiedot WPF näytölle.
                
                //string text = $"Määrä euroina: {lasku.summa}\nHenkilö: {lasku.Vastaanottaja.Etunimi} {lasku.Vastaanottaja.Sukunimi}\n" +
                //    $"\nEräpäivämäärä: {lasku.Eräpäivä}\n" +
                //    $"Maksulisä: {lasku.Maksulisät}";
                
                return lasku.Tietotuloste();
            }
            return "Ei laskutietoja";
        }

    }
}