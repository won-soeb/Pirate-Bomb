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
    public static int score = 0;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
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
            score += 50;//�����߰�
            scoreText.text = score.ToString();//UI�� �ݿ�
            audio.PlayOneShot(soundApple);//���� ���
            Destroy(other.gameObject);//�ı�
        }
        else if (other.tag == "Bomb")
        {
            //Debug.Log("����");
            score = Mathf.CeilToInt(score / 2);//������ ����
            scoreText.text = score.ToString();
            audio.PlayOneShot(soundBomb);
            Destroy(other.gameObject);
        }
    }
}
