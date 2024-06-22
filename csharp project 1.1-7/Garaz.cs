class Garaz
{

    private string adres;
    private int pojemnosc;
    private int liczbaSamochodow = 0;
    private Samochod[] samochody;

    public string Adres
    {
        get { return adres; }
        set { adres = value; }
    }

    public int Pojemnosc
    {
        get { return pojemnosc; }
        set
        {
            pojemnosc = value;
            samochody = new Samochod[pojemnosc];
        }
    }


    public Garaz()
    {
        adres = "nieznany";
        pojemnosc = 0;
        samochody = null;
    }

    public Garaz(string adres_, int pojemnosc_)
    {
        adres = adres_;
        Pojemnosc = pojemnosc_;
    }


    public void WprowadzSamochod(Samochod samochod)
    {
        if (liczbaSamochodow >= pojemnosc)
        {
            Console.WriteLine("Garaż jest pełny. Nie można wprowadzić samochodu.");
        }
        else
        {
            samochody[liczbaSamochodow] = samochod;
            liczbaSamochodow++;
        }
    }


    public Samochod WyprowadzSamochod()
    {
        if (liczbaSamochodow == 0)
        {
            Console.WriteLine("Garaż jest pusty. Nie można wyprowadzić samochodu.");
            return null;
        }
        else
        {
            liczbaSamochodow--;
            Samochod samochod = samochody[liczbaSamochodow];
            samochody[liczbaSamochodow] = null;
            return samochod;
        }
    }


    public void WypiszInfo()
    {
        Console.WriteLine($"Adres garażu: {adres}, Pojemność garażu: {pojemnosc}, Liczba garażowanych samochodów: {liczbaSamochodow}");
        for (int i = 0; i < liczbaSamochodow; i++)
        {
            samochody[i].WypiszInfo();
        }
    }
}
