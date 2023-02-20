using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace BlueScreenStudios.Auth
{
    [RequireComponent(typeof(DiscordConnection))]
    public class PlayFabAuth : MonoBehaviour
    {
        #region Inspector
        [Header("Window Title")]
        [Tooltip("A reference to the window title.")]
        [SerializeField] private TMP_Text windowTitle;

        [Header("Input Fields")]
        [Tooltip("A reference to the username field.")]
        [SerializeField] private TMP_InputField usernameField;
        [Tooltip("A reference to the email field.")]
        [SerializeField] private TMP_InputField emailField;
        [Tooltip("A reference to the password field.")]
        [SerializeField] private TMP_InputField passwordField;

        [Header("Checkboxes")]
        [Tooltip("A reference to the 'I am creating a new account' toggle.")]
        [SerializeField] private Toggle createAccountCheckbox;

        [Header("Outputs")]
        [Tooltip("A reference to the text that appears in the authentication feedback box.")]
        [SerializeField] private TMP_Text authFeedbackBoxText;

        [Header("Animators")]
        [Tooltip("A reference to the animator in charge of coloring and fading the feedback box.")]
        [SerializeField] private Animator guiAnimator;

        [Header("Text Settings")]
        [Tooltip("This text will be displayed in the window title when the user is logging in.")]
        [SerializeField] private string windowTitleLoginMode;
        [Tooltip("This text will be displayed in the window title when the user is registering a new account.")]
        [SerializeField] private string windowTitleCreateAccountMode;
        #endregion Inspector

        #region Data
        /// <summary>
        /// The flags associated with this account
        /// Example: is_staff
        /// </summary>
        public static AccountFlagsData flags;

        /// <summary>
        /// The animator parameter key for a rejected authentication attempt
        /// </summary>
        private const string animatorKeyRejected = "Reject";

        /// <summary>
        /// The animator parameter key for a confirmed authentication attempt
        /// </summary>
        private const string animatorKeyConfirm = "Confirm";

        internal static AccountFlagsData Flags { get => flags; set => flags = value; }
        #endregion Data

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
            if(SceneManager.GetActiveScene().name == "Authentication")
            {
                //If the player has logged in before we should present them with the login screen by default 
                if (PlayerPrefs.GetInt("PreviousLoginCompleted") == 1) createAccountCheckbox.isOn = false;
                else createAccountCheckbox.isOn = true;

                //Update the GUI to reflect this change
                UpdateGUI();
            }
        }

        /// <summary>
        /// Update the input fields and descriptions based on if we are loggin in or registering a new user
        /// </summary>
        public void UpdateGUI()
        {
            //Display the email field if we are creating an account
            emailField.gameObject.SetActive(createAccountCheckbox.isOn);

            //Display the appropriate message for logging in vs registering a user
            if(createAccountCheckbox.isOn)
            {
                windowTitle.text = windowTitleCreateAccountMode;
                authFeedbackBoxText.text = "Privacy Notice:\nBy creating an account you agree to our Terms of Service and Privacy Policy";
            }
            else
            {
                windowTitle.text = windowTitleLoginMode;
                authFeedbackBoxText.text = "Automated Account Deletion Notice:\nAccounts that are inactive for more than a year will be automatically deleted.";
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

            //Authenticate the user
            if (createAccountCheckbox.isOn) Authenticate(username, email, password);
            else Authenticate(username, password);
        }

        /// <summary>
        /// Runs once the Skip button is pressed on the auth screen
        /// </summary>
        public void SkipAuth()
        {
            guiAnimator.SetBool(animatorKeyConfirm, true);
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

            flags = JsonConvert.DeserializeObject<AccountFlagsData>(executionResult.FunctionResult.ToString());

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
            authFeedbackBoxText.text = "Registering Account...";

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
            authFeedbackBoxText.text = "Loggin In...";

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

            authFeedbackBoxText.text = "Success!\nLoading...";

            PlayerPrefs.SetInt("PreviousLoginCompleted", 1);

            GetUserFlags();

            guiAnimator.SetBool(animatorKeyConfirm, true);
        }

        private void OnAPIError(PlayFabError error)
        {
            Debug.LogError(error.GenerateErrorReport());

            guiAnimator.SetBool(animatorKeyRejected, true);

            authFeedbackBoxText.text = "The server rejected your request...\nReason: " + error.ErrorMessage;

            StartCoroutine(ResetAnimator());
        }


        IEnumerator ResetAnimator()
        {
            yield return new WaitForSecondsRealtime(0.25f);

            guiAnimator.SetBool(animatorKeyRejected, false);
            guiAnimator.SetBool(animatorKeyConfirm, false);
        }
    }
}
