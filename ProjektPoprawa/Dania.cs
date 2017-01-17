
namespace Projekt_Poprawa
{
    class Dania
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public double Cena { get; set; }
        public string Rodzaj { get; set; }
        public Dania() { }
        public Dania(int ID, string Nazwa, double Cena, string Rodzaj)
        {
            this.ID = ID;
            this.Nazwa = Nazwa;
            this.Cena = Cena;
            this.Rodzaj = Rodzaj;
        }
    }
}
