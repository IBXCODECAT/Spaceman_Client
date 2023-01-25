using UnityEngine;

namespace BlueScreenStudios.JigsawSystem
{
    public class JigsawPiece : MonoBehaviour
    {
        [Header("Jigsaw Piece Info")]
        [Tooltip("What pool does this jigsaw piece belong too.")]
        [SerializeField] internal JigsawGenerator.GeneratorPool pool;
        [SerializeField] internal JigsawHook[] hooks;
    }
}