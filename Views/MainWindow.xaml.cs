using System.Windows;

namespace Pędzące_Żółwie.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new GameWindow();
            window.Show();
            Close();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new OptionWindow();
            window.Show();
            Close();
        }

        private void AuthorButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AuthorWindow();
            window.Show();
            Close();
        }
    }
}
