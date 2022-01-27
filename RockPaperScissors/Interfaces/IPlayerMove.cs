namespace RockPaperScissors.Interfaces
{
    public interface IPlayerMove
    {
        IPlayer Player { get; }
        Move Move { get; }
    }
}
