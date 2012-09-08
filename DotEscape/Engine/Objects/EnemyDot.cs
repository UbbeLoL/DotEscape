using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DotEscape.Engine.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DotEscape.Engine.Objects
{
    public class EnemyDot : IGameObject
    {
        private Vector2 _pos;
        private Texture2D _texture = Globals.ContentManager.Load<Texture2D>("IngameObjects\\BadDot");

        //Since any IGameObject is scene bound we should be fine doing this. It should save us some precious time 
        //contrary to iterating entire activeobjects list each update
        private Player _player = Globals.ActiveScene.ActiveObjects.First(x => x is Player) as Player; 

        public Vector2 Position
        {
            get { return _pos; }
            set
            {
                ObjectRectangle = new Rectangle((int) _pos.X, (int) _pos.Y, 16, 16);
                _pos = value;
            }
        }

        public Player PlayerObj { get { return _player; } }
        public Texture2D ObjectTexture { get { return _texture; } }

        public Rectangle ObjectRectangle { get; set; }
        public Dictionary<int, Vector2> PathPoints { get; set; }

        public int ID { get; set; }
        public int Speed { get; set; }
        private int TargetPoint { get; set; }

        public bool IsSolid { get; set; }

        public EnemyDot()
        {
            IsSolid = !Globals.Debug;
            PathPoints = new Dictionary<int, Vector2>();
            TargetPoint = 0;
        }

        public void Update(GameTime gameTime)
        {
            int x = (int) Position.X, y = (int) Position.Y;

            if (PathPoints[TargetPoint].X >= Position.X)
                if (x + Speed >= PathPoints[TargetPoint].X)
                    x = (int)PathPoints[TargetPoint].X;
                else
                    x += Speed;

            if (PathPoints[TargetPoint].X <= Position.X)
                if (x - Speed <= PathPoints[TargetPoint].X)
                    x = (int)PathPoints[TargetPoint].X;
                else
                    x -= Speed;

            if (PathPoints[TargetPoint].Y >= Position.Y)
                if (y + Speed >= PathPoints[TargetPoint].Y)
                    y = (int)PathPoints[TargetPoint].Y;
                else
                    y += Speed;

            if (PathPoints[TargetPoint].Y <= Position.Y)
                if (y - Speed <= PathPoints[TargetPoint].Y)
                    y = (int)PathPoints[TargetPoint].Y;
                else
                    y -= Speed;

            if (!Globals.Debug)
            {
                var tmpRect = new Rectangle(x, y, 16, 16);

                if (tmpRect.Intersects(PlayerObj.ObjectRectangle))
                {
                    Globals.Deaths++;
                    Globals.ActiveScene.Reset();
                }
            }

            //Loss of fraction shouldn't be an issue, we're adjusting position
            //in the if statements above
            if (Position.X == x && Position.Y == y) //We've reached our target point, move on to next one
                CyclePoint();

            Position = new Vector2(x, y);
        }

        public void Draw(GameTime gameTime)
        {
            if (Globals.Debug)
                Globals.SpriteBatch.DrawString(Globals.DefaultFont, string.Format("X:{0},Y:{1},P:{2}", Position.X, Position.Y, TargetPoint),
                                               new Vector2(
                                                   Position.X - (Globals.DefaultFont.MeasureString("X:10,Y:10,P:0").X/2),
                                                   Position.Y - 15), Color.Black);

            Globals.SpriteBatch.Draw(ObjectTexture, ObjectRectangle, Color.White);
        }

        public void CyclePoint()
        {
            if (PathPoints.ContainsKey(TargetPoint + 1))
                TargetPoint++;
            else
                TargetPoint = 0;
        }
    }
}
