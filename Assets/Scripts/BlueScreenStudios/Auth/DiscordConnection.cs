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
using static System.Net.WebRequestMethods;

namespace BlueScreenStudios.Auth
{
    public class DiscordConnection : MonoBehaviour
    {
        [SerializeField]
        private string requestURL = "https://discord.com/oauth2/authorize?client_id=988833332445978624&redirect_uri=https%3A%2F%2Fbluescreenstudios.net%2F_functions%2FDiscordOauth&response_type=code&scope=identify%20guilds%20guilds.join%20email%20role_connections.write";

        /// <summary>
        /// This method is called by the "Connect Discord" button
        /// </summary>
        public void ConnectDiscord()
        {
            Application.OpenURL(requestURL + "&state=" + AuthResources.state);
        }
    }
}
