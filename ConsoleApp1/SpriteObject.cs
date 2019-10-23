using Raylib;
using System;
using System.Collections.Generic;
using System.Text;
using static Raylib.Raylib;

namespace Hierarchies
{
    public class SpriteObject : SceneObject
    {
        Texture2D texture = new Texture2D();
        Image image = new Image();
        float scale = 1f;
        /// <summary>
        /// The width of the sprite
        /// </summary>
        public float Width
        {
            get { return texture.width; }
        }
        /// <summary>
        /// The height of the sprite
        /// </summary>
        public float Height
        {
            get { return texture.height; }
        }
        public SpriteObject()
        {
        }
        /// <summary>
        /// Loads the image
        /// </summary>
        /// <param name="filename"></param>
        public void Load(string filename)
        {
            if (Game.texture.ContainsKey(filename))
            {
                texture = Game.texture[filename];
            }
            else
            {
                Image img = LoadImage(filename);
                texture = LoadTextureFromImage(img);
                Game.texture.Add(filename, texture);
            }
        }
        public void ReScale(float newScale)
        {
            scale = newScale;
        }
        /// <summary>
        /// Draws the sprite
        /// </summary>
        public override void OnDraw()
        {
            float rotation = (float)Math.Atan2(
            globalTransform.m2, globalTransform.m1);

            DrawTextureEx(
            texture,
            new Raylib.Vector2(globalTransform.m7, globalTransform.m8),
            rotation * (float)(180.0f / Math.PI),
            scale, Color.WHITE);

           
        }
    }
}
