using System;
using System.Collections.Generic;
using System.Text;

namespace Hierarchies
{
    class Bear : SpriteObject
    {
        public Circle bearCollider = new Circle(new Vector3(), 5);
        List<Vector3> pointList = new List<Vector3>();
        SceneObject point0 = new SceneObject();
        SceneObject point1 = new SceneObject();
        SceneObject point2 = new SceneObject();
        SceneObject point3 = new SceneObject();
        /// <summary>
        /// makes a bear sprite
        /// </summary>
        public Bear()
        {

        }
    }
}
