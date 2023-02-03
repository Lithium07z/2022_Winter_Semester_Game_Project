using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    const int SPEED = 3;
    public bool isWalk = false;
    [SerializeField] float input_x;
    [SerializeField] float input_y;
    public Animator aniCtrl;
    public Rigidbody rigid;

    public GameObject target;

    void Start(){   }
    void Update()
    {
        toAnim();
        Move();
        Jump();
    }

    void toAnim()
    {
        input_x = Input.GetAxis("Horizontal");
        input_y = Input.GetAxis("Vertical");
        if (input_x != 0 || input_y != 0)
            aniCtrl.SetBool("walking", true);
        else
            aniCtrl.SetBool("walking", false);
    }
    void Move()
    {
        input_x = Input.GetAxis("Horizontal");
        input_y = Input.GetAxis("Vertical");
        if (input_x != 0 || input_y != 0)
        {
            aniCtrl.SetBool("walking",true);
            rigid.velocity = new Vector3(input_x,rigid.velocity.y,input_y)*SPEED;
            this.transform.Translate(new Vector3(input_x,0,input_y)*SPEED*Time.deltaTime);
        }
        else{
            aniCtrl.SetBool("walking",false);
        }

        Vector3 a =target.transform.position;
        a.y=this.transform.position.y; 
        this.transform.LookAt(a);
    }

    void Jump(){
        if(Input.GetMouseButtonDown(0)){
            rigid.AddForce(Vector3.up*5,ForceMode.Impulse);
        }
    }
}
