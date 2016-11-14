using System;
using Pędzące_Żółwie.Models;

namespace Pędzące_Żółwie.Controllers
{
    class Algorithms
    {
        private static Algorithms _instance;
        private readonly Random _random;

        private Algorithms()
        {
            _random = new Random();
        }

        public static Algorithms Instance => _instance ?? (_instance = new Algorithms());

        public int EvaluateStrategy(Player player)
        {
            return _random.Next(5);
        }

        public int EvaluateStrategyColor(string strategy, Card card, string[] colors)
        {
            return _random.Next(colors.Length);
        }
    }
}
