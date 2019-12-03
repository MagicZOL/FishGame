using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class NetWork : MonoBehaviour
{
    public static NetWork Instance;

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void GetServerID()
    {
        StartCoroutine(GetServerIDCoroutine("Hong"));
    }

    // 서버에서 Server ID 받기
    IEnumerator GetServerIDCoroutine(string username)
    {
        UnityWebRequest www = UnityWebRequest.Get("localhost:3000/users/new/" + username);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
}
