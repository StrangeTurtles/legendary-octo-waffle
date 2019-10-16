using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using static Raylib.Raylib;

namespace Hierarchies
{
    class AABB
    {
        Vector3 min = new Vector3(float.NegativeInfinity,
            float.NegativeInfinity,
            float.NegativeInfinity);
        Vector3 max = new Vector3(float.PositiveInfinity,
            float.PositiveInfinity,
            float.PositiveInfinity);

        public AABB()
        {
        }
        public AABB(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }

        public Vector3 Center()
        {
            return (min + max) * 0.5f;
        }

        public Vector3 Extents()
        {
            return new Vector3(Math.Abs(max.x - min.x) * 0.5f,
            Math.Abs(max.y - min.y) * 0.5f,
            Math.Abs(max.z - min.z) * 0.5f);
        }

        public float Width()
        {
            return Math.Abs(max.x - min.x);
        }

        public float Height()
        {
            return Math.Abs(max.y - min.y);
        }

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

        public bool Overlaps(Vector3 p)
        {
            // test for not overlapped as it exits faster
            return !(p.x < min.x || p.y < min.y ||
            p.x > max.x || p.y > max.y);
        }

        public bool Overlaps(AABB other)
        {
            // test for not overlapped as it exits faster
            return !(max.x < other.min.x || max.y < other.min.y ||
            min.x > other.max.x || min.y > other.max.y);
        }

        public Vector3 ClosestPoint(Vector3 p)
        {
            return Vector3.Clamp(p, min, max);
        }

        public void Draw()
        {
            DrawLine((int)Corners()[0].x, (int)Corners()[0].y, (int)Corners()[1].x, (int)Corners()[1].y, Color.RED);
            DrawLine((int)Corners()[1].x, (int)Corners()[1].y, (int)Corners()[2].x, (int)Corners()[2].y, Color.RED);
            DrawLine((int)Corners()[2].x, (int)Corners()[2].y, (int)Corners()[3].x, (int)Corners()[3].y, Color.RED);
            DrawLine((int)Corners()[3].x, (int)Corners()[3].y, (int)Corners()[0].x, (int)Corners()[0].y, Color.RED);
        }
    }
}
