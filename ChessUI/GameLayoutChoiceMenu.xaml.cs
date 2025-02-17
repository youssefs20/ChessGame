using ChessLogic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameLayoutChoiceMenu.xaml
    /// </summary>
    public partial class GameLayoutChoiceMenu : UserControl
    {
        public event Action<GameMode> OptionSelected;

        public GameLayoutChoiceMenu()
        {
            InitializeComponent();
        }


        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(GameMode.Standard);

        }

        private void Chess960_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(GameMode.Chess960);

        }
    }
}
