using FluentAssertions;
using RockPaperScissors.Interfaces;
using Xunit;

namespace RockPaperScissors.Tests
{
    public class WinCalculatorTests
    {
        private readonly WinCalculator winCalculator;
        private readonly Player player1;
        private readonly Player player2;

        public WinCalculatorTests()
        {
            winCalculator = new WinCalculator();
            player1 = new Player("Test P1");
            player2 = new Player("Test P2");
        }

        [Theory]
        [InlineData(Move.Rock, Move.Scissors)]
        [InlineData(Move.Paper, Move.Rock)]
        [InlineData(Move.Scissors, Move.Paper)]
        public void XBeatsY(Move winningMove, Move losingMove)
        {
            var p1Move = new PlayerMove(player1, winningMove);
            var p2Move = new PlayerMove(player2, losingMove);
            var moves = new PlayerMoves(p1Move, p2Move);
            var result = winCalculator.CalculateWInner(moves);
            result.ResultType.Should().Be(ResultType.Win);
            result.WinningMove.Should().Be(p1Move);
        }

        [Theory]
        [InlineData(Move.Rock)]
        [InlineData(Move.Paper)]
        [InlineData(Move.Scissors)]
        public void EqualMovesDraw(Move move)
        {
            var p1move = new PlayerMove(player1, move);
            var p2move = new PlayerMove(player2, move);
            var moves = new PlayerMoves(p1move, p2move);
            var result = winCalculator.CalculateWInner(moves);
            result.ResultType.Should().Be(ResultType.Draw);
            result.WinningMove.Should().BeNull();
        }
    }
}
