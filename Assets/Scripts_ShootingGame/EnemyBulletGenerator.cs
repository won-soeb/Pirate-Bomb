using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletGenerator : MonoBehaviour
{
    [SerializeField] private float gentimeRate;//�Ѿ� �����ð�
    [SerializeField] private GameObject enemyBullet;//�Ѿ� �����ð�
    float timer = 0;//�����ð�

    private void Update()
    {
        timer += Time.deltaTime;//�ð����
        //Debug.Log(timer);
        if (timer > gentimeRate)
        {
            timer = 0;
            Instantiate(enemyBullet, transform.position, transform.rotation);//����
        }
    }
}
