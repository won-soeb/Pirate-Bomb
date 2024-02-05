using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMain1 : MonoBehaviour
{
    [SerializeField] private Transform target;
    private void Update()
    {
        //화면을 클릭하면 레이를 발사
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //레이 객체의 속성
            //ray.origin : 시작 위치
            //roa direction : 방향
            //레이를 눈으로 보기
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100);

            /*     C# out,ref한정자(값이 아닌 참조를 전달하는 역할) 자세히 볼것
             *    
             *     out : 메소드 내부의 지정값을 밖의 선언한 변수에 전달
             *     ref : 
             *     참조값이라는건 메소드 호출이 종료되어도 값이 소멸하지 않는다는 의미
             *     
             *  Physic.Raycast는 이미 bool형(콜라이더와의 충돌여부)을 반환하기 때문에
             *  Raycast내부의 정보(충돌에 관한 더 자세한 정보)를 알 수 없다. 
             *  그래서 Raycast의 매개변수 중 RaycastHit타입에 out키워드를 사용해 밖에서 초기화한 후
             *  RaycastHit의 정보를 사용할 수 있도록 한다. */

            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100))
            {
                Debug.Log(hit.point + " 에 충돌");
                //큐브를 클릭지점으로 이동
                target.position = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
            }
        }
    }
}
