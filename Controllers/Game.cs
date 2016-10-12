using System;
using System.Collections;
using Pędzące_Żółwie.Models;
using Pędzące_Żółwie.Views;

namespace Pędzące_Żółwie.Controllers
{
    public class Game
    {
        private static Game _instance;
        //private readonly Deck _deck;

        public int PlayersCount = 2;
        public GameWindow MainWindow { get; set; }
        public Player[] Players { get; set; }

        //public int[][] Board;

        private Game()
        {
            //_deck = Deck.Instance;
            /*Board = new int[10][];
            for(var i = 0; i < Board.Length; i++) { 
                Board[i] = new int[5];*/
        }

        public static Game Instance => _instance ?? (_instance = new Game());

        public void AddPlayers()
        {
            Players = new Player[PlayersCount];
            var turtles = new ArrayList { Turtle.Blue, Turtle.Green, Turtle.Red, Turtle.Violet, Turtle.Yellow };
            var count = PlayersCount;
            var random = new Random();
            for (var i = 0; i < Players.Length; i++)
            {
                Players[i] = new Player((Turtle)turtles[random.Next(count)]);
                turtles.Remove(Players[i].PlayerTurtle);
                count--;
            }
        }
    }
}