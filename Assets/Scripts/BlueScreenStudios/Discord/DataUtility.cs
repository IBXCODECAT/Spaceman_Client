using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Discord
{
    public static class DataUtility
    {
        private static UserManager userManager;

        
        
        /// <summary>
        /// Get the User ID of the person using Discord on this computer
        /// </summary>
        /// <returns>Long UserID</returns>
        public static long GetUserID()
        {
            User currentUser = userManager.GetCurrentUser();
            return currentUser.Id;
        }
    }
}
