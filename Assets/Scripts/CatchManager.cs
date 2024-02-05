using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatchManager : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [SerializeField] private Text resultText;
    [SerializeField] private float timeLimit = 60;//제한시간
    public static int score = 0;
    public static int appleCount = 0;
    public static int bombCount = 0;
    private void Start()
    {
        resultText.text = string.Format("사과개수 : {0}\n폭탄개수 : {1}\n총 점수 : {2}", appleCount, bombCount, score);
        Debug.LogFormat("<color=yellow>사과개수 : {0}, 폭탄개수 : {1}, 총 점수 : {2}</color>", appleCount, bombCount, score);
    }
    void Update()
    {
        timeLimit -= Time.deltaTime;//제한시간 감소
        timeText.text = string.Format("남은시간 : {0:0.00}", timeLimit);
        if (timeLimit <= 0)
        {
            SceneManager.LoadScene("AppleCatchResult");
        }
    }
    public int PlusScore()//득점
    {
        score += 50;
        appleCount++;
        return score;
    }

    public int MinusScore()//감점
    {
        score = Mathf.CeilToInt(score / 2);
        bombCount++;
        return score;
    }
    public void RestartButton()
    {
        score = 0;
        appleCount = 0;
        bombCount = 0;
        SceneManager.LoadScene("AppleCatch");
    }
}
