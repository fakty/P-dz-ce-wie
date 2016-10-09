using Pędzące_Żółwie.Models;

namespace Pędzące_Żółwie.Controllers
{
    public class Player
    {
        private readonly Card[] _hand = new Card[5];
        //private readonly Turtle _turtle;

        public Player()
        {
            for (var i = 0; i < 5; i++)
            {
                _hand[i] = Deck.Instance.DrawCard();
            }
        }
    }
}