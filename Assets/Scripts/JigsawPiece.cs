using UnityEngine;

namespace BlueScreenStudios.Jigsaw
{
    public class JigsawPiece : MonoBehaviour
    {
        [Header("Jigsaw Piece Info")]
        [Tooltip("What generator pool does this jigsaw piece belong too.")]
        [SerializeField] internal Generator.GeneratorPool pool;
        [SerializeField] internal JigsawHook[] hooks;
    }
}