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
        public List<Vastaanottaja> vastaanottajat { get; set; }
        private string tiedostoNimi = "henkilötiedot.Json";

        public Tallentaminen()
        {
            vastaanottajat = new List<Vastaanottaja>();
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
                        this.vastaanottajat = henkilöt.vastaanottajat;
                    }
                }
                Console.WriteLine("Tietokannan luku onnistui");
            }
            catch
            {
                Console.WriteLine("Tietokanta tiedostoa ei voitu lukea");
            }
        }
        public void LisääHenkilö(Vastaanottaja uusiHenkilö)
        {
            vastaanottajat.Add(uusiHenkilö);
            TallennaKanta();
        }
        public void TallennaKanta()
        {
            string json = JsonSerializer.Serialize<Tallentaminen>(this);
            File.WriteAllText(tiedostoNimi, json);
        }
        public void ListaaHenkilöt()

        {

            foreach (var henkilöt in vastaanottajat)
            {
                string text = $"{henkilöt.etunimi} {henkilöt.sukunimi}" +
                    $"\n{henkilöt.sposti} {henkilöt.osoite} {henkilöt.puhNo}";
                
                Console.WriteLine(text);
                Console.WriteLine();
            }

        }

    }
}
