namespace Tennis.Core.Models
{
    /// <summary>
    /// standard game implementation with advantage and two points difference
    /// </summary>
    public class StandardGame : GameBase
    {
        private const int pointsToWinTheGame = 4;
        private const int minAdvantagePointsToWinTheGame = 2;
        private const string advantage = "Adv.";
        private const string deuce = "DEUCE";
        private Player advantagePlayer;
        private bool isDeuce;

        public StandardGame(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string GetScore()
        {
            if (advantagePlayer != null)
            {
                return advantagePlayer == Player1 ?
                    FormatScore(Player1.Name, advantage, Player2.Name, "-") :
                    FormatScore(Player1.Name, "-", Player2.Name, advantage);
            }

            if(isDeuce)
            {
                return $"{Player1.Name} {deuce} {Player2.Name}";
            }

            return base.GetScore();
        }

        private string FormatScore(string name1, string points1, string name2, string points2) =>
            $"{name1} {points1} - {points2} {name2}";

        protected override void SetGameState(Player scoringPlayer, Player nonScoringPlayer)
        {
            isDeuce = Player1.GetScore() == Player2.GetScore() && Player1.GetScore() >= pointsToWinTheGame - 1;
            advantagePlayer = scoringPlayer.GetScore() >= pointsToWinTheGame && GetPointsDifference(scoringPlayer, nonScoringPlayer) == 1 ? scoringPlayer : null;
            Winner = scoringPlayer.GetScore() >= pointsToWinTheGame && GetPointsDifference(scoringPlayer, nonScoringPlayer) >= minAdvantagePointsToWinTheGame ? scoringPlayer : null;
        }

        private int GetPointsDifference(Player player1, Player player2)
        {
            return player1.GetScore() - player2.GetScore();
        }
    }
}
