using ProjektPoprawa;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.IO;

namespace Projekt_Poprawa
{
    /// <summary>
    /// Wyswietlane w tym oknie jest podstawowe menu. Mozliwe jest takze skorzystanie z kalkulatora cofniecie sie do okna po zalogowaniu, a takze zamkniecie aplikacji.
    /// </summary>
    public partial class OknoMenu : Window
    {
        Menu NoweMenu = new Menu();
        public OknoMenu()
        {
            InitializeComponent();
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
            listaDan.ItemsSource = NoweMenu.zwracamListeDan();
            CollectionViewSource.GetDefaultView(listaDan.ItemsSource).Refresh();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listaDan.ItemsSource); // Tworze podzial na rodzaje dan
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Rodzaj"); // Ustalam element , ktory bedzie rozdzielal 
            view.GroupDescriptions.Add(groupDescription);     // Pozwalam na wyswietlenie tego podzialu

        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) //1. Odnosi sie do kontrolki exit
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //2. Odnosi sie do exita i zamyka 
        {
            if (File.Exists("confirmed.txt"))
            {
                File.Delete("confirmed.txt");
            }
            Application.Current.Shutdown();
        }

        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e) //3. Odnosi sie do kalkulatora
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)  //4. Pokazuje kalkulator
        {
            OknoKalkulatora Okno = new OknoKalkulatora();
            Okno.Show();
        }

        private void CommandBinding_CanExecute_2(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e) // 5. Cofa do Menu z wyborem opcji
        {
            this.Close();
            OknoPoZalogowaniu Okno = new OknoPoZalogowaniu();
            Okno.Show();
        }


    }
}
