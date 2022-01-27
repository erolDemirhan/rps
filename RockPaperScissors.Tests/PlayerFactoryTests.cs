using FluentAssertions;
using Xunit;

namespace RockPaperScissors.Tests
{
    public class PlayerFactoryTests
    {
        private PlayerFactory playerFactory;

        public PlayerFactoryTests()
        {
            playerFactory = new PlayerFactory();
        }

        [Fact]
        public void CreatePlayers()
        {
            var result = playerFactory.CreatePlayers();
            result.Player1.Should().NotBeNull();
            result.Player2.Should().NotBeNull();
            result.Player1.Name.Should().NotBeNullOrWhiteSpace();
            result.Player1.Name.Should().NotBeNullOrWhiteSpace();
        }
    }
}
