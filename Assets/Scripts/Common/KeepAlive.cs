using UnityEngine;

namespace BlueScreenStudios.Common
{
    public class KeepAlive : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
