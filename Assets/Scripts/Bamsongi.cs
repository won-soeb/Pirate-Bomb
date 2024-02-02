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
    private void OnCollisionEnter(Collision collision)//과녁과 충돌하면
    {
        Debug.Log(collision.gameObject.name + "과(와) 충돌!");
        rb.isKinematic = true;//움직임 정지
        part.Play();//파티클 재생
        Destroy(gameObject, 2);//파티클 재생 후 파괴
    }
    public void Shoot()
    {
        //화면터치방향
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction, Color.yellow, 100);
        rb.AddForce(ray.direction.normalized * 3000);
    }
}
