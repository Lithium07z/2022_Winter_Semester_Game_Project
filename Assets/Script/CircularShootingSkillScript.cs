/****************���� �߻� ��ų ��ũ��Ʈ****************
*  [ ��� ���� ]
*  public Transform skill�� ��ų prefab ���� ��       
*  radius�� �������� �÷��̾�� ��ų ���� �Ÿ� ����      
*  ��ų ������ ���� �ݺ����� ����� prefab ������ ����   
*  angle�� 360 / prefab���� �� ��ŭ �������ϸ� ��  
*  
*  [ ���� ���� ]                                          
*  1. ��ų ������ ���� �ݺ��� ����, ��ų prefab�� ������ 
*  2. prefab�� ������ �� ������ �´� ������ ȸ����       
*  3. prefab(�ڽ� ������Ʈ) ������ �°� �������� ��ġ��  
*  4. AddForce�� ���� ������ �������� �߻��
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularShootingSkillScript : MonoBehaviour
{
    public Transform skill; // ��ų prefab
    [SerializeField]
    private float radius = 5.0f; // �÷��̾�� ��ų ������ �Ÿ�
    [SerializeField]
    private int skillLevel = 1;  // ��ų ����

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

        int numberOfChild = this.transform.childCount; // �ڽ� ������Ʈ ����

        for (int i = 0; i < numberOfChild; i++)
        {
            float angle = Mathf.PI * 0.5f - i * (Mathf.PI * 2.0f) / numberOfChild;
            GameObject child = this.transform.GetChild(i).gameObject;
            child.transform.position = this.transform.position + (new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle))) * radius;
            child.transform.GetComponent<Rigidbody>().AddForce(child.transform.TransformDirection(Vector3.forward) * 200);
        }

        Destroy(this.gameObject, 5.0f); // �ϴ� �ӽ÷� �߰�, ������ ��ų� �þ� �� �Ǵ� �� �����ڸ��� ������ ���ִ� ������ ���߿� ����
    }

    void Update()
    {

    }
}
