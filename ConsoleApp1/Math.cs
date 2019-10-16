using System;
using System.Collections.Generic;
using System.Text;

namespace Hierarchies
{
    
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
    
    /// <summary>
    /// A Vector with three floats (X,Y,Z)
    /// </summary>
    public struct Vector3
    {
        public float x, y, z;

        public Vector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        /// <summary>
        /// Finds the distance between two Vector3
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float Distance(Vector3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }
        /// <summary>
        /// Finds the distance square between two Vector3
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float DistanceSqr(Vector3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (diffX * diffX + diffY * diffY + diffZ * diffZ);
        }

        /// <summary>
        /// Finds the magnitude of the Vector3
        /// </summary>
        /// <returns></returns>
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        /// <summary>
        /// Finds the magnitude square of the Vector3
        /// </summary>
        /// <returns></returns>
        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z);
        }
        /// <summary>
        /// Finds the min between two points
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Min(a.x, b.x), Math.Min(a.y, b.y), Math.Min(a.z, b.z));
        }
        /// <summary>
        /// Finds the max between two points
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Max(a.x, b.x), Math.Max(a.y, b.y), Math.Max(a.z, b.z));
        }

        public static Vector3 Clamp(Vector3 t, Vector3 a, Vector3 b)
        {
            
            return Max(a, Min(b, t));
        }

        /// <summary>
        /// Adds a point and a vector
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        /// <summary>
        /// subtracts a point and a vector
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        /// <summary>
        /// Scales a vector with a float
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        /// <summary>
        /// Scales a vector with a float
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Finds the dot prodect
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public float Dot(Vector3 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z;
        }
        /// <summary>
        /// finds the cross prodect
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3(
            y * rhs.z - z * rhs.y,
            z * rhs.x - x * rhs.z,
            x * rhs.y - y * rhs.x);
        }
        /// <summary>
        /// finds the angle between the two vectors
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float AngleBetween(Vector3 other)
        {

            Vector3 a = Normalize();
            Vector3 b = other.Normalize();


            float d = a.Dot(b);


            return (float)Math.Acos(d);
        }
        /// <summary>
        /// multiplication a matrix3 by a vector3
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
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
    public struct Vector4
    {
        public float x, y, z, w;

        
        public Vector4(float _x, float _y, float _z, float _w)
        {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }
        public float Distance(Vector4 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }
        public float DistanceSqr(Vector4 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;
            return (diffX * diffX + diffY * diffY + diffZ * diffZ);
        }


        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }
        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z + w * w);
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }
        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        }
        public static Vector4 operator *(float rhs, Vector4 lhs)
        {
            return new Vector4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        }
        public static Vector4 operator /(Vector4 lhs, float rhs)
        {
            return new Vector4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }
        public Vector4 Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
            w /= m;
            return this;
        }
        public float Dot(Vector4 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z + w * rhs.w;
        }
        public Vector4 Cross(Vector4 rhs)
        {
            return new Vector4(
            y * rhs.z - z * rhs.y,
            z * rhs.x - x * rhs.z,
            x * rhs.y - y * rhs.x,
            0);
        }
        public float AngleBetween(Vector4 other)
        {

            Vector4 a = Normalize();
            Vector4 b = other.Normalize();


            float d = a.Dot(b);


            return (float)Math.Acos(d);
        }
        //m1 , m2 , m3 , m4
        //m5 , m6 , m7 , m8
        //m9 , m10, m11, m12
        //m13, m14, m15, m16
        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4((lhs.m1 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m9 * rhs.z) + (lhs.m13 * rhs.w),
                        (lhs.m2 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m10 * rhs.z) + (lhs.m14 * rhs.w),
                        (lhs.m3 * rhs.x) + (lhs.m7 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m15 * rhs.w),
                        (lhs.m4 * rhs.x) + (lhs.m8 * rhs.y) + (lhs.m12 * rhs.z) + (lhs.m16 * rhs.w));
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
    }
    /// <summary>
    /// Makes a Matrix3
    /// </summary>
    public class Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
        //m1 , m4 , m7
        //m2 , m5 , m8
        //m3 , m6 , m9
        /// <summary>
        /// Makes a identity Matrix
        /// </summary>
        public Matrix3()
        {
            m1 = 1; m2 = 0; m3 = 0;
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
        }
        /// <summary>
        /// Sets the matrix3 by a matrix3
        /// </summary>
        /// <param name="m"></param>
        public void Set(Matrix3 m)
        {
            m1 = m.m1; m2 = m.m2; m3 = m.m3;
            m4 = m.m4; m5 = m.m5; m6 = m.m6;
            m7 = m.m7; m8 = m.m8; m9 = m.m9;
        }
        /// <summary>
        /// sets the matrix
        /// </summary>
        /// <param name="_m1"></param>
        /// <param name="_m2"></param>
        /// <param name="_m3"></param>
        /// <param name="_m4"></param>
        /// <param name="_m5"></param>
        /// <param name="_m6"></param>
        /// <param name="_m7"></param>
        /// <param name="_m8"></param>
        /// <param name="_m9"></param>
        public void Set(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        {
            m1 = _m1; m2 = _m2; m3 = _m3;
            m4 = _m4; m5 = _m5; m6 = _m6;
            m7 = _m7; m8 = _m8; m9 = _m9;
        }
        /// <summary>
        /// Makes a matrix (3x3)
        /// </summary>
        /// <param name="_m1"></param>
        /// <param name="_m2"></param>
        /// <param name="_m3"></param>
        /// <param name="_m4"></param>
        /// <param name="_m5"></param>
        /// <param name="_m6"></param>
        /// <param name="_m7"></param>
        /// <param name="_m8"></param>
        /// <param name="_m9"></param>
        public Matrix3(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
        {
            m1 = _m1; m2 = _m2; m3 = _m3;
            m4 = _m4; m5 = _m5; m6 = _m6;
            m7 = _m7; m8 = _m8; m9 = _m9;
        }
        /// <summary>
        /// Scales the matrix by Three floats and sets it
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0;
            m4 = 0; m5 = y; m6 = 0;
            m7 = 0; m8 = 0; m9 = z;
        }
        /// <summary>
        /// Scales the matrix by a vector and sets it
        /// </summary>
        /// <param name="v"></param>
        public void SetScaled(Vector3 v)
        {
            m1 = v.x; m2 = 0; m3 = 0;
            m4 = 0; m5 = v.y; m6 = 0;
            m7 = 0; m8 = 0; m9 = v.z;
        }
        /// <summary>
        /// Scales the matrix by Three floats
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);

            Set(this * m);
        }
        /// <summary>
        /// Scales the matrix by Three floats
        /// </summary>
        /// <param name="v"></param>
        public void Scale(Vector3 v)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(v.x, v.y, v.z);

            Set(this * m);
        }
        /// <summary>
        /// Rotates around the X axis and Sets the matrix
        /// </summary>
        /// <param name="radians"></param>
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
        /// <summary>
        /// Rotates around the Y axis and Sets the matrix
        /// </summary>
        /// <param name="radians"></param>
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
        /// <summary>
        /// Rotates around the Z axis and Sets the matrix
        /// </summary>
        /// <param name="radians"></param>
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
            //m1 , m4 , m7
            //m2 , m5 , m8
            //m3 , m6 , m9
            return new Matrix3(
            lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3, lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3, lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,
            lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6, lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6, lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6,
            lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9, lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9, lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9);
        }
        /// <summary>
        /// Set the Euler
        /// </summary>
        /// <param name="pitch"></param>
        /// <param name="yaw"></param>
        /// <param name="roll"></param>
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
        /// <summary>
        /// Sets the translation
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetTranslation(float x, float y)
        {
            m7 = x; m8 = y; m9 = 1;
        }
        /// <summary>
        /// apply vector offset
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
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
        public static Matrix4 operator *(Matrix4 rhs, Matrix4 lhs)
        {
            return new Matrix4(
                lhs.m1 * rhs.m1 + lhs.m2 * rhs.m5 + lhs.m3 * rhs.m9 + lhs.m4 * rhs.m13, lhs.m1 * rhs.m2 + lhs.m2 * rhs.m6 + lhs.m3 * rhs.m10 + lhs.m4 * rhs.m14, lhs.m1 * rhs.m3 + lhs.m2 * rhs.m7 + lhs.m3 * rhs.m11 + lhs.m4 * rhs.m15, lhs.m1 * rhs.m4 + lhs.m2 * rhs.m8 + lhs.m3 * rhs.m12 + lhs.m4 * rhs.m16,
                lhs.m5 * rhs.m1 + lhs.m6 * rhs.m5 + lhs.m7 * rhs.m9 + lhs.m8 * rhs.m13, lhs.m5 * rhs.m2 + lhs.m6 * rhs.m6 + lhs.m7 * rhs.m10 + lhs.m8 * rhs.m14, lhs.m5 * rhs.m3 + lhs.m6 * rhs.m7 + lhs.m7 * rhs.m11 + lhs.m8 * rhs.m15, lhs.m5 * rhs.m4 + lhs.m6 * rhs.m8 + lhs.m7 * rhs.m12 + lhs.m8 * rhs.m16,
                lhs.m9 * rhs.m1 + lhs.m10 * rhs.m5 + lhs.m11 * rhs.m9 + lhs.m12 * rhs.m13, lhs.m9 * rhs.m2 + lhs.m10 * rhs.m6 + lhs.m11 * rhs.m10 + lhs.m12 * rhs.m14, lhs.m9 * rhs.m3 + lhs.m10 * rhs.m7 + lhs.m11 * rhs.m11 + lhs.m12 * rhs.m15, lhs.m9 * rhs.m4 + lhs.m10 * rhs.m8 + lhs.m11 * rhs.m12 + lhs.m12 * rhs.m16,
                lhs.m13 * rhs.m1 + lhs.m14 * rhs.m5 + lhs.m15 * rhs.m9 + lhs.m16 * rhs.m13, lhs.m13 * rhs.m2 + lhs.m14 * rhs.m6 + lhs.m15 * rhs.m10 + lhs.m16 * rhs.m14, lhs.m13 * rhs.m3 + lhs.m14 * rhs.m7 + lhs.m15 * rhs.m11 + lhs.m16 * rhs.m15, lhs.m13 * rhs.m4 + lhs.m14 * rhs.m8 + lhs.m15 * rhs.m12 + lhs.m16 * rhs.m16);
        }
        public void SetRotateX(double radians)
        {
            Set(
               1, 0, 0, 0,
               0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
               0, (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
               0, 0, 0, 1);
        }
        public void SetRotateY(double radians)
        {
            Set(
               (float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 0,
                0, 1, 0, 0,
                (float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }
        public void SetRotateZ(double radians)
        {
            Set(
               (float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }
        public void Set(float _m1, float _m2, float _m3, float _m4, float _m5, float _m6, float _m7, float _m8, float _m9, float _m10, float _m11, float _m12, float _m13, float _m14, float _m15, float _m16)
        {
            m1 = _m1; m2 = _m2; m3 = _m3; m4 = _m4;
            m5 = _m5; m6 = _m6; m7 = _m7; m8 = _m8;
            m9 = _m9; m10 = _m10; m11 = _m11; m12 = _m12;
            m13 = _m13; m14 = _m14; m15 = _m15; m16 = _m16;
        }
    }
}
