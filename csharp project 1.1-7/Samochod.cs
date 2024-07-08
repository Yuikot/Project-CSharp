class Samochod
{
    private string marka;
    private string model;
    private int iloscDrzwi;
    private double pojemnoscSilnika;
    private double srednieSpalanie;
    public string Marka
    {
        get { return marka; }
        set { marka = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public int IloscDrzwi
    {
        get { return iloscDrzwi; }
        set { iloscDrzwi = value; }
    }

    public double PojemnoscSilnika
    {
        get { return pojemnoscSilnika; }
        set { pojemnoscSilnika = value; }
    }
    public double SrednieSpalanie
    {
        get { return srednieSpalanie; }
        set { srednieSpalanie = value; }
    }

    private static int iloscSamochodow = 0;

    public Samochod()
    {
        marka = "nieznana";
        model = "nieznany";
        iloscSamochodow = 0;
        pojemnoscSilnika = 0.0;
        srednieSpalanie = 0.0;
        iloscSamochodow++;
    }

    public Samochod(string marka_, string model_, int iloscDrzwi_, int pojemnoscSilnika_, double srednieSpalanie_)
    {
        iloscSamochodow++;
        marka = marka_;
        model = model_;
        iloscDrzwi = iloscDrzwi_;
        pojemnoscSilnika = pojemnoscSilnika_;
        srednieSpalanie = srednieSpalanie_;
    }
    private double ObliczSpalanie(double dlugoscTrasy)
    {
        double spalanie = (pojemnoscSilnika * dlugoscTrasy) / 100;
        return spalanie;
    }

    public double ObliczKosztPrzejazdu(double spalanie, double cenaPaliwa)
    {
        double kosztPrzejazdu = spalanie * cenaPaliwa;
        return kosztPrzejazdu;
    }
    public void WypiszInfo()
    {
        Console.WriteLine("Marka: " + marka);
        Console.WriteLine("Model: " + model);
        Console.WriteLine("Ilość drzwi: " + iloscDrzwi);
        Console.WriteLine("Pojemność silnika: " + pojemnoscSilnika);
        Console.WriteLine("Średnie spalanie: " + srednieSpalanie);
    }
    public static void WypiszIloscSamochodow()
    {
        Console.WriteLine("Liczba samochodów: " + iloscSamochodow);
    }

}
