using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class PLayerScoreBehavior : MonoBehaviour
{
    public string[] PlayersData;
    public List<string> PlayersName = new List <string>() ;
    public List<int> PlayerScore = new List<int>();


    public TMP_InputField PlayerNameInputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(GetRequest("http://dreamlo.com/lb/6ac61aed8f40bb15a8d2a8f1/quote"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
            
            //check error
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }

            string pageContent = webRequest.downloadHandler.text;

            //tagliamo quando c'� l'invio
            PlayersData = pageContent.Split('\n');

            for (int i = 0; i < PlayersData.Length; i++)    
                //iniziamo a tutelarci dalle righe vuotes

                if (! string.IsNullOrEmpty(PlayersData[i]))
                {
                    string[] lineElements = PlayersData[i].Split(',');
                    string PlayerNameCleanup = lineElements[0].Trim('"');
              
                    PlayersName.Add(PlayerNameCleanup);

                }
        }
    }
}
