using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;     //속도
    [SerializeField] float startPosition;   //나갔다가 다시 나타날위치
    [SerializeField] float endPosiotion;    //스크롤되서 나간지점

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0); //왼쪽 방향으로 이동

        if(transform.position.x <= endPosiotion) //나간지점에 도달했다면
        {
            transform.Translate(-1 * (endPosiotion - startPosition), 0, 0);

            //파이프가 처음 있었다 사라질 상황
            SendMessage("ChangePosition", SendMessageOptions.DontRequireReceiver);
        }
    }
}
