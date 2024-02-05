using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    private int genPointX;
    private int genPointZ;
    private float timer = 0;
    [SerializeField] private float genRate = 0.5f;//아이템 생성 주기
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
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
