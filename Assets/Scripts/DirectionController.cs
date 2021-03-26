using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{

    Animator myDirectionAnim;
    // Start is called before the first frame update
    void Start()
    {
        myDirectionAnim = GetComponent<Animator>();
        //myDirectionAnim.SetBool("Left", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLeft(bool isleft)
    {
        if (myDirectionAnim.GetBool("Left") != isleft)
        {
            myDirectionAnim.SetBool("Left", isleft);
        }
    }

    public bool IsLeft()
    {
        return myDirectionAnim.GetBool("Left");
    }
}
