namespace Pędzące_Żółwie.Controllers
{
    public class Game
    {
        private static Game _instance;

        private Game()
        {
            
        }

        public static Game Instance => _instance ?? (_instance = new Game());


    }
}