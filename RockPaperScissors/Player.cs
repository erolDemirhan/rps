using System;
using RockPaperScissors.Interfaces;

namespace RockPaperScissors
{
    public class Player : IPlayer
    {
        private readonly Random rnd = new Random();
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        public Move Play()
        {
            var moves = Enum.GetValues(typeof(Move));
            return (Move)moves.GetValue(rnd.Next(moves.Length));
        }
    }
}
