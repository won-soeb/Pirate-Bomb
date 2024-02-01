using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuy_ : MonoBehaviour
{
    enum State { Idle, Run, Jump, Hit, Dead };//�ִϸ��̼� ����
    Animator anim;
    //private Coroutine coroutine;//�ڷ�ƾ�� ������ �����ϴ� ���� - StopCoroutine�� ���� ���ؼ�
    [SerializeField] private float moveSpeed = 1.5f;
    private int dir = 0;
    private void Awake()
    {
        anim = GetComponent<Animator>();//Animator������Ʈ�� �������� ���
        StartCoroutine(CoMove(() => { Debug.Log("�ڷ�ƾ ����"); })); //StopCoroutine�� ���� �� � �ڷ�ƾ�� ���� ������ �����Ѵ�.
        //coroutine = StartCoroutine(CoMove());
    }
    private void Update()
    {
        /*     if (Input.GetMouseButtonDown(0))//���콺�� Ŭ���ϸ�
             {
                 StopCoroutine(coroutine);//�ڷ�ƾ ����. �ڷ�ƾ �ν��Ͻ��� �Ű������� �޴´�
             }*/
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = 1;
            //transform.position += new Vector3(dir * moveSpeed, 0, 0) * Time.deltaTime;//�̵�
            transform.localScale = new Vector3(dir, 1, 1);//ĳ���� ���� �ٲٱ�
            AnimState(State.Run);//�ִϸ��̼� ���� ��ȯ
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = -1;
            //transform.position += new Vector3(dir * moveSpeed, 0, 0) * Time.deltaTime;
            transform.localScale = new Vector3(dir, 1, 1);
            AnimState(State.Run);
        }
        else
        {
            dir = 0;
            AnimState(State.Idle);
        }
    }
    private void AnimState(State state)
    {
        anim.SetInteger("State", (int)state);
    }
    IEnumerator CoMove(Action callback)
    {
        while (true)
        {
            transform.Translate(dir * moveSpeed * Time.deltaTime, 0, 0);
            //float length = flag.transform.position.x - transform.position.x;//��߰��� �Ÿ�
            //if (length < 0.5f)//�Ÿ��� 0.5���ϸ�
            //  break;//������ �����
            yield return null;//���� '������'���� �Ѿ��
            callback();
        }
    }
    //IEnumerator CoMove()
    //{
    //    while (true)
    //    {
    //        Debug.Log(this.dir);
    //        transform.Translate(this.dir * this.moveSpeed * Time.deltaTime, 0, 0);
    //        float length = flag.transform.position.x - transform.position.x;//��߰��� �Ÿ�
    //        if (length < 0.5f)//�Ÿ��� 0.5���ϸ�
    //            break;//������ �����
    //        yield return null;//���� '������'���� �Ѿ��
    //    }
    //}
}
