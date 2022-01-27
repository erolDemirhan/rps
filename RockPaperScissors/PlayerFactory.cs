using RockPaperScissors.Interfaces;

namespace RockPaperScissors
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayers CreatePlayers() =>
            new Players(new Player("Player 1"), new Player("Player 2)"));
    }
}
