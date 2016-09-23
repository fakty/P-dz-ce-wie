using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Pędzące_Żółwie.Views
{
    /// <summary>
    /// Logika interakcji dla klasy GameWindow.xaml
    /// </summary>
    public partial class GameWindow
    {
        private readonly int _playersCount;

        public GameWindow(int playersCount)
        {
            InitializeComponent();
            Cursor = new Cursor(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));

            _playersCount = playersCount;
            if (_playersCount < 5)
                Queue4.Visibility = Visibility.Hidden;
            if (_playersCount < 4)
                Queue3.Visibility = Visibility.Hidden;
            if(_playersCount < 3)
                Queue2.Visibility = Visibility.Hidden;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
