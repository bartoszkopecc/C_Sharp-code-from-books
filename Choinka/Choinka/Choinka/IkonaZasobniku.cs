using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Choinka
{
    public class IkonaZasobniku
    {
        private NotifyIcon notifyIcon;
        private System.Windows.Window okno;

        public IkonaZasobniku(System.Windows.Window okno)
        {
            //ikona
            string nazwaIkony = "christmas.ico";
            string nazwaAplikacji = Application.ProductName;
            System.Windows.Resources.StreamResourceInfo sri = System.Windows.Application.GetResourceStream(new Uri(@"/" + nazwaAplikacji + ";component/" + nazwaIkony, UriKind.RelativeOrAbsolute));
            Icon icon = new Icon(sri.Stream);

            //menu
            ContextMenuStrip menu = tworzMenu();

            //ikona w zasobniku
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = icon;
            notifyIcon.Text = "Choinka" + DateTime.Now.Year.ToString();
            notifyIcon.ContextMenuStrip = menu;
            notifyIcon.Visible = true;

            notifyIcon.DoubleClick += (s, e) =>
              {
                  int ileDniDoŚwiąt = (new DateTime(DateTime.Today.Year, 12, 24) - DateTime.Now).Days;
                  notifyIcon.BalloonTipTitle = notifyIcon.Text;
                  notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                  notifyIcon.BalloonTipText = "Do świąt pozostało " + ileDniDoŚwiąt + " dni";
                  notifyIcon.ShowBalloonTip(3000);
              };

            //menu aplikacji
            this.okno = okno;
            okno.MouseRightButtonDown += (s, e) =>
              {
                  System.Windows.Point p = okno.PointToScreen(e.GetPosition(okno));
                  menu.Show((int)p.X, (int)p.Y);
              };
        }

        public bool Widoczny
        {
            get
            {
                return notifyIcon.Visible;
            }

            set
            {
                notifyIcon.Visible = value;
            }
        }

        private ContextMenuStrip tworzMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem ukryjToolStripMenuItem = new ToolStripMenuItem("Ukryj");
            ukryjToolStripMenuItem.Click += (s, e) => { okno.Hide(); };
            menu.Items.Add(ukryjToolStripMenuItem);

            ToolStripMenuItem przywrocToolStripMenuItem = new ToolStripMenuItem("Przywróć");
            przywrocToolStripMenuItem.Click += (s, e) => { okno.Show(); };
            menu.Items.Add(przywrocToolStripMenuItem);

            ToolStripMenuItem zamknijToolStripMenuItem = new ToolStripMenuItem("Zamknij");
            zamknijToolStripMenuItem.Click += (s, e) => { okno.Close(); };
            menu.Items.Add(zamknijToolStripMenuItem);

            menu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem oAutorzeToolStripMenuItem = new ToolStripMenuItem("O...");
            oAutorzeToolStripMenuItem.Click += (s, e) =>
              {
                  System.Windows.SplashScreen splashScreen = new System.Windows.SplashScreen("SplashScreen.png");
                  splashScreen.Show(false, true);
                  System.Threading.Thread.Sleep(1000);
                  splashScreen.Close(new TimeSpan(0, 0, 1));
              };
            menu.Items.Add(oAutorzeToolStripMenuItem);

            return menu;
        }

        public void Usuń()
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            notifyIcon = null;
        }
    }
}
