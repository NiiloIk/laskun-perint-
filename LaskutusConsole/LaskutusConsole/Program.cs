// See https://aka.ms/new-console-template for more information


using LaskutusConsole;

var matti = new Vastaanottaja("Matti", "Mattinen", "Kotikatu 12", "044123456", "sposti@gmail.fi");

var mattilasku = new AsetaLasku(125.45F, matti);

Console.WriteLine(mattilasku.laskuInfo());

// Console.WriteLine(matti.Info());

