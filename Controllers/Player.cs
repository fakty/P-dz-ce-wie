using System;
using System.Windows;
using System.Windows.Media.Imaging;
using TurtleRace.Models;

namespace TurtleRace.Controllers
{
    public class Player
    {
        public Card[] Hand { get; }
        public Turtle PlayerTurtle { get; set; }
        public BitmapSource TurtleSource { get; }
        public string PlayerType { get; }

        public Player(Turtle turtle, string playerType)
        {
            PlayerType = playerType;
            Hand = new Card[5];
            for (var i = 0; i < 5; i++)
            {
                Hand[i] = DrawCard();
            }
            switch (PlayerTurtle = turtle)
            {
                case Turtle.Blue:
                    TurtleSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.token_blue.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
                case Turtle.Green:
                    TurtleSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.token_green.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
                case Turtle.Red:
                    TurtleSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.token_red.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
                case Turtle.Violet:
                    TurtleSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.token_violet.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
                case Turtle.Yellow:
                    TurtleSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.token_yellow.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
            }
        }

        public Card PlayCard(int id)
        {
            var selected = Hand[id];
            Hand[id] = DrawCard();
            return selected;
        }

        public Card DrawCard()
        {
            return Deck.Instance.DrawCard();
        }
    }
}