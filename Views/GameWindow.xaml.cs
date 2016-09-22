using System.IO;
using System.Windows.Input;

namespace Pędzące_Żółwie.Views
{
    /// <summary>
    /// Logika interakcji dla klasy GameWindow.xaml
    /// </summary>
    public partial class GameWindow
    {
        public GameWindow()
        {
            InitializeComponent();
            Cursor = new Cursor(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));
        }
    }
}
