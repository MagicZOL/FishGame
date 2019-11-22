﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetTrigger("Message");   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gameObject.SetActive(false);
        }
    }
}
