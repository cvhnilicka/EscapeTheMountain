using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    MountainLayerController baseLayer;
    MountainLayerController midLayer;
    MountainLayerController peakLayer;


    float randomTimer;
    [SerializeField] float rotateTimer = 5f;

    bool setUp = false;


    // Start is called before the first frame update
    void Start()
    {
        GetMountainLayers();
        SetInitialSnow();
        randomTimer = rotateTimer;
        setUp = true;


    }

    public bool GetSetUp()
    {
        return this.setUp;
    }

    private void GetMountainLayers()
    {
        MountainLayerController[] temp = GetComponentsInChildren<MountainLayerController>();
        foreach (MountainLayerController layer in temp)
        {
            switch (layer.MyLevel())
            {
                case MountainLayerController.LAYER_LEVEL.BASE:
                    baseLayer = layer;
                    break;
                case MountainLayerController.LAYER_LEVEL.MID:
                    midLayer = layer;
                    break;
                case MountainLayerController.LAYER_LEVEL.PEAK:
                    peakLayer = layer;
                    break;
            }
        }
    }

    void Timers()
    {
        randomTimer -= Time.deltaTime;
        if (randomTimer <= 0)
        {
            print("RUNNING AVALANCHE CEHCK");
            RunAvalanchesCheck();
            randomTimer = 100f;
        }

    }


    /*
     * ##########################################################
     * ################## SNOW CODE ########################
     * ##########################################################
     * **/
    void SetInitialSnow()
    {
        SetLayerSnow(peakLayer, 2);
        SetLayerSnow(midLayer, 3);
        SetLayerSnow(baseLayer, 0);
    }

    void SetLayerSnow(MountainLayerController layer, int amt)
    {
        foreach (TileController tile in layer.GetMyTiles())
        {
            // for now just set all even tiles as snow
            //if (tile.GetMyId() % 2 == 0)
            if (tile.GetMyId() == 0)
            {
                // set all as 2 for now but i want to randomize it at somepoint
                tile.SetMySnow(amt);
            }
        }
    }

    public void SnowFall()
    {

        // this is temp for now but will need to figure out a way to add snowfall better
        peakLayer.GetMyTiles()[0].AddSnow(3);
    }



    /*
     * ##########################################################
     * ################## AVALANCHE CODE ########################
     * ##########################################################
     * **/

    public void RunAvalanchesCheck()
    {
        print("BoardController:RunAvalanchesCheck");
        if (peakLayer.CheckAvalanches())
        {
            CascadeAvalanche(peakLayer, midLayer);
        }
        if (midLayer.CheckAvalanches())
        {
            print("Mid Layer Avalanche");
            //Debug.Break();
            //CascadeAvalanche(midLayer, baseLayer);
        }
    }

    void CascadeAvalanche(MountainLayerController aboveLayer,
        MountainLayerController belowLayer)
    {
        TileController[] aboveTiles = aboveLayer.GetMyTiles();
        TileController[] belowTiles = belowLayer.GetMyTiles();
        for (int i = 0; i < aboveTiles.Length; i++)
        {
            if (aboveTiles[i].HasAvalanche())
            {
                // here i need to cascade them down
                if (i == 0 && aboveTiles[i].GetTileIsLeft())
                {
                    print("A");
                    // need to rotate back tile to first tile
                    print("SnowCount: " + (aboveTiles[i].GetTileSnowCount()-1));
                    belowTiles[belowTiles.Length - 1].AddSnow(aboveTiles[i].GetTileSnowCount() - 1);
                    aboveTiles[i].SetMySnow(1);
                }
                else if (i == 0 && !aboveTiles[i].GetTileIsLeft())
                {
                    print("B");

                    // need to rotate back tile to first tile
                    belowTiles[i + 1].AddSnow(aboveTiles[i].GetTileSnowCount() - 1);
                    aboveTiles[i].SetMySnow(1);
                }
                else if (i == aboveTiles.Length-1 && !aboveTiles[i].GetTileIsLeft())
                {
                    print("C");

                    // need to rotate last to first spot
                    belowTiles[0].AddSnow(aboveTiles[i].GetTileSnowCount()-1);
                    aboveTiles[i].SetMySnow(1);
                }
                //else if (i == aboveTiles.Length - 1 && aboveTiles[i].GetTileIsLeft())
                //{
                //    // need to rotate last to first spot
                //    belowTiles[i-1].AddSnow(aboveTiles[i].GetTileSnowCount() - 1);
                //    aboveTiles[i].SetMySnow(1);
                //}

                else if (i > 0 && i < aboveTiles.Length && aboveTiles[i].GetTileIsLeft())
                {
                    print("D");

                    belowTiles[i - 1].AddSnow(aboveTiles[i].GetTileSnowCount() - 1);
                    aboveTiles[i].SetMySnow(1);
                }
                else if (i > 0 && i < aboveTiles.Length && !aboveTiles[i].GetTileIsLeft())
                {
                    print("E");

                    belowTiles[i + 1].AddSnow(aboveTiles[i].GetTileSnowCount() - 1);
                    aboveTiles[i].SetMySnow(1);
                }
            }
        }
    }
}
