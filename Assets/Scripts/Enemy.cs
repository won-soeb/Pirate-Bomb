using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BombGuy bombGuy;
    enum State { Idle, Run, Attack, Hit, Dead };//적의 애니메이션 상태
    private Vector3 startPos;//초기 고정 위치
    private float dir;//플레이어와의 거리 및 방향
    Animator anim;
    private void Awake()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        dir = bombGuy.transform.position.x - startPos.x;//거리 구하기
        transform.localScale = new(dir > 0 ? 1 : -1, 1, 1);//플레이어를 바라보게 하기
    }
    private void AnimState(State state)
    {
        anim.SetInteger("State", (int)state);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AnimState(State.Attack);//플레이어와 충돌한 경우 공격 애니메이션
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        AnimState(State.Idle);//플레이어와 떨어진 경우 대기 애니메이션
    }
}
