using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;


namespace BlueScreenStudios.Common
{
    public class StreamTextures : MonoBehaviour
    {
        [SerializeField] Material material;

        [Header("Colors")]
        [SerializeField] internal Color baseColor;
        [ColorUsage(true, true)]
        [SerializeField] internal Color emissionColor;

        [Header("Resource Names")]
        [SerializeField] internal string baseMap;
        [SerializeField] internal string normalMap;
        [SerializeField] internal string emissionMap;

        private void Awake()
        {
            string basePath = Application.streamingAssetsPath + "/Textures/";
            
            StartCoroutine(LoadTextureFromCache(basePath + baseMap, "_BaseColorMap"));

            material.EnableKeyword("_NORMALMAP_TANGENT_SPACE");
            material.EnableKeyword("_EMISSIVE_MAPPING_BASE");
            material.EnableKeyword("_EMISSIVE_MAPPING_TRIPLANAR");
            material.EnableKeyword("_EMISSIVE_MAPPING_PLANAR");

            StartCoroutine(LoadTextureFromCache(basePath + normalMap, "_NormalMap"));

            StartCoroutine(LoadTextureFromCache(basePath + emissionMap, "_EmissiveColorMap"));

            material.SetColor("_BaseColor", baseColor);
            material.SetColor("_EmissiveColor", emissionColor);
        }

        IEnumerator LoadTextureFromCache(string filePath, string mapName)
        {
            if (!File.Exists(filePath))
            {
                Debug.LogError("Could not find file: " + filePath);
                yield break;
            }
            
            UnityWebRequest uwr = UnityWebRequestTexture.GetTexture("file://" + filePath);
            
            yield return uwr.SendWebRequest();
            
            Texture2D texture = DownloadHandlerTexture.GetContent(uwr);

            material.SetTexture(mapName, texture);

            Debug.Log("Done");
        }
    }
}
