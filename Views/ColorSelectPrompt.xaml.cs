using System.Windows;
using System.Windows.Media.Imaging;
using Pędzące_Żółwie.Views;

namespace Pędzące_Żółwie
{
    /// <summary>
    /// Logika interakcji dla klasy ColorSelectPrompt.xaml
    /// </summary>
    public partial class ColorSelectPrompt
    {
        private readonly GameWindow _gameWindow;
        public ColorSelectPrompt(BitmapSource source, string[] posColors, GameWindow gameWindow)
        {
            _gameWindow = gameWindow;
            _gameWindow.IsEnabled = false;
            InitializeComponent();
            Image.Source = source;
            if (posColors.Length > 4)
                Button5.Content = posColors[4];
            else Button5.Visibility = Visibility.Hidden;
            if (posColors.Length > 3)
                Button4.Content = posColors[3];
            else Button4.Visibility = Visibility.Hidden;
            if (posColors.Length > 2)
                Button3.Content = posColors[2];
            else Button3.Visibility = Visibility.Hidden;
            Button2.Content = posColors[1];
            Button1.Content = posColors[0];
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            _gameWindow.IsEnabled = true;
            Close();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            _gameWindow.IsEnabled = true;
            Close();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            _gameWindow.IsEnabled = true;
            Close();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            _gameWindow.IsEnabled = true;
            Close();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            _gameWindow.IsEnabled = true;
            Close();
        }

    }
}
