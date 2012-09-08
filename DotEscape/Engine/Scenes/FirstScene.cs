using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotEscape.Engine.Bases;
using DotEscape.Engine.Objects;
using DotEscape.Engine.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DotEscape.Engine.Scenes
{
    public class FirstScene : Scene
    {
        private Goal _goal = new Goal
                                 {
                                     Position = new Vector2(600, 7),
                                     ObjectRectangle =
                                         new Rectangle(600, 7, (int)(Globals.Bounds.X - 607), 50),
                                         ID = 1
                                 };

        public FirstScene()
            : base(new Vector2(10, 10))
        {
        }

        public FirstScene(Vector2 playerStart)
            : base(playerStart)
        {
        }

        public override Goal Goal { get { return _goal; } }
        public override int RequiredCoins { get { return 1; } }

        public override IEnumerable<IGameObject> GetStaticObjects()
        {
            var wall = Globals.ContentManager.Load<Texture2D>("IngameObjects\\Wall");
            var borders = SceneCreation.GenerateBorders(Globals.ContentManager.Load<Texture2D>("IngameObjects\\Border"), 7);

            foreach (var border in borders)
                yield return border;

            yield return new StandardObject(wall)
                             {
                                 Position = new Vector2(100, 7),
                                 ObjectRectangle = new Rectangle(100, 7, 500, 325),
                                 IsSolid = true
                             };
        }
        public override IEnumerable<EnemyDot> GetEnemyDots()
        {
            yield return new EnemyDot
                             {
                                 Speed = 4,
                                 Position = new Vector2(750, 400),
                                 ObjectRectangle = new Rectangle(750, 500, 16, 16),
                                 PathPoints = new Dictionary<int, Vector2>
                                                  {
                                                      {0, new Vector2(8, 400)},
                                                      {1, new Vector2(750, 400)}
                                                  }
                             };

            yield return new EnemyDot
                             {
                                 Speed = 4,
                                 Position = new Vector2(8, 450),
                                 ObjectRectangle = new Rectangle(8, 450, 16, 16),
                                 PathPoints = new Dictionary<int, Vector2>
                                                  {
                                                      {0, new Vector2(8, 450)},
                                                      {1, new Vector2(750, 450)}
                                                  }
                             };

            yield return new EnemyDot
                             {
                                 Speed = 4,
                                 Position = new Vector2(8, 350),
                                 ObjectRectangle = new Rectangle(8, 350, 16, 16),
                                 PathPoints = new Dictionary<int, Vector2>
                                                  {
                                                      {0, new Vector2(8, 350)},
                                                      {1, new Vector2(750, 350)}
                                                  }
                             };

            yield return new EnemyDot
                             {
                                 Speed = 4,
                                 Position = new Vector2(633, 75),
                                 ObjectRectangle = new Rectangle(633, 75, 16, 16),
                                 PathPoints = new Dictionary<int, Vector2>
                                                  {
                                                      {0, new Vector2(633, 450)},
                                                      {1, new Vector2(633, 75)}
                                                  }
                             };

            yield return new EnemyDot
                             {
                                 Speed = 4,
                                 Position = new Vector2(683, 450),
                                 ObjectRectangle = new Rectangle(683, 450, 16, 16),
                                 PathPoints = new Dictionary<int, Vector2>
                                                  {
                                                      {0, new Vector2(683, 75)},
                                                      {1, new Vector2(683, 450)}
                                                  }
                             };

            yield return new EnemyDot
                             {
                                 Speed = 4,
                                 Position = new Vector2(733, 75),
                                 ObjectRectangle = new Rectangle(733, 75, 16, 16),
                                 PathPoints = new Dictionary<int, Vector2>
                                                  {
                                                      {0, new Vector2(733, 450)},
                                                      {1, new Vector2(733, 75)}
                                                  }
                             };
        }
        public override IEnumerable<Coin> GetCoins()
        {
            yield return new Coin
                             {
                                 Position = new Vector2(700, 400),
                                 ObjectRectangle = new Rectangle(700, 450, 16, 16),
                             };
        }
    }
}
