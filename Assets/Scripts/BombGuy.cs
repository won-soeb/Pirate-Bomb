using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuy : MonoBehaviour
{
    enum State { Idle, Run, Jump, Hit, Dead };//�ִϸ��̼� ����
    Animator anim;
    Rigidbody2D rb;
    [SerializeField] private float moveForce = 3f;
    private int dir = 0;//���Ⱚ
    private bool isJumping;//���������� �Ǵ�
    private bool isGameOver;
    private void Awake()
    {
        anim = GetComponent<Animator>();//������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (isJumping) return;

        if (Input.GetKey(KeyCode.RightArrow) && !isGameOver)
        {
            dir = 1;
            rb.AddForce(transform.right * moveForce);//�̵�
            transform.localScale = new Vector3(dir, 1, 1);//ĳ���� ���� �ٲٱ�
            AnimState(State.Run);//�ִϸ��̼� ���� ��ȯ
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !isGameOver)
        {
            dir = -1;
            rb.AddForce(-transform.right * moveForce);//�̵�
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
            rb.AddForce(transform.up * 5, ForceMode2D.Impulse);//����
            AnimState(State.Jump);
        }
        //ȭ�� ��Ż ����
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,
            -2.3f, 2.3f), transform.position.y);
        //�ӵ�����
        if (Mathf.Abs(rb.velocity.x) > 0.1f) return;
    }
    private void AnimState(State state)
    {
        anim.SetInteger("State", (int)state);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;//��������

        float colAng = Vector3.Angle(Vector3.up, collision.contacts[0].point);
        //�� ����(0,1,0)�������� �浹 ������ ����
        if (collision.gameObject.name == "Enemy" && colAng > 20)//������ ����� ���
        {
            AnimState(State.Dead);//�÷��̾�� �浹�� ��� ��� �ִϸ��̼�
            Invoke("Dead", 1.5f);//1.5�� �� �÷��̾ ��Ȱ��ȭ�Ѵ�.
            isGameOver = true;
        }
    }
    private void Dead()
    {
        gameObject.SetActive(false);//��Ȱ��ȭ
        //Destroy()�� ��� nullReferenceException�� �߻��Ѵ�.
    }
}
