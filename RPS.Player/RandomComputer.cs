using RPS.Model;
using RPS.Move.Moves;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RPS.Player
{
    public class RandomComputer : IPlayer
    {
        [DisplayName("Random computer")]
        public PlayerType PlayerType => PlayerType.RandomComputer;

        public PlayerMove DoMove(List<IMove> moves)
        {
            Console.WriteLine($"Opponent's turn.");

            Random rnd = new Random();
            return (PlayerMove)rnd.Next(1, moves.Count + 1);
        }
    }
}
