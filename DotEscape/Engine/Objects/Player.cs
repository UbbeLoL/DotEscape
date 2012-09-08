using System.Runtime.Serialization;
using DotEscape.Engine.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace DotEscape.Engine.Objects
{
    public class Player : IGameObject
    {
        private Vector2 _velocity;
        private Vector2 _pos;
        private Texture2D _texture = Globals.ContentManager.Load<Texture2D>("IngameObjects\\Player");

        public Player PlayerObj { get { return this; } }
        public Texture2D ObjectTexture { get { return _texture; } }
        public Rectangle ObjectRectangle { get; set; }

        public Vector2 Position
        {
            get
            {
                return _pos;
            }
            
            set
            {
                _pos = value;
                ObjectRectangle = new Rectangle((int)value.X, (int)value.Y, ObjectRectangle.Width, ObjectRectangle.Height);
            }
        }
        public Vector2 Velocity { get { return _velocity; } set { _velocity = value; } }

        public int ID { get; set; }
        public int Speed { get; set; }

        public bool IsSolid { get; set; }

        public Player()
        {
            Speed = 2;
        }

        public Player(Vector2 position)
        {
            Speed = 2;
            Position = position;
            ObjectRectangle = new Rectangle((int)Position.X, (int)Position.Y, 24, 24);
        }

        public void Reset(Vector2 pos)
        {
            _pos = pos;
            Position = pos;
        }

        public void Update(GameTime gameTime)
        {
            Velocity = new Vector2(0);

            if (InputManager.IsKeyDown(Keys.W) || InputManager.IsKeyDown(Keys.Up)) _velocity.Y -= Speed;
            if (InputManager.IsKeyDown(Keys.S) || InputManager.IsKeyDown(Keys.Down)) _velocity.Y += Speed;
            if (InputManager.IsKeyDown(Keys.A) || InputManager.IsKeyDown(Keys.Left)) _velocity.X -= Speed;
            if (InputManager.IsKeyDown(Keys.D) || InputManager.IsKeyDown(Keys.Right)) _velocity.X += Speed;

            var newPos = new Vector2(Position.X + Velocity.X, Position.Y + Velocity.Y);

            IGameObject collider;
            if (!CanMove(newPos, out collider))
                AdjustPosition(Position, collider);
            else
                Position = newPos;
        }

        public Vector2 AdjustPosition(Vector2 currentPos, IGameObject collider)
        {
            int x = (int)currentPos.X, y = (int)currentPos.Y;
            var tmpRect = new Rectangle(x, y, 24, 24);

            if (Velocity.X > 0)
                while (tmpRect.Intersects(collider.ObjectRectangle))
                    tmpRect.X += -(int)Velocity.X;

            if(Velocity.Y > 0)
                while (tmpRect.Intersects(collider.ObjectRectangle))
                    tmpRect.Y += -(int)Velocity.Y;

            return new Vector2(tmpRect.X, tmpRect.Y);
        }

        public bool CanMove(Vector2 pos, out IGameObject collider)
        {
            collider = null;
            var tmpRect = new Rectangle((int) pos.X, (int) pos.Y, 24, 24); 

            if (Globals.Debug)
                return true;

            collider =
                Globals.ActiveScene.ActiveObjects.FirstOrDefault(
                    x => tmpRect.Intersects(x.ObjectRectangle) && !(x is Player) && x.IsSolid);

            return collider == null;
        }

        public void Draw(GameTime gameTime)
        {
            if (Globals.Debug)
                Globals.SpriteBatch.DrawString(Globals.DefaultFont, string.Format("X:{0},Y:{1}", Position.X, Position.Y),
                                               new Vector2(
                                                   Position.X - (Globals.DefaultFont.MeasureString("X:0,Y:0").X / 2),
                                                   Position.Y - 15), Color.Black);

            Globals.SpriteBatch.Draw(ObjectTexture, ObjectRectangle, Color.White);
        }
    }
}
