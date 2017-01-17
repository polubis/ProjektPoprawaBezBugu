using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Projekt_Poprawa
{
    class Konta : IZarzadzanieKontami
    {
        private List<Uzytkownicy> listaUzytkownikow;
        public Konta()
        {
            listaUzytkownikow = new List<Uzytkownicy>();
        }
        public void TworzeLogi(string Login)  // Podczas klikniecia przycisku zaloguj tworzy sie folder i informacja o tym, ze ktos sie probowal zalogowac(jego nazwa)+ data
        {
            string Sciezka = Directory.GetCurrentDirectory();
            string Czas = " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            string NazwaPliku = "_" + DateTime.Today.Day + "_" + DateTime.Today.Month + "_" + DateTime.Today.Year;
            if (!Directory.Exists("Logs"))
            {
                Directory.CreateDirectory("Logs");
            }
            Directory.SetCurrentDirectory("Logs");
            if (!File.Exists("Log" + NazwaPliku + ".txt"))
            {
                TextWriter Zapis = new StreamWriter("Log" + NazwaPliku + ".txt", true);
                Zapis.WriteLine(Login + Czas);
                Zapis.Close();
            }
            else
            {
                TextWriter Zapis = new StreamWriter("Log" + NazwaPliku + ".txt", true);
                Zapis.WriteLine(Login + Czas);
                Zapis.Close();
            }
            Directory.SetCurrentDirectory(Sciezka);
        }

        private void TworzeStrukturePlikow(DirectoryInfo directory, string Zawartosc, string Przywitanie, string Sciezka, string Nazwa, string Klucz) // Funkcja tworzy strukture folderu i plikow potrzebna do rejestracji
        {
            if (!Directory.Exists(directory.ToString()))
            {
                directory.Create();
            }
            Directory.SetCurrentDirectory(directory.ToString());
            if (!File.Exists(Nazwa + ".txt"))
            {
                StreamWriter Plik = File.CreateText(Nazwa + ".txt");
                Plik.WriteLine(Zawartosc);
                Plik.WriteLine(Klucz);
                Plik.Close();
                MessageBox.Show("Witaj " + Przywitanie + "!");
            }
            else
            {
                MessageBox.Show("Taki użytkownik już istnieje!");
            }
            Directory.SetCurrentDirectory(Sciezka);
            directory.Refresh();

        }

        private void TworzeniePlikowPracownicy(string Login, string Haslo, string Funkcja)  // Przekazujemy parametry do funkcji TworzeStrukturePlikow dla Pracownikow
        {
            DirectoryInfo Katalog = new DirectoryInfo("Pracownicy");
            TworzeStrukturePlikow(Katalog, Login + Haslo, Login, Directory.GetCurrentDirectory(), Login, "");

        }
        private void TworzeniePlikowWlasciciele(string Login, string Haslo, string Klucz) // Przekazujemy parametry do funkcji TworzeStrukturePlikow dla Wlascicieli
        {
            DirectoryInfo Katalog = new DirectoryInfo("Wlasciciele");
            TworzeStrukturePlikow(Katalog, Login + Haslo, Login, Directory.GetCurrentDirectory(), Login, Klucz);
        }

        public void dodajPracownika(string Login, string Haslo, string Funkcja) // Dodajemy do listy pracownika
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Haslo) || string.IsNullOrEmpty(Funkcja))
            {
                MessageBox.Show("Nie wszystkie pola zostały wypełnione !");
            }
            else
            {
                try
                {
                    listaUzytkownikow.Add(new Pracownik(Login, Haslo, Funkcja));
                    TworzeniePlikowPracownicy(Login, Haslo, Funkcja);

                }
                catch (Exception k)
                {
                    MessageBox.Show(k.Message);
                }
            }

        }
        public void dodajWlasciciela(string Login, string Haslo, string Klucz) // Dodajemy do listy wlasciciela
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Haslo) || string.IsNullOrEmpty(Klucz))
            {
                MessageBox.Show("Nie wszystkie pola zostały wypełnione !");
            }
            else
            {
                try
                {
                    listaUzytkownikow.Add(new Wlasciciel(Login, Haslo, Klucz));
                    TworzeniePlikowWlasciciele(Login, Haslo, Klucz);
                }
                catch (Exception k)
                {
                    MessageBox.Show(k.Message);
                }
            }
        }
    }
}
