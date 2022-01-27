using Xunit;
using RockPaperScissors.Interfaces;
using Moq;

namespace RockPaperScissors.Tests
{
    public class GameTests
    {
        private readonly Player player1;
        private readonly Player player2;
        private readonly Players players;
        private readonly PlayerMoves playerMoves;
        private readonly PlayerMove p1Rock;
        private readonly PlayerMove p2Scissors;
        private readonly Game game;
        private readonly Result result;

        private readonly Mock<IOutput> outputMock;
        private readonly Mock<IPlayerFactory> playerFactoryMock;
        private readonly Mock<IPlayerMoves> movesMock;
        private readonly Mock<IRoundPlayer> roundPlayerMock;
        private readonly Mock<IWinCalculator> winCalculatorMock;

        public GameTests()
        {
            player1 = new Player("TestP1");
            player2 = new Player("TestP2");
            players = new Players(player1, player2);
            p1Rock = new PlayerMove(player1,Move.Rock);
            p2Scissors = new PlayerMove(player2, Move.Scissors);
            playerMoves = new PlayerMoves(p1Rock, p2Scissors);
            result = new Result(ResultType.Win, playerMoves.Player1Move);

            outputMock = new Mock<IOutput>();
            playerFactoryMock = new Mock<IPlayerFactory>();
            roundPlayerMock = new Mock<IRoundPlayer>();
            winCalculatorMock = new Mock<IWinCalculator>();
            movesMock = new Mock<IPlayerMoves>();

            playerFactoryMock.Setup(x => x.CreatePlayers()).Returns(players);
            winCalculatorMock.Setup(x => x.CalculateWInner(It.IsAny<IPlayerMoves>()))
                .Returns(result);
            roundPlayerMock.Setup(x => x.PlayMoves(players)).Returns(movesMock.Object);
            roundPlayerMock.Setup(x => x.PlayMoves(players)).Returns(playerMoves);

            game = new Game(outputMock.Object, playerFactoryMock.Object,
    roundPlayerMock.Object, winCalculatorMock.Object);
            game.Play();
        }

        [Fact]
        public void ClearsConsoleBeforePlay()
        {
            outputMock.Verify(x => x.Clear(), Times.AtLeastOnce);
        }

        [Fact]
        public void WritesTitle()
        {
            outputMock.Verify(x => x.WriteTitle(Constants.Title), Times.Once);
        }

        [Fact]
        public void WritesHorizontalLine()
        {
            outputMock.Verify(x => x.WriteHorizontalLine(), Times.AtLeastOnce);
        }

        [Fact]
        public void CreatesPlayers()
        {
            playerFactoryMock.Verify(x => x.CreatePlayers(), Times.Once);
        }

        [Fact]
        public void PlaysNMoves()
        {
            roundPlayerMock.Verify(x => x.PlayMoves(players),
                Times.Exactly(Constants.NumberOfRounds));
        }

        [Fact]
        public void CalculateRoundWinner()
        {
            winCalculatorMock.Verify(x => x.CalculateWInner(It.IsAny<IPlayerMoves>())
            , Times.Exactly(Constants.NumberOfRounds));
        }
    }
}
