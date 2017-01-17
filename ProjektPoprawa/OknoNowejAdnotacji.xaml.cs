using System.Windows;
using System.IO;

namespace Projekt_Poprawa
{
    /// <summary>
    /// W tym okienku mozna dodawac adnotacje, dla pracownikow od innych uzytkownikow aplikacji, a takze usuwac adnotacje starsze czy wszystkie.
    /// </summary>
    public partial class OknoNowejAdnotacji : Window
    {
        Adnotacje Adnotacja = new Adnotacje();
        public OknoNowejAdnotacji()
        {
            InitializeComponent();
        }

        private void ZamknijAplikacje(object sender, RoutedEventArgs e)
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

        private void Potwierdz(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pobierzAdnotacje.Text))
            {
                MessageBox.Show("Nie ma żadnej adnotacji");
            }
            else
            {
                Adnotacja.TworzePlikAdnotacje(pobierzAdnotacje.Text);
            }

        }

        private void UsunWszystkie(object sender, RoutedEventArgs e)
        {
            Adnotacja.UsunWszystkieAdnotacje(pobierzAdnotacje);
        }

        private void UsunStarsze(object sender, RoutedEventArgs e)
        {
            Adnotacja.UsunStarszeAdnotacje(pobierzAdnotacje);
        }

    }
}
