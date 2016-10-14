using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Pędzące_Żółwie.Views;

namespace Pędzące_Żółwie
{
    /// <summary>
    /// Logika interakcji dla klasy EndGamePrompt.xaml
    /// </summary>
    public partial class EndGamePrompt
    {
        public EndGamePrompt(GameWindow gameWindow, bool isWinner, int[] winPlayers = null)
        {
            InitializeComponent();
            Cursor = new Cursor(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources\\green.cur"));
        }
    }
}
