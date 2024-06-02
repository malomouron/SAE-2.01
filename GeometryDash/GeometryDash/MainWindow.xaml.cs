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
using IUTGame;
using IUTGame.WPF;

namespace GeometryDash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GeometryDashGame game;
        public MainWindow()
        {
            InitializeComponent();
            IScreen screen = new WPFScreen(Canvas);
            game = new GeometryDashGame(screen);
        }
        private void Play(object sender, RoutedEventArgs e)
        {
            game.Run();
        }
        private void SliderSound_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            game.BackgroundVolume = e.NewValue/100.0;
        }
    }
}