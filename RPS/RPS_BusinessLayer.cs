using RPS.Game;
using RPS.Move.Moves;
using RPS.Player;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPS
{
    public class RPS_BusinessLayer
    {
        private List<IPlayer> _players;
        private List<IMove> _moves;
        private List<IGameType> _gameTypes;

        public RPS_BusinessLayer()
        {
            _players = GetPlayers();
            _moves = GetMoves();
            _gameTypes = GetGameTypes();
        }

        public void Run()
        {
            var gameType = SelectMatch();
            var opponent = SelectOpponent();
            var humanPlayerWinsNr = 0;
            var gamesRequiredToWin = (gameType.MaxNumberOfGames + 1) / 2;
            var realPlayer = _players.FirstOrDefault(p => p.PlayerType == Model.PlayerType.RealPlayer);

            Console.WriteLine("\nStart game!");

            for (int i = 0; i < gameType.MaxNumberOfGames; i++)
            {
                Console.WriteLine($"\nRound {i + 1} \n");

                
                if (IsFirstPlayerWinner(opponent, realPlayer))
                {
                    humanPlayerWinsNr++;
                }

                Console.WriteLine($"Player1 - Player2: {humanPlayerWinsNr} - {i + 1 - humanPlayerWinsNr} \n");

                if (IsHumanPlayerWinner(humanPlayerWinsNr, i, gamesRequiredToWin))
                {
                    Console.WriteLine("Player 1 has won the match! \n");
                    break;
                }
                else if (IsOpositePlayerWinner(humanPlayerWinsNr, i, gamesRequiredToWin))
                {
                    Console.WriteLine("Player 2 has won the match! \n");
                    break;
                }
            }
        }

        private bool IsHumanPlayerWinner(int humanPlayerWinsNr, int i, int gamesRequiredToWin)
        {
            return humanPlayerWinsNr == gamesRequiredToWin;
        }

        private bool IsOpositePlayerWinner(int humanPlayerWinsNr, int gameNumber, int gamesRequiredToWin)
        {
            return gameNumber - humanPlayerWinsNr == gamesRequiredToWin;
        }

        private bool IsFirstPlayerWinner(IPlayer opponent, IPlayer realPlayer)
        {
            var humanPlayerChoice = realPlayer.DoMove(_moves);
            var humanPlayerMove = _moves.FirstOrDefault(x => x.CurrentPlayerMove == humanPlayerChoice);
            var opponentMove = opponent.DoMove(_moves);

            Console.WriteLine("\n");
            Console.WriteLine("Let's see the moves!");
            Console.WriteLine($"Player 1: {humanPlayerMove.CurrentPlayerMove}");
            Console.WriteLine($"Player 2: {opponentMove}");
            Console.WriteLine("\n");

            var matchResult = humanPlayerMove.Execute(opponentMove);
            if (matchResult == Model.MatchResult.Win)
            {
                Console.WriteLine($"Player 1 won this round");
                return true;
            }
            else if (matchResult == Model.MatchResult.Draw)
            {
                Console.WriteLine($"It's a draw. This round will be played again.");
                return IsFirstPlayerWinner(opponent, realPlayer);
            }
            else
            {
                Console.WriteLine($"Player 2 won this round");
                return false;
            }
        }

        private IGameType SelectMatch()
        {
            Console.WriteLine($"\nSelect your match (type the match number): ");
            for (int i = 0; i < _gameTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Number of games {_gameTypes[i].MaxNumberOfGames}");
            }

            string playerResponse = Console.ReadLine();
            int matchNo = -1;
            int.TryParse(playerResponse, out matchNo);

            while (matchNo - 1 == -1 || matchNo - 1 > _gameTypes.Count - 1)
            {
                Console.WriteLine("Please select a correct number!");
                playerResponse = Console.ReadLine();
                int.TryParse(playerResponse, out matchNo);
            }

            return _gameTypes[matchNo - 1];
        }

        private IPlayer SelectOpponent()
        {
            Console.WriteLine($"\nSelect your oponent (type the oponent number): ");
            for (int i = 0; i < _players.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {_players[i].PlayerType}");
            }

            string playerResponse = Console.ReadLine();
            int opponentNo;
            int.TryParse(playerResponse, out opponentNo);

            while (opponentNo == 0 || opponentNo > _players.Count)
            {
                Console.WriteLine($"Please select a number between 1 and {_players.Count}!");
                playerResponse = Console.ReadLine();
                int.TryParse(playerResponse, out opponentNo);
            }

            return _players[opponentNo - 1];
        }

        private List<IPlayer> GetPlayers()
        {
            return Factory.GenericFactory<IPlayer>.GetInstancesOfType();
        }

        private List<IMove> GetMoves()
        {
            return Factory.GenericFactory<IMove>.GetInstancesOfType();
        }

        private List<IGameType> GetGameTypes()
        {
            return Factory.GenericFactory<IGameType>.GetInstancesOfType();
        }
    }
}
