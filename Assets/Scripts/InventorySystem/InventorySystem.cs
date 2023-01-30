using System.Collections.Generic;
using UnityEngine;

namespace BlueScreenStudios.InventorySystem
{
    public class InventorySystem : MonoBehaviour
    {
        internal Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
        internal List<InventoryItem> inventory { get; private set; }

        // Start is called before the first frame update
        void Awake()
        {
            inventory = new List<InventoryItem>();
            m_itemDictionary= new Dictionary<InventoryItemData, InventoryItem>();
        }

        internal InventoryItem Get(InventoryItemData referenceData)
        {
            if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
            {
                return value;
            }

            return null;
        }

        internal void AddItem(InventoryItemData referenceData)
        {
            if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
            {
                value.IncreaseStack();
            }
            else
            {
                InventoryItem newItem = new InventoryItem(referenceData);
                inventory.Add(newItem);
                m_itemDictionary.Add(referenceData, newItem);
            }
        }

        internal void RemoveItem(InventoryItemData referenceData) 
        {
            if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
            {
                value.DecreaseStack();  

                if(value.stackSize == 0)
                {
                    inventory.Remove(value);
                    m_itemDictionary.Remove(referenceData);
                }
            }
        }
    }
}
