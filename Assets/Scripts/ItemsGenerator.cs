using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    private int genPointX;
    private int genPointZ;
    private float timer = 0;
    [SerializeField] private float genRate = 0.5f;
    [SerializeField] private float timeLimit = 60f;
    [SerializeField] private Text timeText;
        float timeCount = 0;
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        //timeCount = timer;
        timeLimit -= Time.deltaTime;
        timeText.text = string.Format("남은 시간 : {0:0.00}", timeLimit);
        if (timer > genRate)
        {
            timer = 0;
            genPointX = Random.Range(-1, 2);
            genPointZ = Random.Range(-1, 2);
            //Debug.Log(genPointX);
            Instantiate(items[Random.Range(0, 2)],
                new Vector3(genPointX, 3, genPointZ), Quaternion.identity);
        }
    }
}
