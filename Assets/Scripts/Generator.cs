using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor.SceneManagement;
using Unity.VisualScripting.YamlDotNet.Core;

namespace BlueScreenStudios.Jigsaw
{
    public class Generator : MonoBehaviour
    {
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

        public enum GeneratorPool { Cooridor, Branch, Terminator, Decorations };

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(generationDelay);

            JigsawPiece previousPiece = Instantiate(startPiece, new Vector3(0, 0, 0), Quaternion.identity);

            CorrectBoundingBox(startPiece);

            for(int i = 0; i < generationSteps; i++)
            {
                yield return new WaitForSeconds(generationDelay);

                foreach(JigsawHook outboundHook in previousPiece.hooks)
                {
                    yield return new WaitForSeconds(generationDelay);

                    JigsawPiece piecePrefab = SelectNextPiece(GeneratorPool.Cooridor);

                    JigsawPiece placedPiece = Instantiate(piecePrefab);
                    JigsawHook inboundHook = SelectRandomHook(placedPiece);

                    outboundHook.GetComponent<MeshRenderer>().enabled = true;
                    inboundHook.GetComponent<MeshRenderer>().enabled = true;
                    Debug.Log("Hooks");

                    yield return new WaitForSeconds(generationDelay);

                    SetPieceRotation(placedPiece, outboundHook, inboundHook);
                    SetPiecePosition(previousPiece, placedPiece, outboundHook, inboundHook);

                    CorrectBoundingBox(placedPiece);

                    yield return new WaitForSeconds(generationDelay);
                }
            }

        }

        private void CorrectBoundingBox(JigsawPiece piece)
        {
            piece.boundingBox.center = piece.transform.position + new Vector3Int(0, 2, 0);
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


        private void SetPieceRotation(JigsawPiece placedPiece, JigsawHook outboundHook, JigsawHook inboundHook)
        {
            Vector3 inboundHookRotation = inboundHook.transform.rotation.eulerAngles;
            Vector3 outboundHookRotation = outboundHook.transform.rotation.eulerAngles;

            Debug.Log(inboundHookRotation.y + " | " + outboundHookRotation.y);

            float hookRotationOffset;

            if(outboundHookRotation.y >= inboundHookRotation.y)
            {
                hookRotationOffset = outboundHookRotation.y - inboundHookRotation.y;
            }
            else
            {
                hookRotationOffset = inboundHookRotation.y - outboundHookRotation.y;
            }

            Debug.Log(hookRotationOffset);

            /*//If the hook rotations have no difference the piece must be placed 180
            if(inboundHookRotation.y == outboundHookRotation.y)
            {
                placedPiece.transform.Rotate(new Vector3(0, 180, 0));
            }*/

            if(hookRotationOffset == 180)
            {
                Debug.Log("Jigsaw piece rotated correctly", placedPiece);    
            }
            else
            {
                if (hookRotationOffset == 0)
                {
                    Debug.Log("Flipped 180 Degrees", placedPiece);
                    placedPiece.transform.Rotate(new Vector3(0, 180, 0));
                }
                else
                {
                    Debug.Log("Jigsaw piece rotated incorectly, fixing..." + -hookRotationOffset + "?", placedPiece);
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
            Vector3 offset = outboundHook.transform.position - inboundHook.transform.position;
            placedPiece.transform.position = offset + previousPiece.transform.position;
        }
    }
}