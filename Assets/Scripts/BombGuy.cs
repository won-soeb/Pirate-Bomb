using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuy : MonoBehaviour
{
    enum State { Idle, Run, Jump, Hit, Dead };//�ִϸ��̼� ����
    private State state;
    Animator anim;
    Rigidbody2D rb;
    //private Coroutine coroutine;//�ڷ�ƾ�� ������ �����ϴ� ���� - StopCoroutine�� ���� ���ؼ�
    [SerializeField] private float moveForce = 3f;
    private int dir = 0;//���Ⱚ
    private bool isJumping;//���������� �Ǵ�
    private void Awake()
    {
        anim = GetComponent<Animator>();//������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (isJumping) return;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = 1;
            rb.AddForce(transform.right * moveForce);//�̵�
            transform.localScale = new Vector3(dir, 1, 1);//ĳ���� ���� �ٲٱ�
            AnimState(State.Run);//�ִϸ��̼� ���� ��ȯ
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = -1;
            rb.AddForce(-transform.right * moveForce);//�̵�
            transform.localScale = new Vector3(dir, 1, 1);
            AnimState(State.Run);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            isJumping = true;
            rb.AddForce(transform.up * 5, ForceMode2D.Impulse);//����
            AnimState(State.Jump);
        }
        else
        {
            dir = 0;
            AnimState(State.Idle);
        }
        //ȭ�� ��Ż ����
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,
            -2.3f, 2.3f), transform.position.y);
        //�ӵ�����
        if (Mathf.Abs(rb.velocity.x) > 0.1f) return;

        //�̵��ӵ��� ���� �ִϸ��̼� �ݿ�
        //anim.speed = Mathf.Abs(rb.velocity.x * 2);


        //Debug.Log(rb.velocity.x);
    }
    private void AnimState(State state)
    {
        anim.SetInteger("State", (int)state);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;//��������
    }
}
