// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

internal class Vastaanottaja
{
    public string etunimi { get; set; }
    public string sukunimi { get; set; }
    public string osoite { get; set; }
    public string puhNo { get; set; }
    public string sposti { get; set; }

    public Vastaanottaja(string etunimi, string sukunimi, string osoite, string puhNo, string sposti)
    {
        this.etunimi = etunimi;
        this.sukunimi = sukunimi;
        this.osoite = osoite;
        this.puhNo = puhNo;
        this.sposti = sposti;
    }
}