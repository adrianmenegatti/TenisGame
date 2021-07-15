using System;

namespace Tennis.Core.Models
{
    public abstract class GameBase
    {
        private readonly string[] points = { "0", "15", "30", "40" };

        public Player Winner { get; protected set; }
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

        public Action onGameWon;

        public GameBase(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;

            InitializeGame();
        }

        private void InitializeGame()
        {
            Player1.ResetScore();
            Player2.ResetScore();
        }

        public virtual string GetScore()
        {
            return $"{Player1.Name} {TranslatePoint(Player1.GetScore())} - {TranslatePoint(Player2.GetScore())} {Player2.Name}";
        }

        public string TranslatePoint(int point)
        {
            if (point > points.Length)
                return points[^1];

            return points[point];
        }

        public void AddPointForPlayer1()
        {
            Player1.WinsPoint();
            OnPointScored(Player1, Player2);
        }
        public void AddPointForPlayer2()
        {
            Player2.WinsPoint();
            OnPointScored(Player2, Player1);
        }

        protected void OnPointScored(Player scoringPlayer, Player nonScoringPlayer)
        {
            SetGameState(scoringPlayer, nonScoringPlayer);
            
            if(Winner == scoringPlayer)
            {
                scoringPlayer.WinsGame();
                InitializeGame();
            }
        }

        public bool IsOver() => Winner != null;

        protected abstract void SetGameState(Player scoringPlayer, Player nonScoringPlayer);
    }
}
