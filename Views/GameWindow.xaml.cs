using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Imaging;
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
            PlayerTurtle.Source = ConvertBitmap(Properties.Resources.token);
            CardImage0.Source = ConvertBitmap(Properties.Resources.card);
            Card0.IsEnabled = false;
            CardImage1.Source = ConvertBitmap(Properties.Resources.card);
            Card1.IsEnabled = false;
            CardImage2.Source = ConvertBitmap(Properties.Resources.card);
            Card2.IsEnabled = false;
            CardImage3.Source = ConvertBitmap(Properties.Resources.card);
            Card3.IsEnabled = false;
            CardImage4.Source = ConvertBitmap(Properties.Resources.card);
            Card4.IsEnabled = false;
            EndTurnButton.IsEnabled = false;
            EndTurnButton.Content = "Czekaj...";

            ChangePlayer();
            timer.Tick += (s, e) =>
            {
                ChangePlayer();
                if (!((string) CurrentplayerName.Content).Equals("Gracz 1")) return;
                timer.Stop();
                Cursor = _cursor;
                PlayerTurtle.Source = ConvertBitmap(Properties.Resources.token_red);
                CardImage0.Source = ConvertBitmap(Properties.Resources.card_arrow_2);
                Card0.IsEnabled = true;
                CardImage1.Source = ConvertBitmap(Properties.Resources.card_yellow_minus);
                Card1.IsEnabled = true;
                CardImage2.Source = ConvertBitmap(Properties.Resources.card_violet_plus_2);
                Card2.IsEnabled = true;
                CardImage3.Source = ConvertBitmap(Properties.Resources.card_red_plus);
                Card3.IsEnabled = true;
                CardImage4.Source = ConvertBitmap(Properties.Resources.card_color_plus);
                Card4.IsEnabled = true;
                EndTurnButton.IsEnabled = true;
                EndTurnButton.Content = "Koniec\ntury";
            };

            timer.Start();
        }

        private BitmapSource ConvertBitmap(Bitmap bitmap)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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
