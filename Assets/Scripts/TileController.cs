using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    // Children
    SnowController mySnowStack;
    DirectionController myDirection;

    // Start is called before the first frame update
    void Start()
    {
        mySnowStack = GetComponentInChildren<SnowController>();
        myDirection = GetComponentInChildren<DirectionController>();
    }


    public void SetLeft(bool isleft)
    {
        myDirection.SetLeft(isleft);
    }

    public bool GetTileIsLeft()
    {
        //if (!myDirection) myDirection = GetComponentInChildren<DirectionController>();
        return myDirection.IsLeft();
    }

    //public void SetIsLeft(bool isleft)
    //{
    //    myDirection.SetLeft(isleft);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
