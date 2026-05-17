using System;

namespace CoffeeCraft.Core
{
    public interface IPreparable
    {
        int CzasPrzygotowaniaWSekundach { get; }
        void Przygotuj();
    }

    public abstract class NapojKofeinowy : IPreparable
    {
        public const string MarkaEkspresu = "La Marzocco 2026";
        public readonly DateTime DataParzenia;
        public static int LicznikWydanychNapojow = 0;

        protected double _poziomKofeiny;
        public double PoziomKofeiny => _poziomKofeiny;
        public string Nazwa { get; protected set; }
        public abstract int CzasPrzygotowaniaWSekundach { get; }

        public NapojKofeinowy(string nazwa)
        {
            Nazwa = nazwa;
            DataParzenia = DateTime.Now;
            LicznikWydanychNapojow++;
        }

        public virtual void WyswietlMetryczke()
        {
            Console.WriteLine($"Napój: {Nazwa}, Przygotowano: {DataParzenia.ToLongTimeString()}");
        }

        public abstract void Przygotuj();
    }

    internal class SekretnaRecepturaSzefa
    {
        internal string TajnySkladnik = "Szczypta kardamonu i miłości";
    }
}