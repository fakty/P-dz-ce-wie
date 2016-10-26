using System;
using System.Collections;

namespace Pędzące_Żółwie.Models
{
    class Deck
    {
        private static Deck _instance;
        private readonly ArrayList _deck;
        private readonly Random _random;

        private Deck()
        {
            _deck = new ArrayList();
            _random = new Random();
            Shuffle();
        }

        public static Deck Instance => _instance ?? (_instance = new Deck());

        public static void deleteDeck()
        {
            _instance = null;
        }

        private void Shuffle()
        {
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(Properties.Resources.card_arrow_2, Turtle.Colorfull, "arrow", 2));
            for (var i = 0; i < 3; i++)
                _deck.Add(new Card(Properties.Resources.card_arrow, Turtle.Colorfull, "arrow", 1));

            _deck.Add(new Card(Properties.Resources.card_blue_plus_2, Turtle.Blue, "plus", 2));
            _deck.Add(new Card(Properties.Resources.card_green_plus_2, Turtle.Green, "plus", 2));
            _deck.Add(new Card(Properties.Resources.card_red_plus_2, Turtle.Red, "plus", 2));
            _deck.Add(new Card(Properties.Resources.card_violet_plus_2, Turtle.Violet, "plus", 2));
            _deck.Add(new Card(Properties.Resources.card_yellow_plus_2, Turtle.Yellow, "plus", 2));

            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(Properties.Resources.card_blue_plus, Turtle.Blue, "plus", 1));
            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(Properties.Resources.card_green_plus, Turtle.Green, "plus", 1));
            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(Properties.Resources.card_red_plus, Turtle.Red, "plus", 1));
            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(Properties.Resources.card_violet_plus, Turtle.Violet, "plus", 1));
            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(Properties.Resources.card_yellow_plus, Turtle.Yellow, "plus", 1));
            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(Properties.Resources.card_color_plus, Turtle.Colorfull, "plus", 1));

            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(Properties.Resources.card_blue_minus, Turtle.Blue, "minus", 1));
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(Properties.Resources.card_green_minus, Turtle.Green, "minus", 1));
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(Properties.Resources.card_red_minus, Turtle.Red, "minus", 1));
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(Properties.Resources.card_violet_minus, Turtle.Violet, "minus", 1));
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(Properties.Resources.card_yellow_minus, Turtle.Yellow, "minus", 1));
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(Properties.Resources.card_color_minus, Turtle.Colorfull, "minus", 1));
        }

        public Card DrawCard()
        {
            if (_deck.Count == 0)
            {
                Shuffle();
            }
            var index = _random.Next(0, _deck.Count);
            var result = _deck[index] as Card;
            _deck.RemoveAt(index);
            return result;
        }
    }
}
