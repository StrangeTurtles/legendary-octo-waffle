using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Raylib;
using static Raylib.Raylib;

namespace Hierarchies
{
    class BoxTest
    {
        Stopwatch stopwatch = new Stopwatch();
        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;
        private float deltaTime = 0.005f;

        Color myColor = Color.BLACK;
        //Rectangle wallTop = new Rectangle(200, 400, 100, 100);
        AABB wallColider = new AABB (new Vector3(200, 400, 0), new Vector3(300, 500, 0));
        Vector3 point = new Vector3(250, 375, 0);
        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;
            
        }

        public void Shutdown()
        { }

        public void Update()
        {
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            if(IsKeyDown(KeyboardKey.KEY_W))
            {
                point.y--;
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                point.y++;
            }
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                point.x--;
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                point.x++;
            }
            

            if (wallColider.Overlaps(point))
            {
                myColor = Color.RED;
            }
            if (!wallColider.Overlaps(point))
            {
                myColor = Color.BLACK;
            }
            //Console.WriteLine($"{point.x},{point.y}");
            //Console.WriteLine(wallColider.Center());
            Console.WriteLine(wallColider.Overlaps(point));

            lastTime = currentTime;
        }

        public void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.WHITE);
            DrawText(fps.ToString(), 10, 10, 12, Color.RED);

            Raylib.Raylib.DrawRectangle(200, 400, 100, 100, myColor);
            Raylib.Raylib.DrawRectangle((int)point.x - 5, (int)point.y - 5, 10, 10, Color.BLUE);

            EndDrawing();
        }
    }
}
