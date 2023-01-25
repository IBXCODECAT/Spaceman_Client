using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueScreenStudios.Jigsaw
{
    public class JigsawHook : MonoBehaviour
    {
        [Tooltip("The pool the generator should select from when placing the next piece")]
        [SerializeField] internal Generator.GeneratorPool connectionPool;

        internal bool connected = false;

        private void Awake()
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
