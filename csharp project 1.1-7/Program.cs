using System.Diagnostics;
using System.Text;


void z1()
{
    Samochod s1 = new Samochod();
    s1.WypiszInfo(); 
    s1.Marka = "Fiat";
    s1.Model = "126p";
    s1.IloscDrzwi = 2;
    s1.PojemnoscSilnika = 650;
    s1.SrednieSpalanie = 6.0;
    s1.WypiszInfo();  

    Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);
    s2.WypiszInfo(); 

    double kosztPrzejazdu = s2.ObliczKosztPrzejazdu(30.5, 4.85);
    Console.WriteLine("Koszt przejazdu: " + kosztPrzejazdu);

    Samochod.WypiszIloscSamochodow();  
    Console.ReadKey();
}

void z2()
{
    Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0);
    Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);

    Garaz g1 = new Garaz();
    g1.Adres = "ul. Garażowa 1";
    g1.Pojemnosc = 1;

    Garaz g2 = new Garaz("ul. Garażowa 2", 2);

    g1.WprowadzSamochod(s1);
    g1.WypiszInfo();

    g1.WprowadzSamochod(s2);

    g2.WprowadzSamochod(s2);
    g2.WprowadzSamochod(s1);
    g2.WypiszInfo();

    g2.WyprowadzSamochod();
    g2.WypiszInfo();

    g2.WyprowadzSamochod();
    g2.WyprowadzSamochod();

    Console.ReadKey();
}

void z3()
{
    string filePath = "Test2.txt";

    try
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                string content = sr.ReadToEnd();
                Console.WriteLine(content);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Wystąpił błąd: " + ex.Message);
    }
}

void z4()
{
    string filePath = "Test.txt";

    try
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    char[] charArray = line.ToCharArray();
                    Array.Reverse(charArray);
                    Console.WriteLine(new string(charArray));
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Wystąpił błąd: " + ex.Message);
    }
}

void z5()
{
    string filePath = "data.bin";

    Console.WriteLine("Wybierz opcję:");
    Console.WriteLine("1. Zapisz dane");
    Console.WriteLine("2. Odczytaj dane");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Podaj imię: ");
        string name = Console.ReadLine();
        Console.Write("Podaj wiek: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Podaj adres: ");
        string address = Console.ReadLine();

        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(name);
                writer.Write(age);
                writer.Write(address);
            }
        }
        Console.WriteLine("Dane zapisane.");
    }
    else if (choice == "2")
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    string name = reader.ReadString();
                    int age = reader.ReadInt32();
                    string address = reader.ReadString();

                    Console.WriteLine("Odczytane dane:");
                    Console.WriteLine($"Imię: {name}");
                    Console.WriteLine($"Wiek: {age}");
                    Console.WriteLine($"Adres: {address}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd: " + ex.Message);
        }
    }
    else
    {
        Console.WriteLine("Nieprawidłowy wybór.");
    }
}

void z6()
{
    string sourceFilePath = "Test.txt";
    string destinationFilePath = "Test2.txt";

    try
    {
        using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
        {
            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
            {
                sourceStream.CopyTo(destinationStream);
            }
        }
        Console.WriteLine("Plik został skopiowany.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Wystąpił błąd: " + ex.Message);
    }
}

void z7()
{
    string sourceFilePath = "sourceLargeFile.bin";
    string destinationFilePath = "destinationLargeFile.bin";

    CreateLargeFile(sourceFilePath, 300 * 1024 * 1024);

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    try
    {
        using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
        {
            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
            {
                sourceStream.CopyTo(destinationStream);
            }
        }
        stopwatch.Stop();
        Console.WriteLine("Plik został skopiowany w czasie: " + stopwatch.ElapsedMilliseconds + " ms");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Wystąpił błąd: " + ex.Message);
    }


    static void CreateLargeFile(string filePath, long size)
    {
        byte[] data = new byte[1024 * 1024];
        new Random().NextBytes(data);

        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            for (long i = 0; i < size; i += data.Length)
            {
                fs.Write(data, 0, data.Length);
            }
        }
    }
}

z4();