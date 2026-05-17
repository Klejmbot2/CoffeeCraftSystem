using System;
using System.Reflection;
using System.Threading.Tasks;
using CoffeeCraft.Core;
using CoffeeCraftApp;

namespace CoffeeCraftApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======= WITAJ W EMULATORZE COFFEECRAFT =======");
            Console.ResetColor();

            Zamowienie<Kawa> aktualneZamowienie = new Zamowienie<Kawa>();
            await aktualneZamowienie.RozgrzejBojlerAsynchronicznieAsync();
            Console.WriteLine("--------------------------------------------------");

            WspolrzedneStolika stolikKlienta = new WspolrzedneStolika(1, 4);
            Console.WriteLine($"Klient usiadł w sali nr {stolikKlienta.NumerSali} przy stoliku nr {stolikKlienta.NumerStolika}.");

            string wypowiedzKlienta = "Dzień dobry, poproszę mocne Espresso!";
            Console.WriteLine($"Klient mówi: \"{wypowiedzKlienta}\"");
            if (wypowiedzKlienta.CzyZawieraSformulowanieGrzecznosciowe())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[System] Klient jest kulturalny. Naliczam rabat lojalnościowy 10%!");
                Console.ResetColor();
            }
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("[System] Barista przyjmuje zamówienie i klika przycisk na ekranie...");
            Kawa espresso = new Kawa("Espresso Ristretto", 3.0, 80.0);
            Kawa flatWhite = new Kawa("Flat White Velvet", 4.5, 90.0);
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine($"Kawa 1 była sprawdzana przez baristę: {espresso[0].Imie} (Rola: {espresso[0].Rola})");
            Console.WriteLine($"Pole powierzchni pianki Flat White wynosi: {flatWhite.PolePowierzchniPianki:F2} cm2");
            Console.WriteLine("--------------------------------------------------");

            espresso.OnCoffeeReady += WyswietlKomunikatNaEkranieKlienta;

            espresso.Przygotuj();
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("[System] Klient prosi o zlanie obu kaw do jednego kubka termicznego...");
            Kawa megaMiks = espresso + flatWhite;
            megaMiks.WyswietlMetryczke();
            Console.WriteLine($"Globalny licznik napojów wydanych dzisiaj w systemie: {NapojKofeinowy.LicznikWydanychNapojow}");
            Console.WriteLine("--------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[REFLEKSJA] Dynamiczne badanie kodu przez kompilator:");
            Console.ResetColor();

            Type typKawy = typeof(Kawa);

            var atrybutPremium = typKawy.GetCustomAttribute<PremiumProduktAttribute>();
            if (atrybutPremium != null)
            {
                Console.WriteLine($"Zaszyfrowany certyfikat produktu: {atrybutPremium.Opis}");
            }

            MethodInfo[] metodyKlasy = typKawy.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Console.WriteLine("Wykryte unikalne metody w klasie Kawa:");
            foreach (var m in metodyKlasy)
            {
                Console.WriteLine($" -> Metoda: {m.Name}, Typ zwracany: {m.ReturnType.Name}");
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zamknąć kawiarnię...");
            Console.ReadKey();
        }

        private static void WyswietlKomunikatNaEkranieKlienta(string wiadomosc)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[POWIADOMIENIE SMS KLIENTA] PING! {wiadomosc}");
            Console.ResetColor();
        }
    }
}