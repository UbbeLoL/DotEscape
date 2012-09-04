using System.Linq;
using System.Runtime.Serialization;
using DotEscape.Engine.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DotEscape.Engine.Objects
{
    public class Coin : IGameObject
    {
        private Texture2D _texture = Globals.ContentManager.Load<Texture2D>("IngameObjects\\Coin");
        private Player _player = Globals.ActiveScene.ActiveObjects.First(x => x is Player) as Player;

        public Player PlayerObj { get { return _player; } }
        public Texture2D ObjectTexture { get { return _texture; } }
        public Vector2 Position { get; set; }

        public Rectangle ObjectRectangle { get; set; }
        public int ID { get; set; }
        public bool IsSolid { get; set; }
        public int Speed { get; set; }

        public void Update(GameTime gameTime)
        {
            if(ObjectRectangle.Intersects(Globals.ActiveScene.ActiveObjects.First(x => x is Player).ObjectRectangle))
            {
                Globals.ActiveScene.AquiredCoins++;
                Globals.ActiveScene.ActiveObjects.Remove(this);
            }
        }

        public void Draw(GameTime gameTime)
        {
            Globals.SpriteBatch.Draw(ObjectTexture, ObjectRectangle, Color.White);
        }
    }
}
