namespace Pędzące_Żółwie.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AuthorWindow.xaml
    /// </summary>
    public partial class AuthorWindow
    {
        public AuthorWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
