using System;
using System.Collections.Generic;
using Tennis.Core.Models;

namespace Tennis.Core.Factories.Games
{
    public static class GameFactory
    {
        public static Dictionary<Type, Func<IGameFactory>> factories = new Dictionary<Type, Func<IGameFactory>>();

        static GameFactory()
        {
            factories.Add(typeof(StandardGame), () => new StandardGameFactory());
        }

        public static Func<IGameFactory> GetFactory<T>() => factories.ContainsKey(typeof(T)) ? factories[typeof(T)] : null;

    }
}
