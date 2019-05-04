using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SpidaLib.Util
{
    public static class RandomUtil
    {
        #region RANDOM
        /// <summary>
        /// Gets a random Number (Inclusive)Integers.
        /// </summary>
        /// <returns>The random.</returns>
        /// <param name="min">Minimum number range</param>
        /// <param name="max">Maximum number range</param>
        public static float getRandomInc(float min, float max)
        {
            float value;
            min = Mathf.Ceil(min);
            max = Mathf.Floor(max);
            value = Mathf.Floor(Random.value * (max - min + 1)) + min;
            return value;
        }
        #endregion
    }
}
