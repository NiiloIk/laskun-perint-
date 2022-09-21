// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

internal class Vastaanottaja
{
    string etunimi;
    string sukunimi;
    string osoite;
    string puhNo;
    string sposti;

    public Vastaanottaja(string Etunimi, string Sukunimi, string Osoite, string PuhNo, string Sposti)
    {
        etunimi = Etunimi;
        sukunimi = Sukunimi;
        osoite = Osoite;
        puhNo = PuhNo;
        sposti = Sposti;
    }
    public string Nimi()
    {
        return ($"{etunimi} {sukunimi}");
    }
    public string Info()
    {
        return ($"Nimi: {etunimi} {sukunimi}\nOsoite: {osoite}\nPuhelin numero: {puhNo}\nSähköposti: {sposti}");
    }
}