using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGameController : MonoBehaviour
{
    public enum GAME_STATES { SETUP, PLAY, END }
    public enum PLAY_STATE { PLAYER, ENVIRONMENTPRE, ENVIRONMENTPOST, WAITING }

    GAME_STATES currentGameState;
    PLAY_STATE currentPlayState;

    BoardController myBoard;


    float randomTimer;
    [SerializeField] float rotateTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GAME_STATES.SETUP;
        currentPlayState = PLAY_STATE.WAITING;
        myBoard = GetComponentInChildren<BoardController>();
        DisplayGameStates();

    }

    void Timers()
    {
        randomTimer -= Time.deltaTime;
        if (randomTimer <= 0)
        {
            SwapPlayState();
            randomTimer = rotateTimer;
        }

    }

    void SwapPlayState()
    {
        if (currentPlayState == PLAY_STATE.WAITING)
        {
            currentPlayState = PLAY_STATE.PLAYER;
        }
        else if (currentPlayState == PLAY_STATE.PLAYER)
        {
            currentPlayState = PLAY_STATE.ENVIRONMENTPRE;
            // IN THIS STATE THE GAME WILL DRAW IS ENV CARDS AND ADD SNOW
        }
        else if (currentPlayState == PLAY_STATE.ENVIRONMENTPRE)
        {
            currentPlayState = PLAY_STATE.ENVIRONMENTPOST;
            // IN THIS STATE WE WILL NEED TO DO THE AVALANCHE STUFF AND POST
            // ENV CARDS ACTIONS
        }
        else if (currentPlayState == PLAY_STATE.ENVIRONMENTPOST)
        {
            currentPlayState = PLAY_STATE.PLAYER;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckBoardState();
        if (currentGameState == GAME_STATES.PLAY)
        {
            // in the play loop
            Timers();

            if (currentPlayState == PLAY_STATE.ENVIRONMENTPRE)
            {
                //print("SNOWFALLLLLLLLLL");
                myBoard.SnowFall();
                SwapPlayState();
                randomTimer = rotateTimer;

            }


            else if (currentPlayState == PLAY_STATE.ENVIRONMENTPOST)
            {
                // avalanche control
                myBoard.RunAvalanchesCheck();
                SwapPlayState();
                randomTimer = rotateTimer;

            }

        }
        //DisplayGameStates();
    }

    void CheckBoardState()
    {
        if (myBoard.GetSetUp()) { currentGameState = GAME_STATES.PLAY;  }
    }

    void DisplayGameStates()
    {
        print("Current Game State: " + currentGameState);
        print("Current Play State: " + currentPlayState);
    }
}
