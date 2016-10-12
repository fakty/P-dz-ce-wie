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
        private Player _currentPlayer;

        private readonly int _playersCount;

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

            _playersCount = playersCount;

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

            if (_playersCount < 3)
            {
                Queue2.Visibility = Visibility.Hidden;
            }
            else
            {
                Queue2.Content = "Gracz " + array[curr = rnd.Next(0, playersCount)];
                array.RemoveAt(curr);
                playersCount--;
            }
            if (_playersCount < 4)
            {
                Queue3.Visibility = Visibility.Hidden;
            }
            else
            {
                Queue3.Content = "Gracz " + array[curr = rnd.Next(0, playersCount)];
                array.RemoveAt(curr);
            }
            if (_playersCount < 5)
            {
                Queue4.Visibility = Visibility.Hidden;
            }
            else
            {
                Queue4.Content = "Gracz " + array[0];
            }

            EndTurn();
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

        private void ChangePlayer()
        {
            var second = Queue1.Content;
            if (_playersCount > 2)
            {
                Queue1.Content = Queue2.Content;
                if (_playersCount > 3)
                {
                    Queue2.Content = Queue3.Content;
                    if (_playersCount > 4)
                    {
                        Queue3.Content = Queue4.Content;
                        Queue4.Content = CurrentplayerName.Content;
                        CurrentplayerName.Content = second;
                    }
                    else
                    {
                        Queue3.Content = CurrentplayerName.Content;
                        CurrentplayerName.Content = second;
                    }
                }
                else
                {
                    Queue2.Content = CurrentplayerName.Content;
                    CurrentplayerName.Content = second;
                }
            }
            else
            {
                Queue1.Content = CurrentplayerName.Content;
                CurrentplayerName.Content = second;
            }

            _currentPlayer =
                _gameController.Players[int.Parse(second.ToString().Substring(second.ToString().Length - 1)) - 1];
        }

        private void Card0_Click(object sender, RoutedEventArgs e)
        {
            var card = _currentPlayer.PlayCard(0);
            CardImage0.Source = card.CardImage;
            EndTurn();
        }

        private void Card1_Click(object sender, RoutedEventArgs e)
        {
            var card = _currentPlayer.PlayCard(1);
            CardImage1.Source = card.CardImage;
            EndTurn();
        }

        private void Card2_Click(object sender, RoutedEventArgs e)
        {
            var card = _currentPlayer.PlayCard(2);
            CardImage2.Source = card.CardImage;
            EndTurn();
        }

        private void Card3_Click(object sender, RoutedEventArgs e)
        {
            var card = _currentPlayer.PlayCard(3);
            CardImage3.Source = card.CardImage;
            EndTurn();
        }

        private void Card4_Click(object sender, RoutedEventArgs e)
        {
            var card = _currentPlayer.PlayCard(4);
            CardImage4.Source = card.CardImage;
            EndTurn();
        }

        private void EndTurn()
        {
            /*Cursor = _waitCursor;
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            PlayerTurtle.Source = ConvertBitmap(Properties.Resources.token);

            CardImage0.Source = ConvertBitmap(Properties.Resources.card);
            Card0.IsEnabled = false;
            CardImage1.Source = ConvertBitmap(Properties.Resources.card);
            Card1.IsEnabled = false;
            CardImage2.Source = ConvertBitmap(Properties.Resources.card);
            Card2.IsEnabled = false;
            CardImage3.Source = ConvertBitmap(Properties.Resources.card);
            Card3.IsEnabled = false;
            CardImage4.Source = ConvertBitmap(Properties.Resources.card);
            Card4.IsEnabled = false;

            EndTurnButton.IsEnabled = false;
            EndTurnButton.Content = "Czekaj...";

            ChangePlayer();
            timer.Tick += (s, e) =>
            {*/
                ChangePlayer();
                /*if (!((string)CurrentplayerName.Content).Equals("Gracz 1")) return;
                timer.Stop();
                Cursor = _cursor;*/
                PlayerTurtle.Source = _currentPlayer.TurtleSource;

                /*CardImage0.Source = ConvertBitmap(Properties.Resources.card_arrow_2);
                Card0.IsEnabled = true;
                CardImage1.Source = ConvertBitmap(Properties.Resources.card_yellow_minus);
                Card1.IsEnabled = true;
                CardImage2.Source = ConvertBitmap(Properties.Resources.card_violet_plus_2);
                Card2.IsEnabled = true;
                CardImage3.Source = ConvertBitmap(Properties.Resources.card_red_plus);
                Card3.IsEnabled = true;
                CardImage4.Source = ConvertBitmap(Properties.Resources.card_color_plus);
                Card4.IsEnabled = true;*/
                CardImage0.Source = _currentPlayer.Hand[0].CardImage;
                //Card0.IsEnabled = true;
                CardImage1.Source = _currentPlayer.Hand[1].CardImage;
                //Card1.IsEnabled = true;
                CardImage2.Source = _currentPlayer.Hand[2].CardImage;
                //Card2.IsEnabled = true;
                CardImage3.Source = _currentPlayer.Hand[3].CardImage;
                //Card3.IsEnabled = true;
                CardImage4.Source = _currentPlayer.Hand[4].CardImage;
                //Card4.IsEnabled = true;

                /*EndTurnButton.IsEnabled = true;
                EndTurnButton.Content = "Koniec\ntury";
            };

            timer.Start();*/
        }
    }
}