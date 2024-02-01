using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BombGuy bombGuy;
    enum State { Idle, Run, Attack, Hit, Dead };//���� �ִϸ��̼� ����
    private Vector3 startPos;//�ʱ� ���� ��ġ
    private float dir;//�÷��̾���� �Ÿ� �� ����
    Animator anim;
    private void Awake()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        dir = bombGuy.transform.position.x - startPos.x;//�Ÿ� ���ϱ�
        transform.localScale = new(dir > 0 ? 1 : -1, 1, 1);//�÷��̾ �ٶ󺸰� �ϱ�
    }
    private void AnimState(State state)
    {
        anim.SetInteger("State", (int)state);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AnimState(State.Attack);//�÷��̾�� �浹�� ��� ���� �ִϸ��̼�
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        AnimState(State.Idle);//�÷��̾�� ������ ��� ��� �ִϸ��̼�
    }
}
