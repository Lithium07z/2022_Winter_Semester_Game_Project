using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animator aniCtrl;
    bool input_x;
    bool input_y;

    void Start()
    {
        
    }

    void Update()
    {
        toAnim();
    }

    void toAnim()
    {
        input_x = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        input_y = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);

        if (input_x || input_y)
            aniCtrl.SetBool("walking", true);
        else
            aniCtrl.SetBool("walking", false);
    }
}
