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
        rb.AddForce(new Vector3(0, 20, 200));
    }
}
