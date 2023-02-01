using System.Collections.Generic;
using UnityEngine;

using BlueScreenStudios.Auth;

namespace BlueScreenStudios.InventorySystem
{
    internal class Capes : MonoBehaviour
    {
        [SerializeField] private InventoryItemData discordCape;
        [SerializeField] private InventoryItemData earlyCape;
        [SerializeField] private InventoryItemData staffCape;

        internal InventoryItemData[] GetEnabledCapes()
        {
            List<InventoryItemData> capes = new List<InventoryItemData>();

            if(AccountFlags.DiscordFlagEnabled(PlayFabAuth.flags))
            {
                capes.Add(discordCape);
                Debug.Log("The Discord cape is enabled on this account.");
            }

            if(AccountFlags.EarlyFlagEnabled(PlayFabAuth.flags))
            {
                capes.Add(earlyCape);
                Debug.Log("The Early cape is enabled on this account");
            }

            if(AccountFlags.StaffFlagEnabled(PlayFabAuth.flags))
            {
                capes.Add(staffCape);
                Debug.Log("The staff cape is enabled on this account");
            }

            return capes.ToArray();
        }
    }
}
