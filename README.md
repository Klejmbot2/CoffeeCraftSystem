# ☕ CoffeeCraft - Symulator Kawiarni Rzemieślniczej

To repozytorium zawiera mój projekt zaliczeniowy z przedmiotu Programowanie Obiektowe. Zamiast tworzyć kolejny standardowy system bankowy czy kalkulator, napisałem silnik symulujący działanie inteligentnej kawiarni.

Program został napisany w języku **C# (.NET 8.0)**. Nie pobiera on danych ręcznie z klawiatury (przez `Console.ReadLine`) – zamiast tego działa jako zautomatyzowany scenariusz (Proof of Concept). Dzięki temu po jednym uruchomieniu w ułamku sekundy demonstruje on działanie wszystkich mechanizmów obiektowych i biznesowych, bez tracenia czasu na wpisywanie danych w konsoli.

## 🏗️ Struktura projektu
Projekt został celowo podzielony na dwa niezależne podzespoły (Assemblies), aby zademonstrować poprawną separację odpowiedzialności oraz widoczność kodu między modułami:
1. **CoffeeCraft.Core (Biblioteka klas):** Rdzeń systemu. Zawiera abstrakcję, interfejsy i bazowe właściwości napojów.
2. **CoffeeCraftApp (Aplikacja główna):** Warstwa wykonawcza, która symuluje działanie kawiarni, przyjmuje zamówienia i korzysta z biblioteki Core.

---

## 🧩 Wykorzystane elementy obiektowości (Zgodnie z programem zajęć)

W kodzie zaimplementowałem wszystkie wymagane zagadnienia. Poniżej znajduje się zestawienie, gdzie można je znaleźć:

*   **Klasy i struktury:** System personelu oparty na klasie `Osoba` oraz lekka struktura `WspolrzedneStolika` dla lokalizacji klientów.
*   **Dziedziczenie i Polimorfizm:** Klasa `Kawa` dziedziczy po bazowej klasie `NapojKofeinowy`. Nadpisałem też wirtualną metodę `WyswietlMetryczke()` używając `override`, aby kawa wyświetlała własne, unikalne statystyki (np. powierzchnię latte art).
*   **Interfejsy i Abstrakcja:** Bazą jest klasa abstrakcyjna (`abstract`). Dodatkowo wdrożyłem interfejs `IPreparable`, który wymusza na napojach posiadanie metody parzenia i czasu przygotowania.
*   **Konstruktory (i kolejność inicjalizacji):** Użyłem słowa kluczowego `base(...)` do przekazania parametrów do klasy bazowej. W klasie Kawa wykorzystałem **konstruktor statyczny**, który uruchamia się jako pierwszy i konfiguruje młynek.
*   **Właściwości i Indeksatory:** Właściwość z blokadą ujemnej wartości pianki (enkapsulacja). Użyłem też **indeksatora** (`this[int index]`), dzięki któremu mogę wyciągać członków załogi pracujących nad kawą w intuicyjny sposób: `espresso[0]`.
*   **Delegacje i Zdarzenia:** Komunikacja z klientem odbywa się przez zdarzenie `OnCoffeeReady` (Publisher-Subscriber). Kiedy ekspres kończy parzyć, odpala zdarzenie, a konsola "wysyła" powiadomienie SMS.
*   **Przeciążanie operatorów:** Operator `+` potrafi dodawać do siebie obiekty kawy. Dzięki temu instrukcja `espresso + flatWhite` tworzy nowy napój typu "Double Shot" i sumuje ich kofeinę.
*   **Typy ogólne (Generics):** Koszyk zamówień to generyczna, bezpieczna typologicznie klasa `Zamowienie<T>`.
*   **Modyfikatory dostępu:** Zastosowałem `protected` do ukrywania poziomu kofeiny oraz `internal` do ukrycia tajnej receptury w osobnym assembly (Aplikacja główna nie ma do niej dostępu).

---

## ⭐ Wyjście poza program (Zaawansowane mechanizmy platformy .NET)

W celu zaprezentowania szerszego zrozumienia języka C#, zaimplementowałem trzy mechanizmy wykraczające poza standardowy program zajęć:

### 1. Asynchroniczność (Async / Await)
Symulacja nagrzewania bojlera w ekspresie działa asynchronicznie przy użyciu `async Task` oraz `await Task.Delay()`. Zamiast zamrażać główny wątek aplikacji, maszyna "nagrzewa się w tle", demonstrując prawidłowe zarządzanie wątkami procesora podczas operacji wejścia/wyjścia (I/O).

### 2. Zaawansowana Refleksja i Własne Atrybuty (Custom Attributes)
Stworzyłem autorski atrybut metadanych `[PremiumProduktAttribute]`. Na zakończenie działania programu, system przy użyciu mechanizmu **Refleksji** (klasy `Type` i `MethodInfo`) dynamicznie skanuje własny kod źródłowy, odczytuje ukryty atrybut i automatycznie mapuje wszystkie publiczne metody bez ich jawnego wywoływania.

### 3. Metody Rozszerzające (Extension Methods)
Rozszerzyłem wbudowaną, zamkniętą klasę `string` o własną logikę biznesową. Metoda `CzyZawieraSformulowanieGrzecznosciowe()` sprawdza kulturę językową klienta. Pozwala to na wstrzyknięcie własnego zachowania do systemowych typów danych.

---

### ⚙️ Jak uruchomić?
1. Sklonuj repozytorium na dysk.
2. Otwórz plik `CoffeeCraftSystem.sln` w środowisku Visual Studio.
3. Upewnij się, że projekt **CoffeeCraftApp** jest oznaczony jako startowy (Startup Project).
4. Skompiluj i uruchom (Ctrl + F5).
