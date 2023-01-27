using System;
using UnityEngine;

namespace BlueScreenStudios.Discord
{
    public class DiscordManager : MonoBehaviour
    {
        private Discord discordUtility = new Discord(988833332445978624, (UInt64)CreateFlags.Default);
        private ActivityManager activityManagerUtility;
        private UserManager userManagerUtility;

        #region Engine_Methods
        private void Start()
        {
            activityManagerUtility = discordUtility.GetActivityManager();
            userManagerUtility = discordUtility.GetUserManager();

            UpdateDiscordRPC("test", "test");
        }

        private void Update()
        {
            discordUtility.RunCallbacks();
        }

        private void OnApplicationQuit()
        {
            ClearRPCStatus();
            discordUtility.Dispose();
        }
        #endregion Engine_Methods

        public void ClearRPCStatus()
        {
            activityManagerUtility.ClearActivity((res) => { Debug.Log("Discord Activity Cleared: " + res); });
        }

        public void UpdateDiscordRPC(string details, string state)
        {
            ClearRPCStatus();

            Activity activity = new Activity
            {
                Assets =
                {
                    LargeImage = "logo"
                },
                Details = details,
                State = state,
                Type = ActivityType.Playing,
                Timestamps =
                {
                    Start = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                }
            };

            activityManagerUtility.UpdateActivity(activity, (response) =>
            {
                if (response == Result.Ok) Debug.Log("Discord RPC Updatecd");
            });
        }
    }
}
