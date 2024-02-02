using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int h;//좌우 키
    private int v;//상하 키
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private GameObject explosion;//폭발 효과 프리팹
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        v = (int)Input.GetAxisRaw("Vertical");
        h = (int)Input.GetAxisRaw("Horizontal");
        //Debug.Log("좌우"+Input.GetAxisRaw("Horizontal"));
        //Debug.Log("상하"+Input.GetAxisRaw("Vertical"));

        transform.Translate(new Vector3(h, v, transform.position.z).normalized * speed);//이동

        anim.SetInteger("Direct", h);//애니메이션 반영

        //화면 위치 제한
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.3f, 2.3f),
            Mathf.Clamp(transform.position.y, -3.55f, 5.5f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")//적과 충돌한다면
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
