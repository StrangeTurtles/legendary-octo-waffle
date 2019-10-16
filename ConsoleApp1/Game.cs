using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Raylib;
using static Raylib.Raylib;

namespace Hierarchies
{
    class Game
    {
        Stopwatch stopwatch = new Stopwatch();
        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;
        private float deltaTime = 0.005f;

        Tank tank = new Tank("tankBlue_outline.png", "barrelBlue.png");


        Color myColor = Color.BLACK;
        Rectangle wallTop = new Rectangle(200, 400, 100, 100);
        AABB wallColider = new AABB(new Vector3(200, 400, 0), new Vector3(300, 500, 0));
        /// <summary>
        /// The Initalised step of the game
        /// </summary>
        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;
        }
        /// <summary>
        /// Shutdown the game
        /// </summary>
        public void Shutdown()
        { }
        /// <summary>
        /// The Update step for the game
        /// </summary>
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

            tank.OnUpdate(deltaTime);

            if (wallColider.Overlaps(tank.tankColider))
            {
                myColor = Color.RED;
            }
            if (!wallColider.Overlaps(tank.tankColider))
            {
                myColor = Color.BLACK;
            }

            lastTime = currentTime;
        }
        /// <summary>
        /// Draw the things in the game
        /// </summary>
        public void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.WHITE);
            DrawText(fps.ToString(), 10, 10, 12, Color.RED);
            
            Raylib.Raylib.DrawRectangle((int)wallTop.x, (int)wallTop.y, (int)wallTop.width, (int)wallTop.height, myColor);
            
            wallColider.Draw();
            tank.Update(deltaTime);
            tank.OnDraw();

            EndDrawing();
        }
    }
}
