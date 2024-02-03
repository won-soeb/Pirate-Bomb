using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BossEnemy : EnemyGroup
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(playerBullet);
        StartCoroutine(Damage());
        if (HP <= 0)
        {
            EnemyDead();
        }
    }
    //������ ���� ���� �߰�
}
