using PlayFab;
using PlayFab.ClientModels;
using System.Threading;
using System.Net;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using Discord;
using UnityEngine.UI;
using TMPro;

namespace BlueScreenStudios.Auth
{
    public class DiscordConnection : MonoBehaviour
    {
        private string bearer_auth_token;

        [Header("Configuration")]
        [SerializeField] private string requestURL;

        /// <summary>
        /// This method is called by the "Connect Discord" button
        /// </summary>
        public void ConnectDiscord()
        {
            Application.OpenURL(requestURL);
        }
    }
}
