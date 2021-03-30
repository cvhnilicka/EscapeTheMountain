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

    public GameObject adventurerPrefab;
    public SnowController startTileTEST;

    public SnowController[] testingMoves;
    int currIndx;


    AdventurerController currentUser;
    bool playerInTurn;


    bool testmove;


    float turnTimer;
    float turnTimerMax = 5f;

    // Start is called before the first frame update
    void Start()
    {
        currentUser = InitializeCook();
        playerInTurn = false;
        currIndx = 0;
        turnTimer = 0f;
    }

    public void SetPlayerInTurn(bool inTurn)
    {
        this.playerInTurn = inTurn;
        turnTimer = turnTimerMax;
        testmove = true;
    }
    public bool GetPlayerInTurn() { return this.playerInTurn;  }

    AdventurerController InitializeCook()
    {
        GameObject cook = Instantiate(adventurerPrefab, new Vector2(startTileTEST.transform.position.x, startTileTEST.transform.position.y), Quaternion.identity);
        AdventurerController cookIfo = cook.GetComponent<AdventurerController>();
        cookIfo.SetAdventurerType(GameInformation.ADVENTURERS.COOK);
        cookIfo.SetHealth(GameInformation.TOTALHEALTH_COOK);
        cookIfo.SetCarryLimit(GameInformation.TOTALCARRY_COOK);
        cookIfo.DisplayStats();
        return cookIfo;

    }

    void RotateLocation()
    {
        SnowController newSpot = testingMoves[currIndx];
        currIndx += 1;
        currentUser.transform.position = new Vector2(newSpot.transform.position.x, newSpot.transform.position.y);

        if (currIndx == testingMoves.Length) currIndx = 0;
        testmove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTurn)
        {
            // // need to do player turn stuff here
            if(testmove) RotateLocation();
            turnTimer -= Time.deltaTime;
            if (turnTimer < 0) playerInTurn = false;
            //playerInTurn = false;
        }
    }
}
