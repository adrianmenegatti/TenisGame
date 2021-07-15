using Tennis.Core.Models;

namespace Tennis.Core.Factories.Games
{
    public interface IGameFactory
    {
        GameBase CreateGame(Player player1, Player player2);
    }
}
