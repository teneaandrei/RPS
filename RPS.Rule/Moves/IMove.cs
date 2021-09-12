using RPS.Model;

namespace RPS.Move.Moves
{
    public interface IMove
    {
        PlayerMove CurrentPlayerMove { get; }
        MatchResult Execute(PlayerMove playerMove);
    } 
}
