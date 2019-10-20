using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Choinka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IkonaZasobniku ikonaZasobniku;
        MediaPlayer odtwarzaczAudio;

        public MainWindow()
        {
            InitializeComponent();
            ikonaZasobniku = new IkonaZasobniku(this);

            string scierzkaPlikuDzwiekowego = System.IO.Path.GetFullPath("DJANGO.mp3");
            if(System.IO.File.Exists(scierzkaPlikuDzwiekowego))
            {
                odtwarzaczAudio = new MediaPlayer();
                odtwarzaczAudio.Open(new Uri(scierzkaPlikuDzwiekowego, UriKind.RelativeOrAbsolute));
                odtwarzaczAudio.MediaEnded += (s, e) => { odtwarzaczAudio = null; };
                odtwarzaczAudio.Play();
            }

        }

        #region Przenoszenie okna
        private bool czyPrzenoszenie = false;
        private Point punktPoczątkowy;
        private Cursor kursor;

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ButtonState==Mouse.LeftButton)
            {
                czyPrzenoszenie = true;
                kursor = Cursor;
                Cursor = Cursors.Hand;
                punktPoczątkowy = e.GetPosition(this);
            }

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if(czyPrzenoszenie)
            {
                Vector przesuniecie = e.GetPosition(this) - punktPoczątkowy;
                Left += przesuniecie.X;
                Top += przesuniecie.Y;
            }
        }

        private void Window_MouseUp(object sender, MouseEventArgs e)
        {
            if(czyPrzenoszenie)
            {
                Cursor = kursor;
                czyPrzenoszenie = false;
            }
        }
        #endregion

        #region Zamykanie okna
        private void Window_PerviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) this.Close();
        }

        bool zakonczonaAnimacjaZnikania = false;
               
        private void Okno_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!zakonczonaAnimacjaZnikania)
            {
                Storyboard scenorysZnikaniaOkna = this.Resources["scenorysZnikaniaOkna"] as Storyboard;
                scenorysZnikaniaOkna.Begin();
                e.Cancel = true;
            }
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            zakonczonaAnimacjaZnikania = true;
            Close();
        }
        #endregion
    }
}
