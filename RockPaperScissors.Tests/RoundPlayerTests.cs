using System;
using FluentAssertions;
using Xunit;

namespace RockPaperScissors.Tests
{
    public class RoundPlayerTests
    {
        private RoundPlayer roundPlayer;
        private Player p1;
        private Player p2;
        private Players players;

        public RoundPlayerTests()
        {
            roundPlayer = new RoundPlayer();
            p1 = new Player("Test P1");
            p2 = new Player("Test P2");
            players = new Players(p1, p2);
        }

        [Fact]
        public void PlayMoves()
        {
            var result = roundPlayer.PlayMoves(players);
            result.Player1Move.Player.Should().Be(p1);
            result.Player2Move.Player.Should().Be(p2);
            result.Player1Move.Move.Should().NotBe(null);
            result.Player2Move.Move.Should().NotBe(null);
        }
    }
}
