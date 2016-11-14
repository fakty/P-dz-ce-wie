using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Pędzące_Żółwie.Models;

namespace Pędzące_Żółwie.Controllers
{
    public class Game
    {
        private static Game _instance;
        private int _currentId; //id of current player
        private readonly Algorithms _algorithms;

        //blank card + token
        private readonly BitmapSource _token;
        private readonly BitmapSource _card;

        //turtles
        private readonly int[] _blue;
        private readonly int[] _red;
        private readonly int[] _green;
        private readonly int[] _violet;
        private readonly int[] _yellow;

        //tokens
        private readonly BitmapSource _turtleBlue;
        private readonly BitmapSource _turtleRed;
        private readonly BitmapSource _turtleGreen;
        private readonly BitmapSource _turtleViolet;
        private readonly BitmapSource _turtleYellow;

        //empty '0'-position
        private readonly ArrayList _emptyZeros;

        //EndGame flag
        private bool _endGameFlag;

        public int PlayersCount = 2;
        public GameWindow MainWindow { get; set; }
        private readonly Log _log;
        public Player[] Players { get; set; }

        public static void DeleteGame()
        {
            _instance = null;
            Deck.DeleteDeck();
        }

        private Game()
        {
            _algorithms = Algorithms.Instance;
            _log = Log.Instance;
            _emptyZeros = new ArrayList();

            _yellow = new[] {0, 0};
            _violet = new[] {0, 1};
            _red = new[] {0, 2};
            _green = new[] {0, 3};
            _blue = new[] {0, 4};

            _turtleBlue = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.turtle_blue.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            _turtleRed = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.turtle_red.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            _turtleGreen = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.turtle_green.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            _turtleViolet = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.turtle_violet.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            _turtleYellow = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.turtle_yellow.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            _token = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.token.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            _card = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            
            _log.WriteLine("----------NEW GAME " + string.Format("{0:G}", DateTime.Now) + "----------");
        }

        public static Game Instance => _instance ?? (_instance = new Game());

        public void AddPlayers(string[] playersType)
        {
            Players = new Player[PlayersCount];
            var turtles = new ArrayList { Turtle.Blue, Turtle.Green, Turtle.Red, Turtle.Violet, Turtle.Yellow };
            var count = PlayersCount;
            var random = new Random();
            for (var i = 0; i < Players.Length; i++)
            {
                Players[i] = new Player((Turtle)turtles[random.Next(count)], playersType[i]);
                turtles.Remove(Players[i].PlayerTurtle);
                count--;
            }
            var logPlayers = "";
            for (var i = 0; i < Players.Length; i++)
            {
                logPlayers += "Gracz " + (i + 1) + ": ";
                switch (Players[i].PlayerTurtle)
                {
                    case Turtle.Blue:
                        logPlayers += "blue; ";
                        break;
                    case Turtle.Red:
                        logPlayers += "red; ";
                        break;
                    case Turtle.Green:
                        logPlayers += "green; ";
                        break;
                    case Turtle.Violet:
                        logPlayers += "violet; ";
                        break;
                    default:
                        logPlayers += "yellow; ";
                        break;
                }
            }
            _log.WriteLine(logPlayers);
            _log.WriteLine();
        }

        public void CardSelected(int i)
        {
            var card = Players[_currentId].PlayCard(i);
            if (card.Color == Turtle.Colorfull)
                ColorCardSelected(card);
            else
            {
                var logLine = "Gracz " + (_currentId + 1);
                switch (card.Color)
                {
                    case Turtle.Blue:
                        logLine += ": niebieski, " + card.Sign + ", " + card.Value + ";\n";
                        _log.WriteLine(logLine);
                        MainWindow.GetLogBlock().Text = logLine + MainWindow.GetLogBlock().Text;
                        Move(card, _blue);
                        break;
                    case Turtle.Green:
                        logLine += ": zielony, " + card.Sign + ", " + card.Value + ";\n";
                        _log.WriteLine(logLine);
                        MainWindow.GetLogBlock().Text = logLine + MainWindow.GetLogBlock().Text;
                        Move(card, _green);
                        break;
                    case Turtle.Red:
                        logLine += ": czerwony, " + card.Sign + ", " + card.Value + ";\n";
                        _log.WriteLine(logLine);
                        MainWindow.GetLogBlock().Text = logLine + MainWindow.GetLogBlock().Text;
                        Move(card, _red);
                        break;
                    case Turtle.Violet:
                        logLine += ": fioletowy, " + card.Sign + ", " + card.Value + ";\n";
                        _log.WriteLine(logLine);
                        MainWindow.GetLogBlock().Text = logLine + MainWindow.GetLogBlock().Text;
                        Move(card, _violet);
                        break;
                    case Turtle.Yellow:
                        logLine += ": żółty, " + card.Sign + ", " + card.Value + ";\n";
                        _log.WriteLine(logLine);
                        MainWindow.GetLogBlock().Text = logLine + MainWindow.GetLogBlock().Text;
                        Move(card, _yellow);
                        break;
                }
                EndTurn();
            }
        }

