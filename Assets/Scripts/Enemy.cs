using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BombGuy bombGuy;
    enum State { Idle, Run, Attack, Hit, Dead };//적의 애니메이션 상태
    private Vector3 startPos;//초기 고정 위치
    private float dir;//플레이어와의 거리 및 방향
    private bool isdead;//사망여부
    Animator anim;
    CircleCollider2D col;
    private void Awake()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();
        col = GetComponent<CircleCollider2D>();//콜라이더 가져오기
    }
    private void Update()
    {
        if (!isdead)
        {
            dir = bombGuy.transform.position.x - startPos.x;//거리 구하기
            transform.localScale = new(dir > 0 ? 1 : -1, 1, 1);//플레이어를 바라보게 하기
        }
    }
    private void AnimState(State state)
    {
        anim.SetInteger("State", (int)state);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float colAng = Vector3.Angle(Vector3.up, collision.contacts[0].point);
        //위 방향(0,1,0)기준으로 충돌 각도를 추출
        if (colAng < 20)
        {
            //플레이어와 더이상 충돌하지 않도록 해야 함
            col.offset = new Vector2(0, 50);//플레이어와 collision이벤트를 막음
            //enable,isTrigger등 콜라이더 활성화에 관련된 프로퍼티를 사용할 경우 애니메이션이 멈추는 문제가 있음.
            isdead = true;
            AnimState(State.Dead);//플레이어와 충돌한 경우 사망 애니메이션
            Destroy(gameObject, 2);//1초 후 파괴
        }
        else
        {
            AnimState(State.Attack);//플레이어와 충돌한 경우 공격 애니메이션
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        AnimState(State.Idle);//플레이어와 떨어진 경우 대기 애니메이션
    }
}
