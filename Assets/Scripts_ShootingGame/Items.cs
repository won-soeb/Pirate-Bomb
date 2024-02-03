using System;
using System.Collections;
using UnityEngine;

public class Items : MonoBehaviour
{
    public enum Item { Boom, Power };
    public Item itemType;
    [SerializeField] private float moveSpeed = 0.01f;
    Player player;
    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
    }
    private void Update()
    {
        transform.Translate(-transform.up * moveSpeed / 10);
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")//플레이어에게 닿으면
        {
            Use();//타입에 맞는 아이템을 사용하고
            Destroy(gameObject);//제거한다
        }
    }
    private void Use()
    {
        switch (itemType)
        {
            case Item.Boom:
                player.BoomAttack();
                break;
            case Item.Power:
                player.PowerUp();
                break;
        }
    }
}
