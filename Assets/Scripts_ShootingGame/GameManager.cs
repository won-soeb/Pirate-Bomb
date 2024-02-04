using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int playerDamage = 1;
    //public int enemyDamage = 1;
    public static int killCount = 0;//���� �� ��
    public static int score = 0;//�ջ� ����
    public Text scoreText;
    public GameObject backGroundTop;
    public GameObject backGroundMid;
    public GameObject backGroundBottom;
    private Transform bgTop;
    private Transform bgMid;
    private Transform bgBottom;
    //����� ��ġ �ʱ�ȭ
    private void Awake()
    {
        bgTop = backGroundTop.transform;
        bgMid = backGroundMid.transform;
        bgBottom = backGroundBottom.transform;
    }
    void Update()
    {
        scoreText.text = "���� ���� : " + score;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("ShootingGame");
            playerDamage = 1;
            killCount = 0;
            score = 0;
        }//EscŰ�� �� ��ε�(�ӽ�)
        ScrollBG();
    }
    private void ScrollBG()//ȭ�� ��ũ��
    {
        float rePosT = Mathf.Repeat(Time.time * 7, 12);
        float rePosM = Mathf.Repeat(Time.time * 6, 12);
        float rePosB = Mathf.Repeat(Time.time * 5, 12);
        bgTop.position = new Vector3(0, -rePosT, 0);
        bgMid.position = new Vector3(0, -rePosM, 0);
        bgBottom.position = new Vector3(0, -rePosB, 0);
    }
}
