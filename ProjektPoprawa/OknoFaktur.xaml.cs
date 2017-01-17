using Projekt_Poprawa;
using System;
using System.Windows;
using System.Windows.Data;
using System.IO;

namespace ProjektPoprawa
{
    /// <summary>
    /// Znajduja sie tu funkcje potrzebne dla faktur. Pozwalaja na wyszukiwanie , dodawanie i umozliwiaja wszystkie koniecznie operacje na fakturach.
    /// </summary>
    public partial class OknoFaktur : Window
    {
        Faktury NowaFaktura = new Faktury();
        public OknoFaktur()
        {
            InitializeComponent();
            NowaFaktura.WyswietlamWszystkieFaktury(ListaFaktur);  // Wyswietla faktury i jednoczesnie odslania potrzebne ramki
            Ramka1.Visibility = Visibility.Visible;
            Ramka2.Visibility = Visibility.Visible;
            Ramka3.Visibility = Visibility.Visible;
            Ramka5.Visibility = Visibility.Visible;


        }
        private void Wyswietlam()  // Wyswietla wybrana fakture
        {
            Faktury Nowa = (Faktury)ListaFaktur.SelectedItem;
            string Sciezka = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory("Faktury_" + DateTime.Today.Year.ToString());
            StreamReader Odczyt = new StreamReader(Nowa.Nazwa.ToString());
            using (Odczyt)
            {
                Wyswietlacz.Text = Odczyt.ReadToEnd();
                Odczyt.Close();
            }
            Directory.SetCurrentDirectory(Sciezka);
        }
        private void Wyjscie(object sender, RoutedEventArgs e)
        {
            if (File.Exists("confirmed.txt"))
            {
                File.Delete("confirmed.txt");
            }
            Application.Current.Shutdown();
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            OknoPoZalogowaniu Okno = new OknoPoZalogowaniu();
            Okno.Show();
            this.Close();
        }

        private void Znajdz(object sender, RoutedEventArgs e) // Wyszukiwarka do faktur(po Roku , miesiacu i dniu)
        {
            NowaFaktura.ZwracamListePoWyszukaniu().Clear();
            string Rok = pobierzRok.Text;
            string Miesiac = pobierzMiesiac.Text;
            string Dzien = pobierzDzien.Text;
            try
            {
                if (string.IsNullOrEmpty(Rok) || string.IsNullOrEmpty(Miesiac))
                {
                    MessageBox.Show("Wypełnij wszystkie pola");
                }
                else if (Convert.ToInt32(Rok) > DateTime.Today.Year || Convert.ToInt32(Miesiac) > DateTime.Today.Month || Convert.ToInt32(Dzien) > DateTime.Today.Day
                    || Convert.ToInt32(Rok) < 2000 || Convert.ToInt32(Miesiac) <= 0 || Convert.ToInt32(Dzien) <= 0)
                {
                    MessageBox.Show("Proszę wpisać poprawną date");
                }
                else
                {
                    try
                    {
                        NowaFaktura.SzukamFaktury(Rok, Miesiac, Dzien, ListaFaktur);
                        CollectionViewSource.GetDefaultView(ListaFaktur.ItemsSource).Refresh();

                    }
                    catch (Exception k)
                    {
                        MessageBox.Show(k.Message);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Słowa nie mogą być datą");
            }

        }

        private void WyswietlFakture(object sender, RoutedEventArgs e) // Wyswietla fakture
        {
            int WybranaFaktura = ListaFaktur.SelectedIndex;
            if (WybranaFaktura != -1)
            {
                Ramka1.Visibility = Visibility.Hidden;
                Ramka2.Visibility = Visibility.Hidden;
                Ramka3.Visibility = Visibility.Hidden;
                Ramka5.Visibility = Visibility.Hidden;
                Ramka4.Visibility = Visibility.Visible;
                Wyswietlam();
            }
            else
            {
                MessageBox.Show("Wybierz fakturę");
            }
        }
        private void CofnijDoFaktur(object sender, RoutedEventArgs e)  // Odslania i ukrywa potrzebne kontrolki
        {
            Ramka1.Visibility = Visibility.Visible;
            Ramka2.Visibility = Visibility.Visible;
            Ramka3.Visibility = Visibility.Visible;
            Ramka5.Visibility = Visibility.Visible;
            Ramka4.Visibility = Visibility.Hidden;

        }






    }
}
