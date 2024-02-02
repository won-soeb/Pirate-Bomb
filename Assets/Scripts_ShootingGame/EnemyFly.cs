using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private void OnCollisionEnter2D(Collision2D col)//�÷��̾��� �Ѿ˿� ���� ���
    {
        //Debug.Log("���� " + col + "(��)�� �浹��");
        EnemyDead();
    }
    private void OnTriggerEnter2D(Collider2D col)//�÷��̾�� �ε��� ���
    {
        //Debug.Log("���� "+ col + "(��)�� �����");
        EnemyDead();
    }
    public void EnemyDead()
    {
        Instantiate(explosion,transform.position, Quaternion.identity);//��ƼŬ        
        Destroy(gameObject);
    }
}
