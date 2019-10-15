using Raylib;
using System;
using System.Collections.Generic;
using System.Text;
using static Raylib.Raylib;

namespace Hierarchies
{
    
    class Tank : SpriteObject
    {
        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();
        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();

        float radius = 1f;
        Vector3 origin = new Vector3(450f, 600f, 1f);
        Vector3 top = new Vector3(0f, 0f, 1f);
        
        protected float speed = 1f;

        public Tank()
        {
            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);
        }
        public virtual void OnDraw()
        {
            tankObject.Draw();
        }
        public Tank(string tankImage, string turretImage)
        {
            tankSprite.Load(tankImage);
            tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);
            turretSprite.Load(turretImage);
            turretSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            turretSprite.SetPosition(0, turretSprite.Width / 2.0f);

            radius = tankSprite.Width;


            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);
            tankObject.SetPosition(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);
        }
        public virtual void OnUpdate(float deltaTime)
        {
            ChangeSpeed();
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(-deltaTime * speed);
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(deltaTime * speed);
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector3 facing = new Vector3(
               tankObject.LocalTransform.m1,
               tankObject.LocalTransform.m2, 1) * (deltaTime * speed) * 100;
                tankObject.Translate(facing.x, facing.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 facing = new Vector3(
               tankObject.LocalTransform.m1,
               tankObject.LocalTransform.m2, 1) * (deltaTime * speed) * -100;
                tankObject.Translate(facing.x, facing.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(-deltaTime * speed);
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(deltaTime * speed);
            }

           

            Rectangle wallTop = new Rectangle(200, 400, 100, 100);

           
            

            

            tankObject.Update(deltaTime);
        }
        private void ChangeSpeed()
        {
            if (IsKeyDown(KeyboardKey.KEY_ONE))
            {
                speed = 1f;
            }
            else if (IsKeyDown(KeyboardKey.KEY_TWO))
            {
                speed = 2f;
            }
            else if (IsKeyDown(KeyboardKey.KEY_THREE))
            {
                speed = 3f;
            }
        }
    }
}
