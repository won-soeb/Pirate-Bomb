using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 0.1f;

    private void Update()
    {
        transform.Translate(transform.up * bulletSpeed);//위로 이동
        if (transform.position.y > 6)//총알이 화면 밖으로 나가면
        {
            Destroy(gameObject);//파괴
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            Debug.Log("총알이 " + col.gameObject + "(과)와 충돌함");
            Destroy(gameObject);//파괴
        }
    }
}
