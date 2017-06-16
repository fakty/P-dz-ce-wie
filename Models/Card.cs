using System.Windows.Media.Imaging;

namespace TurtleRace.Models
{
    public class Card
    {
        public Card(BitmapSource bitmap, Turtle color, string sign, int value)
        {
            CardImage = bitmap;
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
                    return "blue, " + Sign + ", " + Value;
                case Turtle.Colourful:
                    return "colour, " + Sign + ", " + Value;
                case Turtle.Green:
                    return "green, " + Sign + ", " + Value;
                case Turtle.Red:
                    return "red, " + Sign + ", " + Value;
                case Turtle.Violet:
                    return "violet, " + Sign + ", " + Value;
                default:
                    return "yellow, " + Sign + ", " + Value;
            }
        }
    }
}