using System;
using System.Collections;
using System.Windows.Controls;
using Pędzące_Żółwie.Models;
using Pędzące_Żółwie.Views;

namespace Pędzące_Żółwie.Controllers
{
    public class Game
    {
        private static Game _instance;
        private int _currentId;
        //private readonly Deck _deck;

        public int PlayersCount = 2;
        public GameWindow MainWindow { get; set; }
        public Player[] Players { get; set; }

        private readonly Turtle[][] _board;

        private Game()
        {
            //_deck = Deck.Instance;
            _board = new Turtle[10][];
            for (var i = 0; i < _board.Length; i++)
            {
                _board[i] = new Turtle[5];
            }
            _board[0][0] = Turtle.Yellow;
            _board[0][1] = Turtle.Violet;
            _board[0][2] = Turtle.Red;
            _board[0][3] = Turtle.Green;
            _board[0][4] = Turtle.Blue;
        }

        public static Game Instance => _instance ?? (_instance = new Game());

        public void AddPlayers()
        {
            Players = new Player[PlayersCount];
            var turtles = new ArrayList { Turtle.Blue, Turtle.Green, Turtle.Red, Turtle.Violet, Turtle.Yellow };
            var count = PlayersCount;
            var random = new Random();
            for (var i = 0; i < Players.Length; i++)
            {
                Players[i] = new Player((Turtle)turtles[random.Next(count)]);
                turtles.Remove(Players[i].PlayerTurtle);
                count--;
            }
        }

        public void CardSelected(Image btnImg, int i)
        {
            var card = Players[_currentId].PlayCard(i);
            if(card.Color == Turtle.Colorfull)
                ColorCardSelected(card);
            else EndTurn();
        }

        private void ColorCardSelected(Card card)
        {
            var colors = !card.Sign.Equals("arrow") ? new[] { "zielony", "czerwony", "niebieski", "żółty", "fioletowy" } : new[] { "zielony", "czerwony", "żółty" };
            new ColorSelectPrompt(card.CardImage, colors, MainWindow).Show();
        }

        public void EndTurn()
        {
            ChangePlayer();
            MainWindow.PlayerTurtle.Source = Players[_currentId].TurtleSource;

            MainWindow.CardImage0.Source = Players[_currentId].Hand[0].CardImage;
            MainWindow.CardImage1.Source = Players[_currentId].Hand[1].CardImage;
            MainWindow.CardImage2.Source = Players[_currentId].Hand[2].CardImage;
            MainWindow.CardImage3.Source = Players[_currentId].Hand[3].CardImage;
            MainWindow.CardImage4.Source = Players[_currentId].Hand[4].CardImage;
        }

        private void ChangePlayer()
        {
            var second = MainWindow.Queue1.Content;
            if (PlayersCount > 2)
            {
                MainWindow.Queue1.Content = MainWindow.Queue2.Content;
                if (PlayersCount > 3)
                {
                    MainWindow.Queue2.Content = MainWindow.Queue3.Content;
                    if (PlayersCount > 4)
                    {
                        MainWindow.Queue3.Content = MainWindow.Queue4.Content;
                        MainWindow.Queue4.Content = MainWindow.CurrentplayerName.Content;
                        MainWindow.CurrentplayerName.Content = second;
                    }
                    else
                    {
                        MainWindow.Queue3.Content = MainWindow.CurrentplayerName.Content;
                        MainWindow.CurrentplayerName.Content = second;
                    }
                }
                else
                {
                    MainWindow.Queue2.Content = MainWindow.CurrentplayerName.Content;
                    MainWindow.CurrentplayerName.Content = second;
                }
            }
            else
            {
                MainWindow.Queue1.Content = MainWindow.CurrentplayerName.Content;
                MainWindow.CurrentplayerName.Content = second;
            }

            _currentId = int.Parse(second.ToString().Substring(second.ToString().Length - 1)) - 1;
        }
    }
}