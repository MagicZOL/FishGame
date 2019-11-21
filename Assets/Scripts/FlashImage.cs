using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlashImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            float alpha = GetComponent<Image>().color.a;
            alpha -= 0.03f;
            GetComponent<Image>().color = new Color(1, 1, 1, alpha);

            if(alpha < 0.01f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    ////비활성화 되었을 때
    //private void OnDisable()
    //{
    //    GetComponent<Image>().color = new Color(1, 1, 1, 1);
    //}
    public void StartFlash()
    {
        gameObject.SetActive(true);
    }
}
