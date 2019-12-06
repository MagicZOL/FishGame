using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

struct UserId
{
    public string id;
    public string username;
}

struct UserScore
{
    public string id;
    public int score;
}
public class NetWork : MonoBehaviour
{
    public static NetWork Instance;

    string serverAddr = "https://myfishserverzol.herokuapp.com";
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void GetServerID(string username, Action success, Action fail)
    {
        StartCoroutine(GetServerIDCoroutine(username,success,fail));
    }

    // 서버에서 Server ID 받기
    IEnumerator GetServerIDCoroutine(string username, Action success, Action fail)
    {
        UnityWebRequest www = UnityWebRequest.Get(serverAddr +"/users/new/" + username);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            fail();
        }
        else
        {
            Debug.Log(www.downloadHandler.text);

            string result = www.downloadHandler.text;

            //UserId resultobj = JsonUtility.FromJson<UserId>(result);
            UserId resultobj = JsonUtility.FromJson<UserId>(result);
            //ID를 저장
            PlayerPrefs.SetString("id", resultobj.id);
            PlayerPrefs.SetString("username", resultobj.username);
            
            success();
        }
    }

    public void UpdateBestScore(string id, int bestScore)
    {
        StartCoroutine(UpdateBestScoreCoroutin(id, bestScore));
    }

    IEnumerator UpdateBestScoreCoroutin(string id, int bestScore)
    {
        UserScore userScore = new UserScore { id = id, score = bestScore };

        string postData = JsonUtility.ToJson(userScore);

        UnityWebRequest www = UnityWebRequest.Put(serverAddr + "/score/add", postData);

        www.SetRequestHeader("content-Type", "application/json");
        www.method = "POST";
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
}
