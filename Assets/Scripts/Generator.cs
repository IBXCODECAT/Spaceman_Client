using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor.SceneManagement;
using Unity.VisualScripting.YamlDotNet.Core;

namespace BlueScreenStudios.Jigsaw
{
    public class Generator : MonoBehaviour
    {
        #region Inspector
        [Header("Generator Settings")]
        [Tooltip("The steps the generator should run through")]
        [SerializeField] private int generationSteps;
        [Tooltip("The amount of times the generator should attempt to generate a piece before giving up")]
        [SerializeField] private int generationAttempts;
        [SerializeField] private float generationDelay;
        
        [SerializeField] JigsawPiece startPiece;

        [Header("Piece Pools")]
        [SerializeField] JigsawPiece[] cooridorPieces;
        [SerializeField] JigsawPiece[] branchPieces;
        [SerializeField] JigsawPiece[] decorationPieces;
        [SerializeField] JigsawPiece[] terminationPieces;

        [Header("Probability Settings")]
        [SerializeField] private float cooridorPlacementProbability;
        [SerializeField] private float BranchPlacementProbablity;
        [SerializeField] private float DecorationPlacementProbablity;
        #endregion Inspector

        /// <summary>
        /// Contains all jigsaw pieces that were generated in the previous generation step
        /// </summary>
        private List<JigsawPiece> lastStepGeneratedPieces = new List<JigsawPiece>();
        
        /// <summary>
        /// Contains a list of all jigsaw hooks that were not connected so far
        /// </summary>
        private List<JigsawHook> unconnectedJigsawHooks = new List<JigsawHook>();

