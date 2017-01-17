using ProjektPoprawa;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.IO;

namespace Projekt_Poprawa
{
    /// <summary>
    /// 
    /// W tym oknie mozliwe jest stworzenie nowego rachunku, zapisanie go do pliku tekstowego, a takze korzystanie z opcji kalkulator,cofnij , wyjscie i wielu innych.
    /// Mozemy powiekszac nasze Menu i dodawac dania do koszyka obserwujac jednoczesnie zwiekszajacy sie stan Sumy koncowej. Mozemy takze skorzystac z wyszukiwarki lub
    /// w informacjiach dowiedziec sie ile rekordow mamy zarowno w koszyku jak i w Menu oryginalnym. 
    /// </summary>
    public partial class OknoNowegoRachunku : Window
    {
        Menu NoweMenu = new Menu();


        public OknoNowegoRachunku()
        {
            InitializeComponent();
            Suma.Text = "0";
            NoweMenu.DodajDanie(1, "CocaCola 330ml", 4, "Napoj");
            NoweMenu.DodajDanie(2, "Sprite 330ml", 4, "Napoj");
            NoweMenu.DodajDanie(3, "Fanta 330ml", 4, "Napoj");
            NoweMenu.DodajDanie(4, "Pepsi 330ml", 4, "Napoj");
            NoweMenu.DodajDanie(5, "Mirinda 330ml", 4, "Napoj");
            NoweMenu.DodajDanie(6, "Woda gazowana 0.5l", 3, "Napoj");
            NoweMenu.DodajDanie(7, "Woda niegazowana 0.5l", 3, "Napoj");
            NoweMenu.DodajDanie(8, "Sok owocowy 0.5l", 4, "Napoj");
            NoweMenu.DodajDanie(9, "Czarna", 5, "Kawa");
            NoweMenu.DodajDanie(10, "Espresso", 6, "Kawa");
            NoweMenu.DodajDanie(11, "Latte", 8, "Kawa");
            NoweMenu.DodajDanie(12, "Americana", 11, "Kawa");
            NoweMenu.DodajDanie(13, "Chaina", 15, "Kawa");
            NoweMenu.DodajDanie(14, "Kawa biała", 7, "Kawa");
            NoweMenu.DodajDanie(15, "Kawa zimna", 10, "Kawa");
            NoweMenu.DodajDanie(16, "Herbata owocowa", 7, "Herbata");
            NoweMenu.DodajDanie(17, "Zwykła", 5, "Herbata");
            NoweMenu.DodajDanie(18, "Elgrey", 9, "Herbata");
            NoweMenu.DodajDanie(19, "Yerbamate", 11, "Herbata");
            NoweMenu.DodajDanie(20, "Mix", 13, "Herbata");
            NoweMenu.DodajDanie(21, "Zupa dnia", 5, "Zupa");
            NoweMenu.DodajDanie(22, "Rosół", 6, "Zupa");
            NoweMenu.DodajDanie(23, "Ogórkowa", 6, "Zupa");
            NoweMenu.DodajDanie(24, "Pomidorro", 6, "Zupa");
            NoweMenu.DodajDanie(25, "Krupnik", 6, "Zupa");
            NoweMenu.DodajDanie(26, "Zupa krem", 7, "Zupa");
            NoweMenu.DodajDanie(27, "Bułeczki pizzowe", 5, "Przystawka");
            NoweMenu.DodajDanie(28, "Pieczywko tostowe", 6, "Przystawka");
            NoweMenu.DodajDanie(29, "Rollada", 8, "Przystawka");
            NoweMenu.DodajDanie(30, "Podbrzuszek", 6, "Przystawka");
            NoweMenu.DodajDanie(31, "Ciasteczka prawdy", 5, "Przystawka");
            NoweMenu.DodajDanie(32, "HNZ", 10, "Przystawka");
            NoweMenu.DodajDanie(33, "Skrzydełka", 15, "DanieGłówne");
            NoweMenu.DodajDanie(34, "Pierś z kuraczaka", 14, "DanieGłówne");
            NoweMenu.DodajDanie(35, "Sandacz w sosie szpinakowym", 17, "DanieGłówne");
            NoweMenu.DodajDanie(36, "Sandacz w sosie koperkowym", 19, "DanieGłówne");
            NoweMenu.DodajDanie(37, "Sandacz w sosie śmietanowym", 21, "DanieGłówne");
            NoweMenu.DodajDanie(38, "Pstrąg z grilla", 17, "DanieGłówne");
            NoweMenu.DodajDanie(39, "Łazanki", 17, "DanieGłówne");
            NoweMenu.DodajDanie(40, "Frytki ze stynki", 11, "DanieGłówne");
            NoweMenu.DodajDanie(41, "Kotlet schabowy", 15, "DanieGłówne");
            NoweMenu.DodajDanie(42, "Owoce morza", 13, "DanieGłówne");
            NoweMenu.DodajDanie(43, "Zapiekanka mazurska", 11, "DanieGłówne");
            NoweMenu.DodajDanie(44, "Łosoś", 17, "DanieGłówne");
            ListaDan.ItemsSource = NoweMenu.zwracamListeDan();
            CollectionView Widok = (CollectionView)CollectionViewSource.GetDefaultView(ListaDan.ItemsSource);
            Widok.Filter = IdFilter;


        }
        private bool IdFilter(object item)  // Sprawdza czy obiekt jest 0 albo pusty
        {
            if (string.IsNullOrEmpty(txtWyszukiwarka.Text))
                return true;
            else
                return ((item as Dania).ID.ToString().IndexOf(txtWyszukiwarka.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    || ((item as Dania).Nazwa.IndexOf(txtWyszukiwarka.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    || ((item as Dania).Rodzaj.IndexOf(txtWyszukiwarka.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void UsunWybrany()
        {
            int wybranyWiersz = ListaDan.SelectedIndex;   // sprawdzam ifem czy nie zwrocilo wartosci -1
            if (wybranyWiersz != -1)
                NoweMenu.zwracamListeDan().RemoveAt(wybranyWiersz);
        }

        private void CommandBinding_CanExecute_3(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            if (File.Exists("confirmed.txt"))
            {
                File.Delete("confirmed.txt");
            }
            Application.Current.Shutdown();
        }

        private void CommandBinding_CanExecute_2(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;


        }
        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            OknoKalkulatora Okno = new OknoKalkulatora();
            Okno.Show();
        }
        private void Cofnij(object sender, RoutedEventArgs e)
        {
            this.Close();
            OknoPoZalogowaniu Okno = new OknoPoZalogowaniu();
            Okno.Show();
        }

        private void Odswiezanie(object sender, TextChangedEventArgs e) // Odswieza zawartosc listy
        {
            OdswiezamListy(ListaDan);
        }

        private void PrzyciskDodaj(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(pobierzID.Text)) || string.IsNullOrEmpty(pobierzDanie.Text) || string.IsNullOrEmpty(Convert.ToString(pobierzCene.Text)) || string.IsNullOrEmpty(pobierzRodzaj.Text))
            {

                MessageBox.Show("Nie dodałeś wartości do pól");
            }
            else
            {
                try
                {
                    NoweMenu.zwracamListeDan().Add(new Dania(Convert.ToInt32(pobierzID.Text), pobierzDanie.Text, double.Parse(pobierzCene.Text), pobierzRodzaj.Text));
                    OdswiezamListy(ListaDan);
                }
                catch
                {
                    MessageBox.Show("Cena lub ID zawierają znak zamiast liczb");
                }
            }
        }
        private void OdswiezamListy(ListView Lista)
        {
            CollectionViewSource.GetDefaultView(Lista.ItemsSource).Refresh();
        }
        private void PrzyciskUsun(object sender, RoutedEventArgs e)
        {
            UsunWybrany();
            OdswiezamListy(ListaDan);
        }

        private void DodajDoRachunku(object sender, RoutedEventArgs e)
        {
            try
            {
                Dania WybranyWiersz = (Dania)ListaDan.SelectedItem;  //rzutuje na Dania poniewaz inaczej nie dam rady wyluskac wartosci i zrobic na nich operacje
                NoweMenu.zwracamListeDanKopie().Add(new Dania(WybranyWiersz.ID, WybranyWiersz.Nazwa, WybranyWiersz.Cena, WybranyWiersz.Rodzaj));
                ListaDanCopy.ItemsSource = NoweMenu.zwracamListeDanKopie();   // lacze liste w kodzie C# z ta wyswietlana
                CollectionViewSource.GetDefaultView(ListaDanCopy.ItemsSource).Refresh();
                Suma.Text = NoweMenu.SumaPoDodaniu();
            }
            catch
            {
                MessageBox.Show("Nie zaznaczono pozycji ");
            }
        }

        private void usunZRachunku(object sender, RoutedEventArgs e)
        {
            int wybranyWiersz = ListaDanCopy.SelectedIndex;   // sprawdzam ifem czy nie zwrocilo wartosci -1
            if (wybranyWiersz != -1)
            {
                NoweMenu.zwracamListeDanKopie().RemoveAt(wybranyWiersz);  // Usuwam wybrany wiersz
                Dania B = (Dania)ListaDanCopy.SelectedItem;
                Suma.Text = NoweMenu.SumaPoOdjeciu(Convert.ToDouble(Suma.Text), B);
                OdswiezamListy(ListaDanCopy);
            }
            else
            {
                MessageBox.Show("Nic nie zaznaczono");
            }

        }

        private void DoZaplaty(object sender, RoutedEventArgs e)
        {
            NoweMenu.ObliczKwote();
            NoweMenu.zwracamListeDanKopie().Clear();
            try
            {
                OdswiezamListy(ListaDanCopy);
            }
            catch
            {
                MessageBox.Show("Brak produktów w rachunku ");
            }
            Suma.Text = "0";
        }

        private void IleRekordow(object sender, RoutedEventArgs e)
        {
            int LiczbaDanWMenu = NoweMenu.zwracamListeDan().Count;
            MessageBox.Show("Liczba rekordow w bazie : " + Convert.ToString(LiczbaDanWMenu));
            int LiczbaDanWKoszyku = NoweMenu.zwracamListeDanKopie().Count;
            MessageBox.Show("Liczba rekordow w koszyku : " + Convert.ToString(LiczbaDanWKoszyku));   // Sprawdzam liczbe wierszow w koszyku i Menu podstawowym
        }









    }
}
