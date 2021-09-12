using RPS.Model;
using RPS.Move.Moves;
using System.Collections.Generic;

namespace RPS.Player
{
    public interface IPlayer
    {
        PlayerType PlayerType { get; }
        PlayerMove DoMove(List<IMove> moves);
    }
}
