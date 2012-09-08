using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DotEscape.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DotEscape.Engine.Bases
{
    [Flags]
    public enum Direction : byte
    {
        Still = 0,
        Up = 0x1,
        Down = 0x2,
        Right = 0x3,
        Left = 0x4
    }

    public interface IGameObject : IGameController
    {
        Player PlayerObj { get; }
        Texture2D ObjectTexture { get; }
        Vector2 Position { get; set; }
        Rectangle ObjectRectangle { get; set; }
        int ID { get; set; }
        bool IsSolid { get; set; }
        int Speed { get; set; }
    }
}
