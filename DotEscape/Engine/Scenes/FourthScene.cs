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
    class FourthScene : Scene
    {
        private Goal _goal = new Goal
                                 {
                                     Position = new Vector2(Globals.Bounds.X - 50, 7),
                                     ObjectRectangle =
                                         new Rectangle((int) (Globals.Bounds.X - 50), 7, 43, (int) Globals.Bounds.Y - 14)
                                 };

        public override Goal Goal
        {
            get { return _goal; }
        }

        public FourthScene()
            :base(new Vector2(20, 250))
        {
        }

        public FourthScene(Vector2 playerStart)
            : base(playerStart)
        {
        }

        public override int RequiredCoins { get { return 4; } }

        public override IEnumerable<IGameObject> GetStaticObjects()
        {
            var borders = SceneCreation.GenerateBorders(Globals.ContentManager.Load<Texture2D>("IngameObjects\\Border"), 7);

            foreach (var border in borders)
                yield return border;

            yield return new StandardObject(Globals.ContentManager.Load<Texture2D>("IngameObjects\\Wall"))
                             {
                                 IsSolid = true,
                                 Position = new Vector2(7, 7),
                                 ObjectRectangle = new Rectangle(7, 7, 100, 200)
                             };

            yield return new StandardObject(Globals.ContentManager.Load<Texture2D>("IngameObjects\\Wall"))
                             {
                                 IsSolid = true,
                                 Position = new Vector2(7, 300),
                                 ObjectRectangle = new Rectangle(7, 300, 100, 173)
                             };
        }
        public override IEnumerable<EnemyDot> GetEnemyDots()
        {
            #region Top->Down

            for (var x = 115; x < 700; x += 75)
            {
                yield return new EnemyDot
                                 {
                                     Speed = 6,
                                     Position = new Vector2(x, 15),
                                     ObjectRectangle = new Rectangle(x, 15, 16, 16),
                                     PathPoints = new Dictionary<int, Vector2>
                                                      {
                                                          {0, new Vector2(x, 450)},
                                                          {1, new Vector2(x, 15)},
                                                      }
                                 };

            }

            #endregion
            #region Down->Top

            for (var x = 150; x < 700; x += 75)
            {
                yield return new EnemyDot
                {
                    Speed = 6,
                    Position = new Vector2(x, 450),
                    ObjectRectangle = new Rectangle(x, 450, 16, 16),
                    PathPoints = new Dictionary<int, Vector2>
                                                      {
                                                          {0, new Vector2(x, 15)},
                                                          {1, new Vector2(x, 450)},
                                                      }
                };

            }

            #endregion
            #region Middle dots

            for(var y = 15;y < 500;y+=110)
            {
                yield return new EnemyDot
                                 {
                                     Speed = 6,
                                     Position = new Vector2(700, y),
                                     ObjectRectangle = new Rectangle(700, y, 16, 16),
                                     PathPoints = new Dictionary<int, Vector2>
                                                      {
                                                          {0, new Vector2(115, y)},
                                                          {1, new Vector2(700, y)}
                                                      }
                                 };
            }

            #endregion
        }

        public override IEnumerable<Coin> GetCoins()
        {
            //Top left
            yield return new Coin
                             {
                                 Position = new Vector2(190, 20),
                                 ObjectRectangle = new Rectangle(190, 20, 16, 16)
                             };

            //Top right
            yield return new Coin
                             {
                                 Position = new Vector2(640, 20),
                                 ObjectRectangle = new Rectangle(640, 20, 16, 16)
                             };

            //Bottom left
            yield return new Coin
                             {
                                 Position = new Vector2(190, 440),
                                 ObjectRectangle = new Rectangle(190, 440, 16, 16)
                             };


            //Bottom right
            yield return new Coin
                             {
                                 Position = new Vector2(640, 440),
                                 ObjectRectangle = new Rectangle(640, 440, 16, 16)
                             };
        }
    }
}
