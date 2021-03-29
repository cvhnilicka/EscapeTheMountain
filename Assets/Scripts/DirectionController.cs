using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{

    Animator myDirectionAnim;

    private void Awake()
    {
        myDirectionAnim = GetComponent<Animator>();

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
