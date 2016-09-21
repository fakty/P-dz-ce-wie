namespace Pędzące_Żółwie.Views
{
    /// <summary>
    /// Logika interakcji dla klasy OptionWindow.xaml
    /// </summary>
    public partial class OptionWindow
    {
        public OptionWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            Close();
        }

        private void ConfirmButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
