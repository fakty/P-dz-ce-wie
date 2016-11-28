using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Pędzące_Żółwie.Models
{
    public class Card
    {
        public Card(Bitmap bitmap, Turtle color, string sign, int value)
        {
            if(bitmap != null) CardImage = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            Color = color;
            Sign = sign;
            Value = value;
        }

        public BitmapSource CardImage { get; }

        public Turtle Color { get; }

        public string Sign { get; }

        public int Value { get; }

        public override string ToString()
        {
            switch (Color)
            {
                case Turtle.Blue:
                    return "niebieski, " + Sign + ", " + Value;
                case Turtle.Colorfull:
                    return "kolor, " + Sign + ", " + Value;
                case Turtle.Green:
                    return "zielony, " + Sign + ", " + Value;
                case Turtle.Red:
                    return "czerwony, " + Sign + ", " + Value;
                case Turtle.Violet:
                    return "fioletowy, " + Sign + ", " + Value;
                default:
                    return "żółty, " + Sign + ", " + Value;
            }
        }
    }
}