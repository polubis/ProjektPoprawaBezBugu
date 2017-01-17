
namespace Projekt_Poprawa
{
    class Pracownik : Uzytkownicy
    {

        private string Funkcja;
        public Pracownik() { }
        public Pracownik(string Login, string Haslo, string Funkcja)
        {
            this.Login = Login;
            this.Haslo = Haslo;
            this.Funkcja = Funkcja;
        }

    }
}
