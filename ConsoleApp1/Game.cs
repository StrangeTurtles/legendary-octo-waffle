using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Raylib;
using static Raylib.Raylib;

namespace Hierarchies
{
    /// <summary>
    /// This is the game
    /// </summary>
    class Game
    {
        Stopwatch stopwatch = new Stopwatch();
        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;
        private float deltaTime = 0.005f;

        public static List<BulletObject> bulletObjects = new List<BulletObject>();
        public static List<BulletSprite> bulletSprites = new List<BulletSprite>();
        public static List<SceneObject> gameObjects = new List<SceneObject>();
        public static List<Bear> bears = new List<Bear>();
        public static Dictionary<string, Texture2D> texture = new Dictionary<string, Texture2D>();

        Tank tank = new Tank("tankBlue_outline.png", "barrelBlue.png");


        public Color myColor = Color.BLACK;
        Rectangle wallTop = new Rectangle(200, 400, 100, 100);
        public AABB wallCollider = new AABB(new Vector3(200, 400, 0), new Vector3(300, 500, 0));
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
            foreach (var i in bulletObjects)
            {
                i.OnUpdate(deltaTime);
            }
            foreach (var i in bulletSprites)
            {
                i.OnUpdate(deltaTime);
            }
            foreach (var i in bulletSprites)
            {
                if (i.bulletCollider.Overlaps(wallCollider) || wallCollider.Overlaps(tank.tankCollider))
                {
                    myColor = Color.RED;
                    break;
                }
                else
                {
                    myColor = Color.BLACK;
                }
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
            foreach(var i in bulletSprites)
            {
                i.Draw();
                i.bulletCollider.Draw();
            }
            
            tank.OnDraw();

            EndDrawing();
        }
    }
}
