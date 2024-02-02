using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private void OnCollisionEnter2D(Collision2D col)//플레이어의 총알에 맞은 경우
    {
        //Debug.Log("적이 " + col + "(과)와 충돌함");
        EnemyDead();
    }
    private void OnTriggerEnter2D(Collider2D col)//플레이어와 부딪힌 경우
    {
        //Debug.Log("적이 "+ col + "(을)를 통과함");
        EnemyDead();
    }
    public void EnemyDead()
    {
        Instantiate(explosion,transform.position, Quaternion.identity);//파티클        
        Destroy(gameObject);
    }
}
