using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotEscape.Engine.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DotEscape
{
    public static class Globals
    {
        public static Vector2 Bounds;
        public static SpriteBatch SpriteBatch;
        public static GraphicsDeviceManager GraphicsMngr;
        public static ContentManager ContentManager;
        public static GraphicsAdapter GraphicsAdapter;
        public static GraphicsDevice GraphicsDevice;
        public static SpriteFont DefaultFont;

        public static bool Pause;
        public static bool Debug = false;

        public static int Deaths;
        public static int CurrentScene;

        public static Dictionary<int, Scene> LoadedScenes;
        public static Scene ActiveScene;
    }
}
