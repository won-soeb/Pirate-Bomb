using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    Animator anim;
    [SerializeField] private int bossHP;
    [SerializeField] private GameObject explosion;
    private Bullet playerBullet;
    private GameManager gameManager;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        playerBullet = FindAnyObjectByType<Bullet>();
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(playerBullet);
        StartCoroutine(Damage());
        if (bossHP <= 0)
        {
            BossDead();
        }
    }
    public void BossDead()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);//��ƼŬ
        Destroy(gameObject);//�ı�
    }
    IEnumerator Damage()//������ ó��
    {
        bossHP -= gameManager.playerDamage;//ü�±��
        anim.SetInteger("Hit", 1);
        yield return new WaitForSeconds(0.1f);
        anim.SetInteger("Hit", 0);//�ִϸ��̼� ����
    }
}
