using System.IO;
using System.Windows;
using System.Windows.Input;

namespace TurtleRace.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Cursor = new Cursor(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            new StartSettingsWindow().Show();
            Close();
        }

        /*private void ManualButton_Click(object sender, RoutedEventArgs e)
        {
            new ManualWindow(false).Show();
            Close();
        }*/

        private void AuthorButton_Click(object sender, RoutedEventArgs e)
        {
            new AuthorWindow().Show();
            Close();
        }
    }
}
