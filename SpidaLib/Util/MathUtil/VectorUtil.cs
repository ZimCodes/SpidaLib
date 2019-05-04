using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.SpidaLib.Util
{
    public static class VectorUtil
    {
        public static Vector4 UnitX { get { return new Vector4(1, 0, 0, 0); } }
        public static Vector4 UnitY { get { return new Vector4(0, 1, 0, 0); } }
        public static Vector4 UnitZ { get { return new Vector4(0, 0, 1, 0); } }
        public static Vector4 UnitW { get { return new Vector4(0, 0, 0, 1); } }
        #region VECTOR UTIL
        /// <summary>
        /// Finds the Angle between two Vectors
        /// </summary>
        /// <returns>The angles.</returns>
        /// <param name="vectorU">Vector u.</param>
        /// <param name="vectorV">Vector v.</param>
        public static float VectorAngle(Vector2 vectorU, Vector2 vectorV)
        {
            float vectors = Vector2.Dot(vectorU, vectorV);
            float magnitude = vectorU.magnitude * vectorV.magnitude;
            float normal = vectors / magnitude;
            float angleInRadian = (float)Mathf.Acos(normal);
            float convertToDegrees = Mathf.Rad2Deg * angleInRadian;
            return convertToDegrees;
        }
        public static float VectorAngle(Vector3 vectorU, Vector3 vectorV)
        {
            float vectors = Vector3.Dot(vectorU, vectorV);
            float magnitude = vectorU.magnitude * vectorV.magnitude;
            float normal = vectors / magnitude;
            float angleInRadian = (float)Mathf.Acos(normal);
            float convertToDegrees = Mathf.Rad2Deg * angleInRadian;
            return convertToDegrees;
        }
        public static float VectorAngle(Vector4 vectorU, Vector4 vectorV)
        {
            float vectors = Vector4.Dot(vectorU, vectorV);
            float magnitude = vectorU.magnitude * vectorV.magnitude;
            float normal = vectors / magnitude;
            float angleInRadian = (float)Mathf.Acos(normal);
            float convertToDegrees = Mathf.Rad2Deg * angleInRadian;
            return convertToDegrees;
        }
        /// <summary>
        /// Gives the Projected Vector of Vector A if Vector A was going the same direction as Vector B.
        /// </summary>
        /// <param name="vectorA">The Vector that will be projecting onto Vector B</param>
        /// <param name="vectorB">The Vector being projected upon</param>
        public static Vector2 Projection(Vector2 vectorA, Vector2 vectorB)
        {
            float scalarC = (Vector2.Dot(vectorA, vectorB)) / (Vector2.Dot(vectorB, vectorB));
            Vector2 projVector = scalarC * vectorB;
            return projVector;
        }
        public static Vector3 Projection(Vector3 vectorA, Vector3 vectorB)
        {
            float scalarC = (Vector3.Dot(vectorA, vectorB)) / (Vector3.Dot(vectorB, vectorB));
            Vector3 projVector = scalarC * vectorB;
            return projVector;
        }
        public static Vector4 Projection(Vector4 vectorA, Vector4 vectorB)
        {
            float scalarC = (Vector4.Dot(vectorA, vectorB)) / (Vector4.Dot(vectorB, vectorB));
            Vector4 projVector = scalarC * vectorB;
            return projVector;
        }
        /// <summary>
        /// Provides a Vector Orthogonal to the Projected Vector
        /// </summary>
        /// <param name="vectorA">The Vector that will be projecting onto Vector B.</param>
        /// <param name="vectorB">The Vector being projected upon</param>
        public static Vector2 Perpendicular(Vector2 vectorA, Vector2 vectorB)
        {
            return vectorA - Projection(vectorA, vectorB);
        }
        public static Vector3 Perpendicular(Vector3 vectorA, Vector3 vectorB)
        {
            return vectorA - Projection(vectorA, vectorB);
        }
        public static Vector4 Perpendicular(Vector4 vectorA, Vector4 vectorB)
        {
            return vectorA - Projection(vectorA, vectorB);
        }
        /// <summary>
        /// Converts 3D Vectors to 2D.
        /// </summary>
        /// <returns>returns a Vector2</returns>
        /// <param name="vector">Vector3 to convert.</param>
        public static Vector2 ConvertTo2D(Vector3 vector)
        {
            Vector2 result;
            result.x = vector.x + (2 * vector.y);
            result.y = 3 * vector.z;
            return result;
        }
        /// <summary>
        /// Multiply the Vectors using Matrix Multiplication
        /// </summary>
        /// <param name="vectA">First Vector</param>
        /// <param name="vectB">Second Vector</param>
        /// <returns>Returns the resulting Vector2 of the matrix multiplication</returns>
        public static Vector2 VectorMatrixMultiply(Vector2 vectA, Vector2 vectB)
        {
            Vector2 result;
            result.x = vectA.x * vectB.x + vectA.y * vectB.x;
            result.y = vectA.x * vectB.y + vectA.y * vectB.y;
            return result;
        }
        /// <summary>
        /// Multiply the Vectors using Matrix Multiplication
        /// </summary>
        /// <param name="vectA">First Vector</param>
        /// <param name="vectB">Second Vector</param>
        /// <returns>Returns the resulting Vector3 of the matrix multiplication</returns>
        public static Vector3 VectorMatrixMultiply(Vector3 vectA, Vector3 vectB)
        {
            Vector3 result;
            result.x = (vectA.x * vectB.x) + (vectA.y * vectB.x) + (vectA.z * vectB.x);
            result.y = (vectA.x * vectB.y) + (vectA.y * vectB.y) + (vectA.z * vectB.y);
            result.z = (vectA.x * vectB.z) + (vectA.y * vectB.z) + (vectA.z * vectB.z);
            return result;
        }
        /// <summary>
        /// Multiply the Vectors using Matrix Multiplication
        /// </summary>
        /// <param name="vectA">First Vector</param>
        /// <param name="vectB">Second Vector</param>
        /// <returns>Returns the resulting Vector4 of the matrix multiplication</returns>
        public static Vector4 VectorMatrixMultiply(Vector4 vectA, Vector4 vectB)
        {
            Vector4 result;
            result.x = (vectA.x * vectB.x) + (vectA.y * vectB.x) + (vectA.z * vectB.x) + (vectA.w * vectB.x);
            result.y = (vectA.x * vectB.y) + (vectA.y * vectB.y) + (vectA.z * vectB.y) + (vectA.w * vectB.y);
            result.z = (vectA.x * vectB.z) + (vectA.y * vectB.z) + (vectA.z * vectB.z) + (vectA.w * vectB.z);
            result.w = (vectA.x * vectB.w) + (vectA.y * vectB.w) + (vectA.z * vectB.w) + (vectA.w * vectB.w);
            return result;
        }
        #endregion
        /// <summary>
        /// Multiplies the vector and matrix.
        /// </summary>
        /// <returns>The vector</returns>
        /// <param name="vector">Vector.</param>
        /// <param name="matrix">Matrix.</param>
        public static Vector2 MultiplyVectAndMatrix(Vector2 vector, Matrix4x4 matrix)
        {
            Vector2 Result;
            Result.x = vector.x * matrix.m00 + vector.y * matrix.m10;
            Result.y = vector.x * matrix.m01 + vector.y * matrix.m11;
            return Result;
        }
        public static Vector3 MultiplyVectAndMatrix(Vector3 vector, Matrix4x4 matrix)
        {
            Vector3 Result;
            Result.x = vector.x * matrix.m00 + vector.y * matrix.m10 + vector.z * matrix.m20;
            Result.y = vector.x * matrix.m01 + vector.y * matrix.m11 + vector.z * matrix.m21;
            Result.z = vector.x * matrix.m02 + vector.y * matrix.m12 + vector.z * matrix.m22;
            return Result;
        }
        public static Vector4 MultiplyVectAndMatrix(Vector4 vector, Matrix4x4 matrix)
        {
            Vector4 Result;
            Result.x = vector.x * matrix.m00 + vector.y * matrix.m10 + vector.z * matrix.m20 + vector.w * matrix.m30;
            Result.y = vector.x * matrix.m01 + vector.y * matrix.m11 + vector.z * matrix.m21 + vector.w * matrix.m31;
            Result.z = vector.x * matrix.m02 + vector.y * matrix.m12 + vector.z * matrix.m22 + vector.w * matrix.m32;
            Result.w = vector.x * matrix.m03 + vector.y * matrix.m13 + vector.z * matrix.m23 + vector.w * matrix.m33;
            return Result;
        }
    }
}
