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
    public static int score = 0;//죽인 적 수
    public Text scoreText;

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
    }
}
