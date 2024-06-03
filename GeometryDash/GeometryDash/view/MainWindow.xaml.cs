using System;
using System.Windows;
using System.Windows.Controls;
using IUTGame;
using IUTGame.WPF;

namespace GeometryDash.view
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GeometryDashGame _game;
        public MainWindow()
        {
            InitializeComponent();
            IScreen screen = new WPFScreen(Canvas);
            _game = new GeometryDashGame(screen);
        }
        
        private void SliderSound_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _game.BackgroundVolume = e.NewValue/100.0;
        }

        private void SliderWind_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _game.Wind2 = e.NewValue;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            _game.Run();
        }

        private void ChooseLevelButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the ChooseLevel window
            ChooseLevel chooseLevelWindow = new ChooseLevel();
            chooseLevelWindow.Show();
        }
    }
}