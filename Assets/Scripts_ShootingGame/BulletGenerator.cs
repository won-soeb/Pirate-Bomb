using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] playerBullet;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.playerDamage > 1)
            {
                Instantiate(playerBullet[1], transform.position, Quaternion.identity);//持失
            }
            else
            {
                Instantiate(playerBullet[0], transform.position, Quaternion.identity);//持失
            }
        }
    }
}
