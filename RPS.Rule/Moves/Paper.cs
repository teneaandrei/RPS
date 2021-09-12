using RPS.Model;

namespace RPS.Move.Moves
{
    public class Paper : IMove
    {
        public PlayerMove CurrentPlayerMove => PlayerMove.Paper;
        public MatchResult Execute(PlayerMove playerMove)
        {
            switch (playerMove)
            {
                case PlayerMove.Rock:
                    return MatchResult.Win;
                case PlayerMove.Scissors:
                    return MatchResult.Lose;
                default:
                    return MatchResult.Draw;
            }
        }
    }
}
