using Tennis.Core.Models;
using Xunit;

namespace Tennis.Tests.GamesTests
{
    public class StandardGameTests
    {
        private readonly Player player1;
        private readonly Player player2;
        private readonly StandardGame game;

        public StandardGameTests()
        {
            player1 = new Player("Player1");
            player2 = new Player("Player2");
            game = new StandardGame(player1, player2);
        }

        [Fact]
        public void Player1ScoresOnePointScoreIs15_0()
        {
            TestsHelper.AddPointsToPlayer(1, game.AddPointForPlayer1);

            Assert.Equal(1, player1.GetScore());
            Assert.Equal($"{player1.Name} 15 - 0 {player2.Name}", game.GetScore());
        }

        [Fact]
        public void Player1ScoresTwoPointscoreIs30_0()
        {
            TestsHelper.AddPointsToPlayer(2, game.AddPointForPlayer1);

            Assert.Equal(2, player1.GetScore());
            Assert.Equal($"{player1.Name} 30 - 0 {player2.Name}", game.GetScore());
        }

        [Fact]
        public void Player1ScoresThreePointscoreIs40_0()
        {
            TestsHelper.AddPointsToPlayer(3, game.AddPointForPlayer1);

            Assert.Equal(3, player1.GetScore());
            Assert.Equal($"{player1.Name} 40 - 0 {player2.Name}", game.GetScore());
        }

        [Fact]
        public void Player1ScoresFourPointWinsTheGame()
        {
            TestsHelper.AddPointsToPlayer(4, game.AddPointForPlayer1);

            Assert.Equal(player1, game.Winner);
        }

        [Fact]
        public void BothPlayesScoresOnePointScoreIs15_15()
        {
            TestsHelper.AddPointsToPlayer(1, game.AddPointForPlayer1);
            TestsHelper.AddPointsToPlayer(1, game.AddPointForPlayer2);

            Assert.Equal(1, player1.GetScore());
            Assert.Equal(1, player2.GetScore());
            Assert.Equal($"{player1.Name} 15 - 15 {player2.Name}", game.GetScore());
        }

        [Fact]
        public void Player1ScoresOnePointAndPlayer2Scores2PointsScoreIs15_30()
        {
            TestsHelper.AddPointsToPlayer(1, game.AddPointForPlayer1);
            TestsHelper.AddPointsToPlayer(2, game.AddPointForPlayer2);

            Assert.Equal(1, player1.GetScore());
            Assert.Equal(2, player2.GetScore());
            Assert.Equal($"{player1.Name} 15 - 30 {player2.Name}", game.GetScore());
        }

        [Fact]
        public void BothPlayesScoresThreePointsScoreIsDeuce()
        {
            TestsHelper.AddPointsToPlayer(3, game.AddPointForPlayer1);
            TestsHelper.AddPointsToPlayer(3, game.AddPointForPlayer2);

            Assert.Equal(3, player1.GetScore());
            Assert.Equal(3, player2.GetScore());
            Assert.Equal($"{player1.Name} DEUCE {player2.Name}", game.GetScore());
        }

        [Fact]
        public void Player1WinsFourPointsAndPlayer2WinsThreePointsScoreIsAdvantagePlayer1()
        {
            TestsHelper.AddPointsToPlayer(3, game.AddPointForPlayer1);
            TestsHelper.AddPointsToPlayer(3, game.AddPointForPlayer2);
            TestsHelper.AddPointsToPlayer(1, game.AddPointForPlayer1);

            Assert.Equal(4, player1.GetScore());
            Assert.Equal(3, player2.GetScore());
            Assert.Equal($"{player1.Name} Adv. - - {player2.Name}", game.GetScore());
        }

        [Fact]
        public void OnePlayerHasAdvantageAndWinsNextPointThenWinsTheGame()
        {
            TestsHelper.AddPointsToPlayer(2, game.AddPointForPlayer1);
            TestsHelper.AddPointsToPlayer(3, game.AddPointForPlayer2);
            TestsHelper.AddPointsToPlayer(3, game.AddPointForPlayer1);

            Assert.Equal(player1, game.Winner);
        }

        [Fact]
        public void OnePlayeHasAdvantageAndOponentWinsNextPointScoreIsDeuce()
        {
            TestsHelper.AddPointsToPlayer(2, game.AddPointForPlayer1);
            TestsHelper.AddPointsToPlayer(3, game.AddPointForPlayer2); 
            TestsHelper.AddPointsToPlayer(2, game.AddPointForPlayer1);
            TestsHelper.AddPointsToPlayer(1, game.AddPointForPlayer2);

            Assert.Equal(4, player1.GetScore());
            Assert.Equal(4, player2.GetScore());
            Assert.Equal($"{player1.Name} DEUCE {player2.Name}", game.GetScore());
        }

        [Fact]
        public void IfPlayerWinsGameNewGameIsAddedToScore()
        {
            TestsHelper.AddPointsToPlayer(4, game.AddPointForPlayer1);

            Assert.Equal(1, player1.GetGames());
        }
    }
}
