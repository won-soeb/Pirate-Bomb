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
    //ȭ����ġ �� ��ġ�� ��ġ�� �̵�
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;//�浹����
            //���콺 Ŭ�� ��ġ�� ���̷� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100))
            {
                //�ٱ��ϸ� ���̷� ���� �浹�� �������� �ű��
                //ĭ�� ����� �ϹǷ� �ݿø�ó��
                transform.position = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + "��(��) ����");
        if (other.tag == "Apple")
        {
            //Debug.Log("����");            
            scoreText.text = catchManager.PlusScore().ToString();//UI�� �ݿ�
            audio.PlayOneShot(soundApple);//���� ���
            Destroy(other.gameObject);//�ı�
        }
        else if (other.tag == "Bomb")
        {
            //Debug.Log("����");
            scoreText.text = catchManager.MinusScore().ToString();
            audio.PlayOneShot(soundBomb);
            Destroy(other.gameObject);
        }
    }
}
