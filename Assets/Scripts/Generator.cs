using UnityEngine;
using System.Collections.Generic;

namespace BlueScreenStudios.Jigsaw
{
    public class Generator : MonoBehaviour
    {
        [Header("Generator Settings")]
        [Tooltip("The steps the generator should run through")]
        [SerializeField] private int generationSteps;
        [Tooltip("The amount of times the generator should attempt to generate a piece before giving up")]
        [SerializeField] private int generationAttempts;
        
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

        private void Start()
        {
            Instantiate(startPiece);

            CorrectBoundingBox(startPiece);

            JigsawPiece previousPiece = startPiece;

            for(int i = 0; i < generationSteps; i++)
            {
                JigsawPiece nextPiece = SelectNextPiece(GeneratorPool.Cooridor);
                JigsawHook[] previousPieceHooks = previousPiece.hooks;
                JigsawHook[] nextPieceHooks = nextPiece.hooks;

                
                foreach(JigsawHook hook in nextPieceHooks)
                {
                    Vector3 placementPosition = hook.transform.position + hook.transform.localPosition;
                    Quaternion placmentRotation = Quaternion.identity;
                    JigsawPiece piece = Instantiate(nextPiece, placementPosition, placmentRotation);

                    CorrectBoundingBox(piece);
                }

            }

        }

        private void CorrectBoundingBox(JigsawPiece piece)
        {
            piece.boundingBox.center = piece.transform.position + new Vector3Int(0, 2, 0);
        }

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
    }
}