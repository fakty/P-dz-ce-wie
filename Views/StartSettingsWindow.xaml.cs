using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pędzące_Żółwie.Views;

namespace Pędzące_Żółwie
{
    /// <summary>
    /// Interaction logic for StartSettingsWindow.xaml
    /// </summary>
    public partial class StartSettingsWindow
    {
        private int _activePlayersCount;
        private string[] _playersType;

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
            GetPlayersType();
            new GameWindow(_activePlayersCount, _playersType, (bool)LogBox.IsChecked).Show();
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

        private void GetPlayersType()
        {
            switch (_activePlayersCount)
            {
                case 5:
                    _playersType = new[]
                    {
                        Player1Type.Items[Player1Type.SelectedIndex].ToString(),
                        Player2Type.Items[Player2Type.SelectedIndex].ToString(),
                        Player3Type.Items[Player3Type.SelectedIndex].ToString(),
                        Player4Type.Items[Player4Type.SelectedIndex].ToString(),
                        Player5Type.Items[Player5Type.SelectedIndex].ToString(),
                    };
                    break;
                case 4:
                    _playersType = new[]
                    {
                        Player1Type.Items[Player1Type.SelectedIndex].ToString(),
                        Player2Type.Items[Player2Type.SelectedIndex].ToString(),
                        Player3Type.Items[Player3Type.SelectedIndex].ToString(),
                        Player4Type.Items[Player4Type.SelectedIndex].ToString()
                    };
                    break;
                case 3:
                    _playersType = new[]
                    {
                        Player1Type.Items[Player1Type.SelectedIndex].ToString(),
                        Player2Type.Items[Player2Type.SelectedIndex].ToString(),
                        Player3Type.Items[Player3Type.SelectedIndex].ToString()
                    };
                    break;
                default:
                    _playersType = new[]
                    {
                        Player1Type.Items[Player1Type.SelectedIndex].ToString(),
                        Player2Type.Items[Player2Type.SelectedIndex].ToString()
                    };
                    break;
            }
        }
    }
}