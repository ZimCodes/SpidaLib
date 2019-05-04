using Assets.SpidaLib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SpidaLib.Util.MathUtil
{
    public static class TransformUtil
    {
        
        #region TRANSFORM UTIL
        /// <summary>
        /// Matrix Transformation with Scale, Euler Angle Rotation, & Translation.
        /// </summary>
        /// <returns>The Euler angle transformation.</returns>
        /// <param name="scale">Scale.</param>
        /// <param name="rotatezxy">Rotatezxy.</param>
        /// <param name="translation">Translation.</param>
        public static Matrix4x4 EulerAngleTransformation(Vector3 scale, Vector3 rotatezxy, Vector3 translation)
        {
            return Matrix4x4.Scale(scale) * Matrix4x4.Rotate(Quaternion.Euler(rotatezxy)) * Matrix4x4.Translate(translation);
        }
        public static Matrix4x4 EulerAngleTransformation(Vector3 scale, Quaternion rotatezxy, Vector3 translation)
        {
            return Matrix4x4.Scale(scale) * Matrix4x4.Rotate(rotatezxy) * Matrix4x4.Translate(translation);
        }
        /// <summary>
        /// Matrix Transformation with Scale, Axis Angle Rotation, & Translation.
        /// </summary>
        /// <returns>The angle transformation.</returns>
        /// <param name="scale">Scale.</param>
        /// <param name="angle">The amount in degrees to rotate</param>
        /// <param name="axis">What axis to rotate over</param>
        /// <param name="translation">Translation.</param>
        public static Matrix4x4 AxisAngleTransformation(Vector3 scale, float angle, Vector3 axis, Vector3 translation)
        {
            return Matrix4x4.Scale(scale) * Matrix4x4.Rotate(Quaternion.AngleAxis(angle, axis)) * Matrix4x4.Translate(translation);
        }
        /// <summary>
        /// 2D rotation.
        /// </summary>
        /// <returns>The 2D rotation Vector.</returns>
        /// <param name="vector">Vector.</param>
        /// <param name="degrees">Degrees.</param>
        public static Vector2 TwoDRotation(Vector2 vector, float degrees)
        {
            Matrix4x4 tempmatrix = new Matrix4x4(
                new Vector4(Mathf.Cos(Mathf.Deg2Rad * degrees), -Mathf.Sin(Mathf.Deg2Rad * degrees), 0, 0),
                new Vector4(Mathf.Sin(Mathf.Deg2Rad * degrees), Mathf.Cos(Mathf.Deg2Rad * degrees), 0, 0),
                Vector4.zero,
                Vector4.zero
            );
            return VectorUtil.MultiplyVectAndMatrix(vector, tempmatrix);
        }
        #endregion
    }
}
