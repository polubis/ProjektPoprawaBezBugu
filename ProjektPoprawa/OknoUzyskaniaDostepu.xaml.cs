using System.Windows;
using System.IO;
using ProjektPoprawa;

namespace Projekt_Poprawa
{
    /// <summary>
    /// Okienko zabezpieczajace przed dostepem do faktur. Do faktur moga miec dostep tylko wlasciciele. Jedno wpisanie potrzebnych danych do wartosci w tym okienku
    /// pozwala na stworzenie plikut tekstowego , ktory uniewaznia wywolywanie tego okienka. Jednak po wylogowaniu lub zsmaknieciu aplikacji plik ten jest usuwany.
    /// </summary>
    public partial class OknoUzyskaniaDostepu : Window
    {
        Faktury Faktura = new Faktury();
        public OknoUzyskaniaDostepu()
        {
            InitializeComponent();
        }

        private void Anuluj(object sender, RoutedEventArgs e)
        {
            OknoPoZalogowaniu Okno = new OknoPoZalogowaniu();
            this.Close();
            Okno.Show();
        }

        private void Potwierdz(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pobierzKod.Password) || string.IsNullOrEmpty(pobierzLogin.Text))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
            }
            else
            {
                string Sciezka = Directory.GetCurrentDirectory();
                if (!Directory.Exists("Wlasciciele"))
                {
                    MessageBox.Show("Nie ma żadnego właściciela");
                }
                else
                {
                    Directory.SetCurrentDirectory("Wlasciciele");
                    if (!File.Exists(pobierzLogin.Text + ".txt"))
                    {
                        MessageBox.Show("Nie ma takiego użytkownika");
                        Directory.SetCurrentDirectory(Sciezka);
                    }
                    else
                    {
                        bool Rezultat = Faktura.sprawdzamDane(pobierzKod.Password, pobierzLogin.Text);
                        if (Rezultat == true)
                        {
                            Directory.SetCurrentDirectory(Sciezka);
                            File.CreateText("confirmed.txt");
                            OknoFaktur Okno = new OknoFaktur();
                            this.Close();
                            Okno.Show();

                        }
                        else
                        {
                            MessageBox.Show("Błędny login lub klucz");
                        }
                        Directory.SetCurrentDirectory(Sciezka);
                    }


                }
            }
            pobierzKod.Password = "";
            pobierzLogin.Text = "";

        }
    }
}
