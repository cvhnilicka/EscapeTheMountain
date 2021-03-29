using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    MountainLayerController baseLayer;
    MountainLayerController midLayer;
    MountainLayerController peakLayer;

    // Start is called before the first frame update
    void Start()
    {
        GetMountainLayers();
        //midLayer.SetInitialSnow(2);
        SetInitialSnow();
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

    // Update is called once per frame
    void Update()
    {
        RunAvalanchesCheck();
    }

    void SetInitialSnow()
    {
        SetLayerSnow(peakLayer, 4);
        SetLayerSnow(midLayer, 3);
        SetLayerSnow(baseLayer, 1);
    }

    void SetLayerSnow(MountainLayerController layer, int amt)
    {
        print(layer.GetMyTiles().Length);
        foreach (TileController tile in layer.GetMyTiles())
        {
            // for now just set all even tiles as snow
            if (tile.GetMyId() % 2 == 0)
            {
                print(tile.GetMyId());
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
        }
    }

    void CascadeAvalanche(MountainLayerController aboveLayer,
        MountainLayerController belowLayer)
    {
        TileController[] aboveTiles = aboveLayer.GetMyTiles();
        for (int i = 0; i < aboveTiles.Length; i++)
        {
            if (aboveTiles[i].HasAvalanche())
            {
                // here i need to cascade them down
                if (i == 0 && aboveTiles[i].GetTileIsLeft())
                {
                    // need to rotate back to last
                   
                }
            }
        }
    }
}
