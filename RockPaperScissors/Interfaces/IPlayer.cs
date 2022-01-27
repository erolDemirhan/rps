namespace RockPaperScissors.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        Move Play();
    }
}
