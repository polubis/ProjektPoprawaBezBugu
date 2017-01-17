using System.Windows;
using System.Windows.Controls;

namespace Projekt_Poprawa
{
    /// <summary>
    /// Strona umozliwa zarejestrowanie sie pracownikowi.
    /// </summary>
    public partial class stronaPracownika : Page
    {
        Konta Konto = new Konta();

        public stronaPracownika()
        {
            InitializeComponent();


        }
        private void CzyszczenieZawartosci()
        {
            pobierzLoginPracownika.Text = "";
            PobierzHasloPracownika.Password = "";
            pobierzFunkcjePracownika.Text = "";
        }
        private void ZarejestrujPracownika(object sender, RoutedEventArgs e)
        {
            Konto.dodajPracownika(pobierzLoginPracownika.Text, PobierzHasloPracownika.Password, pobierzFunkcjePracownika.Text);
            CzyszczenieZawartosci();

        }
    }
}
