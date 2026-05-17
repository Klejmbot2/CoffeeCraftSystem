using System;
using CoffeeCraft.Core;

namespace CoffeeCraftApp
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PremiumProduktAttribute : Attribute
    {
        public string Opis { get; }
        public PremiumProduktAttribute(string opis) { Opis = opis; }
    }

    [PremiumProdukt("Rzemieślnicza kawa segmentu Specialty, palona lokalnie.")]
    public class Kawa : NapojKofeinowy
    {
        public static string StatusMlynka = "Skalibrowany";
        private Osoba[] barisciPrzygotowujacy = new Osoba[2];

        public delegate void PowiadomienieOKawie(string wiadomosc);
        public event PowiadomienieOKawie? OnCoffeeReady;

        private double _objetoscPiankiMl;
        public double ObjetoscPiankiMl
        {
            get => _objetoscPiankiMl;
            set => _objetoscPiankiMl = value < 0 ? 0 : value;
        }

        public double PromienFilizankiCm { get; set; }
        public double PolePowierzchniPianki => Math.PI * Math.Pow(PromienFilizankiCm, 2);
        public override int CzasPrzygotowaniaWSekundach => 3;

        public Osoba this[int index]
        {
            get => barisciPrzygotowujacy[index];
            set => barisciPrzygotowujacy[index] = value;
        }

        static Kawa()
        {
            Console.WriteLine("[Konstruktor Statyczny] Klasa Kawa załadowana. Młynek: " + StatusMlynka);
        }

        public Kawa(string nazwa, double promien, double kofeina) : base(nazwa)
        {
            Console.WriteLine($"[Konstruktor Instancji] Tworzenie filiżanki: {nazwa}");
            PromienFilizankiCm = promien;
            _poziomKofeiny = kofeina;

            barisciPrzygotowujacy[0] = new Osoba("Ania", "Master Barista");
            barisciPrzygotowujacy[1] = new Osoba("Tomek", "Pomocnik");
        }

        public override void WyswietlMetryczke()
        {
            base.WyswietlMetryczke();
            Console.WriteLine($" -> Specyfikacja kawy: Poziom kofeiny: {_poziomKofeiny}mg, Powierzchnia latte art: {PolePowierzchniPianki:F2} cm2");
        }

        public override void Przygotuj()
        {
            Console.WriteLine($"[Ekspres] Rozpoczynam mielenie ziaren dla {Nazwa}...");
            Console.WriteLine($"[Ekspres] Ekstrakcja pod ciśnieniem na urządzeniu {MarkaEkspresu}...");
            OnCoffeeReady?.Invoke($"Twoja pyszna {Nazwa} jest gotowa do odbioru przy barze!");
        }

        public static Kawa operator +(Kawa k1, Kawa k2)
        {
            double nowaKofeina = k1.PoziomKofeiny + k2.PoziomKofeiny;
            double wiekszaFilizanka = Math.Max(k1.PromienFilizankiCm, k2.PromienFilizankiCm);
            return new Kawa($"Double Shot ({k1.Nazwa} + {k2.Nazwa})", wiekszaFilizanka, nowaKofeina);
        }
    }
}