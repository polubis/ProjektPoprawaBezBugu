using System.Windows;
using System.Windows.Controls;

namespace Projekt_Poprawa
{
    /// <summary>
    /// W tym okienku mozemy zalozyc konto, po jego zamknieciu mozemy skorzystac z opcji rejestracji dopiero po restarcie calej aplikacji.
    /// </summary>
    public partial class OknoRejestracji : Window, IZarzadzanieOkienkami
    {
        stronaPracownika StronaPracownika = new stronaPracownika();
        stronaWlasciciela StronaWlasciciela = new stronaWlasciciela();
        public OknoRejestracji()
        {
            InitializeComponent();

        }
        public void Przelacz(int Indeks)
        {
            if (Indeks == 0)
            {
                this.ramkaDoStron.NavigationService.Navigate(StronaWlasciciela);
            }
            else
            {
                this.ramkaDoStron.NavigationService.Navigate(StronaPracownika);
            }
        }
        private void wyborRodzajuKonta(object sender, SelectionChangedEventArgs e)
        {

            int wybranaWartosc = rodzajKonta.SelectedIndex;
            Przelacz(wybranaWartosc);

        }
        private void AnulujRejestracje(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