        private void Move(Card card, int[] turtle)
        {
            var onTurtle = FindOnTurtles(turtle);
            if (card.Sign.Equals("plus") || card.Sign.Equals("arrow"))
            {
                turtle[0] += card.Value;
                if (turtle[0] > 9) turtle[0] = 9;
            }
            else
            {
                turtle[0] -= card.Value;
                if (turtle[0] < 0) turtle[0] = 0;
            }
            MoveTurtlesOnField(turtle[0], onTurtle);
            if (turtle[0] == 9) CheckWinner();
        }

        private void MoveTurtlesOnField(int field, Turtle[] onTurtle)
        {
            if (field != 0)
            {
                var pos = 0;
                if (_red[0] == field) pos++;
                if (_blue[0] == field) pos++;
                if (_yellow[0] == field) pos++;
                if (_green[0] == field) pos++;
                if (_violet[0] == field) pos++;
                pos--;

                foreach (Turtle t in onTurtle)
                {
                    switch (t)
                    {
                        case Turtle.Blue:
                            _blue[0] = field;
                            _blue[1] = pos;
                            ((Image) MainWindow.FindName("Field" + _blue[0] + _blue[1])).Source = _turtleBlue;
                            break;
                        case Turtle.Green:
                            _green[0] = field;
                            _green[1] = pos;
                            ((Image) MainWindow.FindName("Field" + _green[0] + _green[1])).Source = _turtleGreen;
                            break;
                        case Turtle.Red:
                            _red[0] = field;
                            _red[1] = pos;
                            ((Image) MainWindow.FindName("Field" + _red[0] + _red[1])).Source = _turtleRed;
                            break;
                        case Turtle.Violet:
                            _violet[0] = field;
                            _violet[1] = pos;
                            ((Image) MainWindow.FindName("Field" + _violet[0] + _violet[1])).Source = _turtleViolet;
                            break;
                        case Turtle.Yellow:
                            _yellow[0] = field;
                            _yellow[1] = pos;
                            ((Image) MainWindow.FindName("Field" + _yellow[0] + _yellow[1])).Source = _turtleYellow;
                            break;
                    }
                    pos++;
                }
            }
            else
            {
                foreach (var t in onTurtle)
                {
                    switch (t)
                    {
                        case Turtle.Blue:
                            _blue[0] = field;
                            _blue[1] = (int)_emptyZeros[0];
                            ((Image)MainWindow.FindName("Field" + _blue[0] + _blue[1])).Source = _turtleBlue;
                            break;
                        case Turtle.Green:
                            _green[0] = field;
                            _green[1] = (int)_emptyZeros[0];
                            ((Image)MainWindow.FindName("Field" + _green[0] + _green[1])).Source = _turtleGreen;
                            break;
                        case Turtle.Red:
                            _red[0] = field;
                            _red[1] = (int)_emptyZeros[0];
                            ((Image)MainWindow.FindName("Field" + _red[0] + _red[1])).Source = _turtleRed;
                            break;
                        case Turtle.Violet:
                            _violet[0] = field;
                            _violet[1] = (int)_emptyZeros[0];
                            ((Image)MainWindow.FindName("Field" + _violet[0] + _violet[1])).Source = _turtleViolet;
                            break;
                        case Turtle.Yellow:
                            _yellow[0] = field;
                            _yellow[1] = (int)_emptyZeros[0];
                            ((Image)MainWindow.FindName("Field" + _yellow[0] + _yellow[1])).Source = _turtleYellow;
                            break;
                    }
                    _emptyZeros.RemoveAt(0);
                }
            }
        }

