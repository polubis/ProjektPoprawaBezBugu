using System.Windows;
using System.IO;

namespace Projekt_Poprawa
{
    /// <summary>
    /// W tym okienku mozemy wyswietlac adnotacje wystawione przez innych uzytkownikow. Wyswietlac dzisiejsze. 
    /// </summary>
    public partial class OknoWyswietlaniaAdnotacji : Window
    {
        Adnotacje Adnotacja = new Adnotacje();
        public OknoWyswietlaniaAdnotacji()
        {
            InitializeComponent();
            Adnotacja.WyswietlAdnotacje(wyswietlaczAdnotacji);

        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            OknoPoZalogowaniu Okno = new OknoPoZalogowaniu();
            Okno.Show();
            this.Close();
        }

        private void Zamknij(object sender, RoutedEventArgs e)
        {
            if (File.Exists("confirmed.txt"))
            {
                File.Delete("confirmed.txt");
            }
            Application.Current.Shutdown();
        }

        private void PokazDzisiejsze(object sender, RoutedEventArgs e)
        {
            Adnotacja.PokazDzisiejszeAdnotacje(wyswietlaczAdnotacji);
        }
    }
}
