using RockPaperScissors.Interfaces;

namespace RockPaperScissors
{
    public class Result : IResult
    {
        public ResultType ResultType { get; }
        public IPlayerMove WinningMove { get; }

        public Result(ResultType resultType, IPlayerMove winningMove)
        {
            ResultType = resultType;
            WinningMove = winningMove;
        }

    }
}
