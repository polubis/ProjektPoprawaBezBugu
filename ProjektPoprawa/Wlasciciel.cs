
namespace Projekt_Poprawa
{
    class Wlasciciel : Uzytkownicy
    {
        private string Klucz;
        public Wlasciciel() { }
        public Wlasciciel(string Login, string Haslo, string Klucz)
        {
            this.Login = Login;
            this.Haslo = Haslo;
            this.Klucz = Klucz;
        }
    }
}
