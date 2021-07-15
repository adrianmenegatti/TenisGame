using System.Collections.Generic;

namespace Tennis.Core.Models
{
    public class PlayerScore
    {
        public int Points { get; private set; }
        public int Games { get; private set; }
        public int Sets { get; private set; }

        public void AddPoint() => Points++;
        public void ResetPoints() => Points = 0;

        public void AddGame() => Games++;
        public void AddSet() => Sets++;
    }
}
