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

        [Tooltip("This is the distance away from the player that chunks will be drawn.")]
        [SerializeField] private int renderDistance;

        [Tooltip("Set the chunk height and width here. Chunks are squares. The default value is 10.")]
        [SerializeField] private int chunkSize = 10;
        #endregion Inspector

        private Vector2Int playerGridPosition;

        private void Update()
        {
            Vector3 playerPosition = playerTransform.transform.position;

            //Calculate the players position as if they were on a flat grid
            Vector2 playerPosition2D = playerPosition.RemoveYComponent();

            //Calculate a point on the chunk grid that is closest to the player
            playerGridPosition = playerPosition2D.RoundVector(chunkSize);
        }

        private void OnDrawGizmos()
        {
            Vector3Int playerGridPosition3D = playerGridPosition.AddYComponent((int)playerTransform.position.y);
            
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(playerTransform.position, playerGridPosition3D);
            Gizmos.DrawCube(playerGridPosition3D, new Vector3(0.25f, 0.25f, 0.25f));
            Gizmos.DrawWireSphere(playerGridPosition3D, renderDistance);
        }
    }
}
