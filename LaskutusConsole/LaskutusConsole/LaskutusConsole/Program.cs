using LaskutusConsole;
using System.Text.Json;

var matti = new Vastaanottaja("Matti", "Mattinen", "Kotikatu 12", "044123456", "sposti@gmail.fi");
//var hahmo = new Vastaanottaja("Henkilö", "Tietoja", "asunto", "044222222", "sähköp@gmail.com");
Tallentaminen tallentaminen = new Tallentaminen();

var lasku = new Lasku(144.4F, matti);

//tallentaminen.LisääLasku(lasku);
tallentaminen.Init();
tallentaminen.ListaaLaskut();

