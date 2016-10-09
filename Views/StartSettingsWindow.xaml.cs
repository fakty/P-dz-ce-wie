using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pędzące_Żółwie.Views
{
    /// <summary>
    /// Interaction logic for StartSettingsWindow.xaml
    /// </summary>
    public partial class StartSettingsWindow
    {
        private int _activePlayersCount;

        public StartSettingsWindow()
        {
            InitializeComponent();
            Cursor = new Cursor(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            new GameWindow(_activePlayersCount).Show();
            Close();
        }

        private void RadioButton_Select(object sender, RoutedEventArgs e)
        {
            var button = (RadioButton) sender;
            _activePlayersCount = int.Parse(button.Content.ToString());
            if (_activePlayersCount < 5)
            {
                Player5Settings.IsEnabled = false;
                Player5Type.IsEnabled = false;
            }
            else
            {
                Player5Settings.IsEnabled = true;
                Player5Type.IsEnabled = true;
            }
            if (_activePlayersCount < 4)
            {
                Player4Settings.IsEnabled = false;
                Player4Type.IsEnabled = false;
            }
            else
            {
                Player4Settings.IsEnabled = true;
                Player4Type.IsEnabled = true;
            }
            if (_activePlayersCount < 3)
            {
                Player3Settings.IsEnabled = false;
                Player3Type.IsEnabled = false;
            }
            else
            {
                Player3Settings.IsEnabled = true;
                Player3Type.IsEnabled = true;
            }
        }
    }
}
