namespace RockPaperScissors.Interfaces
{
    public interface IWinCalculator
    {
        IResult CalculateWInner(IPlayerMoves moves);
    }
}
