using LaskutusConsole;
using System.Text.Json;

//var matti = new Vastaanottaja("Matti", "Mattinen", "Kotikatu 12", "044123456", "sposti@gmail.fi");
//var hahmo = new Vastaanottaja("Henkilö", "Tietoja", "asunto", "044222222", "sähköp@gmail.com");
Tallentaminen henkilöt = new Tallentaminen();

henkilöt.Init();
henkilöt.ListaaHenkilöt();
/*
var lasku = new Lasku();
var lasku1 = new Lasku();
lasku.AsetaLasku(144.4F, matti);
lasku1.AsetaLasku(255.5F, matti);
Console.WriteLine(lasku.laskuTiedot(matti));
Console.WriteLine();
Console.WriteLine(lasku1.laskuTiedot(matti));
*/
