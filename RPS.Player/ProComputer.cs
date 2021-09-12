using RPS.Model;
using RPS.Move.Moves;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RPS.Player
{
    public class ProComputer : IPlayer
    {
        [DisplayName("Pro computer")]
        public PlayerType PlayerType => PlayerType.ProComputer;

        private PlayerMove? _previousMove = null;

        public PlayerMove DoMove(List<IMove> moves)
        {
            if(_previousMove == null)
            {
                _previousMove = (PlayerMove)new Random().Next(1, moves.Count + 1);
                return (PlayerMove)_previousMove;
            }

            foreach(var move in moves)
            {
                if(move.Execute(_previousMove.Value) == MatchResult.Win)
                {
                    _previousMove = move.CurrentPlayerMove;
                }
            }

            return _previousMove.Value;
        }
    }
}
