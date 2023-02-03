/****************기본 원형 스킬 스크립트****************
*  [ 사용 순서 ]
*  public Transform skill에 스킬 prefab 연결 후       
*  radius값 변경으로 플레이어와 스킬 사이 거리 조절      
*  스킬 레벨에 따라 반복문을 사용해 prefab 개수를 조절   
*  angle은 360 / prefab갯수 값 만큼 누적합하면 됨  
*  
*  [ 동작 순서 ]                                          
*  1. 스킬 레벨에 따라 반복문 동작, 스킬 prefab이 생성됨 
*  2. prefab은 생성될 때 갯수에 맞는 각도로 회전됨       
*  3. prefab(자식 오브젝트) 갯수에 맞게 원형으로 배치됨  
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCircularSkillScript : MonoBehaviour
{
    public Transform skill; // 스킬 prefab
    [SerializeField]
    private float radius = 5.0f; // 플레이어와 스킬 사이의 거리
    [SerializeField]
    private int skillLevel = 1;  // 스킬 레벨

    void Start()
    {
        if (skillLevel == 1)
        {
            int angle = 0;
            for (int i = 0; i < 3; i++)
            {
                GameObject.Instantiate(skill, Vector3.zero, Quaternion.Euler(0, angle, 0)).transform.parent = this.transform;
                angle += 120;
            }
        }
        else if (skillLevel == 2)
        {
            int angle = 0;
            for (int i = 0; i < 5; i++)
            {
                GameObject.Instantiate(skill, Vector3.zero, Quaternion.Euler(0, angle, 0)).transform.parent = this.transform;
                angle += 72;
            }
        }
        else if (skillLevel == 3)
        {
            int angle = 0;
            for (int i = 0; i < 8; i++)
            {
                GameObject.Instantiate(skill, Vector3.zero, Quaternion.Euler(0, angle, 0)).transform.parent = this.transform;
                angle += 45;
            }
        }

        int numberOfChild = this.transform.childCount; // 자식 오브젝트 갯수

        for (int i = 0; i < numberOfChild; i++)
        {
            float angle = Mathf.PI * 0.5f - i * (Mathf.PI * 2.0f) / numberOfChild;
            GameObject child = this.transform.GetChild(i).gameObject;
            child.transform.position = this.transform.position + (new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle))) * radius;
        }

        Destroy(this.gameObject, 5.0f); // 일단 임시로 추가, 적에게 닿거나 시야 밖 또는 맵 가장자리에 닿으면 없애는 식으로 나중에 구현
    }

    void Update()
    {

    }
}
