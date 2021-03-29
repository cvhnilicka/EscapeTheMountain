using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGameController : MonoBehaviour
{
    public enum GAME_STATES { SETUP, PLAY, END }
    public enum PLAY_STATE { PLAYER, ENVIRONMENT, WAITING }

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
            currentPlayState = PLAY_STATE.ENVIRONMENT;
        }
        else if (currentPlayState == PLAY_STATE.ENVIRONMENT)
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


        }
        DisplayGameStates();
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
