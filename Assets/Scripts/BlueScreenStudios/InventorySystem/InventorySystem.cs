using System.Collections.Generic;
using UnityEngine;

namespace BlueScreenStudios.InventorySystem
{
    public class InventorySystem : MonoBehaviour
    {
        [SerializeField] private GameObject capeAnchor;

        internal Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
        internal List<InventoryItem> inventory { get; private set; }

        internal InventoryItemData[] enabledCapes;

        private InventoryGUI gui;

        private void Start()
        {
            inventory = new List<InventoryItem>();
            m_itemDictionary= new Dictionary<InventoryItemData, InventoryItem>();

            CapeSystemInit();

        }

        private void CapeSystemInit()
        {
            Capes capesSystem = GetComponent<Capes>();

            enabledCapes = capesSystem.GetEnabledCapes();

            if (enabledCapes.Length > 0) capeAnchor.SetActive(true);
            else capeAnchor.SetActive(false);
        }

        #region Item Management
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
        #endregion Item Management
    }
}
