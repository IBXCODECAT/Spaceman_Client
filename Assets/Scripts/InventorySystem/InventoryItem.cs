namespace BlueScreenStudios.InventorySystem
{
    [System.Serializable]

    public class InventoryItem
    {
        internal InventoryItemData data { get; private set; }
        public byte stackSize { get; private set; }

        
        public InventoryItem(InventoryItemData source) 
        {
            data = source;
            IncreaseStack();
        }

        internal void IncreaseStack()
        {
            if(stackSize != byte.MaxValue)
            {
                stackSize++;
            }
        }

        internal void DecreaseStack() 
        {
            if(stackSize != byte.MinValue)
            {
                stackSize--;
            }
        }
    }
}
