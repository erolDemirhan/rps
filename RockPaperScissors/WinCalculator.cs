using RockPaperScissors.Interfaces;

namespace RockPaperScissors
{
    public class WinCalculator : IWinCalculator
    {
        public IResult CalculateWInner(IPlayerMoves moves)
        {
            if(moves.Player1Move.Move == moves.Player2Move.Move)
            {
                return new Result(ResultType.Draw, null);
            }

            switch (moves.Player1Move.Move)
            {
                case Move.Rock:
                    return moves.Player2Move.Move == Move.Scissors
                        ? new Result(ResultType.Win, moves.Player1Move)
                        : new Result(ResultType.Win, moves.Player2Move);
                case Move.Paper:
                    return moves.Player2Move.Move == Move.Rock
                        ? new Result(ResultType.Win, moves.Player1Move)
                        : new Result(ResultType.Win, moves.Player2Move);
                case Move.Scissors:
                    return moves.Player2Move.Move == Move.Paper
                        ? new Result(ResultType.Win, moves.Player1Move)
                        : new Result(ResultType.Win, moves.Player2Move);
                default: throw new System.Exception();
            }
        }
    }
}
