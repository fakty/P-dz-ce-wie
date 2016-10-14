using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pędzące_Żółwie.Controllers;
using Pędzące_Żółwie.Views;

namespace Pędzące_Żółwie
{
    /// <summary>
    /// Logika interakcji dla klasy EndGamePrompt.xaml
    /// </summary>
    public partial class EndGamePrompt
    {
        private readonly GameWindow _gameWindow;

        public EndGamePrompt(GameWindow gameWindow, bool isWinner, int winPlayer = -1)
        {
            InitializeComponent();
            Cursor = new Cursor(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));

            _gameWindow = gameWindow;
            _gameWindow.IsEnabled = false;
            var game = Game.Instance;

            if (isWinner) WinLabel.Content = "Zwyciężył gracz " + winPlayer + "!";
            else WinLabel.Content = "Nikt nie zwyciężył!";

            for (var i = 0; i < game.PlayersCount; i++)
            {
                var colP = new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)};
                var player = new Label
                {
                    Content = "Gracz " + (i + 1),
                    FontSize = 22,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetRow(player, 1);
                Grid.SetColumn(player, i);
                PlayerGrid.ColumnDefinitions.Add(colP);
                PlayerGrid.Children.Add(player);

                var colT = new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)};
                var turtle = new Image
                {
                    Source = game.Players[i].TurtleSource,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Width = 90,
                    Height = 90
                };
                Grid.SetRow(turtle, 2);
                Grid.SetColumn(turtle, i);
                TurtleGrid.ColumnDefinitions.Add(colT);
                TurtleGrid.Children.Add(turtle);
            }
        }

        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            Game.DeleteGame();
            new MainWindow().Show();
            _gameWindow.Close();
            Close();
        }
    }
}
