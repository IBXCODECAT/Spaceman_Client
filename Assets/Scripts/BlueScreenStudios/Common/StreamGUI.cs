using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace BlueScreenStudios.Common
{
    [RequireComponent(typeof(RawImage))]
    public class StreamGUI : MonoBehaviour
    {
        [Header("Color Filter")]
        [SerializeField] internal Color spriteColor;

        [Header("Resource Path")]
        [SerializeField] internal string spritePath;

        private string basePath = Application.streamingAssetsPath + "/Textures/";

        private void Awake()
        {
            StartCoroutine(LoadTextureFromCache(basePath + spritePath));    
        }

        private IEnumerator LoadTextureFromCache(string filePath)
        {
            if (filePath != basePath)
            {
                if (!File.Exists(filePath))
                {
                    Debug.LogError("Could not find file: " + filePath);
                    yield break;
                }

                UnityWebRequest uwr = UnityWebRequestTexture.GetTexture("file://" + filePath);

                yield return uwr.SendWebRequest();

                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);

                RawImage graphic = GetComponent<RawImage>();
                graphic.texture = texture;
                graphic.color = spriteColor;


            }
        }
    }
}
