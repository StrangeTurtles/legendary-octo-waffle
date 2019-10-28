using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using static Raylib.Raylib;

namespace Hierarchies
{
    /// <summary>
    /// an Axis Aligned Bounding Box Collider
    /// </summary>
    class AABB
    {
        Vector3 min = new Vector3(float.NegativeInfinity,
            float.NegativeInfinity,
            float.NegativeInfinity);
        Vector3 max = new Vector3(float.PositiveInfinity,
            float.PositiveInfinity,
            float.PositiveInfinity);
        /// <summary>
        /// Makes an Axis Aligned Bounding Box 
        /// </summary>
        public AABB()
        {
        }
        /// <summary>
        /// Makes an Axis Aligned Bounding Box 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public AABB(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }
        /// <summary>
        /// Finds the Center of the AABB
        /// </summary>
        /// <returns></returns>
        public Vector3 Center()
        {
            return (min + max) * 0.5f;
        }
        /// <summary>
        /// Finds the extents of the AABB
        /// </summary>
        /// <returns></returns>
        public Vector3 Extents()
        {
            return new Vector3(Math.Abs(max.x - min.x) * 0.5f,
            Math.Abs(max.y - min.y) * 0.5f,
            Math.Abs(max.z - min.z) * 0.5f);
        }
        /// <summary>
        /// Finds the Width of the AABB
        /// </summary>
        /// <returns></returns>
        public float Width()
        {
            return Math.Abs(max.x - min.x);
        }
        /// <summary>
        /// Finds the Height of the AABB
        /// </summary>
        /// <returns></returns>
        public float Height()
        {
            return Math.Abs(max.y - min.y);
        }
        /// <summary>
        /// Finds the 4 corners of the AABB
        /// </summary>
        /// <returns></returns>
        public List<Vector3> Corners()
        {
            // ignoring z axis for 2D
            List<Vector3> corners = new List<Vector3>();
            corners.Add(min);
            corners.Add(new Vector3(min.x, max.y, min.z));
            corners.Add(max);
            corners.Add(new Vector3(max.x, min.y, min.z));
            return corners;
        }
        /// <summary>
        /// using a List of points it changes the box to fit them
        /// </summary>
        /// <param name="points"></param>
        public void Fit(List<Vector3> points)
        {
            // invalidate the extents
            min = new Vector3(float.PositiveInfinity,
            float.PositiveInfinity,
           float.PositiveInfinity);
            max = new Vector3(float.NegativeInfinity,
            float.NegativeInfinity,
           float.NegativeInfinity);
            // find min and max of the points
            foreach (Vector3 p in points)
            {
                min = Vector3.Min(min, p);
                max = Vector3.Max(max, p);
            }
        }

        /// <summary>
        /// using an array of points it changes the box to fit them
        /// </summary>
        /// <param name="points"></param>
        public void Fit(Vector3[] points)
        {
            // invalidate the extents
            min = new Vector3(float.PositiveInfinity,
            float.PositiveInfinity,
            float.PositiveInfinity);
            max = new Vector3(float.NegativeInfinity,
            float.NegativeInfinity,
           float.NegativeInfinity);
            // find min and max of the points
            foreach (Vector3 p in points)
            {
                min = Vector3.Min(min, p);
                max = Vector3.Max(max, p);
            }
        }
        /// <summary>
        /// see if the AABBB overlaps a point
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Overlaps(Vector3 p)
        {
            // test for not overlapped as it exits faster
            return !(p.x < min.x || p.y < min.y ||
            p.x > max.x || p.y > max.y);
        }
        /// <summary>
        /// sees if the AABB overlaps an AABB
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Overlaps(AABB other)
        {
            // test for not overlapped as it exits faster
            return !(max.x < other.min.x || max.y < other.min.y ||
            min.x > other.max.x || min.y > other.max.y);
        }
        /// <summary>
        /// Finds the closest point on the AABB to the min and max Corners
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Vector3 ClosestPoint(Vector3 p)
        {
            return Vector3.Clamp(p, min, max);
        }
        /// <summary>
        /// Draws the AABB
        /// </summary>
        public void Draw()
        {
            DrawLine((int)Corners()[0].x, (int)Corners()[0].y, (int)Corners()[1].x, (int)Corners()[1].y, Color.RED);
            DrawLine((int)Corners()[1].x, (int)Corners()[1].y, (int)Corners()[2].x, (int)Corners()[2].y, Color.RED);
            DrawLine((int)Corners()[2].x, (int)Corners()[2].y, (int)Corners()[3].x, (int)Corners()[3].y, Color.RED);
            DrawLine((int)Corners()[3].x, (int)Corners()[3].y, (int)Corners()[0].x, (int)Corners()[0].y, Color.RED);
        }
    }
}
