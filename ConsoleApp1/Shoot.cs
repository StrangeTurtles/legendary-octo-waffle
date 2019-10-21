using System;
using System.Collections.Generic;
using System.Text;
using static Raylib.Raylib;
using Raylib;

namespace Hierarchies
{
    class Bullet : SpriteObject
    {
        
        public Bullet()
        {
            Load("bulletBlueSilver_outline.png");
            SetRotate(90 * (float)(Math.PI / 180.0f));
            Game.gameSprites.Add(this);
        }

    }
    class BulletMove : SceneObject
    {
        public BulletMove()
        {
            
            Game.gameObjects.Add(this);
        }
        public override void OnUpdate(float deltaTime)
        {
            Vector3 facing = new Vector3(
               LocalTransform.m1,
               LocalTransform.m2, 1) * (deltaTime) * 100;
            Translate(facing.x, facing.y);
        }
    }
}
