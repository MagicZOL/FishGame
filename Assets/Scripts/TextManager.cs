using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] GameObject Logo;
    [SerializeField] GameObject StartMessage;

    [SerializeField] GameObject Score;
    bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        if(isActive)
        {
            Score.SetActive(!isActive);
            Logo.SetActive(isActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Score.SetActive(isActive);
            Logo.SetActive(!isActive);
            StartMessage.SetActive(!isActive);
        }
    }
}
