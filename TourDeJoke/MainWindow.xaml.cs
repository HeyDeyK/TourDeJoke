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
        double x = 635;
        double y = 606;
        int mapa = 0;
        static String[] poleBck = { @"D:\Ondra\Photoshop\export\gamebck.png", @"D:\Ondra\Photoshop\export\gamebck2.png", @"D:\Ondra\Photoshop\export\gamebck3.png" };
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(MovePlayer);
            timer.Start();
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
                        Console.WriteLine("zmenseni" + mapa);
                        mapa = mapa-1;
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
                if (y <= 377)
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
                if (y >= 607)
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
    }
}
