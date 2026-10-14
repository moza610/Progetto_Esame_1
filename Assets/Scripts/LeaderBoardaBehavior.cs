using System.Collections;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class LeaderBoardaBehavior : MonoBehaviour
{
    public string FixedDreamloLink;
    public string PlayerName;
    public int PlayerScore;
    int scorePlayer;

    public TMP_InputField PlayerNameInputField;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    string completeLink = FixedDreamloLink + "/add/" + PlayerName + "/" + PlayerScore.ToString();
        //    print(completeLink);
        //    StartCoroutine(GetRequest(completeLink));

        //}


    }

    public void PostScoreOnline()
    {
        PlayerName = PlayerNameInputField.text;
        PlayerScore = Random.Range(1, 1000);
        string completeLink = FixedDreamloLink + "/add/" + PlayerName + "/" + PlayerScore.ToString();
        print(completeLink);
        StartCoroutine(GetRequest(completeLink));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

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
        }
    }
}
