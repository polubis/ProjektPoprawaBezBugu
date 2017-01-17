using System.Windows;
using System.IO;

namespace Projekt_Poprawa
{
    /// <summary>
    /// Okno glowne. Mozemy w nim zalozyc konto, czy zalogowac sie do aplikacji. Jest wyswietlane zawsze na starcie. 
    /// </summary>
    public partial class MainWindow : Window
    {
        OknoRejestracji Okno = new OknoRejestracji();
        Konta konto = new Konta();


        public MainWindow()
        {
            InitializeComponent();

        }

        private void przyciskWyjscia(object sender, RoutedEventArgs e) // Zamyka aplikacje i usuwa plik confirmed
        {
            if (File.Exists("confirmed.txt"))
            {
                File.Delete("confirmed.txt");
            }
            Application.Current.Shutdown();
        }

        private void przyciskRejestracji(object sender, RoutedEventArgs e)
        {
            try
            {
                Okno.Show();
            }
            catch
            {
                MessageBox.Show("Można zakładać tylko jedno konto na jedno uruchomienie aplikacji!");
            }
        }

        private void Zaloguj(object sender, RoutedEventArgs e) // Umozliwia zalogowanie sie i sprawdza poprawnosc danych
        {
            if (!Directory.Exists("Adnotacje"))
            {
                Directory.CreateDirectory("Adnotacje");
            }
            string Login = pobierzLogin.Text;
            string Haslo = pobierzHaslo.Password;
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Haslo))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
            }
            else
            {
                string Powrot = Directory.GetCurrentDirectory();
                if (!Directory.Exists("Wlasciciele"))
                {
                    MessageBox.Show("Nie ma takiego użytkownika");
                }
                else
                {
                    Directory.SetCurrentDirectory("Wlasciciele");
                    SzukaniePlikuTxt(Login + ".txt", Login + Haslo);
                    Directory.SetCurrentDirectory(Powrot);
                    if (Directory.Exists("Pracownicy"))
                    {
                        Directory.SetCurrentDirectory("Pracownicy");
                        SzukaniePlikuTxt(Login + ".txt", Login + Haslo);
                        Directory.SetCurrentDirectory(Powrot);
                    }
                    konto.TworzeLogi(pobierzLogin.Text);

                }


            }
        }
        private void SzukaniePlikuTxt(string Nazwa, string Zawartosc) // Szuka potrzebnego pliku tekstowego i odczytuje go jednoczesnie porownujac jego zawartosc
        {

            if (File.Exists(Nazwa))
            {
                StreamReader Odczyt = new StreamReader(Nazwa);
                using (Odczyt)
                {
                    if (Odczyt.ReadLine() == Zawartosc)
                    {
                        OknoPoZalogowaniu Okno = new OknoPoZalogowaniu();
                        Okno.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Błędne dane logowania");
                    }
                }
            }
        }
    }
}
