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
            int screenWidth = 600;
            int screenHeight = 480;

            

            rl.InitWindow(screenWidth, screenHeight, "Tanks for Everything!");

            rl.SetTargetFPS(60);
            Game game = new Game();
            game.Init();
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                game.Update();
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                game.Draw();
                //rl.BeginDrawing();

                //rl.ClearBackground(Color.RAYWHITE);

                //rl.DrawText("Congrats! You created your first window!", 190, 200, 20, Color.LIGHTGRAY);

                //rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            game.Shutdown();
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
