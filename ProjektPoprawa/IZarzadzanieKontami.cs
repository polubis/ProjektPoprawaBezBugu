
namespace Projekt_Poprawa
{
    interface IZarzadzanieKontami
    {
        void dodajPracownika(string Login, string Haslo, string Funkcja);
        void dodajWlasciciela(string Login, string Haslo, string Klucz);
    }
}
