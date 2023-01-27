using System;
using UnityEngine;

namespace BlueScreenStudios.Common
{
    public static class VectorUtilities
    {

        public static Vector2 RemoveYComponent(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        public static Vector2Int RemoveYComponent(this Vector3Int vector)
        {
            return new Vector2Int(vector.x, vector.z);
        }

        /// <summary>
        /// Rounds a vector
        /// </summary>
        /// <param name="vector">The vector to round</param>
        /// <param name="roundToNearest">What value should we round by</param>
        /// <returns>A rounded vector</returns>
        public static Vector2Int RoundVector(this Vector2 vector, double roundToNearest)
        {
            float x = vector.x;
            float y = vector.y;

            int roundedX = ((int)Math.Round(x / roundToNearest)) * (int)roundToNearest;
            int roundedY = ((int)Math.Round(y / roundToNearest)) * (int)roundToNearest;

            return new Vector2Int(roundedX, roundedY);
        }

        /// <summary>
        /// Rounds a vector
        /// </summary>
        /// <param name="vector">The vector to round</param>
        /// <param name="roundToNearest">What value should we round by</param>
        /// <returns>A rounded vector</returns>
        public static Vector2Int RoundVector(this Vector2Int vector, double roundToNearest)
        {
            int x = vector.x;
            int y = vector.y;

            int roundedX = ((int)Math.Round(x / roundToNearest)) * (int)roundToNearest;
            int roundedY = ((int)Math.Round(y / roundToNearest)) * (int)roundToNearest;

            return new Vector2Int(roundedX, roundedY);
        }
    }
}
