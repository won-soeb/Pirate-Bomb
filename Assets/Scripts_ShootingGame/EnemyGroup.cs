using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour//�� ������� ���� Ư��(�θ�Ŭ����)
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
    private void OnTriggerEnter2D(Collider2D col)//�÷��̾�� �ε��� ���
    {
        //Debug.Log("���� "+ col + "(��)�� �����");
        StartCoroutine(Damage());
        if (HP <= 0 || col.gameObject.tag == "Boom")
        {
            EnemyDead();
        }
    }
    public void EnemyDead()//�� ���
    {
        GameManager.killCount++;//���� �� ���� ���� - ���߿� ������ ���
        generator.GenEliteEnemy();//�� ���� ���� ����Ʈ �� ��ȯ
        ScoreUp(10);//10�� �߰�(���� Ÿ��)

        //Debug.Log("���� �� �� : " + GameManager.killCount);
        Instantiate(explosion, transform.position, Quaternion.identity);//��ƼŬ
        Destroy(gameObject);
    }
    protected IEnumerator Damage()//������ ó��
    {
        HP -= GameManager.playerDamage;//ü�±��
        anim.SetInteger("Hit", 1);
        yield return new WaitForSeconds(0.1f);
        anim.SetInteger("Hit", 0);//�ִϸ��̼� ����
    }
    //�� ��� �� Ȯ���� ������ ���
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
