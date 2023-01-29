using System;
using UnityEngine;

namespace BlueScreenStudios.Common
{
    public static class VectorUtilities
    {
        #region Y Component
        /// <summary>
        /// Removes the Y component from the vector
        /// </summary>
        /// <param name="vector">The vector to convert</param>
        /// <returns>A Vector2 equivilent to the associated Vector3 two dimensional position</returns>
        public static Vector2 RemoveYComponent(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        /// <summary>
        /// Removes the Y component from the vector
        /// </summary>
        /// <param name="vector">The vector to convert</param>
        /// <returns>A Vector2 equivilent to the associated Vector3 two dimensional position</returns>
        public static Vector2Int RemoveYComponent(this Vector3Int vector)
        {
            return new Vector2Int(vector.x, vector.z);
        }

        /// <summary>
        /// Adds a Y component to a vector
        /// </summary>
        /// <param name="vector">The vector to convert</param>
        /// <param name="value">The value for the Y component</param>
        /// <returns>A Vector3 equivilent to the associated vector2, but with an added Y component</returns>
        public static Vector3 AddYComponent(this Vector2 vector, float value)
        {
            return new Vector3(vector.x, value, vector.y);
        }

        /// <summary>
        /// Adds a Y component to a vector
        /// </summary>
        /// <param name="vector">The vector to convert</param>
        /// <param name="value">The value for the Y component</param>
        /// <returns>A Vector3 equivilent to the associated vector2, but with an added Y component</returns>
        public static Vector3Int AddYComponent(this Vector2Int vector, int value)
        {
            return new Vector3Int(vector.x, value, vector.y);
        }
        #endregion Y Component

        #region Rounding
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
        #endregion Rounding

        #region Grids
        public static Vector2[] Generate2DGrid(int xCount, int yCount, float spacing, Vector2 offset)
        {
            Vector2[] vectorArray = new Vector2[xCount * yCount];

            int modifyIndex = 0;

            for(int x = 0; x < xCount; x++)
            {
                for(int y = 0; y < yCount; y++)
                {
                    float xCoord = x * spacing;
                    float yCoord = y * spacing;

                    float x1 = xCoord + offset.x;
                    float y1 = yCoord + offset.y;

                    Debug.Log(x1 + "|" + y1);

                    vectorArray[modifyIndex] = new Vector2(xCoord + offset.x, yCoord + offset.y);
                    modifyIndex++;
                }
            }

            return vectorArray;
        }
        #endregion Grids

        /// <summary>
        /// Checks if a set of Vector3 coordinates is inside of a sphere
        /// </summary>
        /// <param name="center">The center of the sphere</param>
        /// <param name="radius">The radius of the sphere</param>
        /// <param name="check">The vector to check</param>
        /// <returns>True if the coordinate set provided is within the bounds of a sphere</returns>
        public static bool Vector3InSphere(Vector3 center, float radius, Vector3 check)
        {
            float diameter = Mathf.Pow(radius, 2);

            float centerX = center.x;
            float centerY = center.y;
            float centerZ = center.z;

            float checkX = check.x;
            float checkY = check.y;
            float checkZ = check.z;

            float ansX = Mathf.Pow((checkX - centerX), 2);
            float ansY = Mathf.Pow((checkY - centerY), 2);
            float ansZ = Mathf.Pow((checkZ - centerZ), 2);

            return ansX + ansY + ansZ < diameter;
        }
    }
}
