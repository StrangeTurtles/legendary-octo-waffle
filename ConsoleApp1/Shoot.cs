using System;
using System.Collections.Generic;
using System.Text;
using static Raylib.Raylib;
using Raylib;

namespace Hierarchies
{
    class BulletSprite : SpriteObject
    {
        public Circle bulletCollider = new Circle(new Vector3(), 5);
        List<Vector3> bulletPointList = new List<Vector3>();
        SceneObject point0 = new SceneObject();
        SceneObject point1 = new SceneObject();
        SceneObject point2 = new SceneObject();
        SceneObject point3 = new SceneObject();
        /// <summary>
        /// Creates the Bullet's sprite
        /// </summary>
        public BulletSprite()
        {
            Load("bulletBlueSilver_outline.png");
            SetRotate(90 * (float)(Math.PI / 180.0f));
            ReScale(.5f);

            //
            bulletPointList.Add(new Vector3());
            bulletPointList.Add(new Vector3());
            bulletPointList.Add(new Vector3());
            bulletPointList.Add(new Vector3());
            //
            point0.SetPosition(Width / 4.0f , Height / 4.0f + 10);
            point1.SetPosition(-Width / 4.0f + 10, Height / 4.0f + 10);
            point2.SetPosition(Width / 4.0f , -Height / 4.0f + 10);
            point3.SetPosition(-Width / 4.0f + 10, -Height / 4.0f + 10);
            AddChild(point0);
            AddChild(point1);
            AddChild(point2);
            AddChild(point3);



            Game.gameSprites.Add(this);
        }
        /// <summary>
        /// The BulletSprite's Update
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void OnUpdate(float deltaTime)
        {
            bulletPointList[0] = new Vector3(point0.GlobalTransform.m7, point0.GlobalTransform.m8, 0f);
            bulletPointList[1] = new Vector3(point1.GlobalTransform.m7, point1.GlobalTransform.m8, 0f);
            bulletPointList[2] = new Vector3(point2.GlobalTransform.m7, point2.GlobalTransform.m8, 0f);
            bulletPointList[3] = new Vector3(point3.GlobalTransform.m7, point3.GlobalTransform.m8, 0f);
            

            bulletCollider.Fit(bulletPointList);
        }
        /// <summary>
        /// Draw the Bullet's points
        /// </summary>
        public override void OnDraw()
        {
            DrawCircle((int)point0.GlobalTransform.m7, (int)point0.GlobalTransform.m8, 2, Color.GREEN);
            DrawCircle((int)point1.GlobalTransform.m7, (int)point1.GlobalTransform.m8, 2, Color.GREEN);
            DrawCircle((int)point2.GlobalTransform.m7, (int)point2.GlobalTransform.m8, 2, Color.GREEN);
            DrawCircle((int)point3.GlobalTransform.m7, (int)point3.GlobalTransform.m8, 2, Color.GREEN);
            base.OnDraw();
        }

    }
    class BulletObject : SceneObject
    {
        /// <summary>
        /// Creates the BulletObject
        /// </summary>
        public BulletObject()
        {
            Game.gameObjects.Add(this);
        }
        /// <summary>
        /// The Bullet's Update
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void OnUpdate(float deltaTime)
        {
            
            Vector3 facing = new Vector3(
               LocalTransform.m1,
               LocalTransform.m2, 1) * (deltaTime * 100);
            UpdateTransform();
            Translate(facing.x, facing.y); 
        }
        
    }
}
