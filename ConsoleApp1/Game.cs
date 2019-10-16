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

        public static List<SceneObject> gameObjects = new List<SceneObject>();
        public static List<SpriteObject> gameSprites = new List<SpriteObject>();
        public static Dictionary<string, Texture2D> texture = new Dictionary<string, Texture2D>();

        Tank tank = new Tank("tankBlue_outline.png", "barrelBlue.png");


        Color myColor = Color.BLACK;
        Rectangle wallTop = new Rectangle(200, 400, 100, 100);
        AABB wallCollider = new AABB(new Vector3(200, 400, 0), new Vector3(300, 500, 0));
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
            foreach (var i in gameObjects)
            {
                i.OnUpdate(deltaTime);
            }

            if (wallCollider.Overlaps(tank.tankCollider))
            {
                myColor = Color.RED;
            }
            if (!wallCollider.Overlaps(tank.tankCollider))
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
            
            DrawRectangle((int)wallTop.x, (int)wallTop.y, (int)wallTop.width, (int)wallTop.height, myColor);
            
            wallCollider.Draw();
            tank.Update(deltaTime);
            foreach(var i in gameSprites)
            {
                i.Draw();
            }
            tank.OnDraw();

            EndDrawing();
        }
    }
}
