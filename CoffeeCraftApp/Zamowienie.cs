using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeCraft.Core;

namespace CoffeeCraftApp
{
    public class Zamowienie<T> where T : NapojKofeinowy
    {
        private List<T> koszykProduktow = new List<T>();

        public void DodajDoZamowienia(T produkt)
        {
            koszykProduktow.Add(produkt);
            Console.WriteLine($"[Koszyk] Dodano {produkt.Nazwa} do Twojego zamówienia.");
        }

        public List<T> PobierzProdukty() => koszykProduktow;

        public async Task RozgrzejBojlerAsynchronicznieAsync()
        {
            Console.WriteLine("[Async] Ekspres uruchamia procedurę nagrzewania bojlera (Eko-tryb)...");
            await Task.Delay(2000);
            Console.WriteLine("[Async] Bojler osiągnął temperaturę 94°C. Można parzyć!");
        }
    }
}