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
using System.Windows.Threading;

namespace TourDeJoke
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double x = 590;
        double y = 644;
        int mapa = 0;
        static String[] poleBck = { @"\\data.sps-prosek.local\vileton15\Stažené\export\export\gamebck.png", @"\\data.sps-prosek.local\vileton15\Stažené\export\export\gamebck2.png", @"\\data.sps-prosek.local\vileton15\Stažené\export\export\gamebck3.png" };
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(MovePlayer);
            timer.Start();
            
            DispatcherTimer timer2 = new DispatcherTimer();
            timer2.Tick += new EventHandler(KolizeNPC);
            timer2.Start();
        }

        private void MovePlayer(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                
                if (x <= -161) // nacist novou mapu z leva
                {
                    if(mapa==0)
                    {
                        
                    }

                    else
                    {
                        mapa = mapa-1;
                        KontrolaNPC();
                        CanvasBrush.ImageSource = new BitmapImage(new Uri(poleBck[mapa], UriKind.Relative));
                        x = 1519;
                        Canvas.SetLeft(Player, x);
                    }

                    
                }
                else
                {
                    x -= .05;
                    Canvas.SetLeft(Player, x);
                }
            }
            if (Keyboard.IsKeyDown(Key.Up))
            {
                if (y <= 490)
                {
                }
                else
                {
                    y -= .05;
                    Canvas.SetTop(Player, y);
                }
                
            }
            if (Keyboard.IsKeyDown(Key.Down))
            {
                if (y >= 705)
                {
                }
                else
                {
                    y += .05;
                    Canvas.SetTop(Player, y);
                }
                
            }
            if (Keyboard.IsKeyDown(Key.Right)) // nacist novou mapu z prava
            {
                if (x >= 1520)
                {
                    
                    if (mapa ==2)
                    {

                    }
                    else
                    {
                        
                        mapa = mapa+1;
                        KontrolaNPC();
                        Console.WriteLine("zvetseni"+mapa);
                        CanvasBrush.ImageSource = new BitmapImage(new Uri(poleBck[mapa], UriKind.Relative));
                        x = -160;
                        Canvas.SetLeft(Player, x);
                    }
                    
                }
                else
                {
                    x += .05;
                    Canvas.SetLeft(Player, x);
                }
                
            }
        }
        private void KontrolaNPC()
        {
            if (mapa == 0)
            {
                npc.Visibility = Visibility.Visible;

            }
            else
            {
                npc.Visibility = Visibility.Hidden;
                
            }
        }
        private void KolizeNPC(object sender, EventArgs e)
        {
            var x1 = Canvas.GetLeft(Player);
            var y1 = Canvas.GetTop(Player);
            Rect r1 = new Rect(x1, y1, Player.ActualWidth, Player.ActualHeight);

            var x2 = Canvas.GetLeft(npc);
            var y2 = Canvas.GetTop(npc);
            Rect r2 = new Rect(x2, y2, npc.ActualWidth, npc.ActualHeight);

            if (r1.IntersectsWith(r2))
            {

                mark.Visibility = Visibility.Visible;
            }
            else
            {
                mark.Visibility = Visibility.Hidden;
            }
        }
        private void NewKolizeNPC(object sender, EventArgs e)
        {
        }
    }
}
