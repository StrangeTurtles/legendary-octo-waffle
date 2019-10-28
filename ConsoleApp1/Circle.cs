using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using static Raylib.Raylib;

namespace Hierarchies
{
    /// <summary>
    /// a circle Collider
    /// </summary>
    class Circle
    {
        Vector3 center = new Vector3();
        float radius = 0f;
        /// <summary>
        /// Makes a circle Collider
        /// </summary>
        public Circle()
        {

        }
        /// <summary>
        /// Makes a circle Collider
        /// </summary>
        /// <param name="p"></param>
        /// <param name="r"></param>
        public Circle(Vector3 p, float r)
        {
            center = p;
            radius = r;
        }
        /// <summary>
        /// Checks if a point overlaps with a circle
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Overlaps(Vector3 p)
        {
            Vector3 toPoint = p - center;
            return toPoint.MagnitudeSqr() <= (radius * radius);
        }
        /// <summary>
        /// Checks if a circle overlaps with another circle
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Overlaps(Circle other)
        {
            Vector3 diff = other.center - center;
            float r = radius + other.radius;
            return diff.MagnitudeSqr() <= (r * r);
        }
        /// <summary>
        /// Checks if an AABB overlaps with a circle
        /// </summary>
        /// <param name="aabb"></param>
        /// <returns></returns>
        public bool Overlaps(AABB aabb)
        {
            Vector3 diff = aabb.ClosestPoint(center) - center;
            return diff.Dot(diff) <= (radius * radius);
        }
        /// <summary>
        /// using an array of points it changes the circle to fit them
        /// </summary>
        /// <param name="points"></param>
        public void Fit(Vector3[] points)
        {
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            for (int i = 0; i < points.Length; ++i)
            {
                min = Vector3.Min(min, points[i]);
                max = Vector3.Max(max, points[i]);
            }
            center = (min + max) * 0.5f;
            radius = center.Distance(max);
        }
        /// <summary>
        /// using a list of points it changes the box to fit them
        /// </summary>
        /// <param name="points"></param>
        public void Fit(List<Vector3> points)
        {
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            foreach (Vector3 p in points)
            {
                min = Vector3.Min(min, p);
                max = Vector3.Max(max, p);
            }
            center = (min + max) * 0.5f;
            radius = center.Distance(max);
        }
        /// <summary>
        /// Draws the circle
        /// </summary>
        public void Draw()
        {
            DrawCircleLines((int)center.x, (int)center.y, radius, Color.RED);
        }
    }
}
