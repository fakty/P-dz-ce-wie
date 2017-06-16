using System;
using System.Collections;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Pędzące_Żółwie.Models
{
    class Deck
    {
        private static readonly BitmapSource BluePlus2 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_blue_plus_2.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource VioletPlus2 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_violet_plus_2.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource YellowPlus2 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_yellow_plus_2.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource RedPlus2 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_red_plus_2.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource GreenPlus2 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_green_plus_2.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        private static readonly BitmapSource BluePlus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_blue_plus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource VioletPlus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_violet_plus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource YellowPlus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_yellow_plus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource RedPlus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_red_plus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource GreenPlus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_green_plus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource ColourPlus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_color_plus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        private static readonly BitmapSource BlueMinus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_blue_minus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource VioletMinus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_violet_minus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource YellowMinus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_yellow_minus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource RedMinus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_red_minus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource GreenMinus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_green_minus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource ColourMinus = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_color_minus.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        private static readonly BitmapSource Arrow = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_arrow.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        private static readonly BitmapSource Arrow2 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.card_arrow_2.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

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

        public static void DeleteDeck()
        {
            _instance = null;
            GC.Collect();
        }

        private void Shuffle()
        {
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(Arrow2, Turtle.Colourful, "arrow", 2));
            for (var i = 0; i < 3; i++)
                _deck.Add(new Card(Arrow, Turtle.Colourful, "arrow", 1));

            _deck.Add(new Card(BluePlus2, Turtle.Blue, "plus", 2));
            _deck.Add(new Card(GreenPlus2, Turtle.Green, "plus", 2));
            _deck.Add(new Card(RedPlus2, Turtle.Red, "plus", 2));
            _deck.Add(new Card(VioletPlus2, Turtle.Violet, "plus", 2));
            _deck.Add(new Card(YellowPlus2, Turtle.Yellow, "plus", 2));

            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(BluePlus, Turtle.Blue, "plus", 1));
            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(GreenPlus, Turtle.Green, "plus", 1));
            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(RedPlus, Turtle.Red, "plus", 1));
            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(VioletPlus, Turtle.Violet, "plus", 1));
            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(YellowPlus, Turtle.Yellow, "plus", 1));
            for (var i = 0; i < 5; i++)
                _deck.Add(new Card(ColourPlus, Turtle.Colourful, "plus", 1));

            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(BlueMinus, Turtle.Blue, "minus", 1));
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(GreenMinus, Turtle.Green, "minus", 1));
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(RedMinus, Turtle.Red, "minus", 1));
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(VioletMinus, Turtle.Violet, "minus", 1));
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(YellowMinus, Turtle.Yellow, "minus", 1));
            for (var i = 0; i < 2; i++)
                _deck.Add(new Card(ColourMinus, Turtle.Colourful, "minus", 1));
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
