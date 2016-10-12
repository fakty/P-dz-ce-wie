using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Pędzące_Żółwie.Controllers;

namespace Pędzące_Żółwie.Views
{
    /// <summary>
    /// Logika interakcji dla klasy GameWindow.xaml
    /// </summary>
    public partial class GameWindow
    {
        private readonly Cursor _cursor;
        //private readonly Cursor _waitCursor;
        private readonly Game _gameController;

        public GameWindow(int playersCount)
        {
            InitializeComponent();
            _gameController = Game.Instance;
            _gameController.PlayersCount = playersCount;
            _gameController.AddPlayers();
            _gameController.MainWindow = this;

            _cursor = new Cursor(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));
            //_waitCursor = new Cursor(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\green_busy.cur"));

            Cursor = _cursor;

            var playersCount1 = playersCount;

            var temp = new int[playersCount];
            var rnd = new Random();
            int curr;
            for (var i = 0; i < playersCount; i++)
                temp[i] = i + 1;
            var array = new ArrayList(temp);
            playersCount--;
            CurrentplayerName.Content = "Gracz " + array[curr = rnd.Next(0, playersCount)];
            array.RemoveAt(curr);
            playersCount--;
            Queue1.Content = "Gracz " + array[curr = rnd.Next(0, playersCount)];
            array.RemoveAt(curr);
            playersCount--;

            if (playersCount1 < 3)
            {
                Queue2.Visibility = Visibility.Hidden;
            }
            else
            {
                Queue2.Content = "Gracz " + array[curr = rnd.Next(0, playersCount)];
                array.RemoveAt(curr);
                playersCount--;
            }
            if (playersCount1 < 4)
            {
                Queue3.Visibility = Visibility.Hidden;
            }
            else
            {
                Queue3.Content = "Gracz " + array[curr = rnd.Next(0, playersCount)];
                array.RemoveAt(curr);
            }
            if (playersCount1 < 5)
            {
                Queue4.Visibility = Visibility.Hidden;
            }
            else
            {
                Queue4.Content = "Gracz " + array[0];
            }

            _gameController.EndTurn();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void EndTurnButton_Click(object sender, RoutedEventArgs re)
        {
            EndTurnButton.Content = new Random().Next(52);
        }

        
        private void Card0_Click(object sender, RoutedEventArgs e)
        {
            _gameController.CardSelected(CardImage0, 0);
        }

        private void Card1_Click(object sender, RoutedEventArgs e)
        {
            _gameController.CardSelected(CardImage1, 1);
        }

        private void Card2_Click(object sender, RoutedEventArgs e)
        {
            _gameController.CardSelected(CardImage2, 2);
        }

        private void Card3_Click(object sender, RoutedEventArgs e)
        {
            _gameController.CardSelected(CardImage3, 3);
        }

        private void Card4_Click(object sender, RoutedEventArgs e)
        {
            _gameController.CardSelected(CardImage4, 4);
        }

        
    }
}