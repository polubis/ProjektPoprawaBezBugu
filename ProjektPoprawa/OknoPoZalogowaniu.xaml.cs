using System.Windows;
using System.IO;
using ProjektPoprawa;

namespace Projekt_Poprawa
{
    /// <summary>
    /// W tyk okienku aplikacja daje nam mozliwosc wyboru opcji. Jest poprostu skupiskiem wiekszosci opcji i posredniczy pomieczy funkcjami aplikacji.
    /// </summary>
    public partial class OknoPoZalogowaniu : Window
    {
        OknoMenu OknoMenu = new OknoMenu();
        public OknoPoZalogowaniu()
        {
            InitializeComponent();
        }

        private void DodajAdnotacje(object sender, RoutedEventArgs e)
        {
            OknoNowejAdnotacji Okno = new OknoNowejAdnotacji();
            Okno.Show();
            this.Close();
        }

        private void NowyRachunek(object sender, RoutedEventArgs e)
        {
            OknoNowegoRachunku Okno = new OknoNowegoRachunku();
            Okno.Show();
            this.Close();
        }
        private void PokazMenu(object sender, RoutedEventArgs e)
        {
            OknoMenu.Show();
            this.Close();
        }
        private void Wyloguj(object sender, RoutedEventArgs e)
        {
            if (File.Exists("confirmed.txt"))
            {
                File.Delete("confirmed.txt");
            }
            this.Close();
            MainWindow Okno = new MainWindow();
            Okno.Show();
        }

        private void WyswietlFakture(object sender, RoutedEventArgs e)
        {
            if (File.Exists("confirmed.txt"))
            {
                OknoFaktur Okno = new OknoFaktur();
                Okno.Show();
                this.Close();
            }
            else
            {
                OknoUzyskaniaDostepu Okno = new OknoUzyskaniaDostepu();
                Okno.Show();
                this.Close();
            }

        }

        private void WyswietlAdnotacje(object sender, RoutedEventArgs e)
        {
            Adnotacje Adnotacja = new Adnotacje();
            string[] Pliki = Directory.GetFiles("Adnotacje");
            if (Pliki.Length <= 0)
            {
                MessageBox.Show("Nie masz żadnych adnotacji");
            }
            else
            {
                OknoWyswietlaniaAdnotacji OknoWyswietlania = new OknoWyswietlaniaAdnotacji();
                OknoWyswietlania.Show();
                this.Close();
            }


        }
    }
}
