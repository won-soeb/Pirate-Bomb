using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuy : MonoBehaviour
{
    enum State { Idle, Run, Jump, Hit, Dead };//애니메이션 상태
    Animator anim;
    Rigidbody2D rb;
    [SerializeField] private float moveForce = 3f;
    private int dir = 0;//방향값
    private bool isJumping;//점프중인지 판단
    private bool isGameOver;
    private void Awake()
    {
        anim = GetComponent<Animator>();//컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (isJumping) return;

        if (Input.GetKey(KeyCode.RightArrow) && !isGameOver)
        {
            dir = 1;
            rb.AddForce(transform.right * moveForce);//이동
            transform.localScale = new Vector3(dir, 1, 1);//캐릭터 방향 바꾸기
            AnimState(State.Run);//애니메이션 상태 변환
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !isGameOver)
        {
            dir = -1;
            rb.AddForce(-transform.right * moveForce);//이동
            transform.localScale = new Vector3(dir, 1, 1);
            AnimState(State.Run);
        }
        else
        {
            dir = 0;
            AnimState(State.Idle);
        }

        if (Input.GetKey(KeyCode.UpArrow) && !isGameOver)
        {
            isJumping = true;
            rb.AddForce(transform.up * 5, ForceMode2D.Impulse);//점프
            AnimState(State.Jump);
        }
        //화면 이탈 방지
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,
            -2.3f, 2.3f), transform.position.y);
        //속도제한
        if (Mathf.Abs(rb.velocity.x) > 0.1f) return;
    }
    private void AnimState(State state)
    {
        anim.SetInteger("State", (int)state);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;//점프해제

        float colAng = Vector3.Angle(Vector3.up, collision.contacts[0].point);
        //위 방향(0,1,0)기준으로 충돌 각도를 추출
        if (collision.gameObject.name == "Enemy" && colAng > 20)//적에게 닿았을 경우
        {
            AnimState(State.Dead);//플레이어와 충돌한 경우 사망 애니메이션
            Invoke("Dead", 1.5f);//1.5초 후 플레이어를 비활성화한다.
            isGameOver = true;
        }
    }
    private void Dead()
    {
        gameObject.SetActive(false);//비활성화
        //Destroy()할 경우 nullReferenceException이 발생한다.
    }
}