        private Turtle[] FindOnTurtles(int[] turtle)
        {
            if (turtle[0] == 0)
            {
                var onTurtles = new Turtle[1];
                if (_red[0] == turtle[0] && _red[1] == turtle[1])
                {
                    onTurtles[0] = Turtle.Red;
                }
                if (_blue[0] == turtle[0] && _blue[1] == turtle[1])
                {
                    onTurtles[0] = Turtle.Blue;
                }
                if (_yellow[0] == turtle[0] && _yellow[1] == turtle[1])
                {
                    onTurtles[0] = Turtle.Yellow;
                }
                if (_green[0] == turtle[0] && _green[1] == turtle[1])
                {
                    onTurtles[0] = Turtle.Green;
                }
                if (_violet[0] == turtle[0] && _violet[1] == turtle[1])
                {
                    onTurtles[0] = Turtle.Violet;
                }
                ((Image)MainWindow.FindName("Field" + turtle[0] + turtle[1])).Source = null;
                _emptyZeros.Add(turtle[1]);
                return onTurtles;
            }
            else
            {
                var count = 0;

                if (_red[0] == turtle[0] && _red[1] >= turtle[1]) count++;
                if (_blue[0] == turtle[0] && _blue[1] >= turtle[1]) count++;
                if (_yellow[0] == turtle[0] && _yellow[1] >= turtle[1]) count++;
                if (_green[0] == turtle[0] && _green[1] >= turtle[1]) count++;
                if (_violet[0] == turtle[0] && _violet[1] >= turtle[1]) count++;

                if (count == 0) return null;

                var onTurtles = new Turtle[count];

                if (_red[0] == turtle[0] && _red[1] >= turtle[1])
                {
                    onTurtles[_red[1] - turtle[1]] = Turtle.Red;
                    ((Image) MainWindow.FindName("Field" + _red[0] + _red[1])).Source = null;
                }
                if (_blue[0] == turtle[0] && _blue[1] >= turtle[1])
                {
                    onTurtles[_blue[1] - turtle[1]] = Turtle.Blue;
                    ((Image) MainWindow.FindName("Field" + _blue[0] + _blue[1])).Source = null;
                }
                if (_yellow[0] == turtle[0] && _yellow[1] >= turtle[1])
                {
                    onTurtles[_yellow[1] - turtle[1]] = Turtle.Yellow;
                    ((Image) MainWindow.FindName("Field" + _yellow[0] + _yellow[1])).Source = null;
                }
                if (_green[0] == turtle[0] && _green[1] >= turtle[1])
                {
                    onTurtles[_green[1] - turtle[1]] = Turtle.Green;
                    ((Image) MainWindow.FindName("Field" + _green[0] + _green[1])).Source = null;
                }
                if (_violet[0] == turtle[0] && _violet[1] >= turtle[1])
                {
                    onTurtles[_violet[1] - turtle[1]] = Turtle.Violet;
                    ((Image) MainWindow.FindName("Field" + _violet[0] + _violet[1])).Source = null;
                }

                return onTurtles;
            }
        }

        private void ColorCardSelected(Card card)
        {
            var colors = !card.Sign.Equals("arrow") ? new[] { "zielony", "czerwony", "niebieski", "żółty", "fioletowy" } : SelectColorsForArrow();
            if (Players[_currentId].PlayerType.Equals("Człowiek")) new ColorSelectPrompt(card, colors, MainWindow).Show();
            else MoveColored(card, colors[_algorithms.EvaluateStrategyColor(Players[_currentId].PlayerType, card, colors)]);
        }

        private string[] SelectColorsForArrow()
        {
            var min = 9;
            if (_red[0] < min) min = _red[0];
            if (_blue[0] < min) min = _blue[0];
            if (_green[0] < min) min = _green[0];
            if (_yellow[0] < min) min = _yellow[0];
            if (_violet[0] < min) min = _violet[0];

            var list = new ArrayList();

            if (_red[0] == min) list.Add("czerwony");
            if (_blue[0] == min) list.Add("niebieski");
            if (_green[0] == min) list.Add("zielony");
            if (_yellow[0] == min) list.Add("żółty");
            if (_violet[0] == min) list.Add("fioletowy");

            var result = new string[list.Count];
            for (var i = 0; i < list.Count; i++)
            {
                result[i] = list[i] as string;
            }
            return result;
        }

