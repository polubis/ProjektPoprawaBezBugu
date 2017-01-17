using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Projekt_Poprawa
{
    class Menu : IZarzadzanieMenu
    {
        private List<Dania> ListaDan;
        private List<Dania> listaDanKopia;
        public Menu()
        {
            ListaDan = new List<Dania>();
            listaDanKopia = new List<Dania>();
        }
        public void DodajDanie(int ID, string Nazwa, double Cena, string Rodzaj)  // Dodaje danie do listy
        {
            if (string.IsNullOrEmpty(ID.ToString()) || string.IsNullOrEmpty(Nazwa) || string.IsNullOrEmpty(Convert.ToString(Cena)) || string.IsNullOrEmpty(Rodzaj))
            {
                MessageBox.Show("Nie wszystkie pola zostały wypełnione");
            }
            ListaDan.Add(new Dania(ID, Nazwa, Cena, Rodzaj));
        }
        public List<Dania> zwracamListeDan()
        {
            return ListaDan;
        }
        public List<Dania> zwracamListeDanKopie()
        {
            return listaDanKopia;
        }
        public void ObliczKwote()  // Oblicza kwote do zaplacenia (Koncowa)
        {
            int RozmiarListy = listaDanKopia.Count;
            double[] Tablica = new double[RozmiarListy];
            double Suma = 0;
            int i = 0;
            foreach (var element in listaDanKopia)
            {
                Tablica[i] = element.Cena;
                i++;
            }
            for (int j = 0; j < RozmiarListy; j++)
            {
                Suma += Tablica[j];
            }
            if (Suma > 0)
            {
                MessageBox.Show("Do zapłaty : " + Suma.ToString() + " zł");
                tworzeFaktury(Convert.ToString(Suma));
            }
        }
        public string SumaPoDodaniu()  // Kontroluje wartosc w aktualnym stanie kwoty do zaplaty
        {
            double suma = 0;
            foreach (var element in listaDanKopia)
            {
                suma = suma + element.Cena;
            }
            return suma.ToString();
        }
        public string SumaPoOdjeciu(double Suma, Dania Obiekt) //Kontroluje wartosc w aktualnym stanie kwoty do zaplaty
        {
            Suma = Suma - Obiekt.Cena;
            return Suma.ToString();
        }

        private void tworzeFaktury(string Suma)  // Tworzy foldery i podfoldery Rok-miesiac-plik.txt
        {
            string NazwaPlikuTxt = DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + ".txt";
            string AktualnyKatalog = Directory.GetCurrentDirectory();
            if (!Directory.Exists("Faktury_" + DateTime.Now.Year.ToString()))
            {
                Directory.CreateDirectory("Faktury_" + DateTime.Now.Year.ToString());
            }
            Directory.SetCurrentDirectory("Faktury_" + DateTime.Now.Year.ToString());
            if (!File.Exists(NazwaPlikuTxt))
            {
                TextWriter Plik = new StreamWriter(NazwaPlikuTxt, true);
                wpisujeDoFaktury(Suma, Plik);
                Plik.Close();
            }
            else
            {
                TextWriter Plik = new StreamWriter(NazwaPlikuTxt, true);
                wpisujeDoFaktury(Suma, Plik);
                Plik.Close();
            }
            Directory.SetCurrentDirectory(AktualnyKatalog);
        }
        private void wpisujeDoFaktury(string Suma, TextWriter Plik)  // Wpisuje rachunek do pliku tekstowego
        {
            string Data = "Czas: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            Plik.WriteLine(Data);
            foreach (var element in listaDanKopia)
            {
                Plik.WriteLine("ID: " + element.ID.ToString() + " Nazwa: " + element.Nazwa + " Cena: " + Convert.ToString(element.Cena) + " Rodzaj: " + element.Rodzaj);
            }
            Plik.WriteLine("Suma: " + Suma);
            Plik.WriteLine();
        }



    }
}
