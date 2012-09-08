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
    class CutScene2 : Scene
    {
        private Goal _goal = new Goal
                                 {
                                     Position = new Vector2(-100, -100),
                                     ObjectRectangle =
                                         new Rectangle(-100, -100, 1, 1)
                                 };

        private SpriteFont _spriteFont = Globals.ContentManager.Load<SpriteFont>("CutSceneFont");
        private int _counter = 250;

        public override Goal Goal
        {
            get { return _goal; }
        }

        public CutScene2()
            :base(new Vector2(20, 250))
        {
        }

        public CutScene2(Vector2 playerStart)
            : base(playerStart)
        {
        }

        public override int RequiredCoins { get { return 5; } }

        public override IEnumerable<IGameObject> GetStaticObjects()
        {
            var borders = SceneCreation.GenerateBorders(Globals.ContentManager.Load<Texture2D>("IngameObjects\\Border"), 7);

            foreach (var border in borders)
                yield return border;
        }
        public override IEnumerable<EnemyDot> GetEnemyDots()
        {
            yield return new EnemyDot
                             {
                                 Speed = 2,
                                 Position = new Vector2(-100, -100),
                                 ObjectRectangle = new Rectangle(-100, -100, 16, 16),
                                 PathPoints = new Dictionary<int,Vector2>
                                                  {
                                                      {0, new Vector2(-100, -100)}
                                                  }
                             };
        }
        public override IEnumerable<Coin> GetCoins()
        {
            yield return new Coin
                             {
                                 Position = new Vector2(-100, -100),
                                 ObjectRectangle = new Rectangle(-100, -100, 16, 16)
                             };

        }

        public override void Update(GameTime gameTime)
        {
            if (_counter-- >= 1)
                return;

            CycleScene();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.SpriteBatch.DrawString(_spriteFont, "GETTING A LITTLE\n      BIT HARDER...",
                                           new Vector2(
                                               Globals.Bounds.X/2 -
                                               (_spriteFont.MeasureString("GETTING A LITTLE\n      BIT HARDER...").X / 2),
                                               Globals.Bounds.Y/2 -
                                               (_spriteFont.MeasureString("GETTING A LITTLE\n      BIT HARDER...").Y / 2)),
                                           Color.Black);

            base.Draw(gameTime);
        }
    }
}
