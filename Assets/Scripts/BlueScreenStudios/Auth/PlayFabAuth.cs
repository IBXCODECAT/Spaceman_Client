using Newtonsoft;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace BlueScreenStudios.Auth
{
    public class PlayFabAuth : MonoBehaviour
    {
        [Header("Window Title")]
        [SerializeField] private TMP_Text windowTitle;

        [Header("Input Fields")]
        [SerializeField] private TMP_InputField usernameField;
        [SerializeField] private TMP_InputField emailField;
        [SerializeField] private TMP_InputField passwordField;

        [Header("Checkboxes")]
        [SerializeField] private Toggle createAccountCheckbox;

        [Header("Text Settings")]
        [SerializeField] private string windowTitleLoginMode;
        [SerializeField] private string windowTitleCreateAccountMode;

        [Header("Outputs")]
        [SerializeField] private Image outputBox;
        [SerializeField] private TMP_Text outputBoxText;

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

        private void Start()
        {
            if(PlayerPrefs.GetInt("PreviousLoginCompleted") == 1)
            {
                createAccountCheckbox.isOn = false;
            }
            else
            {
                createAccountCheckbox.isOn = true;
            }

            UpdateGUI();
        }

        /// <summary>
        /// Runs when the create account checkbox value is changed
        /// </summary>
        public void UpdateGUI()
        {
            emailField.gameObject.SetActive(createAccountCheckbox.isOn);

            if(createAccountCheckbox.isOn)
            {
                windowTitle.text = windowTitleCreateAccountMode;
                outputBoxText.text = "Privacy Notice:\nBy creating an account you agree to our Terms of Service and Privacy Policy";
                outputBox.color = Color.yellow;
            }
            else
            {
                windowTitle.text = windowTitleLoginMode;
                outputBoxText.text = "Automated Account Deletion Notice:\nAccounts that are inactive for more than a year will be automatically deleted.";
                outputBox.color = Color.cyan;
            }
        }

        /// <summary>
        /// Runs once the Continue button is pressed on the Auth screen
        /// </summary>
        public void OnAuthenticate()
        {
            string username = usernameField.text;
            string email = emailField.text;
            string password = passwordField.text;

            Debug.Log("Start Login user: " + username);

            if (createAccountCheckbox.isOn)
            {
                Authenticate(username, email, password);
            }
            else
            {
                Authenticate(username, password);
            }
        }

        /// <summary>
        /// Runs once the Skip button is pressed on the auth screen
        /// </summary>
        public void SkipAuth()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

            Authenticate(result.Username, passwordField.text);
        }

        private void OnLogin(LoginResult result)
        {
            Debug.Log("Logged in:\n" + result.ToJson().ToString());

            outputBoxText.text = "Success!\nLoading...";
            outputBox.color = Color.green;

            PlayerPrefs.SetInt("PreviousLoginCompleted", 1);

            GetUserFlags();
        }

        private void OnAPIError(PlayFabError error)
        {
            Debug.LogError(error.GenerateErrorReport());

            outputBoxText.text = "The server rejected your request...\nReason: " + error.ErrorMessage;
            outputBox.color = Color.red;
        }
    }
}
