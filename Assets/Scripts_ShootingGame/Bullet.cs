using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 0.1f;

    private void Update()
    {
        transform.Translate(transform.up * bulletSpeed);//���� �̵�
        if (transform.position.y > 6)//�Ѿ��� ȭ�� ������ ������
        {
            Destroy(gameObject);//�ı�
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            Debug.Log("�Ѿ��� " + col.gameObject + "(��)�� �浹��");
            Destroy(gameObject);//�ı�
        }
    }
}
