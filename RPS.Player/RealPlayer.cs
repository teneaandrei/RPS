using RPS.Model;
using RPS.Move.Moves;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RPS.Player
{
    public class RealPlayer : IPlayer
    {
        [DisplayName("Real player")]
        public PlayerType PlayerType => PlayerType.RealPlayer;

        public PlayerMove DoMove(List<IMove> moves)
        {
			Console.WriteLine($"Select your move (type the move number): ");
			for (int i = 0; i < moves.Count; i++)
			{
				Console.WriteLine($"{i + 1}: {moves[i].CurrentPlayerMove}");
			}

			string playerResponse = Console.ReadLine();
			int moveNo = -1;
			int.TryParse(playerResponse, out moveNo);

			while (moveNo - 1 == -1 || moveNo - 1 > moves.Count - 1)
			{
				Console.WriteLine("Please select a correct number!");
				playerResponse = Console.ReadLine();
				int.TryParse(playerResponse, out moveNo);
			}

			return moves[moveNo - 1].CurrentPlayerMove;
		}
    }
}
