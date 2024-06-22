
class Samochod
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public int IloscDrzwi { get; set; }
    public double PojemnoscSilnika { get; set; }
    public double SrednieSpalanie { get; set; }

    private static int iloscSamochodow = 0;

    public Samochod()
    {
        Marka = "nieznana";
        Model = "nieznany";
        IloscDrzwi = 0;
        PojemnoscSilnika = 0.0;
        SrednieSpalanie = 0.0;
        iloscSamochodow++;
    }


    public Samochod(string marka, string model, int iloscDrzwi, double pojemnoscSilnika, double srednieSpalanie)
    {
        Marka = marka;
        Model = model;
        IloscDrzwi = iloscDrzwi;
        PojemnoscSilnika = pojemnoscSilnika;
        SrednieSpalanie = srednieSpalanie;
        iloscSamochodow++;
    }


    private double ObliczSpalanie(double dlugoscTrasy)
    {
        return (SrednieSpalanie * dlugoscTrasy) / 100.0;
    }


    public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa)
    {
        double spalanie = ObliczSpalanie(dlugoscTrasy);
        return spalanie * cenaPaliwa;
    }


    public void WypiszInfo()
    {
        Console.WriteLine($"Marka: {Marka}, Model: {Model}, Ilość drzwi: {IloscDrzwi}, Pojemność silnika: {PojemnoscSilnika} l, Średnie spalanie: {SrednieSpalanie} l/100km");
    }


    public static void WypiszIloscSamochodow()
    {
        Console.WriteLine($"Liczba utworzonych samochodów: {iloscSamochodow}");
    }
}
