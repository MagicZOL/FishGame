using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] GameObject Logo;
    [SerializeField] GameObject StartMessage;

    bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        if(isActive)
        {
            Logo.SetActive(isActive);
            StartMessage.GetComponent<Animator>().SetTrigger("Message");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Logo.SetActive(!isActive);
            StartMessage.SetActive(!isActive);
        }
    }
}
