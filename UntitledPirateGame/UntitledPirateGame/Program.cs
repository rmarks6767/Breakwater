using System;

namespace UntitledPirateGame
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TerrainGenerator tg = new TerrainGenerator();
            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
