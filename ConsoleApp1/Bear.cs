using System;
using System.Collections.Generic;
using System.Text;
using static Raylib.Raylib;
using Raylib;

namespace Hierarchies
{
    class Bear : Animal
    {
        public Circle bearCollider = new Circle(new Vector3(), 5);
        List<Vector3> pointList = new List<Vector3>();
        SceneObject point0 = new SceneObject();
        SceneObject point1 = new SceneObject();
        SceneObject point2 = new SceneObject();
        SceneObject point3 = new SceneObject();
        int hitPoints = 2;
        Random random = new Random();
        /// <summary>
        /// makes a bear sprite
        /// </summary>
        public Bear()
        {
            Game.bears.Add(this);
            Load("Bear.png");
            ReScale(.5f);
            SetPosition(random.Next(GetScreenWidth()), random.Next(GetScreenHeight()));
            //Adds blank vectors in to the list
            pointList.Add(new Vector3());
            pointList.Add(new Vector3());
            pointList.Add(new Vector3());
            pointList.Add(new Vector3());
            //Sets the position of the points
            point0.SetPosition(Width / 4.0f + 23, Height / 4.0f + 23);
            point1.SetPosition(Width / 8.0f, Height / 4.0f);
            point2.SetPosition(Width / 4.0f, Height / 8.0f);
            point3.SetPosition(Width / 8.0f - 3, Height / 8.0f - 3);
            //Makes them a child of the bullet sprite
            AddChild(point0);
            AddChild(point1);
            AddChild(point2);
            AddChild(point3);
        }
        public void Hit()
        {
            hitPoints--;
        }
        public void Die()
        {
            Game.bears.Remove(this);
        }
        public override void OnUpdate(float deltaTime)
        {
            pointList[0] = new Vector3(point0.GlobalTransform.m7, point0.GlobalTransform.m8, 0f);
            pointList[1] = new Vector3(point1.GlobalTransform.m7, point1.GlobalTransform.m8, 0f);
            pointList[2] = new Vector3(point2.GlobalTransform.m7, point2.GlobalTransform.m8, 0f);
            pointList[3] = new Vector3(point3.GlobalTransform.m7, point3.GlobalTransform.m8, 0f);

            bearCollider.Fit(pointList);

            if(hitPoints == 1)
            {
                Load("Twenty_seven_lbs_cocaine_bear.png");
                speed = 2;
            }
            if(hitPoints == 0)
            {
                Die();
            }
            base.OnUpdate(deltaTime);
        }
        public override void OnDraw()
        {
            DrawCircle((int)point0.GlobalTransform.m7, (int)point0.GlobalTransform.m8, 2, Color.GREEN);
            DrawCircle((int)point1.GlobalTransform.m7, (int)point1.GlobalTransform.m8, 2, Color.GREEN);
            DrawCircle((int)point2.GlobalTransform.m7, (int)point2.GlobalTransform.m8, 2, Color.GREEN);
            DrawCircle((int)point3.GlobalTransform.m7, (int)point3.GlobalTransform.m8, 2, Color.GREEN);
            base.OnDraw();
        }
    }
}
