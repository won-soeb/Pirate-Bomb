using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : EnemyGroup
{
    [SerializeField] private float moveSpeed = 0.01f;
    [SerializeField] private int scoreUp;
    private void Update()
    {
        transform.Translate(-transform.up * moveSpeed / 10);
        if(transform.position.y <= 1)
        {
            transform.position = new Vector3(transform.position.x, 1, 0);
        }//y��ǥ�� 1���Ϸ� �������� ���ϰ� �Ѵ�
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(playerBullet);//�÷��̾��� �Ѿ��� ������ �Ѿ��� �����ϰ�
        StartCoroutine(Damage());//ü���� �Ҹ���
        if (HP <= 0)
        {
            EnemyDead();//���
            ScoreUp(scoreUp);//N�� �߰�(Ư�� Ÿ��)
            DropItem(dropPercent);//�������� Ȯ�������� ���
        }
    }
}
