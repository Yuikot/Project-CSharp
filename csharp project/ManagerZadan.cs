using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using csharp_project;

public class ManagerZadan
{
    private List<Zadanie> zadania = new List<Zadanie>();

    public void DodajZadanie(Zadanie zadanie)
    {
        zadania.Add(zadanie);
    }

    public void UsunZadanie(int id)
    {
        zadania.RemoveAll(z => z.Id == id);
    }

    public List<Zadanie> PobierzZadania()
    {
        return zadania;
    }

    public void EdytujZadanie(int id, string nowaNazwa, string nowyOpis, DateTime nowaDataZakonczenia, bool czyWykonane)
    {
        var zadanie = zadania.Find(z => z.Id == id);
        if (zadanie != null)
        {
            zadanie.Nazwa = nowaNazwa;
            zadanie.Opis = nowyOpis;
            zadanie.DataZakonczenia = nowaDataZakonczenia;
            zadanie.CzyWykonane = czyWykonane;
        }
    }

    public void OznaczJakoWykonane(int id)
    {
        var zadanie = zadania.Find(z => z.Id == id);
        if (zadanie != null)
        {
            zadanie.CzyWykonane = true;
        }
    }

    // Serializacja binarna
    public void ZapiszDoPlikuBinarnego(string sciezka)
    {
        using (FileStream fs = new FileStream(sciezka, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, zadania);
        }
    }

    public void WczytajZPlikuBinarnego(string sciezka)
    {
        if (File.Exists(sciezka))
        {
            using (FileStream fs = new FileStream(sciezka, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                zadania = (List<Zadanie>)formatter.Deserialize(fs);
            }
        }
    }

    // Serializacja XML
    public void ZapiszDoPlikuXML(string sciezka)
    {
        using (StreamWriter sw = new StreamWriter(sciezka))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Zadanie>));
            serializer.Serialize(sw, zadania);
        }
    }

    public void WczytajZPlikuXML(string sciezka)
    {
        if (File.Exists(sciezka))
        {
            using (StreamReader sr = new StreamReader(sciezka))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Zadanie>));
                zadania = (List<Zadanie>)serializer.Deserialize(sr);
            }
        }
    }

    // Serializacja JSON
    public void ZapiszDoPlikuJSON(string sciezka)
    {
        var json = JsonConvert.SerializeObject(zadania, Formatting.Indented);
        File.WriteAllText(sciezka, json);
    }

    public void WczytajZPlikuJSON(string sciezka)
    {
        if (File.Exists(sciezka))
        {
            var json = File.ReadAllText(sciezka);
            zadania = JsonConvert.DeserializeObject<List<Zadanie>>(json);
        }
    }

    public void SortujZadaniaPoDacie()
    {
        zadania.Sort((z1, z2) => z1.DataZakonczenia.CompareTo(z2.DataZakonczenia));
    }

    public void SortujZadaniaPoNazwie()
    {
        zadania.Sort((z1, z2) => z1.Nazwa.CompareTo(z2.Nazwa));
    }
}
