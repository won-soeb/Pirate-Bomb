using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour//적 비행기의 공통 특성(부모클래스)
{
    [SerializeField] protected int HP;
    [SerializeField] protected GameObject explosion;
    [SerializeField] protected int dropPercent;
    EnemyGenerator generator;
    ItemGenerator itemGenerator;
    protected Bullet playerBullet;
    protected GameManager gameManager;
    protected Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        playerBullet = FindAnyObjectByType<Bullet>();
        gameManager = FindAnyObjectByType<GameManager>();
        generator = FindAnyObjectByType<EnemyGenerator>();
        itemGenerator = FindAnyObjectByType<ItemGenerator>();
    }
    private void OnTriggerEnter2D(Collider2D col)//플레이어와 부딪힌 경우
    {
        //Debug.Log("적이 "+ col + "(을)를 통과함");
        StartCoroutine(Damage());
        if (HP <= 0 || col.gameObject.tag == "Boom")
        {
            EnemyDead();
        }
    }
    public void EnemyDead()//적 사망
    {
        GameManager.killCount++;//죽인 적 수를 샌다 - 나중에 점수로 계산
        generator.GenEliteEnemy();//적 수에 따라 엘리트 적 소환
        ScoreUp(10);//10점 추가(공통 타입)

        //Debug.Log("죽인 적 수 : " + GameManager.killCount);
        Instantiate(explosion, transform.position, Quaternion.identity);//파티클
        Destroy(gameObject);
    }
    protected IEnumerator Damage()//데미지 처리
    {
        HP -= GameManager.playerDamage;//체력깎기
        anim.SetInteger("Hit", 1);
        yield return new WaitForSeconds(0.1f);
        anim.SetInteger("Hit", 0);//애니메이션 적용
    }
    //적 사망 후 확률적 아이템 드랍
    protected void DropItem(int percent)
    {
        int rand = Random.Range(0, 100);
        if (rand < percent)
        {
            itemGenerator.GenItem(gameObject.transform.position);
        }
    }
    protected void ScoreUp(int score)
    {
        GameManager.score += score;
    }
}
