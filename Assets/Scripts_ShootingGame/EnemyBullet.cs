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
            //Debug.Log("�Ѿ��� " + col.gameObject + "(��)�� �浹��");
            Destroy(gameObject);
        }
    }
    private void BulletA()
    {
        //Debug.Log("�÷��̾�� ������.");
    }
    private void BulletB()//�Ʒ��������� ���
    {
        transform.Translate(Vector3.down * bulletSpeed / 10);
    }
    private void BulletC()//�÷��̾ ���� ���
    {
        Vector3 dir = (target - transform.position).normalized;

        if (player == null)//�÷��̾ ���������
        {
            transform.Translate(Vector3.down * bulletSpeed / 10);
        }
        else
        {
            transform.Translate(dir * bulletSpeed / 10);//�÷��̾� ��ġ���� ���ߴ� ���� ����.
        }
    }
}
