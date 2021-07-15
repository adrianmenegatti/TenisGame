using System;
using Tennis.Core.Factories.Games;

namespace Tennis.Core.Models
{
    public abstract class SetBase
    {
        private readonly Player player1;
        private readonly Player player2;
        private Func<IGameFactory> gameFactory;

        protected  GameBase currentGame;

        public Player Winner { get; protected set; }

        public SetBase(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;

            gameFactory = GameFactory.GetFactory<StandardGame>();

            currentGame = gameFactory()?.CreateGame(player1, player2);
        }

        public void AddPointForPlayer1()
        {
            currentGame.AddPointForPlayer1();
            OnPointScored(player1, player2);
        }

        public void AddPointForPlayer2()
        {
            currentGame.AddPointForPlayer2();
            OnPointScored(player2, player1);
        }

        protected void OnPointScored(Player scoringPlayer, Player nonScoringPlayer)
        {
            SetCurrentSetState(scoringPlayer, nonScoringPlayer);

            if(currentGame.IsOver())
            {
                currentGame = gameFactory()?.CreateGame(player1, player2);
            }

            if(Winner == scoringPlayer)
            {
                scoringPlayer.WinsSet();
            }
        }

        protected abstract void SetCurrentSetState(Player scoringPlayer, Player nonScoringPlayer);

        public string GetScore() => $"{player1.Name} {player1.GetGames()} - {player2.GetGames()} {player2.Name}";

    }
}
