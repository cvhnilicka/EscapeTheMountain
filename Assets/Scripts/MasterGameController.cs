using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameInformation;

public class MasterGameController : MonoBehaviour
{
    public enum GAME_STATES { SETUP, PLAY, END }
    public enum PLAY_STATE { PLAYER, ENVIRONMENTPRE, ENVIRONMENTPOST, WAITING }

    GAME_STATES currentGameState;
    PLAY_STATE currentPlayState;

    BoardController myBoard;


    float randomTimer;
    [SerializeField] float rotateTimer = 5f;


    // Deck Info
    ENVIRONMENT_CARD_TYPES[] currentEnvironmentDeck;
    private int environmentCardIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GAME_STATES.SETUP;
        currentPlayState = PLAY_STATE.WAITING;
        myBoard = GetComponentInChildren<BoardController>();
        DisplayGameStates();
        currentEnvironmentDeck = ShuffleDeck();
        //PrintDecks();
        if (!DeckChecker()) print("Something wrong with deck");
        else print("Deck Is Proper");
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

    void UpdateGameStateUI(PLAY_STATE state)
    {
        GameStateUIController.SetGameState(state.ToString());
    }

    void UpdateLECUI(ENVIRONMENT_CARD_TYPES envcard)
    {
        GameStateUIController.SetLEC(envcard.ToString());
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
        UpdateGameStateUI(currentPlayState);
        //randomTimer = rotateTimer;
    }

    // Update is called once per frame
    void Update()
    {
        CheckBoardState();
        if (currentGameState == GAME_STATES.PLAY)
        {
            // in the play loop

            if (currentPlayState == PLAY_STATE.ENVIRONMENTPRE)
            {
                // here i need to add in the "draw a card and do that action"
                EnvironmentCardAction(DrawEnvironmentCard());
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
            else
            {
                Timers();
            }

        }
    }


    ENVIRONMENT_CARD_TYPES DrawEnvironmentCard()
    {
        ENVIRONMENT_CARD_TYPES drewCard = currentEnvironmentDeck[environmentCardIndex];
        environmentCardIndex += 1;
        if (environmentCardIndex == currentEnvironmentDeck.Length) currentEnvironmentDeck =  ShuffleDeck();
        UpdateLECUI(drewCard);
        return drewCard;
    }


    void EnvironmentCardAction(ENVIRONMENT_CARD_TYPES drewCard)
    {
        switch (drewCard)
        {
            case ENVIRONMENT_CARD_TYPES.SNOWFALLALL:
                myBoard.SnowFall(ENVIRONMENT_CARD_TYPES.SNOWFALLALL);
                break;
            case ENVIRONMENT_CARD_TYPES.SNOWFALLEVEN:
                myBoard.SnowFall(ENVIRONMENT_CARD_TYPES.SNOWFALLEVEN);
                break;
            case ENVIRONMENT_CARD_TYPES.SNOWFALLODD:
                myBoard.SnowFall(ENVIRONMENT_CARD_TYPES.SNOWFALLODD);
                break;
            case ENVIRONMENT_CARD_TYPES.WHITEOUT:
                print("WhiteOUT");
                myBoard.WhiteOut();
                break;
            default:
                print("OTHER CARD");
                break;
        }
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

    void PrintDecks()
    {
        print("Environment Deck:");
        for (int i = 0; i < currentEnvironmentDeck.Length; i++)
        {
            print(i + " : " + currentEnvironmentDeck[i]);
        }
    }



    ENVIRONMENT_CARD_TYPES[] ShuffleDeck()
    {
        ENVIRONMENT_CARD_TYPES[] ret = UNSHUFFLED_DECK;
        for(int i = 0; i < ret.Length; i++)
        {
            int r = Random.Range(i, ret.Length);
            ENVIRONMENT_CARD_TYPES t = ret[r];
            ret[r] = ret[i];
            ret[i] = t;
        }
        environmentCardIndex = 0;
        return ret;
    }


    bool DeckChecker()
    {
        bool ret = true;
        int sfo = 0,
            sfe = 0,
            sfa = 0,
            wo = 0,
            wd = 0,
            cs = 0;
        for (int i = 0; i < currentEnvironmentDeck.Length; i++)
        {
            switch (currentEnvironmentDeck[i])
            {
                case ENVIRONMENT_CARD_TYPES.COLDSNAP: cs += 1;
                    break;
                case ENVIRONMENT_CARD_TYPES.SNOWFALLALL: sfa += 1;
                    break;
                case ENVIRONMENT_CARD_TYPES.SNOWFALLODD: sfo += 1;
                    break;
                case ENVIRONMENT_CARD_TYPES.SNOWFALLEVEN: sfe += 1;
                    break;
                case ENVIRONMENT_CARD_TYPES.WARMDAY: wd += 1;
                    break;
                case ENVIRONMENT_CARD_TYPES.WHITEOUT: wo += 1;
                    break;
            }
        }
        if (sfo > NUM_SNOWFALLODD ||
            sfe > NUM_SNOWFALLEVEN ||
            sfa > NUM_SNOWFALLALL ||
            wo > NUM_WHITEOUT ||
            wd > NUM_WARMDAY ||
            cs > NUM_COLDSNAP)
        {
            ret = false;
        }
        return ret;
    }
}
