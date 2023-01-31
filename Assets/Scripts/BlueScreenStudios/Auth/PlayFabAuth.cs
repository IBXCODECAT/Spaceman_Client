using Newtonsoft;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace BlueScreenStudios.Auth
{
    public class PlayFabAuth : MonoBehaviour
    {
        public static AccountFlags flags;

        /// <summary>
        /// Initialize PlayFab Settings
        /// </summary>
        [RuntimeInitializeOnLoadMethod] 
        public static void PlayfabInit() 
        {
            PlayFabSettings.TitleId = "8BD04";
            PlayFabSettings.DisableDeviceInfo = false;
        }

        private void Update()
        {

        }


        internal void GetUserFlags()
        {
            ExecuteCloudScriptRequest request = new ExecuteCloudScriptRequest
            {
                FunctionName = "GetUserReadOnlyData"
            };

            PlayFabClientAPI.ExecuteCloudScript(request, OnGetUserFlags, OnAPIError);
        }

        internal void OnGetUserFlags(ExecuteCloudScriptResult executionResult)
        {
            if(executionResult.FunctionResult != null)
            {
                Debug.Log("CloudScript Executed:\n" + executionResult.FunctionResult.ToString());
            }
            else
            {
                Debug.LogError("CloudScript execution failed.");
            }

            flags = JsonConvert.DeserializeObject<AccountFlags>(executionResult.FunctionResult.ToString());
        }

        /// <summary>
        /// Attempts to authenticate a player by registering them as a new user
        /// </summary>
        /// <param name="username">The user's username & DisplayName</param>
        /// <param name="email">The email address of the user</param>
        /// <param name="password">The password the user wants to use to login</param>
        internal void Authenticate(string username, string email, string password)
        {
            RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest
            {
                DisplayName = username,

                Username = username,
                Email = email,
                Password = password
            };

            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegister, OnAPIError);
        }

        /// <summary>
        /// Attempts to authenticate a player by logging them in as a new user
        /// </summary>
        /// <param name="username">The user's username & Displayname</param>
        /// <param name="password">The password the user uses to login</param>
        internal void Authenticate(string username, string password)
        {
            LoginWithPlayFabRequest request = new LoginWithPlayFabRequest
            {
                Username = username,
                Password = password,
                TitleId = PlayFabSettings.TitleId
            };

            
            PlayFabClientAPI.LoginWithPlayFab(request, OnLogin, OnAPIError);
        }

        private void OnRegister(RegisterPlayFabUserResult result)
        {
            Debug.Log("Registered new user:\n" + result.ToJson().ToString());
        }

        private void OnLogin(LoginResult result)
        {
            Debug.Log("Logged in:\n" + result.ToJson().ToString());
            GetUserFlags();
        }

        private void OnAPIError(PlayFabError error)
        {
            Debug.LogError(error.GenerateErrorReport());
        }
    }
}
