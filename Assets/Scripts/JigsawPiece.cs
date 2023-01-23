using UnityEngine;

namespace BlueScreenStudios.Jigsaw
{
    public class JigsawPiece : MonoBehaviour
    {
        [Header("Jigsaw Piece Info")]
        [Tooltip("What generator pool does this jigsaw piece belong too.")]
        [SerializeField] Generator.GeneratorPool pool;
        [SerializeField] internal JigsawHook[] hooks;

        [Tooltip("The bounding box for this piece")]
        [SerializeField] internal Bounds boundingBox;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(boundingBox.center, boundingBox.size);
        }
    }
}