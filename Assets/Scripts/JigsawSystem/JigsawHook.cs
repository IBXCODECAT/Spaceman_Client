using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueScreenStudios.JigsawSystem
{
    public class JigsawHook : MonoBehaviour
    {
        [Tooltip("What pool should the generator choose from when placing the next piece?")]
        [SerializeField] internal JigsawGenerator.GeneratorPool primaryConnectionPool;

        [Tooltip("If an object from the primary connection pool can not be placed, what should the generator try instead?")]
        [SerializeField] internal JigsawGenerator.GeneratorPool secondaryConnectionPool;

        internal bool connected = false;

        private void Awake()
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
