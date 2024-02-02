using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    public int damage = 1;

    private void Update()
    {
        transform.Translate(transform.up * bulletSpeed);
        Destroy(gameObject, 3);        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col + " 충돌");
        Destroy(gameObject);
        //파티클 추가 예정
    }
}