        public enum GeneratorPool { Cooridor, Branch, Terminator, Decorations };

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.F5))
            {
                StopAllCoroutines();
                StartCoroutine(GenerateLevel());
            }
        }

        private IEnumerator GenerateLevel()
        {
            JigsawPiece previousPiece = Instantiate(startPiece, new Vector3(0, -10, 0), Quaternion.identity);

            for(int i = 0; i < generationSteps; i++)
            {
                Debug.Log("Starting Generation Step " + generationSteps + ".");

                foreach(JigsawHook outboundHook in previousPiece.hooks)
                {
                    JigsawPiece piecePrefab = SelectNextPiece(GeneratorPool.Cooridor);
                    Debug.Log("Instantiating piece " + piecePrefab.name);

                    JigsawPiece placedPiece = Instantiate(piecePrefab);
                    JigsawHook inboundHook = SelectRandomHook(placedPiece);
                    Debug.Log("Selected random inbound hook " + inboundHook.name + " for " + placedPiece.name + ".");
                    Debug.Log("Using outbound hook " + outboundHook.name + " for this jigsaw placment.");

                    outboundHook.GetComponent<MeshRenderer>().enabled = true;
                    inboundHook.GetComponent<MeshRenderer>().enabled = true;

                    SetPlacedJigsawPieceRotation(placedPiece, outboundHook, inboundHook);
                    SetPiecePosition(previousPiece, placedPiece, outboundHook, inboundHook);

                    yield return new WaitForSeconds(generationDelay);
                }
            }

        }

        #region Random_Selections
        private JigsawPiece SelectNextPiece(GeneratorPool pool)
        {
            int selectedPiece;

            switch(pool)
            {
                case GeneratorPool.Cooridor:
                    selectedPiece = Mathf.RoundToInt(Random.Range(0, cooridorPieces.Length));
                    return cooridorPieces[selectedPiece];
                case GeneratorPool.Branch:
                    selectedPiece = Mathf.RoundToInt(Random.Range(0, branchPieces.Length));
                    return branchPieces[selectedPiece];
                case GeneratorPool.Decorations:
                    selectedPiece = Mathf.RoundToInt(Random.Range(0, decorationPieces.Length));
                    return decorationPieces[selectedPiece];
                default:
                    selectedPiece = Mathf.RoundToInt(Random.Range(0, terminationPieces.Length));
                    return terminationPieces[selectedPiece];
            }
        }

        private JigsawHook SelectRandomHook(JigsawPiece piece)
        {
            JigsawHook[] hooks = piece.hooks;

            int hookIndex = Mathf.RoundToInt(Random.Range(0, hooks.Length));

            return hooks[hookIndex];
        }
        #endregion Random_Selections

        
        #region Placment_Methods
        /// <summary>
        /// Sets a placed jigsaw piece's rotation so that its hook aligns with the placment of the piece's hook it will join to
        /// </summary>
        /// <param name="placedPiece">The piece to rotate</param>
        /// <param name="outboundHook">The outbound hook of the jigsaw piece we connect to</param>
        /// <param name="inboundHook">The inbound hook of this jigsaw piece</param>
        private void SetPlacedJigsawPieceRotation(JigsawPiece placedPiece, JigsawHook outboundHook, JigsawHook inboundHook)
        {
            Vector3 inboundHookRotation = inboundHook.transform.rotation.eulerAngles;
            Vector3 outboundHookRotation = outboundHook.transform.rotation.eulerAngles;

            float hookRotationOffset = outboundHookRotation.y - inboundHookRotation.y;

            if(Mathf.Abs(hookRotationOffset) == 180)
            {
                Debug.Log("Jigsaw piece " + placedPiece.name + " is already rotated correctly.", placedPiece);    
            }
            else
            {
                if (hookRotationOffset == 0)
                {
                    Debug.Log("Jigsaw piece " + placedPiece.name + " has been flipped 180 degrees.", placedPiece);
                    placedPiece.transform.Rotate(new Vector3(0, 180, 0));
                }
                else
                {
                    Debug.Log("Jigsaw piece " + placedPiece.name + " has been rotated " + -hookRotationOffset + " degrees.", placedPiece);
                    placedPiece.transform.Rotate(new Vector3(0, -hookRotationOffset, 0));
                }
            }
        }

        /// <summary>
        /// Snaps two jigsaw pieces together by matching the positions of their hooks
        /// </summary>
        /// <param name="previousPiece"></param>
        /// <param name="placedPiece"></param>
        /// <param name="outboundHook"></param>
        /// <param name="inboundHook"></param>
        private void SetPiecePosition(JigsawPiece previousPiece, JigsawPiece placedPiece, JigsawHook outboundHook, JigsawHook inboundHook)
        {
            //Calculate the vector offset between the two hooks and snap the two pieces together
            Vector3 offset = outboundHook.transform.position - inboundHook.transform.position;
            placedPiece.transform.position = new Vector3(offset.x + previousPiece.transform.position.x, outboundHook.transform.position.y, offset.z + previousPiece.transform.position.z);
            Debug.Log("Jigsaw piece " + placedPiece.name + " has been snapped into place.");

            //Establish the hooks we used as connected
            inboundHook.connected = true;
            outboundHook.connected = true;

            //Set the connection capsules color for debugging purposes
            SetConnectionColor(inboundHook, outboundHook);

            //Add the piece we just placed to the list of pieces we generated in the previous step for the next generation step to access
            lastStepGeneratedPieces.Add(placedPiece);
        }
        #endregion Placement_Methods

        #region Debug_Methods
        /// <summary>
        /// Sets a random color to the hooks representing this connection
        /// </summary>
        /// <param name="inboundHook">A reference to the inbound hook for this connection</param>
        /// <param name="outboundHook">A reference to the outbound hook for this connection</param>
        private void SetConnectionColor(JigsawHook inboundHook, JigsawHook outboundHook)
        {
            Color hookColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            Renderer inboundHookRender = inboundHook.GetComponent<Renderer>();
            Renderer outboundHookRender = outboundHook.GetComponent<Renderer>();
            inboundHookRender.material.SetColor("_BaseColor", hookColor);
            outboundHookRender.material.SetColor("_BaseColor", hookColor);
        }
        #endregion Debug_Methods
    }
}