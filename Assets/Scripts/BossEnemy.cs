using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    Animator anim;
    [SerializeField] private int bossHP;
    [SerializeField] private Bullet playerBullet;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        playerBullet = GetComponent<Bullet>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bossHP -= playerBullet.damage;
        anim.SetInteger("Hit", 1);
    }
}
