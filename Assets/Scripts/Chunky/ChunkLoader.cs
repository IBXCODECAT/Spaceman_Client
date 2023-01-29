using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BlueScreenStudios.Common;

namespace BlueScreenStudios.Chunky
{
    public class ChunkLoader : MonoBehaviour
    {
        #region Inspector
        [Header("Chunky Resources")]

        [Tooltip("A reference to the player's transform, this will be the transform all rendering will revolve around.")]
        [SerializeField] private Transform playerTransform;

        [Tooltip("Assign a GameObject for the chunky generation system to use as a chunk.")]
        [SerializeField] private GameObject chunkPrefab;

        [Header("Chunky Settings")]

        [Tooltip("Assign a GameObject Transform to nest all new chunks under.")]
        [SerializeField] private Transform nestChunksUnder;

        [Tooltip("This is the distance away from the player that chunks will be drawn.")]
        [SerializeField] private int renderDistance;

        [Tooltip("Set the chunk height and width here. Chunks are squares. The default value is 10.")]
        [SerializeField] private int chunkSize = 10;

        [Tooltip("Set a Y coordinate to instantiate chunks at.")]
        [SerializeField] private int instantiationHeight;

        [Range(1, 10)]
        [Tooltip("The amount of time to wait before recalculating which chunks need to be loaded/unloaded.")]
        [SerializeField] private int recalculationDelay;
        #endregion Inspector

        private Vector2Int playerGridPosition;

        /// <summary>
        /// Stores the grid position of each chunk with the chuk objects.
        /// Grid positions are checked to when determining if a new chunk should be placed
        /// </summary>
        private Dictionary<Vector2, Chunk> chunkPositionsDict = new Dictionary<Vector2, Chunk>();

        private IEnumerator Start()
        {
            chunkPositionsDict.Clear();

            while (true)
            {
                Vector3 playerPosition = playerTransform.transform.position;

                //Calculate the players position as if they were on a flat grid
                Vector2 playerPosition2D = playerPosition.RemoveYComponent();

                //Calculate a point on the chunk grid that is closest to the player
                playerGridPosition = playerPosition2D.RoundVector(chunkSize);

                int gridExtents = renderDistance / chunkSize;
                Vector2[] chunkPositions = VectorUtilities.Generate2DGrid(-gridExtents, -gridExtents, gridExtents, gridExtents, chunkSize, playerGridPosition);

                InstantiateChunks(chunkPositions);

                yield return new WaitForSeconds(recalculationDelay);
            }
        }

        /// <summary>
        /// Instantiates chunk prefabs around the player.
        /// Skips duplicate or bad placments.
        /// </summary>
        /// <param name="chunkPositions">The positions around the player chunks can be instantiated</param>
        private void InstantiateChunks(Vector2[] chunkPositions)
        {
            foreach (Vector2 position in chunkPositions)
            {
                if (VectorUtilities.Vector3InSphere((Vector2)playerGridPosition, renderDistance, position))
                {
                    if (!chunkPositionsDict.ContainsKey(position))
                    {
                        Vector3 chunkPositionWorldSpace = position.AddYComponent(instantiationHeight);

                        GameObject newchunkObject = Instantiate(chunkPrefab, chunkPositionWorldSpace, Quaternion.identity, nestChunksUnder);
                        Chunk newchunk = newchunkObject.GetComponent<Chunk>();

                        chunkPositionsDict.Add(position, newchunk);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Vector3Int playerGridPosition3D = playerGridPosition.AddYComponent((int)playerTransform.position.y);
            Vector3 cubeSize = new Vector3(0.25f, 0.25f, 0.25f);

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(playerTransform.position, playerGridPosition3D);
            Gizmos.DrawCube(playerGridPosition3D, cubeSize);
            Gizmos.DrawWireSphere(playerGridPosition3D, renderDistance);
        }
    }
}
