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
    [SerializeField] private float timeLimit = 60;//���ѽð�
    public static int score = 0;
    public static int appleCount = 0;
    public static int bombCount = 0;
    private void Start()
    {
        resultText.text = string.Format("������� : {0}\n��ź���� : {1}\n�� ���� : {2}", appleCount, bombCount, score);
        Debug.LogFormat("<color=yellow>������� : {0}, ��ź���� : {1}, �� ���� : {2}</color>", appleCount, bombCount, score);
    }
    void Update()
    {
        timeLimit -= Time.deltaTime;//���ѽð� ����
        timeText.text = string.Format("�����ð� : {0:0.00}", timeLimit);
        if (timeLimit <= 0)
        {
            SceneManager.LoadScene("AppleCatchResult");
        }
    }
    public int PlusScore()//����
    {
        score += 50;
        appleCount++;
        return score;
    }

    public int MinusScore()//����
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
