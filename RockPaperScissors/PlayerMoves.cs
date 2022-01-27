using RockPaperScissors.Interfaces;

namespace RockPaperScissors
{
    public class PlayerMoves : IPlayerMoves
    {
        public IPlayerMove Player1Move { get; }

        public IPlayerMove Player2Move { get; }

        public PlayerMoves(IPlayerMove player1Move, IPlayerMove player2Move)
        {
            Player1Move = player1Move;
            Player2Move = player2Move;
        }
    }
}
