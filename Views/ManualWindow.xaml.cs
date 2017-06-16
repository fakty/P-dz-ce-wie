using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace TurtleRace.Views
{
    /// <summary>
    /// Logika interakcji dla klasy OptionWindow.xaml
    /// </summary>
    public partial class ManualWindow
    {
        private readonly BitmapSource _manual01;
        private readonly BitmapSource _manual02;
        private bool _fromGame;

        public ManualWindow(bool fromGame)
        {
            _fromGame = fromGame;
            InitializeComponent();
            Cursor = new Cursor(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));
            _manual01 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.manual01.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            _manual02 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.manual02.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            PreviousButton.Visibility = Visibility.Hidden;
            ConfirmButton.Visibility = Visibility.Hidden;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            PreviousButton.Visibility = Visibility.Visible;
            NextButton.Visibility = Visibility.Hidden;
            ConfirmButton.Visibility = Visibility.Visible;
            ManualView.Source = _manual02;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(!_fromGame) new MainWindow().Show();
            Close();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            PreviousButton.Visibility = Visibility.Hidden;
            NextButton.Visibility = Visibility.Visible;
            ConfirmButton.Visibility = Visibility.Hidden;
            ManualView.Source = _manual01;
        }
    }
}
