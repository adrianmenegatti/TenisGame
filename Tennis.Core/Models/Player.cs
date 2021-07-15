namespace Tennis.Core.Models
{
    public class Player
    {
        private readonly PlayerScore score;

        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
            score = new PlayerScore();
        }

        public void WinsPoint()
        {
            score.AddPoint();
        }

        public void WinsGame()
        {
            score.AddGame();
        }

        public void WinsSet()
        {
            score.AddSet();
        }

        public int GetScore() => score.Points;
        public int GetGames() => score.Games;

        public void ResetScore() => score.ResetPoints();
            
    }
}
