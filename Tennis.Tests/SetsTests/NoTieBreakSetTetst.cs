using Tennis.Core.Models;
using Xunit;

namespace Tennis.Tests.SetsTests
{
    public class NoTieBreakSetTetst
    {
        private readonly NoTiebreakSet set;
        private readonly Player player1;
        private readonly Player player2;

        public NoTieBreakSetTetst()
        {
            player1 = new Player("Player 1");
            player2 = new Player("Player 2");
            set = new NoTiebreakSet(player1, player2);
        }

        [Fact]
        public void Player1WinsGameCorrectScoreIsReturned()
        {
            TestsHelper.AddGamesToPlayer(1, set.AddPointForPlayer1);

            Assert.Equal("Player 1 1 - 0 Player 2", set.GetScore());
        }

        [Fact]
        public void BothPlayersWinsGameCorrectScoreIsReturned()
        {
            TestsHelper.AddGamesToPlayer(1, set.AddPointForPlayer1);
            TestsHelper.AddGamesToPlayer(1, set.AddPointForPlayer2);

            Assert.Equal("Player 1 1 - 1 Player 2", set.GetScore());
        }

        [Fact]
        public void Player1WinsTwoGrameAndPlayer2WinsOneGameCorrectScoreIsReturned()
        {
            TestsHelper.AddGamesToPlayer(1, set.AddPointForPlayer1);
            TestsHelper.AddGamesToPlayer(1, set.AddPointForPlayer2);
            TestsHelper.AddGamesToPlayer(1, set.AddPointForPlayer1);

            Assert.Equal("Player 1 2 - 1 Player 2", set.GetScore());
        }

        [Fact]
        public void Player1WinsSixGamesThenWinsTheSet()
        {
            TestsHelper.AddGamesToPlayer(6, set.AddPointForPlayer1);

            Assert.Equal(player1, set.Winner);
            Assert.Equal("Player 1 6 - 0 Player 2", set.GetScore());
        }

        [Fact]
        public void Player1WinsSixGamesAndPlayer2WinsFiveGamesThenNoWinner()
        {
            TestsHelper.AddGamesToPlayer(3, set.AddPointForPlayer1);
            TestsHelper.AddGamesToPlayer(5, set.AddPointForPlayer2);
            TestsHelper.AddGamesToPlayer(3, set.AddPointForPlayer1);

            Assert.Null(set.Winner);
            Assert.Equal("Player 1 6 - 5 Player 2", set.GetScore());
        }

        [Fact]
        public void Player1WinsByDifferenceOfTwoThenWinsTheSet()
        {
            TestsHelper.AddGamesToPlayer(3, set.AddPointForPlayer1);
            TestsHelper.AddGamesToPlayer(5, set.AddPointForPlayer2);
            TestsHelper.AddGamesToPlayer(3, set.AddPointForPlayer1);
            TestsHelper.AddGamesToPlayer(1, set.AddPointForPlayer2);
            TestsHelper.AddGamesToPlayer(2, set.AddPointForPlayer1);

            Assert.Equal(player1, set.Winner);
            Assert.Equal("Player 1 8 - 6 Player 2", set.GetScore());
        }

    }
}
