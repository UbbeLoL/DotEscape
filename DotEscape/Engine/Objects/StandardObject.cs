using System.Linq;
using System.Runtime.Serialization;
using DotEscape.Engine.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DotEscape.Engine.Objects
{
    class StandardObject : IGameObject
    {
        private Player _player = Globals.ActiveScene.ActiveObjects.First(x => x is Player) as Player;

        public StandardObject(Texture2D texture)
        {
            ObjectTexture = texture;
        }

        public Player PlayerObj { get { return _player; } }
        public Texture2D ObjectTexture { get; private set; }

        public Vector2 Position { get; set; }
        public Rectangle ObjectRectangle { get; set; }

        public int ID { get; set; }
        public bool IsSolid { get; set; }
        public int Speed { get; set; }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            Globals.SpriteBatch.Draw(ObjectTexture, ObjectRectangle, Color.White);
        }
    }
}
