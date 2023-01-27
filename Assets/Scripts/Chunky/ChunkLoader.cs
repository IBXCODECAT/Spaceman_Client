using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BlueScreenStudios.Common;

namespace BlueScreenStudios.Chunky
{
    public class ChunkLoader : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private GameObject chunkPrefab;
        [SerializeField] private int renderDistance;

        private int chunkSize = 10;

        private Vector2Int playerGridPosition;

        private void Update()
        {
            Vector3 playerPos = playerTransform.transform.position;

            //Debug.Log(playerPos);

            //Calculate the players position as if they were on a flat grid
            Vector2 playerPosition2D = playerPos.RemoveYComponent();

            //Debug.Log(playerPosition2D);
            //Calculate a point on the chunk grid that is closest to the player
            playerGridPosition = playerPosition2D.RoundVector(10);

            Debug.Log(playerGridPosition);
        }
    }
}
