using Tennis.Core.Models;

namespace Tennis.Core.Factories.Games
{
    public class StandardGameFactory : IGameFactory
    {
        public GameBase CreateGame(Player player1, Player player2)
        {
            return new StandardGame(player1, player2);
        }
    }
}
