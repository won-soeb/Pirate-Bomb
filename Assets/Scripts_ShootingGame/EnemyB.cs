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
        }//y좌표가 1이하로 내려오지 못하게 한다
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(playerBullet);//플레이어의 총알을 맞으면 총알을 제거하고
        StartCoroutine(Damage());//체력을 소모함
        if (HP <= 0)
        {
            EnemyDead();//사망
            ScoreUp(scoreUp);//N점 추가(특수 타입)
            DropItem(dropPercent);//아이템을 확률적으로 드랍
        }
    }
}
