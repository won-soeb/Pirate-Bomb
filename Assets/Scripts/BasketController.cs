using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketController : MonoBehaviour
{
    [SerializeField] private AudioClip soundApple;
    [SerializeField] private AudioClip soundBomb;
    [SerializeField] private Text scoreText;
    private AudioSource audio;
    private CatchManager catchManager;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        catchManager = FindAnyObjectByType<CatchManager>();
    }
    //화면터치 시 터치한 위치로 이동
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;//충돌정보
            //마우스 클릭 위치를 레이로 받음
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100))
            {
                //바구니를 레이로 쏴서 충돌한 지점으로 옮긴다
                //칸에 맞춰야 하므로 반올림처리
                transform.position = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + "와(과) 닿음");
        if (other.tag == "Apple")
        {
            //Debug.Log("득점");            
            scoreText.text = catchManager.PlusScore().ToString();//UI에 반영
            audio.PlayOneShot(soundApple);//사운드 재생
            Destroy(other.gameObject);//파괴
        }
        else if (other.tag == "Bomb")
        {
            //Debug.Log("감점");
            scoreText.text = catchManager.MinusScore().ToString();
            audio.PlayOneShot(soundBomb);
            Destroy(other.gameObject);
        }
    }
}
