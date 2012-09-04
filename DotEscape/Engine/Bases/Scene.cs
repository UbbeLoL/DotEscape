using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DotEscape.Engine.Objects;
using Microsoft.Xna.Framework;

namespace DotEscape.Engine.Bases
{
    public abstract class Scene
    {
        public List<IGameObject> ActiveObjects { get; private set; }
        public Vector2 PlayerStart { get; set; }
        public int AquiredCoins { get; set; }
        public abstract Goal Goal { get; }

        public abstract int RequiredCoins { get; }

        public virtual IEnumerable<IGameObject> StaticObjects { get { return GetStaticObjects(); } }
        public virtual IEnumerable<EnemyDot> EnemyDots { get { return GetEnemyDots(); } }
        public virtual IEnumerable<Coin> Coins { get { return GetCoins(); } }

        public abstract IEnumerable<IGameObject> GetStaticObjects();
        public abstract IEnumerable<EnemyDot> GetEnemyDots();
        public abstract IEnumerable<Coin> GetCoins();

        protected Scene(Vector2 playerStart)
        {
            PlayerStart = playerStart;
            ActiveObjects = new List<IGameObject>();
        }

        public void Reset()
        {
            (Globals.ActiveScene.ActiveObjects.First(x => x is Player) as Player).Reset(PlayerStart);
            AquiredCoins = 0;
            ActiveObjects.ForEach(x =>
                                      {
                                          if (!(x is Coin))
                                              return;

                                          ActiveObjects.Remove(x);
                                      });
            ActiveObjects.AddRange(GetCoins());
        }

        public void CycleScene()
        {
            if (Globals.LoadedScenes.ContainsKey(Globals.CurrentScene + 1))
            {
                Globals.ActiveScene = Globals.LoadedScenes[++Globals.CurrentScene];
                Globals.ActiveScene.Initialize();
            }
            else
                Environment.Exit(-1);
        }

        public void Initialize()
        {
            ActiveObjects.Add(new Player(PlayerStart));
            ActiveObjects.AddRange(StaticObjects);
            ActiveObjects.AddRange(EnemyDots);
            ActiveObjects.AddRange(Coins);
            ActiveObjects.Add(Goal);
        }

        public void SpawnObject<T>() where T : IGameObject
        {
            ActiveObjects.Add(Activator.CreateInstance<T>());
        }

        public void SpawnObject(IGameObject obj)
        {
            ActiveObjects.Add(obj);
        }

        public void Update(GameTime gameTime)
        {
            InputManager.Update();
            ActiveObjects.ForEach(x => x.Update(gameTime));
        }

        public void Draw(GameTime gameTime)
        {
            ActiveObjects.ForEach(x => x.Draw(gameTime));
        }
    }
}
