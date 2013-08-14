using System;

namespace TestGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリー ポイントです。
        /// </summary>
        static void Main(string[] args)
        {
            using (GameMain game = new GameMain())
            {
                game.graphics.PreferredBackBufferWidth = 800;
                game.graphics.PreferredBackBufferHeight = 600;
                game.IsMouseVisible = true;
                game.Run();
            }
        }
    }
#endif
}

