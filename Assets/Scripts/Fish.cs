using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] float jumpVelocity;
    [SerializeField] float maxHight;
    [SerializeField] GameObject sprite;
    [SerializeField] FlashImage flashImage;

    Animator animator;
    Rigidbody2D rigidbody;
    bool isDead;

    public bool IsDead
    {
        get
        {
            return this.isDead;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 터치시 && 최고높이가 아닐시 if문 실행
        if (Input.GetButtonDown("Fire1") && transform.position.y < maxHight) 
        {
            if(!isDead && rigidbody.isKinematic==false)
            {
                rigidbody.velocity = new Vector2(0f, jumpVelocity);
            }
        }

        //물고기 회전
        float angle;
        
        if(isDead)
        {
            angle = -90;
        }
        else
        {
            angle = Mathf.Atan2(rigidbody.velocity.y, 10) * Mathf.Rad2Deg; //각도 구하기
        }

        sprite.transform.localRotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Camera.main.SendMessage("Shake");

        flashImage.StartFlash();
        //물고기 사망처리 
        isDead = true;

        animator.speed = 0.0f;
    }
    
    public void SetKinematic(bool value)
    {
        rigidbody.isKinematic = value;
    }
}
