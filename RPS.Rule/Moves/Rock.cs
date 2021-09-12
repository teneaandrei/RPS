using RPS.Model;

namespace RPS.Move.Moves
{
    public class Rock : IMove
    {
        public PlayerMove CurrentPlayerMove => PlayerMove.Rock;
        public MatchResult Execute(PlayerMove playerMove)
        {
            switch (playerMove)
            {
                case PlayerMove.Scissors:
                    return MatchResult.Win;
                case PlayerMove.Paper:
                    return MatchResult.Lose;
                default:
                    return MatchResult.Draw;
            }
        }
    }
}
