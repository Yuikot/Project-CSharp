using System;
using csharp_project;

class Program
{
    static void Main(string[] args)
    {
        ManagerZadan manager = new ManagerZadan();
        string sciezka = "zadania";

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Dodaj zadanie");
            Console.WriteLine("2. Usuń zadanie");
            Console.WriteLine("3. Wyświetl zadania");
            Console.WriteLine("4. Edytuj zadanie");
            Console.WriteLine("5. Oznacz zadanie jako wykonane");
            Console.WriteLine("6. Zapisz zadania do pliku");
            Console.WriteLine("7. Wczytaj zadania z pliku");
            Console.WriteLine("8. Sortuj zadania po dacie");
            Console.WriteLine("9. Sortuj zadania po nazwie");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybierz opcję: ");
            var opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    DodajZadanie(manager);
                    break;
                case "2":
                    UsunZadanie(manager);
                    break;
                case "3":
                    WyswietlZadania(manager);
                    break;
                case "4":
                    EdytujZadanie(manager);
                    break;
                case "5":
                    OznaczJakoWykonane(manager);
                    break;
                case "6":
                    ZapiszZadania(manager, sciezka);
                    break;
                case "7":
                    WczytajZadania(manager, sciezka);
                    break;
                case "8":
                    manager.SortujZadaniaPoDacie();
                    Console.WriteLine("Zadania posortowane po dacie.");
                    break;
                case "9":
                    manager.SortujZadaniaPoNazwie();
                    Console.WriteLine("Zadania posortowane po nazwie.");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }

    static void DodajZadanie(ManagerZadan manager)
    {
        try
        {
            Console.Write("Podaj ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Podaj nazwę: ");
            string nazwa = Console.ReadLine();
            Console.Write("Podaj opis: ");
            string opis = Console.ReadLine();
            DateTime dataZakonczenia;

            while (true)
            {
                Console.Write("Podaj datę zakończenia (yyyy-mm-dd): ");
                dataZakonczenia = DateTime.Parse(Console.ReadLine());

                if (dataZakonczenia < DateTime.Today)
                {
                    Console.WriteLine("Data zadania, które chcesz dodać, jest w przeszłości. Czy chcesz kontynuować? (tak/nie)");
                    var decyzja = Console.ReadLine();
                    if (decyzja.ToLower() == "tak")
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            Zadanie zadanie = new Zadanie(id, nazwa, opis, dataZakonczenia);
            manager.DodajZadanie(zadanie);
            Console.WriteLine("Zadanie dodane.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Nieprawidłowy format danych. Spróbuj ponownie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }

    static void UsunZadanie(ManagerZadan manager)
    {
        try
        {
            Console.Write("Podaj ID zadania do usunięcia: ");
            int id = int.Parse(Console.ReadLine());
            manager.UsunZadanie(id);
            Console.WriteLine("Zadanie usunięte.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Nieprawidłowy format danych. Spróbuj ponownie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }

    static void WyswietlZadania(ManagerZadan manager)
    {
        var zadania = manager.PobierzZadania();
        if (zadania.Count == 0)
        {
            Console.WriteLine("Brak zadań do wyświetlenia.");
        }
        else
        {
            foreach (var zadanie in zadania)
            {
                Console.WriteLine(zadanie);
            }
        }
    }

    static void EdytujZadanie(ManagerZadan manager)
    {
        try
        {
            Console.Write("Podaj ID zadania do edycji: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Podaj nową nazwę: ");
            string nowaNazwa = Console.ReadLine();
            Console.Write("Podaj nowy opis: ");
            string nowyOpis = Console.ReadLine();
            Console.Write("Podaj nową datę zakończenia (yyyy-mm-dd): ");
            DateTime nowaDataZakonczenia = DateTime.Parse(Console.ReadLine());
            Console.Write("Czy zadanie wykonane? (true/false): ");
            bool czyWykonane = bool.Parse(Console.ReadLine());

            manager.EdytujZadanie(id, nowaNazwa, nowyOpis, nowaDataZakonczenia, czyWykonane);
            Console.WriteLine("Zadanie zaktualizowane.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Nieprawidłowy format danych. Spróbuj ponownie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }

    static void OznaczJakoWykonane(ManagerZadan manager)
    {
        try
        {
            Console.Write("Podaj ID zadania do oznaczenia jako wykonane: ");
            int id = int.Parse(Console.ReadLine());
            manager.OznaczJakoWykonane(id);
            Console.WriteLine("Zadanie oznaczone jako wykonane.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Nieprawidłowy format danych. Spróbuj ponownie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }

    static void ZapiszZadania(ManagerZadan manager, string sciezka)
    {
        Console.WriteLine("Wybierz format zapisu: ");
        Console.WriteLine("1. Binarne");
        Console.WriteLine("2. XML");
        Console.WriteLine("3. JSON");
        Console.Write("Wybierz opcję: ");
        var opcja = Console.ReadLine();

        try
        {
            switch (opcja)
            {
                case "1":
                    manager.ZapiszDoPlikuBinarnego($"{sciezka}.bin");
                    Console.WriteLine("Zadania zapisane w formacie binarnym.");
                    break;
                case "2":
                    manager.ZapiszDoPlikuXML($"{sciezka}.xml");
                    Console.WriteLine("Zadania zapisane w formacie XML.");
                    break;
                case "3":
                    manager.ZapiszDoPlikuJSON($"{sciezka}.json");
                    Console.WriteLine("Zadania zapisane w formacie JSON.");
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas zapisu: {ex.Message}");
        }
    }

    static void WczytajZadania(ManagerZadan manager, string sciezka)
    {
        Console.WriteLine("Wybierz format wczytywania: ");
        Console.WriteLine("1. Binarne");
        Console.WriteLine("2. XML");
        Console.WriteLine("3. JSON");
        Console.Write("Wybierz opcję: ");
        var opcja = Console.ReadLine();

        try
        {
            switch (opcja)
            {
                case "1":
                    manager.WczytajZPlikuBinarnego($"{sciezka}.bin");
                    Console.WriteLine("Zadania wczytane z formatu binarnego.");
                    break;
                case "2":
                    manager.WczytajZPlikuXML($"{sciezka}.xml");
                    Console.WriteLine("Zadania wczytane z formatu XML.");
                    break;
                case "3":
                    manager.WczytajZPlikuJSON($"{sciezka}.json");
                    Console.WriteLine("Zadania wczytane z formatu JSON.");
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania: {ex.Message}");
        }
    }
}
