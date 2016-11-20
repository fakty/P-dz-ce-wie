using System;
using Pędzące_Żółwie.Models;

namespace Pędzące_Żółwie.Controllers
{
    class Algorithms
    {
        private static Algorithms _instance;
        private readonly Random _random;

        /* Turtles in arrays:
         * 0 - blue
         * 1 - green
         * 2 - red
         * 3 - violet
         * 4 - yellow
         */ 

        private Algorithms()
        {
            _random = new Random();
        }

        public static Algorithms Instance => _instance ?? (_instance = new Algorithms());

        public int EvaluateStrategyColor(int[] turtlesPos, Player player, Card card, Turtle[] colors, int playerTurtlePos)
        {
            if (player.PlayerType.Equals("Random")) return _random.Next(5);
            var cards = new Card[colors.Length];
            for (var i = 0; i < colors.Length; i++)
            {
                cards[i] = new Card(null, colors[i], card.Sign, card.Value);
            }
            return EvaluateStrategy(turtlesPos, player, cards, colors, playerTurtlePos);
        }

        public int EvaluateStrategy(int[] turtlesPos, Player player, Card[] hand, Turtle[] colors, int playerTurtlePos)
        {
            if (player.PlayerType.Equals("Random")) return _random.Next(5);
            var index = 0;
            var max = int.MinValue;
            for (var i = 0; i < hand.Length; i++)
            {
                var card = hand[i];
                var val = 0;
                if (card.Color != Turtle.Colorfull)
                {
                    if(player.PlayerType.Equals("Strategia FWS")) val = FastestCalculate(turtlesPos[(int)card.Color], player.PlayerTurtle, card, card.Color);
                    else if (player.PlayerType.Equals("Strategia SWS")) val = SavestCalculate(turtlesPos[(int)card.Color], player.PlayerTurtle, card, card.Color);
                    else if (player.PlayerType.Equals("Strategia MASK")) val = MaskCalculate(turtlesPos[(int)card.Color], playerTurtlePos, player.PlayerTurtle, card, card.Color);
                }
                else if (card.Sign.Equals("arrow"))
                {
                    var idColor = EvaluateStrategyColor(turtlesPos, player, card, colors, playerTurtlePos);

                    if (player.PlayerType.Equals("Strategia FWS")) val = FastestCalculate(turtlesPos[idColor], player.PlayerTurtle, card, colors[idColor]);
                    else if (player.PlayerType.Equals("Strategia SWS")) val = SavestCalculate(turtlesPos[idColor], player.PlayerTurtle, card, colors[idColor]);
                    else if (player.PlayerType.Equals("Strategia MASK")) val = MaskCalculate(turtlesPos[idColor],playerTurtlePos, player.PlayerTurtle, card, colors[idColor]);
                }
                else
                {
                    var tempColors = new[] { Turtle.Blue, Turtle.Green, Turtle.Red, Turtle.Violet, Turtle.Yellow };
                    var idColor = EvaluateStrategyColor(turtlesPos, player, card, tempColors, playerTurtlePos);

                    if (player.PlayerType.Equals("Strategia FWS")) val = FastestCalculate(turtlesPos[idColor], player.PlayerTurtle, card, tempColors[idColor]);
                    else if (player.PlayerType.Equals("Strategia SWS")) val = SavestCalculate(turtlesPos[idColor], player.PlayerTurtle, card, tempColors[idColor]);
                    else if (player.PlayerType.Equals("Strategia MASK")) val = MaskCalculate(turtlesPos[idColor], playerTurtlePos, player.PlayerTurtle, card, tempColors[idColor]);
                }
                if (max >= val) continue;
                max = val;
                index = i;
            }
            return index;
        }

        private int FastestCalculate(int turtlePos, Turtle playerTurtle, Card card, Turtle cardTurtle)
        {
            if (playerTurtle == cardTurtle)
            {
                if (card.Sign.Equals("minus"))
                {
                    turtlePos += -card.Value*10;
                }
                else
                {
                    turtlePos += card.Value * 10;
                }
            }
            else
            {
                if (card.Sign.Equals("minus"))
                {
                    turtlePos += card.Value;
                }
                else
                {
                    turtlePos += -card.Value;
                }
            }
            return turtlePos;
        }

        private int SavestCalculate(int turtlePos, Turtle playerTurtle, Card card, Turtle cardTurtle)
        {
            if (playerTurtle == cardTurtle)
            {
                if (card.Sign.Equals("minus"))
                {
                    turtlePos += -card.Value * 10;
                }
                else
                {
                    turtlePos += card.Value;
                }
            }
            else
            {
                if (card.Sign.Equals("minus"))
                {
                    turtlePos += card.Value * 10;
                }
                else
                {
                    turtlePos += -card.Value;
                }
            }
            return turtlePos;
        }

        private int MaskCalculate(int turtlePos, int playerTurtlePos, Turtle playerTurtle, Card card, Turtle cardTurtle)
        {
            int value;

            if (card.Sign.Equals("minus")) value = -card.Value;
            else value = 3 - card.Value;

            if (turtlePos == playerTurtlePos)
            {
                value *= card.Value;
            }
            else if (playerTurtle == cardTurtle)
            {
                value *= playerTurtlePos;
            }
            else
            {
                value *= (playerTurtlePos - turtlePos);
            }

            return value;
        }
    }
}
