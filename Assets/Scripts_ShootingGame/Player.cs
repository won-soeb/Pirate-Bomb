using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int h;//�¿� Ű
    private int v;//���� Ű
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private GameObject explosion;//���� ȿ�� ������
    [SerializeField] private GameObject resultText;//���ӿ���â
    [SerializeField] private GameObject boomAttack;//��ź����
    Animator anim;
    Coroutine coroutine = null;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        v = (int)Input.GetAxisRaw("Vertical");
        h = (int)Input.GetAxisRaw("Horizontal");
        //Debug.Log("�¿�"+Input.GetAxisRaw("Horizontal"));
        //Debug.Log("����"+Input.GetAxisRaw("Vertical"));

        transform.Translate(new Vector3(h, v, transform.position.z).normalized * speed);//�̵�

        anim.SetInteger("Direct", h);//�ִϸ��̼� �ݿ�

        //ȭ�� ��ġ ����
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.3f, 2.3f),
            Mathf.Clamp(transform.position.y, -3.55f, 5.5f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")//���� �浹�Ѵٸ�
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            resultText.SetActive(true);
        }
    }
    public void PowerUp()//�Ϲݰ��ݷ� ����
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(CoPowerUp());
    }
    IEnumerator CoPowerUp()
    {
        GameManager.playerDamage = 5;
        yield return new WaitForSeconds(5f);
        GameManager.playerDamage = 1;
        //Debug.Log("�ڷ�ƾ ����");
    }
    public void BoomAttack()//��ź����
    {
        Instantiate(boomAttack, transform.position, Quaternion.identity);
    }
}
