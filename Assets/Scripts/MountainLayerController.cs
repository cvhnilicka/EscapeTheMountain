using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainLayerController : MonoBehaviour
{
    TileController[] myTiles;
    int leftTiles = 0;


    float randomTimer = 4f;

    // Start is called before the first frame update
    void Start()
    {
        myTiles = GetComponentsInChildren<TileController>();
        InitialRandomDirection();
        //print(gameObject.name + " my tiles: " + myTiles.Length);
        GetNumberLeftTiles();
        //foreach (TileController tile in myTiles)
        //{
        //    tile.SetLeft(false);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        Timers();
    }

    void Timers()
    {
        randomTimer -= Time.deltaTime;
        if (randomTimer <= 0)
        {
            InitialRandomDirection();
            randomTimer = 4f;
        }

    }

    public int GetNumberLeftTiles()
    {
        leftTiles = 0;
        foreach (TileController tile in myTiles)
        {
            if (tile.GetTileIsLeft()) { leftTiles += 1; }
        }
        print(gameObject.name + " has " + leftTiles + " left tiles");
        return leftTiles;
    }


    void InitialRandomDirection()
    {
        int leftRemaining = 4;
        int rightRemaining = 4;
        foreach (TileController tile in myTiles)
        {
            bool willBeLeft = (Random.value > 0.5f);
            if (willBeLeft && leftRemaining > 0)
            {
                tile.SetLeft(true);
                leftRemaining -= 1;
            }
            else if (rightRemaining > 0)
            {
                tile.SetLeft(false);
                rightRemaining -= 1;
            }
            else
            {
                tile.SetLeft(true);
                leftRemaining -= 1;
            }
        }
    }


}
