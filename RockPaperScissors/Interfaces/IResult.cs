namespace RockPaperScissors.Interfaces
{
    public interface IResult
    {
        ResultType ResultType {get;}
        IPlayerMove WinningMove { get; }
    }
}
