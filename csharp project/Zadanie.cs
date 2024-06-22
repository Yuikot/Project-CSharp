using System;

namespace csharp_project
{

    [Serializable]
    public class Zadanie
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public bool CzyWykonane { get; set; }

        public Zadanie() { }

        public Zadanie(int id, string nazwa, string opis, DateTime dataZakonczenia, bool czyWykonane = false)
        {
            Id = id;
            Nazwa = nazwa;
            Opis = opis;
            DataZakonczenia = dataZakonczenia;
            CzyWykonane = czyWykonane;
        }

        public override string ToString()
        {
            return $"Zadanie(Id={Id}, Nazwa={Nazwa}, Opis={Opis}, DataZakonczenia={DataZakonczenia.ToShortDateString()}, CzyWykonane={CzyWykonane})";
        }
    }


}
