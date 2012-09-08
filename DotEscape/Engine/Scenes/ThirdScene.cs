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
    class ThirdScene : Scene
    {
        private Goal _goal = new Goal
                                 {
                                     Position = new Vector2(0, 0),
                                     ObjectRectangle =
                                         new Rectangle(7, 7, 35, 168)
                                 };

        public override Goal Goal
        {
            get { return _goal; }
        }

        public ThirdScene()
            :base(new Vector2(20, 350))
        {
        }

        public ThirdScene(Vector2 playerStart)
            : base(playerStart)
        {
        }

        public override int RequiredCoins { get { return 2; } }

        public override IEnumerable<IGameObject> GetStaticObjects()
        {
            var borders = SceneCreation.GenerateBorders(Globals.ContentManager.Load<Texture2D>("IngameObjects\\Border"), 7);

            foreach (var border in borders)
                yield return border;

            yield return new StandardObject(Globals.ContentManager.Load<Texture2D>("IngameObjects\\Wall"))
                             {
                                 Position = new Vector2(0, 175),
                                 ObjectRectangle = new Rectangle(0, 175, 700, 150),
                                 IsSolid = true
                             };
        }
        public override IEnumerable<EnemyDot> GetEnemyDots()
        {
            #region Low part

            for (var x = 100; x < 700; x += 75)
            {
                yield return new EnemyDot
                                 {
                                     Speed = (x > 500 ? 5 : 4),
                                     Position = new Vector2(x, 325),
                                     ObjectRectangle = new Rectangle(x, 325, 16, 16),
                                     PathPoints = new Dictionary<int, Vector2>
                                                      {
                                                          {0, new Vector2(x, 325)},
                                                          {1, new Vector2(x, 460)}
                                                      }
                                 };
            }

            for (var x = 137; x < 700; x += 75)
            {
                yield return new EnemyDot
                                 {
                                     Speed = (x > 500 ? 5 : 4),
                                     Position = new Vector2(x, 460),
                                     ObjectRectangle = new Rectangle(x, 460, 16, 16),
                                     PathPoints = new Dictionary<int, Vector2>
                                                      {
                                                          {0, new Vector2(x, 460)},
                                                          {1, new Vector2(x, 325)}
                                                      }
                                 };
            }

            #endregion

            #region Middle part

            for (var y = 300; y > 150; y -= 75)
            {
                yield return new EnemyDot
                                 {
                                     Speed = 2,
                                     Position = new Vector2(700, y),
                                     ObjectRectangle = new Rectangle(700, y, 16, 16),
                                     PathPoints = new Dictionary<int, Vector2>
                                                      {
                                                          {0, new Vector2(700, y)},
                                                          {1, new Vector2(770, y)}
                                                      }
                                 };
            }

            for (var y = 262; y > 150; y -= 75)
            {
                yield return new EnemyDot
                {
                    Speed = 2,
                    Position = new Vector2(770, y),
                    ObjectRectangle = new Rectangle(770, y, 16, 16),
                    PathPoints = new Dictionary<int, Vector2>
                                                      {
                                                          {0, new Vector2(770, y)},
                                                          {1, new Vector2(700, y)}
                                                      }
                };
            }

            #endregion

            #region High part

            for (var x = 100; x < 700; x += 75)
            {
                yield return new EnemyDot
                {
                    Speed = (x > 500 ? 5 : 4),
                    Position = new Vector2(x, 7),
                    ObjectRectangle = new Rectangle(x, 7, 16, 16),
                    PathPoints = new Dictionary<int, Vector2>
                                                      {
                                                          {0, new Vector2(x, 7)},
                                                          {1, new Vector2(x, 155)}
                                                      }
                };
            }

            for (var x = 137; x < 700; x += 75)
            {
                yield return new EnemyDot
                {
                    Speed = (x > 500 ? 5 : 4),
                    Position = new Vector2(x, 155),
                    ObjectRectangle = new Rectangle(x, 155, 16, 16),
                    PathPoints = new Dictionary<int, Vector2>
                                                      {
                                                          {0, new Vector2(x, 155)},
                                                          {1, new Vector2(x, 7)}
                                                      }
                };
            }

            #endregion
        }

        public override IEnumerable<Coin> GetCoins()
        {
            yield return new Coin
                             {
                                 Position = new Vector2(770, 262),
                                 ObjectRectangle = new Rectangle(770, 262, 16, 16)
                             };

            yield return new Coin
                             {
                                 Position = new Vector2(705, 225),
                                 ObjectRectangle = new Rectangle(705, 225, 16, 16)
                             };
        }
    }
}
