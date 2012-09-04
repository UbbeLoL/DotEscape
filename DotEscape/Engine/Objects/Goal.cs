using System.Linq;
using System.Runtime.Serialization;
using DotEscape.Engine.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DotEscape.Engine.Objects
{
    public class Goal : IGameObject
    {
        private Texture2D _goodTexture = Globals.ContentManager.Load<Texture2D>("IngameObjects\\GoodGoal"), _badTexture = Globals.ContentManager.Load<Texture2D>("IngameObjects\\BadGoal");
        private Player _player;

        public Player PlayerObj { get { return _player; } }
        public Texture2D ObjectTexture { get { return (Globals.ActiveScene.AquiredCoins >= Globals.ActiveScene.RequiredCoins ? _goodTexture : _badTexture); } }

        public Vector2 Position { get; set; }
        public Rectangle ObjectRectangle { get; set; }

        public int ID { get; set; }
        public bool IsSolid { get; set; }
        public int Speed { get; set; }

        public void Update(GameTime gameTime)
        {
            if(_player == null)
                _player = Globals.ActiveScene.ActiveObjects.First(x => x is Player) as Player;

            if (!IsActivated())
                return;

            if (ObjectRectangle.Intersects(Globals.ActiveScene.ActiveObjects.First(x => x is Player).ObjectRectangle))
                Globals.ActiveScene.CycleScene();
        }

        private bool IsActivated()
        {
            return Globals.ActiveScene.AquiredCoins >= Globals.ActiveScene.RequiredCoins;
        }

        public void Draw(GameTime gameTime)
        {
            Globals.SpriteBatch.Draw(ObjectTexture, ObjectRectangle, Color.White);
        }
    }
}
