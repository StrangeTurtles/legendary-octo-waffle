using Raylib;
using rl = Raylib.Raylib;

namespace Hierarchies
{
    static class Program
    {
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 1200;
            int screenHeight = 900;
            
            

            rl.InitWindow(screenWidth, screenHeight, "Tanks For Nothing!");

            rl.SetTargetFPS(60);
            Game game = new Game();

            //BoxTest boxTest = new BoxTest();
            game.Init();
            //boxTest.Init();
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                game.Update();
                //boxTest.Update();
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                game.Draw();
                //boxTest.Draw();
                
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            game.Shutdown();
            //boxTest.Shutdown();
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
