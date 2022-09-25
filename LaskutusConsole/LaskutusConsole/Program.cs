// See https://aka.ms/new-console-template for more information


using LaskutusConsole;
var lasku = new Lasku();
var matti = new Vastaanottaja("Matti", "Mattinen", "Kotikatu 12", "044123456", "sposti@gmail.fi");
var lasku1 = new Lasku();
lasku.AsetaLasku(144.4F, matti);
lasku1.AsetaLasku(255.5F, matti);
Console.WriteLine(lasku.laskuInfo(matti));

Console.WriteLine(lasku1.laskuInfo(matti));