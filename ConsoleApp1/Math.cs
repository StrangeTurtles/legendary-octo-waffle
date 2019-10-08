using System;
using System.Collections.Generic;
using System.Text;

namespace Hierarchies
{
    public struct Point2
    {
        public float x, y;

        public Point2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
        public float Distance(Point2 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY);
        }
        public float Distance(Vector2 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY);
        }

        public static Point2 operator +(Point2 lhs, Point2 rhs)
        {
            return new Point2(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static Point2 operator -(Point2 lhs, Point2 rhs)
        {
            return new Point2(lhs.x - rhs.x, lhs.y - rhs.y);
        }
        public static Point2 operator *(Point2 lhs, float rhs)
        {
            return new Point2(lhs.x * rhs, lhs.y * rhs);
        }
        public static Point2 operator /(Point2 lhs, float rhs)
        {
            return new Point2(lhs.x / rhs, lhs.y / rhs);
        }
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
    public struct Vector2
    {
        public float x, y;
        /// <summary>
        /// Vector2
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }
        public float MagnitudeSqr()
        {
            return (x * x + y * y);
        }
        public float Distance(Vector2 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY);
        }
        public float DistanceSqr(Vector2 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            return diffX * diffX + diffY * diffY;
        }
        public float Distance(Point2 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY);
        }
        public float DistanceSqr(Point2 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            return diffX * diffX + diffY * diffY;
        }
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }
        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x * rhs, lhs.y * rhs);
        }
        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x / rhs, lhs.y / rhs);
        }
        public Vector2 Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            return this;
        }
        public float Dot(Vector2 rhs)
        {
            return x * rhs.x + y * rhs.y;
        }
        public Vector2 GetPerpendicularRH()
        {
            return new Vector2(-y, x);
        }
        public Vector2 GetPerpendicularLH()
        {
            return new Vector2(y, -x);
        }
        public float AngleBetween(Vector2 other)
        {

            Vector2 a = Normalize();
            Vector2 b = other.Normalize();


            float d = a.Dot(b);


            return (float)Math.Acos(d);
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
    public struct Point3
    {
        public float x, y, z;

        public Point3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        public float Distance(Point3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }
        public float Distance(Vector3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }

        public static Point3 operator +(Point3 lhs, Point3 rhs)
        {
            return new Point3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        public static Point3 operator -(Point3 lhs, Point3 rhs)
        {
            return new Point3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        public static Point3 operator *(Point3 lhs, float rhs)
        {
            return new Point3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Point3 operator /(Point3 lhs, float rhs)
        {
            return new Point3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }
        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
    }
    public struct Vector3
    {
        public float x, y, z;

        public Vector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        public float Distance(Vector3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }
        public float DistanceSqr(Vector3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (diffX * diffX + diffY * diffY + diffZ * diffZ);
        }
        public float Distance(Point3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z);
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }
        public Vector3 Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
            return this;
        }
        public float Dot(Vector3 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z;
        }
        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3(
            y * rhs.z - z * rhs.y,
            z * rhs.x - x * rhs.z,
            x * rhs.y - y * rhs.x);
        }
        public float AngleBetween(Vector3 other)
        {

            Vector3 a = Normalize();
            Vector3 b = other.Normalize();


            float d = a.Dot(b);


            return (float)Math.Acos(d);
        }
        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3((lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z),
                        (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z),
                        (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z));
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
    }
    public struct Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
        //m1 , m2 , m3
        //m4 , m5 , m6
        //m7 , m8 , m9
        public void Set(Matrix3 m)
        {
            m1 = m.m1; m2 = m.m2; m3 = m.m3;
            m4 = m.m4; m5 = m.m5; m6 = m.m6;
            m7 = m.m7; m8 = m.m8; m9 = m.m9;
        }
        public void Set(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        {
            m1 = _m1; m2 = _m2; m3 = _m3;
            m4 = _m4; m5 = _m5; m6 = _m6;
            m7 = _m7; m8 = _m8; m9 = _m9;
        }
        public Matrix3(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        {
            m1 = _m1; m2 = _m2; m3 = _m3;
            m4 = _m4; m5 = _m5; m6 = _m6;
            m7 = _m7; m8 = _m8; m9 = _m9;
        }
        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0;
            m4 = 0; m5 = y; m6 = 0;
            m7 = 0; m8 = 0; m9 = z;
        }
        public void SetScaled(Vector3 v)
        {
            m1 = v.x; m2 = 0; m3 = 0;
            m4 = 0; m5 = v.y; m6 = 0;
            m7 = 0; m8 = 0; m9 = v.z;
        }
        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);

            Set(this * m);
        }
        public void Scale(Vector3 v)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(v.x, v.y, v.z);

            Set(this * m);
        }
        public void SetRotateX(double radians)
        {
            Set(1, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(radians),
                0, (float)-Math.Sin(radians), (float)Math.Cos(radians));
        }
        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);
            Set(this * m);
        }
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)-Math.Sin(radians),
                0, 1, 0,
                (float)Math.Sin(radians), 0, (float)Math.Cos(radians));
        }
        public void RotateY(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);
            Set(this * m);
        }
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1);
        }
        public void RotateZ(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);
            Set(this * m);
        }
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
            lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3, lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3, lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,
            lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6, lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6, lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6,
            lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9, lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9, lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9);
        }
        void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            Set(z * y * x);
        }
        public void SetTranslation(float x, float y)
        {
            m7 = x; m8 = y; m9 = 1;
        }
        public void Translate(float x, float y)
        {
            // apply vector offset
            m7 += x; m8 += y;
        }
        public override string ToString()
        {
            return $"({m1},{m2},{m3},{m4},{m5},{m6},{m7},{m8},{m9})";
        }
    }
    public struct Matrix2
    {
        public float m1, m2, m3, m4;
        //m1 , m2 
        //m3 , m4 
        public void Set(Matrix2 m)
        {
            m1 = m.m1; m2 = m.m2;
            m3 = m.m3; m4 = m.m4;
        }
        public void Set(float _m1, float _m2, float _m3, float _m4)
        {
            m1 = _m1; m2 = _m2;
            m3 = _m3; m4 = _m4;
        }
        public void SetRotate(double radians)
        {
            Set((float)Math.Cos(radians), (float)Math.Sin(radians),
                (float)-Math.Sin(radians), (float)Math.Cos(radians));
        }
        public void Rotate(double radians)
        {
            Matrix2 m = new Matrix2();
            m.SetRotate(radians);
            Set(this * m);
        }
        public void SetScaled(float x, float y)
        {
            m1 = x; m2 = 0;
            m3 = 0; m4 = y;
        }
        public void Scale(float x, float y)
        {
            Matrix2 m = new Matrix2();
            m.SetScaled(x, y);

            Set(this * m);
        }
        public Matrix2(float _m1, float _m2, float _m3, float _m4)
        {
            m1 = _m1; m2 = _m2;
            m3 = _m3; m4 = _m4;
        }
        public static Matrix2 operator *(Matrix2 lhs, Matrix2 rhs)
        {
            return new Matrix2(
            lhs.m1 * rhs.m1 + lhs.m2 * rhs.m3, lhs.m1 * rhs.m2 + lhs.m2 * rhs.m4,
            lhs.m3 * rhs.m1 + lhs.m4 * rhs.m3, lhs.m3 * rhs.m2 + lhs.m4 * rhs.m4);
        }
        public override string ToString()
        {
            return $"({m1},{m2},{m3},{m4})";
        }
    }
    public struct Matrix4
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;
        //m1 , m2 , m3 , m4
        //m5 , m6 , m7 , m8
        //m9 , m10, m11, m12
        //m13, m14, m15, m16
        public Matrix4(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9, float _m10, float _m11, float _m12, float _m13, float _m14, float _m15, float _m16)
        {
            m1 = _m1; m2 = _m2; m3 = _m3; m4 = _m4;
            m5 = _m5; m6 = _m6; m7 = _m7; m8 = _m8;
            m9 = _m9; m10 = _m10; m11 = _m11; m12 = _m12;
            m13 = _m13; m14 = _m14; m15 = _m15; m16 = _m16;
        }
        //public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        //{
        //    return new Matrix4(
        //        0,0,0,0,
        //        0,0,0,0,
        //        0,0,0,0,
        //        0,0,0,0);
        //}
    }
}
