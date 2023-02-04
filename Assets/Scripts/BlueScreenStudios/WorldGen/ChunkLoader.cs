using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BlueScreenStudios.Common;
using UnityEngine.Rendering;

namespace BlueScreenStudios.WorldGen
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

        [Tooltip("World Height")]
        [SerializeField] private float terrainDataY;

        [Range(1, 10)]
        [Tooltip("The amount of time to wait before recalculating which chunks need to be loaded/unloaded.")]
        [SerializeField] private int recalculationDelay;

        [Header("Terrain Generation Settings")]
        [SerializeField] private int noiseOctaves;
        [SerializeField] private Vector2 noiseScale;

        [Header("Debug")]
        [SerializeField] private bool enableDebug;
        [Range(-3, 3)]
        [SerializeField] private int logChunkX;
        [Range(-3, 3)]
        [SerializeField] private int logChunkY;

        #endregion Inspector

        private Vector2Int playerGridPosition;

        /// <summary>
        /// Stores all loaded chunks.
        /// </summary>
        private List<Chunk> loadedChunks = new List<Chunk>();

        private IEnumerator Start()
        {
            //Clear the list of loaded chunks
            loadedChunks.Clear();

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
            DestroyAndUnloadChunks();

            //For each proposed chunk positiion...
            foreach (Vector2 newChunkGridPosition in chunkPositions)
            {
                //Is this chunk position within the player's render distance...
                if (VectorUtilities.Vector3InSphere((Vector2)playerGridPosition, renderDistance, newChunkGridPosition))
                {
                    bool proposedPositionAlreadyLoaded = false;

                    //For each loaded chunk...
                    foreach(Chunk loadedChunk in loadedChunks)
                    {
                        //Calculate the grid position of the loaded chunk
                        Vector2 loadedChunkGridPosition = loadedChunk.transform.position.RemoveYComponent();

                        //If the loaded chunks grid position is not equal to the proposed grid position...
                        if (loadedChunkGridPosition == newChunkGridPosition)
                        {
                            //The proposed position already has a chunk loaded
                            proposedPositionAlreadyLoaded = true;
                        }
                    }

                    //If the proposed position does not have a chunk loaded...
                    if(!proposedPositionAlreadyLoaded)
                    {
                        //Convert the proposed grid position to a position to instantate the chunk in world space
                        Vector3 chunkPositionWorldSpace = newChunkGridPosition.AddYComponent(instantiationHeight);

                        //Create a new chunk object from the chunk prefab
                        GameObject newchunkObject = Instantiate(chunkPrefab, chunkPositionWorldSpace, Quaternion.identity, nestChunksUnder);
                        Chunk newchunk = newchunkObject.GetComponent<Chunk>();

                        newchunk.SetGridPosition(newChunkGridPosition);
                        newchunk.SetWorldPosition(chunkPositionWorldSpace);

                        SetTerrainData(newchunkObject);

                        //Add this chunk and it's grid position to the chunk dict
                        loadedChunks.Add(newchunk);
                    }
                }
            }
        }

        /// <summary>
        /// Destroys and unloads all chunks outside of the players render sphere
        /// </summary>
        private void DestroyAndUnloadChunks()
        {
            //Create a copy of our loaded chunks dictionary values into an array to prevent an enumeration error
            Chunk[] loadedChunkValues = loadedChunks.ToArray();

            //For each loaded chunk...
            foreach (Chunk chunk in loadedChunkValues)
            {
                //If this chunk is outside of our render sphere...
                if (!VectorUtilities.Vector3InSphere((Vector2)playerGridPosition, renderDistance, chunk.gameObject.transform.position))
                {
                    //Remove the chunk from the loaded chunks dictionary and destroy this chunk
                    loadedChunks.Remove(chunk);

                    //If the chunk was not modified by the player...
                    if (!chunk.ChunkWasPlayerModified())
                    {
                        Destroy(chunk.gameObject);
                    }
                }
            }
        }

        private void SetTerrainData(GameObject chunkInstance)
        {
            Chunk chunk = chunkInstance.GetComponent<Chunk>();

            //Create new terrain data for this chunk
            TerrainData data = new TerrainData();
            data.size = new Vector3(chunkSize, terrainDataY, chunkSize);

            //Get the height map resolution from our chunk
            int heightMapResolution = data.heightmapResolution;

            float chunkOffsetX = chunk.GetGridPosition().x / chunkSize;
            float chunkOffsetY = chunk.GetGridPosition().y / chunkSize;
            
            //Create an offset to offset our 
            float perlinSampleOffsetX = chunkOffsetX * heightMapResolution;
            float perlinSampleOffsetY = chunkOffsetY * heightMapResolution;

            chunk.gameObject.name = "Chunk: " + perlinSampleOffsetX + " | " + perlinSampleOffsetY;

            //Create our terrainDataHeightMap for this terrain with size of resolution
            float[,] terrainDataHeightMap = new float[heightMapResolution, heightMapResolution];

            //Create a texture to overlay on top of plane for debuggin purposes
            Texture2D debugTexture = new Texture2D(heightMapResolution, heightMapResolution);
            GameObject debugObject = GameObject.CreatePrimitive(PrimitiveType.Plane);

            //For each X coordinate on the terrain data heightmap
            for (int heightMapX = 0; heightMapX < terrainDataHeightMap.GetLength(0); heightMapX++)
            {
                //For each Y coordinate on the terrain data heightmap
                for (int heightMapY = 0; heightMapY < terrainDataHeightMap.GetLength(1); heightMapY++)
                {
                    float perlinSampleX = perlinSampleOffsetX + heightMapX;
                    float perlinSampleY = perlinSampleOffsetY + heightMapY;

                    perlinSampleX *= noiseScale.x;
                    perlinSampleY *= noiseScale.y;

                    
                    //If this the first row on our height map...
                    if(heightMapX == 0)
                    {
                        //Offset the sample by one perlin sample so border height aligns with the previuos chunk
                        perlinSampleX -= noiseScale.x;
                    }

                    //If this is the first column in our height map...
                    if(heightMapY == 0)
                    {
                        //Offset the sample by one perlin sample so border height aligns with the previuos chunk
                        perlinSampleY -= noiseScale.y;
                    }

                    float height = Mathf.PerlinNoise(perlinSampleX, perlinSampleY);

                    terrainDataHeightMap[heightMapX, heightMapY] = height;

                    if (enableDebug)
                    {
                        //Sample our perlin noise into a color
                        Color perlinColor = new Color(height, height, height);

                        //Set the heightmap coordinate (0, 0) to max on terrain and red on perlin map
                        if(heightMapX == 0 && heightMapY == 0)
                        {
                            terrainDataHeightMap[0, 0] = 1f;
                        }

                        if(heightMapX == 1 && heightMapY == 1)
                        {
                            perlinColor = Color.red;
                        }

                        if (perlinSampleX == 3.3f && perlinSampleY == -0.1)
                        {
                            perlinColor = Color.green;
                            Debug.Log("[DEBUG] Green Sample: " + new Vector2(perlinSampleX, perlinSampleY) + " Height: " + height);
                        }

                        if(perlinSampleX == 3.2f && perlinSampleY == -0.1)
                        {
                            perlinColor = Color.blue;
                            Debug.Log("[DEBUG] Blue Sample: " + new Vector2(perlinSampleX, perlinSampleY) + " Height: " +  height);
                        }

                        debugTexture.SetPixel(heightMapX, heightMapY, perlinColor);

                        debugObject.transform.Rotate(0, 180, 0);
                        debugObject.transform.position = chunk.GetWorldPosition();
                        debugObject.transform.parent = nestChunksUnder;
                        debugObject.name = "[DEBUG] Perlin Map";
                    }
                }
            }

            //Is debug mode neabled...
            if(enableDebug)
            {
                //Apply all of our changes to the perlin texture
                debugTexture.Apply();

                //Get the renderer and material components for the debugObject
                Renderer debugChunkRender = debugObject.GetComponent<Renderer>();
                Material chunkMaterial = debugChunkRender.material;

                //Disable Shadows
                debugChunkRender.shadowCastingMode = ShadowCastingMode.Off;

                //Display on both sides, apply perlin texture, set smoothness 0 and color white for visibility
                chunkMaterial.SetFloat("_Cull", (float)CullMode.Off);
                chunkMaterial.SetTexture("_BaseMap", debugTexture);
                chunkMaterial.SetFloat("_smoothness", 0);
                chunkMaterial.color = Color.white;
            }

            data.SetHeights(0, 0, terrainDataHeightMap);

            chunk.GetComponentInChildren<Terrain>().terrainData = data;
            chunk.GetComponentInChildren<TerrainCollider>().terrainData = data;
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
