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

            lastTime = currentTime;
        }

        public void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.WHITE);
            DrawText(fps.ToString(), 10, 10, 12, Color.RED);

            //tank.Update(deltaTime);
            //tank.OnDraw();
            //Raylib.Raylib.DrawRectangle((int)wallTop.x, (int)wallTop.y, (int)wallTop.width, (int)wallTop.height, Color.BLACK);

            EndDrawing();
        }
    }
}
