using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int playerDamage = 1;
    //public int enemyDamage = 1;
    public static int killCount = 0;//죽인 적 수
    public static int score = 0;//합산 점수
    public Text scoreText;
    public GameObject backGroundTop;
    public GameObject backGroundMid;
    public GameObject backGroundBottom;
    private Transform bgTop;
    private Transform bgMid;
    private Transform bgBottom;
    //배경의 위치 초기화
    private void Awake()
    {
        bgTop = backGroundTop.transform;
        bgMid = backGroundMid.transform;
        bgBottom = backGroundBottom.transform;
    }
    void Update()
    {
        scoreText.text = "현재 점수 : " + score;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("ShootingGame");
            playerDamage = 1;
            killCount = 0;
            score = 0;
        }//Esc키로 씬 재로드(임시)
        ScrollBG();
    }
    private void ScrollBG()//화면 스크롤
    {
        float rePosT = Mathf.Repeat(Time.time * 7, 12);
        float rePosM = Mathf.Repeat(Time.time * 6, 12);
        float rePosB = Mathf.Repeat(Time.time * 5, 12);
        bgTop.position = new Vector3(0, -rePosT, 0);
        bgMid.position = new Vector3(0, -rePosM, 0);
        bgBottom.position = new Vector3(0, -rePosB, 0);
    }
}
