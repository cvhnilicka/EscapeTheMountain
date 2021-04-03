using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerController : MonoBehaviour
{


    /*
     * Single adventurer specific functionality 
     *
     * Set Type
     * Get Type
     *
     * Set Health
     * Get Health
     * Take Damage
     * Add Health
     * Get CurrHealth
     * 
     * Set CarryLimit
     * Get CarryLimit
     * Add Weight
     * Remove Weight
     * Get CurrCarry
     * 
     * 
     * Position info
     * 
     * 
     * [] Carried Gear
     * [] Carried Equipment
     * 
     * 
     * Avialable actions?
     * 
     * etc
     * 
     * 
     * 
     * 
     * **/




    /*
     * Looks like i can set the location using the snow controllers on each tile
     * **/
    public SnowController test;


    private GameInformation.ADVENTURERS adventurertype;
    private int health;
    private int carrylimit;

    private int maxTurns;
    private int turnsRemaining;

    private MountainLayerController.LAYER_LEVEL currLevel;
    private int currTileID;

    private string mountainLayer;

    private bool turnDone;

    SpriteRenderer mySprite;

    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SpriteRenderer GetMySprite() { return this.mySprite; }


    /*
     * // So this will move the play techinically 
     * Now i will need to focus on the restriction for the moves
     * 
     * amount of snow
     * player abilities
     * number of moves remaining
     * 
     * 
     * 
     * 
     * **/
    public void MoveTo(TileController tile)
    {
        if (turnsRemaining > 0 && !turnDone)
        {
            print(VerifyMovableToTile(tile));
            if (VerifyMovableToTile(tile))
            {
                transform.position = new Vector2(tile.GetSnowController().transform.position.x, tile.GetSnowController().transform.position.y);
                SetLocation(tile);
                TakeTurn();

            }
        }
    }


    /*
     * Right now we are doing 1 turn at a time.
     * single tile moves 
     * 
     * **/
    public bool VerifyMovableToTile(TileController tile)
    {
        int tempTileId = tile.GetMyId();
        // check if same tile
        if (TagToLayer(tile.tag) == currLevel)
        {
            // just check ID as it is in same level
            int dist = Mathf.Abs(tempTileId - currTileID);
            if (dist > 1)
            {
                // this is janky but check for a dist of 7 to check for the wrap around
                if (dist == 7) return true;
                return false;
            }

            return true;
        }


        //print("Tile level: " + tile)
        switch (currLevel)
        {
            case MountainLayerController.LAYER_LEVEL.BASE: // can only go up
                if (tile.tag == "Mid")
                {
                    // it can only move to mid from base for now
                    // just check fo same ID
                    if (tempTileId == currTileID) return true;
                    //return true;
                }
                break;
            case MountainLayerController.LAYER_LEVEL.MID: // can go up and down
                if (tempTileId == currTileID) return true;
                break;
            case MountainLayerController.LAYER_LEVEL.PEAK: // can only go down
                if (tile.tag == "Mid")
                {
                    if (tempTileId == currTileID) return true;
                }
                break;
        }
        return false;
    }

    public void SetLocation(TileController tile)
    {
        this.currLevel = TagToLayer(tile.tag);
        this.currTileID = tile.GetMyId();
        SetMountainLayer(tile.tag);

    }

    public MountainLayerController.LAYER_LEVEL TagToLayer(string tag)
    {
        switch (tag)
        {
            case "Base": return MountainLayerController.LAYER_LEVEL.BASE;
            case "Mid": return MountainLayerController.LAYER_LEVEL.MID;
            case "Peak": return MountainLayerController.LAYER_LEVEL.PEAK;
            default: return 0;
        }
        //return;
    }


    public void DisplayStats()
    {
        print("Adventurer: " + this.adventurertype.ToString());
        print("Health: " + this.health + "\tCarryLimit: " + this.carrylimit+"\n");

    }


    public void SetAdventurerType(GameInformation.ADVENTURERS adventurertype) { this.adventurertype = adventurertype; }
    public GameInformation.ADVENTURERS GetAdventurerType() { return this.adventurertype;  }

    public void SetHealth(int health) { this.health = health; }
    public int GetHealth() { return this.health; }

    public void SetCarryLimit(int carrylimit) { this.carrylimit = carrylimit; }
    public int GetCarryLimit() { return this.carrylimit;  }

    public int GetMaxTurns() { return this.maxTurns;  }
    public int GetRemainingTurns() { return this.turnsRemaining;  }
    public void TakeTurn() {
        this.turnsRemaining -= 1;
        if (this.turnsRemaining <= 0)
        {
            turnDone = true;
        }

    }
    public void SetMaxTurns(int maxTurns) { this.maxTurns = maxTurns; }
    public void ResetTurnsRemaining() { this.turnsRemaining = maxTurns; }

    public bool GetTurnDone() { return this.turnDone; }
    public void StartTurn()
    {
        turnDone = false;
        ResetTurnsRemaining();
    }

    public string GetMountainLayer() { return this.mountainLayer;  }
    public void SetMountainLayer(string ml) { this.mountainLayer = ml; }
}
