using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    // Children
    SnowController mySnowStack;
    DirectionController myDirection;

    public int myId;

    private void Awake()
    {
        mySnowStack = GetComponentInChildren<SnowController>();
        myDirection = GetComponentInChildren<DirectionController>();
    }

    // Getters dude
    public int GetTileSnowCount() { return this.mySnowStack.GetSnowCount(); }


    public bool GetTileIsLeft()
    {
        return myDirection.IsLeft();
    }

    public bool HasAvalanche()
    {
        if (mySnowStack.GetSnowCount() > 4) { return true; }
        return false;
    }


    public int GetMyId()
    {
        return this.myId;

    }

    public void SetMyId(int id)
    {
        myId = id;
    }

    public void SetMySnow(int snowAmt)
    {
        mySnowStack.SetSnowCount(snowAmt);
    }

    public void AddSnow(int toAdd)
    {
        mySnowStack.AddSnow(toAdd);
    }

    public void SetLeft(bool isleft)
    {
        myDirection.SetLeft(isleft);
    }

}
