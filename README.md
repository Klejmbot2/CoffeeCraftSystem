# CoffeeCraft - Symulator Kawiarni

Projekt zaliczeniowy z przedmiotu Zaawansowane Programowanie Obiektowe. Aplikacja symuluje działanie kawiarni i została napisana w języku C# (.NET 8.0). 

Zamiast interaktywnego pobierania danych od użytkownika (np. przez Console.ReadLine), program wykonuje z góry zaplanowany scenariusz. Taki zabieg pozwala w krótkim czasie zademonstrować wszystkie zaimplementowane mechanizmy obiektowe w konkretnym kontekście biznesowym, bez konieczności ręcznego wprowadzania danych.

## Struktura projektu
Rozwiązanie składa się z dwóch powiązanych ze sobą projektów:
1. CoffeeCraft.Core - biblioteka klas stanowiąca rdzeń systemu. Zawiera abstrakcję, interfejsy oraz logikę, która z założenia powinna być odseparowana od aplikacji głównej (enkapsulacja na poziomie modułów).
2. CoffeeCraftApp - aplikacja konsolowa (uruchomieniowa), która korzysta z biblioteki Core, tworzy obiekty i symuluje proces obsługi zamówień.

## Zrealizowane elementy programowania obiektowego
W kodzie zaimplementowałem wszystkie zagadnienia wymagane w programie zajęć:

* Klasy i struktury: Oprócz standardowych klas (np. Osoba), wykorzystałem strukturę WspolrzedneStolika do lżejszego przechowywania prostych danych.
* Dziedziczenie i Polimorfizm: Klasa Kawa dziedziczy po abstrakcyjnej klasie NapojKofeinowy. Metoda WyswietlMetryczke() została oznaczona jako virtual w klasie bazowej i nadpisana (override) w klasie pochodnej.
* Interfejsy i Abstrakcja: Wykorzystałem klasę abstrakcyjną oraz interfejs IPreparable, który definiuje kontrakt parzenia dla każdego napoju.
* Konstruktory i kolejność inicjalizacji: Wykorzystałem słowo kluczowe base do wywołania konstruktora klasy bazowej. W klasie Kawa znajduje się również konstruktor statyczny, który uruchamia się tylko raz, przed konstruktorami instancji.
* Właściwości i Indeksatory: Zastosowałem hermetyzację danych za pomocą właściwości z sekcjami get/set (np. zabezpieczenie przed ustawieniem ujemnej wartości). Zaimplementowałem też indeksator pozwalający na łatwy dostęp do tablicy baristów przypisanych do danej kawy.
* Zdarzenia (Events) i Delegaty: Stworzyłem zdarzenie OnCoffeeReady. Powiadamia ono główny program o zakończeniu przygotowywania napoju, co pozwala na luźne powiązanie obiektów ze sobą.
* Przeciążanie operatorów: Przeciążony operator dodawania (+) pozwala na złączenie dwóch obiektów typu Kawa w nowy napój, sumując przy tym ich poziom kofeiny.
* Typy ogólne (Generics): Klasa Zamowienie<T> została napisana jako generyczna, co pozwala na bezpieczne typologicznie przechowywanie i przetwarzanie zamówień.
* Modyfikatory dostępu: Zastosowałem modyfikatory takie jak protected (dla pól klasy bazowej) oraz internal (dla ukrycia konkretnej klasy wewnątrz projektu Core, aby nie była widoczna dla aplikacji głównej).

## Elementy wykraczające poza program podstawowy
W celu poszerzenia funkcjonalności i zademonstrowania znajomości platformy .NET, zastosowałem dodatkowo:

* Asynchroniczność (Async/Await): Symulacja nagrzewania bojlera ekspresu używa operacji Task.Delay, co demonstruje nieblokowanie głównego wątku aplikacji.
* Refleksję i atrybuty (Custom Attributes): Klasa Kawa została oznaczona autorskim atrybutem metadanych. Program na koniec swojego działania wykorzystuje refleksję do zbadania własnego kodu w czasie rzeczywistym i wypisania zadeklarowanych w klasie metod.
* Metody rozszerzające (Extension Methods): Dodałem własną metodę do systemowej, wbudowanej klasy string, co pozwala na prostą analizę językową ciągów znakowych.

## Jak uruchomić projekt?
1. Pobierz repozytorium na dysk.
2. Otwórz plik CoffeeCraftSystem.sln w środowisku Visual Studio.
3. Upewnij się, że projekt CoffeeCraftApp jest ustawiony jako projekt startowy (Startup Project).
4. Skompiluj i uruchom aplikację (skrót Ctrl + F5).
