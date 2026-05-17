using System;

namespace CoffeeCraftApp
{
    public struct WspolrzedneStolika
    {
        public int NumerSali { get; set; }
        public int NumerStolika { get; set; }

        public WspolrzedneStolika(int sala, int stolik)
        {
            NumerSali = sala;
            NumerStolika = stolik;
        }
    }

    public class Osoba
    {
        public string Imie { get; set; }
        public string Rola { get; set; }

        public Osoba(string imie, string rola)
        {
            Imie = imie;
            Rola = rola;
        }
    }
}