using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletGenerator : MonoBehaviour
{
    [SerializeField] private float gentimeRate;//총알 생성시간
    [SerializeField] private GameObject enemyBullet;//총알 생성시간
    float timer = 0;//생성시간

    private void Update()
    {
        timer += Time.deltaTime;//시간경과
        //Debug.Log(timer);
        if (timer > gentimeRate)
        {
            timer = 0;
            Instantiate(enemyBullet, transform.position, transform.rotation);//생성
        }
    }
}
