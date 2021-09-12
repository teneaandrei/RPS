using RPS.Model;

namespace RPS.Move.Moves
{
    public class Scissors : IMove
    {
        public PlayerMove CurrentPlayerMove => PlayerMove.Scissors;

        public MatchResult Execute(PlayerMove playerMove)
        {
            switch (playerMove)
            {
                case PlayerMove.Paper:
                    return MatchResult.Win;
                case PlayerMove.Rock:
                    return MatchResult.Lose;
                default:
                    return MatchResult.Draw;
            }
        }
    }
}
