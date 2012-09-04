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
    class SecondScene : Scene
    {
        private Goal _goal = new Goal
                                 {
                                     Position = new Vector2(Globals.Bounds.X - 50, 15),
                                     ObjectRectangle =
                                         new Rectangle((int) (Globals.Bounds.X - 50), 15, 35, (int) Globals.Bounds.Y - 30)
                                 };

        public override Goal Goal
        {
            get { return _goal; }
        }

        public SecondScene()
            :base(new Vector2(20, 250))
        {
        }

        public SecondScene(Vector2 playerStart)
            : base(playerStart)
        {
        }

        public override int RequiredCoins { get { return 5; } }

        public override IEnumerable<IGameObject> GetStaticObjects()
        {
            var borders = SceneCreation.GenerateBorders(Globals.ContentManager.Load<Texture2D>("IngameObjects\\Border"), 15);

            foreach (var border in borders)
                yield return border;
        }
        public override IEnumerable<EnemyDot> GetEnemyDots()
        {
            for (var y = -100; y < Globals.Bounds.Y; y += 125)
            {
                for (var x = 150; x < Globals.Bounds.X - 200; x += 100)
                    yield return new EnemyDot
                                     {
                                         Speed = 2,
                                         Position = new Vector2(x, y),
                                         ObjectRectangle = new Rectangle(x, y, 16, 16),
                                         PathPoints =
                                             SceneCreation.GenerateSquarePath(new Vector2(x, y), new Vector2(100, 125),
                                                                              Direction.Right)
                                     };
            }

        }
        public override IEnumerable<Coin> GetCoins()
        {
            //Top left
            yield return new Coin
                             {
                                 Position = new Vector2(200, 20),
                                 ObjectRectangle = new Rectangle(200, 20, 16, 16)
                             };

            //Bottom left
            yield return new Coin
                             {
                                 Position = new Vector2(200, 450),
                                 ObjectRectangle = new Rectangle(200, 440, 16, 16)
                             };

            //Bottom right
            yield return new Coin
                             {
                                 Position = new Vector2(600, 450),
                                 ObjectRectangle = new Rectangle(600, 440, 16, 16)
                             };
        
            //Top right
            yield return new Coin
                             {
                                 Position = new Vector2(600, 20),
                                 ObjectRectangle = new Rectangle(600, 20, 16, 16)
                             };

            //Middle
            yield return new Coin
                             {
                                 Position = new Vector2(400, 235),
                                 ObjectRectangle = new Rectangle(400, 245, 16, 16)
                             };
        }
    }
}
