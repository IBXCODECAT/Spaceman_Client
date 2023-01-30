using UnityEngine;

namespace BlueScreenStudios.InventorySystem
{
    [CreateAssetMenu(menuName = "Inventory Item Data")]
    public class InventoryItemData : ScriptableObject
    {
        public string id;
        public string displayName;
        public Sprite icon;
        public GameObject prefab;
    }
}
