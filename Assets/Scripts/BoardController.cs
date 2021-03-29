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


    // Start is called before the first frame update
    void Start()
    {
        GetMountainLayers();
        //midLayer.SetInitialSnow(2);
        SetInitialSnow();
        randomTimer = rotateTimer;

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

    // Update is called once per frame
    void Update()
    {
        Timers();
        //RunAvalanchesCheck();
    }

    void SetInitialSnow()
    {
        SetLayerSnow(peakLayer, 5);
        SetLayerSnow(midLayer, 1);
        SetLayerSnow(baseLayer, 0);
    }

    void SetLayerSnow(MountainLayerController layer, int amt)
    {
        foreach (TileController tile in layer.GetMyTiles())
        {
            // for now just set all even tiles as snow
            if (tile.GetMyId() == 0)
            {
                // set all as 2 for now but i want to randomize it at somepoint
                tile.SetMySnow(amt);
            }
        }
    }

    void RunAvalanchesCheck()
    {
        if (peakLayer.CheckAvalanches())
        {
            print("PEAK HAS AN AVALANCHE");
            CascadeAvalanche(peakLayer, midLayer);
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
                    // need to rotate back tile to first tile
                    belowTiles[belowTiles.Length - 1].AddSnow(aboveTiles[i].GetTileSnowCount() - 1);
                    aboveTiles[i].SetMySnow(1);
                }
                else if (i == 0 && !aboveTiles[i].GetTileIsLeft())
                {
                    // need to rotate back tile to first tile
                    belowTiles[i + 1].AddSnow(aboveTiles[i].GetTileSnowCount() - 1);
                    aboveTiles[i].SetMySnow(1);
                }
                else if (i == aboveTiles.Length-1 && !aboveTiles[i].GetTileIsLeft())
                {
                    // need to rotate last to first spot
                    belowTiles[0].AddSnow(aboveTiles[i].GetTileSnowCount()-1);
                    aboveTiles[i].SetMySnow(1);
                }

                else if (i > 0 && i < aboveTiles.Length && aboveTiles[i].GetTileIsLeft())
                {
                    belowTiles[i - 1].AddSnow(aboveTiles[i].GetTileSnowCount() - 1);
                    aboveTiles[i].SetMySnow(1);
                }
                else if (i > 0 && i < aboveTiles.Length && !aboveTiles[i].GetTileIsLeft())
                {
                    belowTiles[i + 1].AddSnow(aboveTiles[i].GetTileSnowCount() - 1);
                    aboveTiles[i].SetMySnow(1);
                }
            }
        }
    }
}
