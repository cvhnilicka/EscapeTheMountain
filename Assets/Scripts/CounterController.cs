using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    Animator myAnimator;
    public int tempID;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }



    public void SetNumber(int number)
    {
        myAnimator.SetInteger("Number", number);
    }
}
