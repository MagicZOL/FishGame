using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] float minPosY;
    [SerializeField] float maxPosY;

    private void Start()
    {
        ChangePosition();
    }
    public void ChangePosition()
    {
        float positionY = Random.Range(minPosY, maxPosY);

        transform.localPosition = new Vector3(transform.localPosition.x, positionY, transform.localPosition.z);
    }
}
