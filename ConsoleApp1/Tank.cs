using Raylib;
using System;
using System.Collections.Generic;
using System.Text;
using static Raylib.Raylib;

namespace Hierarchies
{
    /// <summary>
    /// Makes A tank
    /// </summary>
    class Tank : SpriteObject
    {
        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();
        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();
        SceneObject point0 = new SceneObject();
        SceneObject point1 = new SceneObject();
        SceneObject point2 = new SceneObject();
        SceneObject point3 = new SceneObject();

        List<Vector3> corners = new List<Vector3>();
        

        protected float speed = 1f;

        public AABB tankCollider = new AABB();

        public Tank()
        {
            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);
        }
        /// <summary>
        /// Draw the the tank
        /// </summary>
        public virtual void OnDraw()
        {
            tankObject.Draw();
            tankCollider.Draw();

            DrawCircle((int)point0.GlobalTransform.m7, (int)point0.GlobalTransform.m8, (int)2, Color.GREEN);
            DrawCircle((int)point1.GlobalTransform.m7, (int)point1.GlobalTransform.m8, (int)2, Color.GREEN);
            DrawCircle((int)point2.GlobalTransform.m7, (int)point2.GlobalTransform.m8, (int)2, Color.GREEN);
            DrawCircle((int)point3.GlobalTransform.m7, (int)point3.GlobalTransform.m8, (int)2, Color.GREEN);
        }
        /// <summary>
        /// Makes a tank
        /// </summary>
        /// <param name="tankImage"></param>
        /// <param name="turretImage"></param>
        public Tank(string tankImage, string turretImage)
        {
            corners.Add(new Vector3());
            corners.Add(new Vector3());
            corners.Add(new Vector3());
            corners.Add(new Vector3());
            tankSprite.Load(tankImage);
            tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);
            turretSprite.Load(turretImage);
            turretSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            turretSprite.SetPosition(0, turretSprite.Width / 2.0f);

            


            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);
            tankObject.SetPosition(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);
            

            tankCollider = new AABB(new Vector3( -tankSprite.Width / 2.0f + 3, -tankSprite.Height / 2.0f - 5 , 0), 
                new Vector3( tankSprite.Width / 2.0f - 6, tankSprite.Height / 2.0f - 1, 0));

            tankCollider.Corners();
            corners[0] = tankCollider.Corners()[0];
            corners[1] = tankCollider.Corners()[1];
            corners[2] = tankCollider.Corners()[2];
            corners[3] = tankCollider.Corners()[3];

            point0.SetPosition(corners[0].x, corners[0].y);
            point1.SetPosition(corners[1].x, corners[1].y);
            point2.SetPosition(corners[2].x, corners[2].y);
            point3.SetPosition(corners[3].x, corners[3].y);

            tankObject.AddChild(point0);
            tankObject.AddChild(point1);
            tankObject.AddChild(point2);
            tankObject.AddChild(point3);

            tankObject.UpdateTransform();
        }
        /// <summary>
        /// The tanks Update
        /// </summary>
        /// <param name="deltaTime"></param>
        public virtual void OnUpdate(float deltaTime)
        {
            
            corners[0] = new Vector3(point0.GlobalTransform.m7, point0.GlobalTransform.m8, 0f);
            corners[1] = new Vector3(point1.GlobalTransform.m7, point1.GlobalTransform.m8, 0f);
            corners[2] = new Vector3(point2.GlobalTransform.m7, point2.GlobalTransform.m8, 0f);
            corners[3] = new Vector3(point3.GlobalTransform.m7, point3.GlobalTransform.m8, 0f);

            tankCollider.Fit(corners);

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
            if(IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                Shoot();
            }

            tankObject.Update(deltaTime);
        }
        /// <summary>
        /// Shoots a bullet
        /// </summary>
        public void Shoot()
        {
            SceneObject bulletObject = new BulletObject();
            BulletSprite bullet = new BulletSprite();
            bulletObject.AddChild(bullet);
            turretObject.AddChild(bulletObject);
            tankObject.UpdateTransform();
            turretObject.RemoveChild(bulletObject);
            bullet.SetPosition(-6, -6);

            Vector3 facing = new Vector3(
               bulletObject.LocalTransform.m1,
               bulletObject.LocalTransform.m2, 1) * 75;
            bulletObject.Translate(facing.x, facing.y);
        }
        /// <summary>
        /// Changes the speed of the tank
        /// </summary>
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
