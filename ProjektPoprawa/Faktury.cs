using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.IO;

namespace Projekt_Poprawa
{
    class Faktury
    {
        // Tworze dwie listy potrzebne do wyszukiwania faktur i pokazania faktur na starcie okienka - OknoFaktur
        public string Nazwa { get; set; }

        private List<Faktury> ListaFaktur;
        private List<Faktury> ListaPoWyszukaniu;
        public Faktury() { ListaFaktur = new List<Faktury>(); ListaPoWyszukaniu = new List<Faktury>(); }
        public List<Faktury> ZwracamListeFaktur()
        {
            return ListaFaktur;
        }
        public List<Faktury> ZwracamListePoWyszukaniu()
        {
            return ListaPoWyszukaniu;
        }
        public Faktury(string Nazwa)
        {
            this.Nazwa = Nazwa;

        }
        public bool sprawdzamDane(string Kod, string Login)   // Sprawdza zawartosc pliku tekstowego o ponizszej nazwie
        {
            StreamReader Odczyt = new StreamReader(Login + ".txt");
            using (Odczyt)
            {
                Odczyt.ReadLine();
                string odczytanyKod = Odczyt.ReadLine();
                if (odczytanyKod == Kod)
                {
                    Odczyt.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void WyswietlamWszystkieFaktury(ListView Lista)  // Wyswietla faktury na starcie w kontrolce ListView
        {

            string Sciezka = Directory.GetCurrentDirectory();
            if (Directory.Exists("Faktury_" + DateTime.Now.Year.ToString()))
            {
                string[] NazwyPlikow = Directory.GetFiles("Faktury_" + DateTime.Now.Year.ToString());
                for (int i = 0; i < NazwyPlikow.Length; i++)
                {
                    ListaFaktur.Add(new Faktury(PrzycinamSciezke(NazwyPlikow[i])));

                }
                Directory.SetCurrentDirectory(Sciezka);
                Lista.ItemsSource = ListaFaktur;
                CollectionViewSource.GetDefaultView(Lista.ItemsSource).Refresh();
            }

        }
        public string PrzycinamSciezke(string Sciezka)  // Obcina sciezke uzyskana za pomoca funkcji GetFiles tak aby byla wygodniejsza w odczycie
        {
            string Nowy = Sciezka.Remove(0, 13);
            return Nowy;
        }
        public void SzukamFaktury(string Rok, string Miesiac, string Dzien, ListView Lista)  // Funckja umozliwiajaca znalezienie faktury po Roku dniu i miesiacu
        {
            string Sciezka = Directory.GetCurrentDirectory();
            if (!Directory.Exists("Faktury_" + Rok))
            {
                MessageBox.Show("Nie ma faktur z roku: " + Rok);
            }
            else
            {
                Directory.SetCurrentDirectory("Faktury_" + Rok);
                if (!File.Exists(Miesiac + "_" + Dzien + ".txt"))
                {
                    MessageBox.Show("Nie ma faktur z tego dnia");
                }
                else
                {
                    Directory.SetCurrentDirectory(Sciezka);
                    string[] NazwyPlikow = Directory.GetFiles("Faktury_" + Rok);
                    ListaPoWyszukaniu.Add(new Faktury(Miesiac + "_" + Dzien + ".txt"));
                    Lista.ItemsSource = ListaPoWyszukaniu;

                }

            }
            Directory.SetCurrentDirectory(Sciezka);
        }



    }
}
