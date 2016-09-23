using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;

namespace Pędzące_Żółwie.Views
{
    /// <summary>
    /// Logika interakcji dla klasy GameWindow.xaml
    /// </summary>
    public partial class GameWindow
    {
        private readonly Cursor _cursor;
        private readonly Cursor _waitCursor;

        private readonly int _playersCount;

        public GameWindow(int playersCount)
        {
            InitializeComponent();
            _cursor = new Cursor(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));
            _waitCursor = new Cursor(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\green_busy.cur"));

            Cursor = _cursor;

            _playersCount = playersCount;

            var temp = new int[playersCount];
            var rnd = new Random();
            int curr;
            for (var i = 0; i < playersCount; i++)
                temp[i] = i + 1;
            var array = new ArrayList(temp);
            playersCount--;
            CurrentplayerName.Content = "Gracz " + array[curr = rnd.Next(0, playersCount)];
            array.RemoveAt(curr);
            playersCount--;
            Queue1.Content = "Gracz " + array[curr = rnd.Next(0, playersCount)];
            array.RemoveAt(curr);
            playersCount--;

            if (_playersCount < 3)
            {
                Queue2.Visibility = Visibility.Hidden;
            }
            else
            {
                Queue2.Content = "Gracz " + array[curr = rnd.Next(0, playersCount)];
                array.RemoveAt(curr);
                playersCount--;
            }
            if (_playersCount < 4)
            {
                Queue3.Visibility = Visibility.Hidden;
            }
            else
            {
                Queue3.Content = "Gracz " + array[curr = rnd.Next(0, playersCount)];
                array.RemoveAt(curr);
            }
            if (_playersCount < 5)
            {
                Queue4.Visibility = Visibility.Hidden;
            }
            else
            {
                Queue4.Content = "Gracz " + array[0];
            }

            VisualStateManager.GoToState(EndTurnButton, "Released", true);
            EndTurnButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void EndTurnButton_Click(object sender, RoutedEventArgs re)
        {
            Cursor = _waitCursor;
            var timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(2)};
            Card0.IsEnabled = false;
            Card1.IsEnabled = false;
            Card2.IsEnabled = false;
            Card3.IsEnabled = false;
            Card4.IsEnabled = false;
            EndTurnButton.IsEnabled = false;
            EndTurnButton.Content = "Czekaj...";

            timer.Tick += (s, e) =>
            {
                ChangePlayer();
                if (!((string) CurrentplayerName.Content).Equals("Gracz 1")) return;
                timer.Stop();
                Cursor = _cursor;
                Card0.IsEnabled = true;
                Card1.IsEnabled = true;
                Card2.IsEnabled = true;
                Card3.IsEnabled = true;
                Card4.IsEnabled = true;
                EndTurnButton.IsEnabled = true;
                EndTurnButton.Content = "Koniec\ntury";
            };

            timer.Start();
        }

        private void ChangePlayer()
        {
            var second = Queue1.Content;
            if (_playersCount > 2)
            {
                Queue1.Content = Queue2.Content;
                if (_playersCount > 3)
                {
                    Queue2.Content = Queue3.Content;
                    if (_playersCount > 4)
                    {
                        Queue3.Content = Queue4.Content;
                        Queue4.Content = CurrentplayerName.Content;
                        CurrentplayerName.Content = second;
                    }
                    else
                    {
                        Queue3.Content = CurrentplayerName.Content;
                        CurrentplayerName.Content = second;
                    }
                }
                else
                {
                    Queue2.Content = CurrentplayerName.Content;
                    CurrentplayerName.Content = second;
                }
            }
            else
            {
                Queue1.Content = CurrentplayerName.Content;
                CurrentplayerName.Content = second;
            }
        }
    }
}
