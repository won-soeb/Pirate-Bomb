using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMain1 : MonoBehaviour
{
    [SerializeField] private Transform target;
    private void Update()
    {
        //ȭ���� Ŭ���ϸ� ���̸� �߻�
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //���� ��ü�� �Ӽ�
            //ray.origin : ���� ��ġ
            //roa direction : ����
            //���̸� ������ ����
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100);

            /*     C# out,ref������(���� �ƴ� ������ �����ϴ� ����) �ڼ��� ����
             *    
             *     out : �޼ҵ� ������ �������� ���� ������ ������ ����
             *     ref : 
             *     �������̶�°� �޼ҵ� ȣ���� ����Ǿ ���� �Ҹ����� �ʴ´ٴ� �ǹ�
             *     
             *  Physic.Raycast�� �̹� bool��(�ݶ��̴����� �浹����)�� ��ȯ�ϱ� ������
             *  Raycast������ ����(�浹�� ���� �� �ڼ��� ����)�� �� �� ����. 
             *  �׷��� Raycast�� �Ű����� �� RaycastHitŸ�Կ� outŰ���带 ����� �ۿ��� �ʱ�ȭ�� ��
             *  RaycastHit�� ������ ����� �� �ֵ��� �Ѵ�. */

            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100))
            {
                Debug.Log(hit.point + " �� �浹");
                //ť�긦 Ŭ���������� �̵�
                target.position = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
            }
        }
    }
}
