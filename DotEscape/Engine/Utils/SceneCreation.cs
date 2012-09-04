using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotEscape.Engine.Bases;
using DotEscape.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DotEscape.Engine.Utils
{
    public static class SceneCreation
    {
        public static IEnumerable<IGameObject> GenerateBorders(Texture2D texture, int thickness)
        {
            //Left side
            yield return new StandardObject(texture)
                             {
                                 Position = new Vector2(0, Globals.Bounds.Y),
                                 ObjectRectangle = new Rectangle(0, 0, thickness, (int)Globals.Bounds.Y),
                                 IsSolid = true
                             };

            //Right side
            yield return new StandardObject(texture)
                             {
                                 Position = new Vector2((int)Globals.Bounds.X - thickness, (int)Globals.Bounds.Y),
                                 ObjectRectangle = new Rectangle((int)Globals.Bounds.X - thickness, 0, thickness, (int)Globals.Bounds.Y),
                                 IsSolid = true
                             };

            //Top
            yield return new StandardObject(texture)
                             {
                                 Position = new Vector2(0, 0),
                                 ObjectRectangle = new Rectangle(0, 0, (int)Globals.Bounds.X, thickness),
                                 IsSolid = true
                             };

            //Bottom
            yield return new StandardObject(texture)
                             {
                                 Position = new Vector2(0, (int)Globals.Bounds.Y - thickness),
                                 ObjectRectangle = new Rectangle(0, (int)Globals.Bounds.Y - thickness, (int)Globals.Bounds.X, thickness),
                                 IsSolid = true
                             };
        }
        public static Dictionary<int, Vector2> GenerateSquarePath(Vector2 startPos, Vector2 bounds, Direction direction)
        {
            return InternalGenerateSquarePath(startPos, bounds, direction).ToDictionary(point => point.Key, point => point.Value);
        }

        private static IEnumerable<KeyValuePair<int, Vector2>> InternalGenerateSquarePath(Vector2 startPos, Vector2 bounds, Direction direction)
        {
            yield return new KeyValuePair<int, Vector2>(0, startPos);

            if (direction == Direction.Right)
            {
                yield return new KeyValuePair<int, Vector2>(1, new Vector2(startPos.X + bounds.X, startPos.Y));
                yield return new KeyValuePair<int, Vector2>(2, new Vector2(startPos.X + bounds.X, startPos.Y + bounds.Y));
                yield return new KeyValuePair<int, Vector2>(3, new Vector2(startPos.X, startPos.Y + bounds.Y));
            }
            else if (direction == Direction.Left)
            {
                yield return new KeyValuePair<int, Vector2>(1, new Vector2(startPos.X - bounds.X, startPos.Y));
                yield return new KeyValuePair<int, Vector2>(2, new Vector2(startPos.X - bounds.X, startPos.Y + bounds.Y));
                yield return new KeyValuePair<int, Vector2>(3, new Vector2(startPos.X, startPos.Y + bounds.Y));
            }
        }
    }
}
