using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.SpidaLib.Util.MathUtil
{
    public static class MatrixUtil
    {
        #region MATRIX UTIL
        /// <summary>
        /// Cuts the matrix. It Deletes a row and column then returns a 3x3 Matrix
        /// </summary>
        /// <returns>The 3x3 matrix.</returns>
        /// <param name="matrix">Matrix.</param>
        /// <param name="row">Row to delete</param>
        /// <param name="column">Column to delete</param>
        public static Matrix4x4 CutMatrix(Matrix4x4 matrix, int row, int column)
        {
            //M00
            if (row == 1 && column == 1)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m11, matrix.m12, matrix.m13, 0),
                    new Vector4(matrix.m21, matrix.m22, matrix.m23, 0),
                    new Vector4(matrix.m31, matrix.m32, matrix.m33, 0),
                    VectorUtil.UnitW
                );
            }
            //M01
            if (row == 1 && column == 2)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m10, matrix.m12, matrix.m13, 0),
                    new Vector4(matrix.m20, matrix.m22, matrix.m23, 0),
                    new Vector4(matrix.m30, matrix.m32, matrix.m33, 0),
                    VectorUtil.UnitW
                );
            }
            //M02
            if (row == 1 && column == 3)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m10, matrix.m11, matrix.m13, 0),
                    new Vector4(matrix.m20, matrix.m21, matrix.m23, 0),
                    new Vector4(matrix.m30, matrix.m31, matrix.m33, 0),
                    VectorUtil.UnitW
                );
            }
            //M03
            if (row == 1 && column == 4)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m10, matrix.m11, matrix.m12, 0),
                    new Vector4(matrix.m20, matrix.m21, matrix.m22, 0),
                    new Vector4(matrix.m30, matrix.m31, matrix.m32, 0),
                    VectorUtil.UnitW
                );
            }

            //M10
            if (row == 2 && column == 1)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m01, matrix.m02, matrix.m03, 0),
                    new Vector4(matrix.m21, matrix.m22, matrix.m23, 0),
                    new Vector4(matrix.m31, matrix.m32, matrix.m33, 0),
                    VectorUtil.UnitW
                );
            }
            //M11
            if (row == 2 && column == 2)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m00, matrix.m02, matrix.m03, 0),
                    new Vector4(matrix.m20, matrix.m22, matrix.m23, 0),
                    new Vector4(matrix.m30, matrix.m32, matrix.m33, 0),
                    VectorUtil.UnitW
                );
            }
            //M12
            if (row == 2 && column == 3)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m00, matrix.m01, matrix.m03, 0),
                    new Vector4(matrix.m20, matrix.m21, matrix.m23, 0),
                    new Vector4(matrix.m30, matrix.m31, matrix.m33, 0),
                    VectorUtil.UnitW
                );
            }
            //M13
            if (row == 2 && column == 4)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m00, matrix.m01, matrix.m02, 0),
                    new Vector4(matrix.m20, matrix.m21, matrix.m22, 0),
                    new Vector4(matrix.m30, matrix.m31, matrix.m32, 0),
                    VectorUtil.UnitW
                );
            }
            //M20
            if (row == 3 && column == 1)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m01, matrix.m02, matrix.m03, 0),
                    new Vector4(matrix.m11, matrix.m12, matrix.m13, 0),
                    new Vector4(matrix.m31, matrix.m32, matrix.m33, 0),
                    VectorUtil.UnitW
                );
            }
            //M21
            if (row == 3 && column == 2)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m00, matrix.m02, matrix.m03, 0),
                    new Vector4(matrix.m10, matrix.m12, matrix.m13, 0),
                    new Vector4(matrix.m30, matrix.m32, matrix.m33, 0),
                    VectorUtil.UnitW
                );
            }
            //M22
            if (row == 3 && column == 3)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m00, matrix.m01, matrix.m03, 0),
                    new Vector4(matrix.m10, matrix.m11, matrix.m13, 0),
                    new Vector4(matrix.m30, matrix.m31, matrix.m33, 0),
                    VectorUtil.UnitW
                );
            }
            //M23
            if (row == 3 && column == 4)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m00, matrix.m01, matrix.m02, 0),
                    new Vector4(matrix.m10, matrix.m11, matrix.m12, 0),
                    new Vector4(matrix.m30, matrix.m31, matrix.m32, 0),
                    VectorUtil.UnitW
                );
            }
            //M30
            if (row == 4 && column == 1)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m01, matrix.m02, matrix.m03, 0),
                    new Vector4(matrix.m11, matrix.m12, matrix.m13, 0),
                    new Vector4(matrix.m21, matrix.m22, matrix.m23, 0),
                    VectorUtil.UnitW
                );
            }
            //M31
            if (row == 4 && column == 2)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m00, matrix.m02, matrix.m03, 0),
                    new Vector4(matrix.m10, matrix.m12, matrix.m13, 0),
                    new Vector4(matrix.m20, matrix.m22, matrix.m23, 0),
                    VectorUtil.UnitW
                );
            }
            //M32
            if (row == 4 && column == 3)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m00, matrix.m01, matrix.m03, 0),
                    new Vector4(matrix.m10, matrix.m11, matrix.m13, 0),
                    new Vector4(matrix.m20, matrix.m21, matrix.m23, 0),
                    VectorUtil.UnitW
                );
            }
            //M33
            if (row == 4 && column == 4)
            {
                matrix = new Matrix4x4(
                    new Vector4(matrix.m00, matrix.m01, matrix.m02, 0),
                    new Vector4(matrix.m10, matrix.m11, matrix.m12, 0),
                    new Vector4(matrix.m20, matrix.m21, matrix.m22, 0),
                    VectorUtil.UnitW

                );
            }
            return matrix;
        }
        /// <summary>
        /// Inverse of specified matrix.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        public static Matrix4x4 MatrixInverse(Matrix4x4 matrix)
        {
            return Matrix4x4.Inverse(matrix);
        }
        #endregion
        /// <summary>
        /// Multiplies the matrix and vector. Row Major
        /// </summary>
        /// <returns>a matrix</returns>
        /// <param name="vector">Vector.</param>
        /// <param name="matrix">Matrix.</param>
        public static Matrix4x4 MultiplyMatrixAndVect(Vector2 vector, Matrix4x4 matrix)
        {
            Matrix4x4 Result = new Matrix4x4();
            Result.m03 = vector.x * matrix.m00 + vector.y * matrix.m10;
            Result.m13 = vector.x * matrix.m01 + vector.y * matrix.m11;
            return Result;
        }
        public static Matrix4x4 MultiplyMatrixAndVect(Vector3 vector, Matrix4x4 matrix)
        {
            Matrix4x4 Result = new Matrix4x4();
            Result.m03 = vector.x * matrix.m00 + vector.y * matrix.m10 + vector.z * matrix.m20;
            Result.m13 = vector.x * matrix.m01 + vector.y * matrix.m11 + vector.z * matrix.m21;
            Result.m23 = vector.x * matrix.m02 + vector.y * matrix.m12 + vector.z * matrix.m22;
            return Result;
        }
        public static Matrix4x4 MultiplyMatrixAndVect(Vector4 vector, Matrix4x4 matrix)
        {
            Matrix4x4 Result = new Matrix4x4();
            Result.m03 = vector.x * matrix.m00 + vector.y * matrix.m10 + vector.z * matrix.m20 + vector.w * matrix.m30;
            Result.m13 = vector.x * matrix.m01 + vector.y * matrix.m11 + vector.z * matrix.m21 + vector.w * matrix.m31;
            Result.m23 = vector.x * matrix.m02 + vector.y * matrix.m12 + vector.z * matrix.m22 + vector.w * matrix.m32;
            Result.m33 = vector.x * matrix.m03 + vector.y * matrix.m13 + vector.z * matrix.m23 + vector.w * matrix.m33;
            return Result;
        }
    }
}
