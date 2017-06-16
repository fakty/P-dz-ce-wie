using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using TurtleRace.Controllers;
using TurtleRace.Models;

namespace TurtleRace
{
    /// <summary>
    /// Logika interakcji dla klasy ColorSelectPrompt.xaml
    /// </summary>
    public partial class ColorSelectPrompt
    {
        private readonly GameWindow _gameWindow;
        private readonly Card _card;

        public ColorSelectPrompt(Card card, string[] posColors, GameWindow gameWindow)
        {
            _gameWindow = gameWindow;
            _gameWindow.IsEnabled = false;
            _card = card;

            InitializeComponent();
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
            Cursor = new Cursor(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));

            Image.Source = card.CardImage;
            if (posColors.Length > 4)
                Button5.Content = posColors[4];
            else Button5.Visibility = Visibility.Hidden;
            if (posColors.Length > 3)
                Button4.Content = posColors[3];
            else Button4.Visibility = Visibility.Hidden;
            if (posColors.Length > 2)
                Button3.Content = posColors[2];
            else Button3.Visibility = Visibility.Hidden;
            if (posColors.Length > 1)
                Button2.Content = posColors[1];
            else Button2.Visibility = Visibility.Hidden;
            Button1.Content = posColors[0];
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            _gameWindow.IsEnabled = true;
            Game.Instance.MoveColored(_card, Button1.Content as string);
            Close();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            _gameWindow.IsEnabled = true;
            Game.Instance.MoveColored(_card, Button2.Content as string);
            Close();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            _gameWindow.IsEnabled = true;
            Game.Instance.MoveColored(_card, Button3.Content as string);
            Close();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            _gameWindow.IsEnabled = true;
            Game.Instance.MoveColored(_card, Button4.Content as string);
            Close();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            _gameWindow.IsEnabled = true;
            Game.Instance.MoveColored(_card, Button5.Content as string);
            Close();
        }

        /*private Turtle GetTurtle(string turtleColor)
        {
            if(turtleColor.Equals("czerwony")) return Turtle.Red;
            if(turtleColor.Equals("niebieski")) return Turtle.Blue;
            if(turtleColor.Equals("zielony")) return Turtle.Green;
            return turtleColor.Equals("fioletowy") ? Turtle.Violet : Turtle.Yellow;
        }*/
    }
}
