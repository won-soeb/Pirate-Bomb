using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 0.03f;
    Player player;
    Vector3 target;
    public enum EnemyTypes { A, B, C, Boss }
    public EnemyTypes enemyTypes;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        if (player != null)
        {
            target = player.transform.position;
        }
    }
    private void Update()
    {
        switch (enemyTypes)
        {
            case EnemyTypes.A:
                BulletA();
                break;
            case EnemyTypes.B:
                BulletB();
                break;
            case EnemyTypes.C:
                BulletC();
                break;
            case EnemyTypes.Boss:
                break;
        }
        Destroy(gameObject, 7);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Boom")
        {
            //Debug.Log("총알이 " + col.gameObject + "(과)와 충돌함");
            Destroy(gameObject);
        }
    }
    private void BulletA()
    {
        //Debug.Log("플레이어에게 접근중.");
    }
    private void BulletB()//아래방향으로 쏘기
    {
        transform.Translate(Vector3.down * bulletSpeed / 10);
    }
    private void BulletC()//플레이어를 향해 쏘기
    {
        Vector3 dir = (target - transform.position).normalized;

        if (player == null)//플레이어가 사망했으면
        {
            transform.Translate(Vector3.down * bulletSpeed / 10);
        }
        else
        {
            transform.Translate(dir * bulletSpeed / 10);//플레이어 위치에서 멈추는 문제 있음.
        }
    }
}
