using System.IO;
using System.Windows.Input;

namespace Pędzące_Żółwie
{
    /// <summary>
    /// Logika interakcji dla klasy EndGamePrompt.xaml
    /// </summary>
    public partial class EndGamePrompt
    {
        public EndGamePrompt()
        {
            InitializeComponent();
            Cursor = new Cursor(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));
        }
    }
}
