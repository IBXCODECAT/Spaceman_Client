using PlayFab;
using PlayFab.ClientModels;
using System.Threading;
using System.Net;
using UnityEngine;
using System;
using System.IO;

namespace BlueScreenStudios.Auth
{
    public class DiscordConnection : MonoBehaviour
    {
        private HttpListener listener;
        private Thread listenerThread;

        private string tokenExchangeCode;

        [Header("Configuration")]
        [SerializeField] private string requestURL;
        [SerializeField] private short port;

        private void Start()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:" + port + "/");
            listener.Prefixes.Add("http://127.0.0.1:" + port + "/");
            listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            listener.Start();

            listenerThread = new Thread(StartListener);
            listenerThread.Start();
            Debug.Log("HTTP listener started.");

            Application.OpenURL(requestURL);
        }

        private void StartListener()
        {
            while (true)
            {
                var result = listener.BeginGetContext(ListenerCallback, listener);
                result.AsyncWaitHandle.WaitOne();
            }
        }

        private void ListenerCallback(IAsyncResult result)
        {
            var context = listener.EndGetContext(result);

            Debug.Log("Method: " + context.Request.HttpMethod);
            Debug.Log("LocalUrl: " + context.Request.Url.LocalPath);

            if (context.Request.QueryString.AllKeys.Length > 0)
                foreach (var key in context.Request.QueryString.AllKeys)
                {
                    Debug.Log("Response Recieveed | Key: " + key + ", Value: " + context.Request.QueryString.GetValues(key)[0]);
                    
                    if(key.ToLower().Equals("code"))
                    {
                        tokenExchangeCode = context.Request.QueryString.GetValues(key)[0];
                    }
                }

            if (context.Request.HttpMethod == "POST")
            {
                Thread.Sleep(1000);
                var data_text = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding).ReadToEnd();
                Debug.Log(data_text);
            }

            context.Response.Close();
        }

        /// <summary>
        /// Exchange the "code" we recieved from discord for the users token in cloud script
        /// Cloud script function will add the token to the player's internal data (client can not access this data)
        /// </summary>
        internal void SendDiscordTokenExchange()
        {
            ExecuteCloudScriptRequest request = new ExecuteCloudScriptRequest
            {
                FunctionName = "DiscordTokenExchange",
                FunctionParameter = new { code = tokenExchangeCode}
            };

            PlayFabClientAPI.ExecuteCloudScript(request, ExecuteCloudScriptCallback, OnError);
        }

        private void ExecuteCloudScriptCallback(ExecuteCloudScriptResult result)
        {
            Debug.Log(result.FunctionResult.ToString());
        }

        private void OnError(PlayFabError error)
        {
            Debug.LogError(error.GenerateErrorReport());
        }
    }
}