        public void MoveColored(Card card, string color)
        {
            var logLine = "Gracz " + (_currentId + 1) + ": kolor ";
            int[] turtle;
            switch (color)
            {
                case "czerwony":
                    turtle = _red;
                    logLine += "(czerwony), ";
                    break;
                case "fioletowy":
                    turtle = _violet;
                    logLine += "(fioletowy), ";
                    break;
                case "zielony":
                    turtle = _green;
                    logLine += "(zielony), ";
                    break;
                case "niebieski":
                    turtle = _blue;
                    logLine += "(niebieski), ";
                    break;
                default:
                    turtle = _yellow;
                    logLine += "(żółty), ";
                    break;
            }
            logLine += card.Sign + ", " + card.Value + ";\n";
            _log.WriteLine(logLine);
            MainWindow.GetLogBlock().Text = logLine + MainWindow.GetLogBlock().Text;
            Move(card, turtle);
            EndTurn();
        }

        public void EndTurn()
        {
            ChangePlayer();
            if (Players[_currentId].PlayerType.Equals("Człowiek"))
            {
                MainWindow.SetCursor();
                MainWindow.PlayerTurtle.Source = Players[_currentId].TurtleSource;

                MainWindow.CardImage0.Source = Players[_currentId].Hand[0].CardImage;
                MainWindow.CardImage1.Source = Players[_currentId].Hand[1].CardImage;
                MainWindow.CardImage2.Source = Players[_currentId].Hand[2].CardImage;
                MainWindow.CardImage3.Source = Players[_currentId].Hand[3].CardImage;
                MainWindow.CardImage4.Source = Players[_currentId].Hand[4].CardImage;
            }
            else
            {
                MainWindow.SetWaitCursor();
                MainWindow.PlayerTurtle.Source = _token;

                MainWindow.CardImage0.Source = _card;
                MainWindow.CardImage1.Source = _card;
                MainWindow.CardImage2.Source = _card;
                MainWindow.CardImage3.Source = _card;
                MainWindow.CardImage4.Source = _card;

                //System.Threading.Thread.Sleep(1000);

                if (!_endGameFlag) CardSelected(_algorithms.EvaluateStrategy(Players[_currentId]));
            }
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

        private void CheckWinner()
        {
            _endGameFlag = true;
            Turtle[] finishedTurtles = {Turtle.Colorfull, Turtle.Colorfull, Turtle.Colorfull, Turtle.Colorfull, Turtle.Colorfull};

            if (_red[0] == 9) finishedTurtles[_red[1]] = Turtle.Red;
            if (_blue[0] == 9) finishedTurtles[_blue[1]] = Turtle.Blue;
            if (_green[0] == 9) finishedTurtles[_green[1]] = Turtle.Green;
            if (_yellow[0] == 9) finishedTurtles[_yellow[1]] = Turtle.Yellow;
            if (_violet[0] == 9) finishedTurtles[_violet[1]] = Turtle.Violet;

            var finishedTurtlesCount = 5;
            while (finishedTurtlesCount > 0 && finishedTurtles[finishedTurtlesCount - 1] == Turtle.Colorfull) finishedTurtlesCount--;

            if (finishedTurtlesCount <= 0) return;
            var winPlayer = -1;
            for (var i = 0; i < finishedTurtlesCount && winPlayer == -1; i++)
            {
                for(var j = 0; j < Players.Length && winPlayer == -1; j++)
                {
                    if (Players[j].PlayerTurtle != finishedTurtles[i]) continue;
                    winPlayer = j + 1;
                } 
            }
            string logLine;
            _log.WriteLine();
            if (winPlayer == -1)
            {
                new EndGamePrompt(MainWindow, false).Show();
                _log.WriteLine(logLine = "*****Brak zwycięzcy*****\n");
                _log.WriteLine();
                MainWindow.GetLogBlock().Text = logLine + MainWindow.GetLogBlock().Text;
            }
            else
            {
                new EndGamePrompt(MainWindow, true, winPlayer).Show();
                _log.WriteLine(logLine = "*****Zwycięzca: Grzacz " + winPlayer + "*****\n");
                _log.WriteLine();
                MainWindow.GetLogBlock().Text = logLine + MainWindow.GetLogBlock().Text;
            }
        }
    }
}