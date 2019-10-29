using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using static Raylib.Raylib;

namespace Hierarchies
{
    class Animal : SpriteObject
    {
        public Vector3 Position = new Vector3();
        public int speed = 1; //How "fast" it can go
        public string name = "NotListed";
        Random random = new Random();
        int tempX;
        int tempY;
        public int moveTime = 10;
        bool start = true;
        int screenWidth = 1200;
        int screenHeight = 900;

        /// <summary>
        /// Gives a new random directions
        /// </summary>
        public void NewRand()
        {
            tempX = random.Next(3);
            tempY = random.Next(3);
        }

        public void RunUpdate()
        {
            //buttonAction = false;
            // gives a random deriton to start
            if (start)
            {
                NewRand();
                start = false;
            }


            //Screen Wrap
            if (globalTransform.m7 > screenWidth)
            {
                //globalTransform.m7 = -30;
                globalTransform.SetTranslation(-30, GlobalTransform.m8);
            }
            if (globalTransform.m7 < -30)
            {
                //globalTransform.m7 = screenWidth;
                globalTransform.SetTranslation(screenWidth, GlobalTransform.m8);
            }
            if (globalTransform.m8 > screenHeight)
            {
                //globalTransform.m8 = -30;
                globalTransform.SetTranslation(GlobalTransform.m7, -30);
            }
            if (globalTransform.m8 < -30)
            {
                //globalTransform.m8 = screenHeight;
                globalTransform.SetTranslation(GlobalTransform.m7, screenHeight);
            }

            //if the time is not up
            //then the animal can move 
            if (moveTime > 0)
            {

                if (tempY == 2)
                {
                    //up
                    //globalTransform.m8 -= speed;
                    Translate(0, -speed);
                }
                if (tempY == 1)
                {
                    //down
                    //globalTransform.m8 += speed;
                    Translate(0, speed);
                }
                if (tempX == 2)
                {
                    //left
                    //globalTransform.m7 -= speed;
                    Translate(-speed, 0);
                }
                if (tempX == 1)
                {
                    //right
                    //globalTransform.m7 += speed;
                    Translate(speed, 0);
                }

            }
            //if not then change drection and give a new time
            else
            {
                NewRand();
                moveTime = random.Next(25, 50);
            }
            moveTime--;
            
        }
    }
}
