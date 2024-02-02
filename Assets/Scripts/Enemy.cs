using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BombGuy bombGuy;
    enum State { Idle, Run, Attack, Hit, Dead };//���� �ִϸ��̼� ����
    private Vector3 startPos;//�ʱ� ���� ��ġ
    private float dir;//�÷��̾���� �Ÿ� �� ����
    private bool isdead;//�������
    Animator anim;
    CircleCollider2D col;
    private void Awake()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();
        col = GetComponent<CircleCollider2D>();//�ݶ��̴� ��������
    }
    private void Update()
    {
        if (!isdead)
        {
            dir = bombGuy.transform.position.x - startPos.x;//�Ÿ� ���ϱ�
            transform.localScale = new(dir > 0 ? 1 : -1, 1, 1);//�÷��̾ �ٶ󺸰� �ϱ�
        }
    }
    private void AnimState(State state)
    {
        anim.SetInteger("State", (int)state);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float colAng = Vector3.Angle(Vector3.up, collision.contacts[0].point);
        //�� ����(0,1,0)�������� �浹 ������ ����
        if (colAng < 20)
        {
            //�÷��̾�� ���̻� �浹���� �ʵ��� �ؾ� ��
            col.offset = new Vector2(0, 50);//�÷��̾�� collision�̺�Ʈ�� ����
            //enable,isTrigger�� �ݶ��̴� Ȱ��ȭ�� ���õ� ������Ƽ�� ����� ��� �ִϸ��̼��� ���ߴ� ������ ����.
            isdead = true;
            AnimState(State.Dead);//�÷��̾�� �浹�� ��� ��� �ִϸ��̼�
            Destroy(gameObject, 2);//1�� �� �ı�
        }
        else
        {
            AnimState(State.Attack);//�÷��̾�� �浹�� ��� ���� �ִϸ��̼�
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        AnimState(State.Idle);//�÷��̾�� ������ ��� ��� �ִϸ��̼�
    }
}
