using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GeometryDash
{
    public partial class ChooseLevel : Window
    {
        private ObservableCollection<Level> _levels;
        private ICollectionView _levelsView;

        public ChooseLevel()
        {
            InitializeComponent();

            // Créez vos niveaux ici
            _levels = new ObservableCollection<Level>();
            for (int i = 1; i <= 20; i++)
            {
                _levels.Add(new Level
                {
                    Color = new SolidColorBrush(Color.FromRgb((byte)(i * 10), (byte)(i * 5), (byte)(i * 20)))
                });
            }

            _levelsView = CollectionViewSource.GetDefaultView(_levels);
            LevelsControl.Content = _levelsView.CurrentItem;        }

        private void PreviousLevel(object sender, RoutedEventArgs e)
        {
            if (_levelsView.CurrentPosition > 0)
            {
                _levelsView.MoveCurrentToPrevious();
                LevelsControl.Content = _levelsView.CurrentItem;
            }
        }

        private void NextLevel(object sender, RoutedEventArgs e)
        {
            if (_levelsView.CurrentPosition < _levels.Count - 1)
            {
                _levelsView.MoveCurrentToNext();
                LevelsControl.Content = _levelsView.CurrentItem;
            }
        }

        private void Level_Click(object sender, RoutedEventArgs e)
        {
            // Ajoutez ici le code pour gérer le clic sur un niveau
        }
    }

    public class Level
    {
        public SolidColorBrush Color { get; set; }
    }
}