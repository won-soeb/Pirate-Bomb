using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerDamage = 1;
    //public int enemyDamage = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("ShootingGame");
        }//Esc키로 씬 재로드(임시)
    }
}
