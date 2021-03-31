using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainLayerController : MonoBehaviour
{

    public enum LAYER_LEVEL {  BASE, MID, PEAK };


    TileController[] myTiles;
    int leftTiles = 0;

    [SerializeField] float rotateTimer = .5f;
    [SerializeField] int numLefts = 4;
    [SerializeField] LAYER_LEVEL myLayerLevel;


    float randomTimer;

    // very first initalization method called
    private void Awake()
    {
        myTiles = GetComponentsInChildren<TileController>();
        SetTileIds();
        InitialRandomDirection();

    }

    // Start is called before the first frame update
    void Start()
    {
        GetNumberLeftTiles();
        randomTimer = rotateTimer;
    }

    void SetTileIds()
    {
        int id = 0;
        foreach (TileController tile in myTiles)
        {
            tile.SetMyId(id);
            id += 1;
        }
    }


    public LAYER_LEVEL MyLevel() { return this.myLayerLevel;   }

    public int GetNumberLeftTiles()
    {
        leftTiles = 0;
        foreach (TileController tile in myTiles)
        {
            if (tile.GetTileIsLeft()) { leftTiles += 1; }
        }
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
                //tile.SetMySnow(3);
                rightRemaining -= 1;
            }
            else
            {
                tile.SetLeft(true);
                leftRemaining -= 1;
            }
        }
    }

    public TileController[] GetMyTiles()
    {
        return this.myTiles;
    }

    public TileController GetTileById(int id)
    {
        foreach(TileController tile in myTiles)
        {
            if (tile.GetMyId() == id) return tile;
        }
        return null;
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
    public void RotateClockwise()
    {
        bool lastTileIsLeft = myTiles[myTiles.Length-1].GetTileIsLeft();
        //myTiles[0].SetLeft(myTiles[myTiles.Length - 1].GetTileIsLeft());
        for (int i = myTiles.Length-1; i > 0; i--)
        {
            myTiles[i].SetLeft(myTiles[i - 1].GetTileIsLeft());
        }
        myTiles[0].SetLeft(lastTileIsLeft);

    }


    public bool CheckAvalanches()
    {
        foreach (TileController tile in myTiles)
        {
            if (tile.HasAvalanche()) return true;
        }
        return false;
    }

    public void SetInitialSnow(int amt)
    {

        foreach (TileController tile in myTiles)
        {
            // for now just set all even tiles as snow
            if (tile.GetMyId() % 2 == 0)
            {
                // set all as 2 for now but i want to randomize it at somepoint
                tile.SetMySnow(amt);
            }
        }
    }


}
