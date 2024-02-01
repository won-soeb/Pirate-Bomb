using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuy_ : MonoBehaviour
{
    enum State { Idle, Run, Jump, Hit, Dead };//애니메이션 상태
    Animator anim;
    //private Coroutine coroutine;//코루틴을 변수로 선언하는 이유 - StopCoroutine를 쓰기 위해서
    [SerializeField] private float moveSpeed = 1.5f;
    private int dir = 0;
    private void Awake()
    {
        anim = GetComponent<Animator>();//Animator컴포넌트를 가져오는 방법
        StartCoroutine(CoMove(() => { Debug.Log("코루틴 종료"); })); //StopCoroutine을 쓰기 전 어떤 코루틴을 멈출 것인지 지정한다.
        //coroutine = StartCoroutine(CoMove());
    }
    private void Update()
    {
        /*     if (Input.GetMouseButtonDown(0))//마우스를 클릭하면
             {
                 StopCoroutine(coroutine);//코루틴 정지. 코루틴 인스턴스를 매개변수로 받는다
             }*/
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = 1;
            //transform.position += new Vector3(dir * moveSpeed, 0, 0) * Time.deltaTime;//이동
            transform.localScale = new Vector3(dir, 1, 1);//캐릭터 방향 바꾸기
            AnimState(State.Run);//애니메이션 상태 변환
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
            //float length = flag.transform.position.x - transform.position.x;//깃발과의 거리
            //if (length < 0.5f)//거리가 0.5이하면
            //  break;//루프를 벗어난다
            yield return null;//다음 '프레임'으로 넘어간다
            callback();
        }
    }
    //IEnumerator CoMove()
    //{
    //    while (true)
    //    {
    //        Debug.Log(this.dir);
    //        transform.Translate(this.dir * this.moveSpeed * Time.deltaTime, 0, 0);
    //        float length = flag.transform.position.x - transform.position.x;//깃발과의 거리
    //        if (length < 0.5f)//거리가 0.5이하면
    //            break;//루프를 벗어난다
    //        yield return null;//다음 '프레임'으로 넘어간다
    //    }
    //}
}
