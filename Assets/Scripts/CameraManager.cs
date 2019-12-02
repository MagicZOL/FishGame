using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{   
    public void Shake()
    {
        GetComponent<Animator>().SetTrigger("shake");
    }
}
