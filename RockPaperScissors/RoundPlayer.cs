using RockPaperScissors.Interfaces;

namespace RockPaperScissors
{
    public class RoundPlayer : IRoundPlayer
    {
        public IPlayerMoves PlayMoves(IPlayers players)
        {
            var p1Move = players.Player1.Play();
            var p2Move = players.Player2.Play();
            return new PlayerMoves(
                new PlayerMove(players.Player1, p1Move),
                new PlayerMove(players.Player2, p2Move));
        }
    }
}
