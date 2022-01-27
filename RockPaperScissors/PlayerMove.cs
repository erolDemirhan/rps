using RockPaperScissors.Interfaces;

namespace RockPaperScissors
{
    public class PlayerMove : IPlayerMove
    {
        public IPlayer Player { get; }
        public Move Move { get; }

        public PlayerMove(IPlayer player, Move move)
        {
            Player = player;
            Move = move;
        }

    }
}
