using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainLayerController : MonoBehaviour
{
    TileController[] myTiles;
    int leftTiles = 0;

    [SerializeField] float rotateTimer = .5f;
    [SerializeField] int numLefts = 4;


    float randomTimer;

    // Start is called before the first frame update
    void Start()
    {
        myTiles = GetComponentsInChildren<TileController>();
        InitialRandomDirection();
        GetNumberLeftTiles();
        randomTimer = rotateTimer;


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
            //RotateCounterClockwise();
            //RotateClockwise();
            randomTimer = rotateTimer;
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
        int leftRemaining = numLefts;
        int rightRemaining = 8-leftRemaining;
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

    // Rotates the Directions Counterclockwise by 1
    void RotateCounterClockwise()
    {
        bool firstTileIsLeft = myTiles[0].GetTileIsLeft();
        for (int i = 0; i < myTiles.Length-1; i++)
        {
            myTiles[i].SetLeft(myTiles[i + 1].GetTileIsLeft());
        }
        myTiles[myTiles.Length - 1].SetLeft(firstTileIsLeft);
    }

    // Rotates the Directions Clockwise by 1
    void RotateClockwise()
    {
        bool lastTileIsLeft = myTiles[myTiles.Length-1].GetTileIsLeft();
        //myTiles[0].SetLeft(myTiles[myTiles.Length - 1].GetTileIsLeft());
        for (int i = myTiles.Length-1; i > 0; i--)
        {
            myTiles[i].SetLeft(myTiles[i - 1].GetTileIsLeft());
        }
        myTiles[0].SetLeft(lastTileIsLeft);

    }


}
