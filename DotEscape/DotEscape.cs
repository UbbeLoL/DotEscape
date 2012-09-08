using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DotEscape.Engine;
using DotEscape.Engine.Bases;
using DotEscape.Engine.Objects;
using DotEscape.Engine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DotEscape
{
    public class DotEscape : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private int _totalFrames = 0;
        private float _elapsedTime = 0.0f;
        private int _fps = 0;

        public DotEscape()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            IsFixedTimeStep = true;

            Globals.SpriteBatch = _spriteBatch;
            Globals.ContentManager = Content;
            Globals.GraphicsMngr = _graphics;
            Globals.DefaultFont = Content.Load<SpriteFont>("DefaultFont");
            Globals.GraphicsDevice = GraphicsDevice;
            Globals.Bounds = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            Globals.LoadedScenes = new Dictionary<int, Scene>
                                       {
                                           {0, new FirstScene()},
                                           {1, new CutScene1()},
                                           {2, new SecondScene()},
                                           {3, new ThirdScene()},
                                           {4, new CutScene2()},
                                           {5, new FourthScene()},
                                           {6, new CutScene3()}
                                       };

            Globals.ActiveScene = Globals.LoadedScenes[0];

            Globals.ActiveScene.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            _elapsedTime += (float) gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_elapsedTime > 1000.0f)
            {
                _fps = _totalFrames;
                _totalFrames = 0;
                _elapsedTime = 0;
            }

           // if (InputManager.IsKeyPressed(Keys.F1))
           //     Globals.Debug = !Globals.Debug;

            if (!Globals.Pause)
                Globals.ActiveScene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            Globals.ActiveScene.Draw(gameTime);

            #region Debug

            _totalFrames++;

            if (Globals.Debug)
            {
                _spriteBatch.DrawString(Globals.DefaultFont, "#Debug Info", new Vector2(5, 10), Color.Black);
                _spriteBatch.DrawString(Globals.DefaultFont, "A. Objects: " + Globals.ActiveScene.ActiveObjects.Count, new Vector2(5, 25), Color.Black);
                _spriteBatch.DrawString(Globals.DefaultFont, "IsGoal?: " + (Globals.ActiveScene.AquiredCoins >= Globals.ActiveScene.RequiredCoins), new Vector2(5, 40), Color.Black);
                _spriteBatch.DrawString(Globals.DefaultFont, "VelX: " + (Globals.ActiveScene.ActiveObjects.First(x => x is Player) as Player).Velocity.X, new Vector2(5, 55), Color.Black);
                _spriteBatch.DrawString(Globals.DefaultFont, "VelY: " + (Globals.ActiveScene.ActiveObjects.First(x => x is Player) as Player).Velocity.Y, new Vector2(5, 70), Color.Black);
                _spriteBatch.DrawString(Globals.DefaultFont, "FPS: " + _fps, new Vector2(5, 85), Color.Black);
                _spriteBatch.DrawString(Globals.DefaultFont, string.Format("Coins: ({0}/{1})", Globals.ActiveScene.AquiredCoins, Globals.ActiveScene.RequiredCoins), new Vector2(5, 100), Color.Black);
            }

            #endregion

            _spriteBatch.DrawString(Globals.DefaultFont, "Deaths: " + Globals.Deaths,
                                    new Vector2(Globals.Bounds.X - Globals.DefaultFont.MeasureString("Deaths: " + Globals.Deaths).X - 15, 10), Color.Black);
            _spriteBatch.DrawString(Globals.DefaultFont, "Level: " + (Globals.CurrentScene+1) ,
                        new Vector2(Globals.Bounds.X - Globals.DefaultFont.MeasureString("Level: " + (Globals.CurrentScene+1)).X - 15, 30), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
