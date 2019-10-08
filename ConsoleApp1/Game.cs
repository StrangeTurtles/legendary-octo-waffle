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
        private long lastTime = 0;        private float timer = 0;
        private int fps = 1;
        private int frames;
        private float deltaTime = 0.005f;

        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();
        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            tankSprite.Load("tankBlue_outline.png");
            tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);
            turretSprite.Load("barrelBlue_outline.png");
            turretSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            turretSprite.SetPosition(0, turretSprite.Width / 2.0f);

            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);
            tankObject.SetPosition(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);
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
            
            
            tankObject.Update(deltaTime);
            tankObject.Draw();

            EndDrawing();
        }
    }
}
