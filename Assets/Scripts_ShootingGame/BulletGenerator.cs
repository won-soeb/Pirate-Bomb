using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private GameObject playerBullet;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerBullet, transform.position, Quaternion.identity);//»ý¼º
        }
    }
}
