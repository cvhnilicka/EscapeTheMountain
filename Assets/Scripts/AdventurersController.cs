using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurersController : MonoBehaviour
{

    /*
     * This can start to serve as the master controller for the adventurers
     * 
     * Initiallizing them
     * 
     * keeping track of whose turn it is
     * 
     * check for deaths
     * 
     * check for instants
     * 
     * maybe store adventurer difference info? i.e. snow patrol extra turn?
     * 
     * 
     * **/


    [Header("Sprites section")]
    public Sprite engineerSprite;
    public Sprite cookSprite;

    public GameObject adventurerPrefab;
    public SnowController startTileTEST;

    public SnowController[] testingMoves;


    AdventurerController currentUser;
    bool playerInTurn;


    bool testmove;


    float turnTimer;
    float turnTimerMax = 5f;

    AdventurerController engineer;

    List<AdventurerController> playingAdventurers;
    int currPlayerIndex;


    // Start is called before the first frame update
    void Start()
    {

        //testing
        playerInTurn = false;
        currPlayerIndex = 0;
        turnTimer = 0f;
        playingAdventurers = GetPlayingAdventurers();
        SetCurrentUser(playingAdventurers[0]);
        //RotateCurrPlayer();
    }

    List<AdventurerController> GetPlayingAdventurers()
    {
        List<AdventurerController> newAdventurers = new List<AdventurerController>();
        newAdventurers.Add(InitializeAdventurer(GameInformation.ADVENTURERS.COOK));
        newAdventurers.Add(InitializeAdventurer(GameInformation.ADVENTURERS.ENGINEER));
        newAdventurers.Add(InitializeAdventurer(GameInformation.ADVENTURERS.MOUNTAINEER));
        return newAdventurers;
    }

    void RotateCurrPlayer()
    {
        currPlayerIndex += 1;
        if (currPlayerIndex == playingAdventurers.Count) currPlayerIndex = 0;
        SetCurrentUser(playingAdventurers[currPlayerIndex]);
        //currentUser = playingAdventurers[currPlayerIndex];
        //SetCurrentUser(currentUser);
        
    }


    void SetCurrentUser(AdventurerController nextUser)
    {
        if (currentUser)
            this.currentUser.tag = "OutOfTurn";
        nextUser.tag = "Player";
        this.currentUser = nextUser;

    }

    public void SetPlayerInTurn(bool inTurn)
    {
        //print(currentUser.GetAdventurerType() + " : STARTING TURN");
        this.playerInTurn = inTurn;
        turnTimer = turnTimerMax;
        currentUser.StartTurn();
    }
    public bool GetPlayerInTurn() { return this.playerInTurn;  }



    AdventurerController InitializeAdventurer(GameInformation.ADVENTURERS adventurerType)
    {
        GameObject adventurer = Instantiate(adventurerPrefab, new Vector2(startTileTEST.transform.position.x, startTileTEST.transform.position.y), Quaternion.identity);
        AdventurerController adventControl = adventurer.GetComponent<AdventurerController>();



        switch(adventurerType)
        {
            case GameInformation.ADVENTURERS.COOK:
                adventurer.AddComponent<CookController>();
                adventControl.GetMySprite().sprite = cookSprite;
                break;
            case GameInformation.ADVENTURERS.ENGINEER:
                adventurer.AddComponent<EngineerController>();
                adventControl.GetMySprite().sprite = engineerSprite;
                break;
            case GameInformation.ADVENTURERS.DOGSLED:
                adventurer.AddComponent<DogSledController>();
                adventControl.GetMySprite().sprite = cookSprite; // TEMP
                break;
            case GameInformation.ADVENTURERS.MOUNTAINEER:
                adventurer.AddComponent<MountaineerController>();
                adventControl.GetMySprite().sprite = cookSprite; // TEMP 
                break;
            case GameInformation.ADVENTURERS.SKIER:
                adventurer.AddComponent<SkierController>();
                adventControl.GetMySprite().sprite = cookSprite; // TEMP
                break;
            case GameInformation.ADVENTURERS.SNOWPATROL:
                adventurer.AddComponent<SnowPatrolController>();
                adventControl.GetMySprite().sprite = cookSprite; // TEMP
                break;

        }



        adventControl.SetLocation(startTileTEST.GetComponentInParent<TileController>());
        return adventControl;

    }


    // Update is called once per frame
    void Update()
    {
        if (playerInTurn)
        {
            if (currentUser.GetTurnDone())
            {
                // players turn is over (all actions used)
                print("PLAYER DONE");
                playerInTurn = false;
                RotateCurrPlayer();
            }
            // // need to do player turn stuff here
            //if(testmove) RotateLocation();
            //turnTimer -= Time.deltaTime;
            //if (turnTimer < 0) playerInTurn = false;
            //playerInTurn = false;
        }
    }


}
