using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 0.1f;

    private void Update()
    {
        transform.Translate(transform.up * bulletSpeed);
        Destroy(gameObject, 3);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            Debug.Log("�Ѿ��� " + col.gameObject + "(��)�� �浹��");
            Destroy(gameObject);
        }
    }
}
