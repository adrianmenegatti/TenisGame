using System;

namespace Tennis.Tests
{
    public static class TestsHelper
    {
        public static void AddPointsToPlayer(int points, Action action)
        {
            for(var i = 0; i < points; i++)
            {
                action();
            }
        }
        public static void AddGamesToPlayer(int games, Action action)
        {
            for(var i = 0; i < games; i++)
            {
                AddPointsToPlayer(4, action);
                //for(var x = 0; x < 4; x++)
                //{
                //    action();
                //}
            }
        }
    }
}
