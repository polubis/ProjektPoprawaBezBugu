using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjektPoprawa
{
    /// <summary>
    /// Interaction logic for OknoKalkulatora.xaml
    /// </summary>
    public partial class OknoKalkulatora : Window
    {
        enum Operacja { brakOperacji = 0, dodawanie, odejmowanie, mnozenie, dzielenie, wynik } // Deklaracja operacji jakie beda wykonywane na kalkulatorze
        private Operacja ostatnioWybranaOperacja = Operacja.brakOperacji;        // Ustawienie operacji na brak operacji czyli 0, domyslnie zawsze zmienna ta bedzie miec wartosc 0 
        public OknoKalkulatora()
        {
            InitializeComponent();
        }

        private void PrzyciskNumer(object sender, RoutedEventArgs e)
        {
            if (Operacja.wynik == ostatnioWybranaOperacja) // Jezeli wynik jest rowny ostatnio wybranej operacji 0 lub innej 
            {
                txtWyswietlany.Text = string.Empty;              // To tekst wyswietlony bedzie pusty.
                ostatnioWybranaOperacja = Operacja.brakOperacji;
            }
            Button oButton = (Button)sender;
            txtWyswietlany.Text += oButton.Content;
        }

        private void PrzyciskOperacji(object sender, RoutedEventArgs e)
        {
            if ((Operacja.brakOperacji != ostatnioWybranaOperacja) || (Operacja.wynik != ostatnioWybranaOperacja))
            {
                PrzyciskWyniku(this, e);
            }
            Button oButton = (Button)sender;
            switch (oButton.Content.ToString())
            {
                case "+":
                    ostatnioWybranaOperacja = Operacja.dodawanie;
                    break;
                case "-":
                    ostatnioWybranaOperacja = Operacja.odejmowanie;
                    break;
                case "*":
                    ostatnioWybranaOperacja = Operacja.mnozenie;
                    break;
                case "/":
                    ostatnioWybranaOperacja = Operacja.dzielenie;
                    break;
                default:
                    MessageBox.Show("Nieznana operacja!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
            txtWyswietlany2.Text = txtWyswietlany.Text;
            txtOperacja.Text = oButton.Content.ToString();
            txtWyswietlany.Text = string.Empty;
        }

        private void PrzyciskWyniku(object sender, RoutedEventArgs e)
        {
            if ((Operacja.wynik == ostatnioWybranaOperacja) || (Operacja.brakOperacji == ostatnioWybranaOperacja))  // Sprawdza czy wynik nie jest rowny ostatnio wybranej operacji badz nierowny 0
            {
                return;
            }
            if (string.IsNullOrEmpty(txtWyswietlany.Text)) // Jezeli wartosc jest pusta to poprostu przyporzadkowuje jej 0.
            {
                txtWyswietlany.Text = "0";
            }
            switch (ostatnioWybranaOperacja)  // Implementacja dzialan na kalkulatorze
            {
                case Operacja.dodawanie:
                    txtWyswietlany.Text = (double.Parse(txtWyswietlany2.Text) +
                        double.Parse(txtWyswietlany.Text)).ToString();
                    break;
                case Operacja.odejmowanie:
                    txtWyswietlany.Text = (double.Parse(txtWyswietlany2.Text) -
                        double.Parse(txtWyswietlany.Text)).ToString();
                    break;
                case Operacja.mnozenie:
                    txtWyswietlany.Text = (double.Parse(txtWyswietlany2.Text) *
                        double.Parse(txtWyswietlany.Text)).ToString();
                    break;
                case Operacja.dzielenie:
                    txtWyswietlany.Text = (double.Parse(txtWyswietlany2.Text) /
                        double.Parse(txtWyswietlany.Text)).ToString();
                    break;
            }
            ostatnioWybranaOperacja = Operacja.wynik;  // Zeruje wartosci 
            txtOperacja.Text = string.Empty;
            txtWyswietlany2.Text = string.Empty;
        }

        private void PrzyciskDodajacyZnak(object sender, RoutedEventArgs e)
        {
            if (Operacja.wynik == ostatnioWybranaOperacja)
            {
                txtWyswietlany.Text = string.Empty;
                ostatnioWybranaOperacja = Operacja.brakOperacji;
            }
            if ((txtWyswietlany.Text.Contains(',')) ||  // jezeli wyswietlany tekst zawiera przecinek badz jeglo dlugosc jest rowna 0 to zwraca ten tekst
                (0 == txtWyswietlany.Text.Length))
            {
                return;
            }
            txtWyswietlany.Text += ",";  // Dodaje do tekstu znak przecinka
        }


        private void PrzyciskCzyszczenia(object sender, RoutedEventArgs e)
        {
            txtWyswietlany.Text = string.Empty;
            txtWyswietlany2.Text = string.Empty;
            txtOperacja.Text = string.Empty;
            ostatnioWybranaOperacja = Operacja.brakOperacji;
        }

        private void ZamykamKalkulator(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
