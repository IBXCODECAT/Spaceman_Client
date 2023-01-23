using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueScreenStudios.Jigsaw
{
    public class JigsawHook : MonoBehaviour
    {
        [Tooltip("The pool the generator should select from when placing the next piece")]
        [SerializeField] Generator.GeneratorPool connectionPool;

        [SerializeField] private bool outboundConnection;

        private void OnDrawGizmos()
        {
            //Gizmos.DrawSphere(transform.position, 1f);
        }
    }
}
