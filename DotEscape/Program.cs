using System;

namespace DotEscape
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (DotEscape game = new DotEscape())
            {
                game.Run();
            }
        }
    }
#endif
}

