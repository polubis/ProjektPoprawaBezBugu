using System.Windows;
using System.Windows.Controls;


namespace Projekt_Poprawa
{
    /// <summary>
    /// Strona pozwala na zarejestrowanie sie wlascicielowi. Tworzona sa potem odpowiednie pliki umozliwajace pozniejsze uwierzytelnianie uzytkownika w aplikacji.
    /// </summary>
    public partial class stronaWlasciciela : Page
    {

        Konta Konto = new Konta();
        public stronaWlasciciela()
        {
            InitializeComponent();
        }
        private void CzyszczenieZawartosci()
        {
            pobierzLoginWlasciciela.Text = "";
            pobierzHasloWlasciciela.Password = "";
            pobierzKluczWlasciciela.Password = "";
        }
        private void ZarejestrujWlasciciela(object sender, RoutedEventArgs e)
        {
            Konto.dodajWlasciciela(pobierzLoginWlasciciela.Text, pobierzHasloWlasciciela.Password, pobierzKluczWlasciciela.Password);
            CzyszczenieZawartosci();

        }
    }
}
