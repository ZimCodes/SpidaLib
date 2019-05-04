using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpidaLib.Collision
{
    public class SeparationAxisTheorem
    {
        float min, max;
        /// <summary>
        /// Gets the interval projected along declared axis
        /// </summary>
        /// <returns>The interval.</returns>
        /// <param name="rectangle">Rectangle.</param>
        /// <param name="axis">Axis.</param>
        private static SeparationAxisTheorem GetInterval(Rect rectangle, Vector2 axis)
        {
            SeparationAxisTheorem result = new SeparationAxisTheorem();
            //The Maximum and minimum parts of a rectangle
            Vector2 min, max;
            min.x = rectangle.min.x;
            min.y = rectangle.min.y;
            max.x = rectangle.max.x;
            max.y = rectangle.max.y;
            //The Max and Min Vertices of a rectangle
            Vector2[] vertsOfRect = {
            new Vector2 (min.x, min.y),
            new Vector2 (min.x, max.y),
            new Vector2 (max.x, max.y),
            new Vector2 (max.x, min.y)
        };

            //Projects each vertex onto the axis, and store the smallest and largest values
            result.min = result.max = Vector2.Dot(axis, vertsOfRect[0]);
            for (int i = 1; i < 4; i++)
            {
                float projection = Vector2.Dot(axis, vertsOfRect[i]);
                if (projection < result.min)
                {
                    result.min = projection;
                }
                if (projection > result.max)
                {
                    result.max = projection;
                }
            }
            return result;
        }
        /// <summary>
        /// Tests if the two intervals overlap
        /// </summary>
        /// <returns><c>true</c>, if intervals overlap, <c>false</c> otherwise.</returns>
        /// <param name="rect1">Rect1.</param>
        /// <param name="rect2">Rect2.</param>
        /// <param name="axis">Axis.</param>
        private static bool OverlapOnAxis(Rect rect1, Rect rect2, Vector2 axis)
        {
            SeparationAxisTheorem a = GetInterval(rect1, axis);
            SeparationAxisTheorem b = GetInterval(rect2, axis);
            return ((b.min <= a.max) && (a.min <= b.max));
        }
        /// <summary>
        /// Tests collision between 2 rectangles using (S.A.T)
        /// </summary>
        /// <returns><c>true</c>, if rectangles collided, <c>false</c> otherwise.</returns>
        /// <param name="rect1">Rect1</param>
        /// <param name="rect2">Rect2.</param>
        public static bool RectangleRectangleSAT(Rect rect1, Rect rect2)
        {
            //X-axis & y-axis(Axes to test)
            Vector2[] axisToTest = { new Vector2(1, 0), new Vector2(0, 1) };
            for (int i = 0; i < 2; i++)
            {

                //Intervals dont'overlap, separating axis found
                if (!OverlapOnAxis(rect1, rect2, axisToTest[i]))
                {
                    //No collison has taken place
                    return false;
                }
            }
            //All intervals Overlap; Separating axis not found
            return true;
        }
    }
}
