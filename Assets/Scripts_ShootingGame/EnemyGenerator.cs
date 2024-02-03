using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject EnemyA;
    [SerializeField] private GameObject EnemyB;
    [SerializeField] private GameObject EnemyC;
    //[SerializeField] private GameObject EnemyBoss;
    [SerializeField] private float gentimeRate;//利 积己矫埃
    float genPositionX;
    float timer = 0;//积己矫埃

    private void Update()
    {
        timer += Time.deltaTime;//矫埃版苞
        Vector3 genPos = new Vector3(genPositionX, 7, 0);
        //Debug.Log(timer);
        if (timer > gentimeRate)
        {
            timer = 0;
            genPositionX = Random.Range(-2.5f, 2.5f);
            Instantiate(EnemyA, genPos, Quaternion.identity);//A积己
        }
    }
    public void GenEliteEnemy()
    {
        Vector3 genPosX = new Vector3(Random.Range(-2.5f, 2.5f), 7, 0);
        if (GameManager.killCount % 3 == 0 && GameManager.killCount != 0)
        {
            Instantiate(EnemyB, genPosX, Quaternion.identity);//B积己
        }
        if (GameManager.killCount % 5 == 0 && GameManager.killCount != 0)
        {
            Instantiate(EnemyC, genPosX, Quaternion.identity);//C积己
        }
    }
}
