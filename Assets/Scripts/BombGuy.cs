using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuy : MonoBehaviour
{
    enum State { Idle, Run, Jump, Hit, Dead };//애니메이션 상태
    private State state;
    Animator anim;
    Rigidbody2D rb;
    //private Coroutine coroutine;//코루틴을 변수로 선언하는 이유 - StopCoroutine를 쓰기 위해서
    [SerializeField] private float moveForce = 3f;
    private int dir = 0;//방향값
    private bool isJumping;//점프중인지 판단
    private void Awake()
    {
        anim = GetComponent<Animator>();//컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (isJumping) return;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = 1;
            rb.AddForce(transform.right * moveForce);//이동
            transform.localScale = new Vector3(dir, 1, 1);//캐릭터 방향 바꾸기
            AnimState(State.Run);//애니메이션 상태 변환
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = -1;
            rb.AddForce(-transform.right * moveForce);//이동
            transform.localScale = new Vector3(dir, 1, 1);
            AnimState(State.Run);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            isJumping = true;
            rb.AddForce(transform.up * 5, ForceMode2D.Impulse);//점프
            AnimState(State.Jump);
        }
        else
        {
            dir = 0;
            AnimState(State.Idle);
        }
        //화면 이탈 방지
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,
            -2.3f, 2.3f), transform.position.y);
        //속도제한
        if (Mathf.Abs(rb.velocity.x) > 0.1f) return;

        //이동속도에 따라서 애니메이션 반영
        //anim.speed = Mathf.Abs(rb.velocity.x * 2);


        //Debug.Log(rb.velocity.x);
    }
    private void AnimState(State state)
    {
        anim.SetInteger("State", (int)state);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;//점프해제
    }
}
