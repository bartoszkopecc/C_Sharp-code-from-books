using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using BartoszKopec.WpfUtils;

namespace Notatnik.NET
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        

        private string ścierzkaPliku = null;
        private bool czyTekstZmieniony = false;

        public MainWindow()
        {
            InitializeComponent();

            openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Wybierz plik tekstowy";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Pliki tekstowe (*.txt|*.txt|Pliki XML (*.xml|xml|Pliki źródłowe (*.cs)|*.cs|Wszystkie pliki (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Zapisz plik tekstowy";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = openFileDialog.Filter;
            saveFileDialog.FilterIndex = 1;
            
        }

        private void MenuItem_Otwórz_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(ścierzkaPliku))
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(ścierzkaPliku);
                openFileDialog.FileName = Path.GetFileName(ścierzkaPliku);
            }

            bool? wynik = openFileDialog.ShowDialog();
            if(wynik.HasValue && wynik.Value)
            {
                ścierzkaPliku = openFileDialog.FileName;
                textBox.Text = File.ReadAllText(ścierzkaPliku);
                statusBarText.Text = Path.GetFileName(ścierzkaPliku);
                czyTekstZmieniony = false;
            }
        }

        private void MenuItem_ZapiszJako_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(ścierzkaPliku))
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(ścierzkaPliku);
                saveFileDialog.FileName = Path.GetFileName(ścierzkaPliku);

            }

            bool? wynik = saveFileDialog.ShowDialog();
            if(wynik.HasValue && wynik.Value)
            {
                ścierzkaPliku = saveFileDialog.FileName;
                File.WriteAllText(ścierzkaPliku, textBox.Text);
                statusBarText.Text = Path.GetFileName(ścierzkaPliku);
                czyTekstZmieniony = false;
            }
        }

        private void MenuItem_Zapisz_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ścierzkaPliku))
            {
                File.WriteAllText(ścierzkaPliku, textBox.Text);
                czyTekstZmieniony = false;
            }
            else MenuItem_ZapiszJako_Click(sender, e);
        }

        private void MenuItem_Zamknij_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            czyTekstZmieniony = true;
        }

        private void zapytajOZapisanietekstuDoPliku(object sender, out bool anuluj)
        {
            anuluj = false;
            if (czyTekstZmieniony)
            {
                MessageBoxResult wynik =
                    MessageBox.Show("Czy zapisać zmiany w edytowanym dokumencie?",
                                    this.Title,
                                    MessageBoxButton.YesNoCancel,
                                    MessageBoxImage.Question,
                                    MessageBoxResult.Cancel);
                switch (wynik)
                {
                    case MessageBoxResult.Yes:
                        MenuItem_Zapisz_Click(sender, null);
                        break;
                    case MessageBoxResult.No: break;
                    case MessageBoxResult.Cancel:
                    default:
                        anuluj = true;
                        break;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool anuluj;
            zapytajOZapisanietekstuDoPliku(sender, out anuluj);
            e.Cancel = anuluj;

        }

        private void MenuItem_Nowy_Click(object sender, RoutedEventArgs e)
        {
            bool anuluj;
            zapytajOZapisanietekstuDoPliku(sender, out anuluj);
            if (!anuluj) textBox.Text = "";
        }

        private void MenuItem_Cofnij_Click(object sender, RoutedEventArgs e)
        {
            textBox.Undo();
        }
        private void MenuItem_Powtórz_Click(object sender, RoutedEventArgs e)
        {
            textBox.Redo();
        }
        private void MenuItem_Wytnij_Click(object sender, RoutedEventArgs e)
        {
            textBox.Cut();
        }
        private void MenuItem_Kopiuj_Click(object sender, RoutedEventArgs e)
        {
            textBox.Copy();
        }

        private void MenuItem_Wklej_Click(object sender, RoutedEventArgs e)
        {
            textBox.Paste();
        }

        private void MenuItem_Usuń_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText="";
        }

        private void MenuItem_ZaznaczWszystko_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectAll();
        }

        private void MenuItem_GodzinaData_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText = System.DateTime.Now.ToString();
        }

        private void MenuItem_ZawijanieWierszy_Click(object sender, RoutedEventArgs e)
        {
            bool czyPozycjaZaznaczona = (sender as MenuItem).IsChecked;
            textBox.TextWrapping = czyPozycjaZaznaczona ? TextWrapping.Wrap : TextWrapping.NoWrap;
        }

        private void MenuItem_PasekNarzędzi_Click(object sender, RoutedEventArgs e)
        {
            bool czyPozycjaZaznaczona = (sender as MenuItem).IsChecked;
            toolBar.Visibility = czyPozycjaZaznaczona ? Visibility.Visible : Visibility.Collapsed;
        }

        private void MenuItem_PasekStanu_Click(object sender, RoutedEventArgs e)
        {
            bool czyPozycjaZaznaczona = (sender as MenuItem).IsChecked;
            statusBar.Visibility = czyPozycjaZaznaczona ? Visibility.Visible : Visibility.Collapsed;
        }

        private void MenuItem_KolorTła_Click(object sender, RoutedEventArgs e)
        {
            Color kolorTła = Colors.White;
            if (textBox.Background is SolidColorBrush)
                kolorTła = (textBox.Background as SolidColorBrush).Color;
            if (WindowsFormsHelper.ChooseColor(ref kolorTła))
                textBox.Background = new SolidColorBrush(kolorTła);
        }
    }
}
