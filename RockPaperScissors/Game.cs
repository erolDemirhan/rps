using System.Linq;
using RockPaperScissors.Interfaces;

namespace RockPaperScissors
{
    public class Game : IGame
    {
        private readonly IOutput output;
        private readonly IPlayerFactory playerFactory;
        private readonly IRoundPlayer roundPlayer;
        private readonly IWinCalculator winCalculator;

        public Game(IOutput output, IPlayerFactory playerFactory,
            IRoundPlayer roundPlayer, IWinCalculator winCalculator)
        {
            this.output = output;
            this.playerFactory = playerFactory;
            this.roundPlayer = roundPlayer;
            this.winCalculator = winCalculator;
        }

        public void Play()
        {
            output.Clear();
            output.WriteTitle(Constants.Title);
            output.WriteLine($"Playing {Constants.NumberOfRounds} Rounds...");
            output.WriteHorizontalLine();
            var players = playerFactory.CreatePlayers();

            foreach (var _ in Enumerable.Range(1, Constants.NumberOfRounds))
            {
                var moves = roundPlayer.PlayMoves(players);
                var winner = winCalculator.CalculateWInner(moves);
                output.WriteLine($"{players.Player1.Name} plays {moves.Player1Move.Move}");
                output.WriteLine($"{players.Player2.Name} plays {moves.Player2Move.Move}");
                switch (winner.ResultType)
                {
                    case ResultType.Win:
                        output.WriteLine($"{winner.WinningMove.Player.Name} wins");
                        break;
                    case ResultType.Draw:
                        output.WriteLine(Constants.NoWinner);
                        break;
                }
                output.WriteHorizontalLine();
            }

        }
    }
}
