using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bamsongi : MonoBehaviour
{
    Rigidbody rb;
    ParticleSystem part;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        part = GetComponent<ParticleSystem>();
    }
    private void FixedUpdate()
    {
        Shoot();
        Destroy(gameObject, 2);
    }
    private void OnCollisionEnter(Collision collision)//����� �浹�ϸ�
    {
        Debug.Log(collision.gameObject.name + "��(��) �浹!");
        rb.isKinematic = true;//������ ����
        part.Play();//��ƼŬ ���
        Destroy(gameObject, 2);//��ƼŬ ��� �� �ı�
    }
    public void Shoot()
    {
        //ȭ����ġ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction, Color.yellow, 100);
        rb.AddForce(ray.direction.normalized * 3000);
    }
}
