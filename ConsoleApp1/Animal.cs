using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using static Raylib.Raylib;

namespace Hierarchies
{
    class Animal
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
            if (Position.x > screenWidth)
            {
                Position.x = -30;
            }
            if (Position.x < -30)
            {
                Position.x = screenWidth;
            }
            if (Position.y > screenHeight)
            {
                Position.y = -30;
            }
            if (Position.y < -30)
            {
                Position.y = screenHeight;
            }

            //if the time is not up
            //then the animal can move 
            if (moveTime > 0)
            {

                if (tempY == 2)
                {
                    //up
                    Position.y -= speed;
                }
                if (tempY == 1)
                {
                    //down
                    Position.y += speed;
                }
                if (tempX == 2)
                {
                    //left
                    Position.x -= speed;
                }
                if (tempX == 1)
                {
                    //right
                    Position.x += speed;
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
