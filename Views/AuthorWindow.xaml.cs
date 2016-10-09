using System.IO;
using System.Windows.Input;

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
            Cursor = new Cursor(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
