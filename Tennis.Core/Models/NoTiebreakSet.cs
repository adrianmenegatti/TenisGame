namespace Tennis.Core.Models
{
    public class NoTiebreakSet : SetBase
    {
        private const int gamesToWinTheSet = 6;
        private const int minAdvantageToWinTheSet = 2;

        public NoTiebreakSet(Player player1, Player player2) : base(player1, player2)
        {
        }

        protected override void SetCurrentSetState(Player scoringPlayer, Player nonScoringPlayer)
        {
            Winner = scoringPlayer.GetGames() >= gamesToWinTheSet && GetGamesDifference(scoringPlayer, nonScoringPlayer) >= minAdvantageToWinTheSet ? scoringPlayer : null;
        }

        private int GetGamesDifference(Player player1, Player player2)
        {
            return player1.GetGames() - player2.GetGames();
        }
    }
}
