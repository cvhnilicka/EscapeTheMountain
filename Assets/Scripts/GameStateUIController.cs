using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateUIController : MonoBehaviour
{

    static GameObject stateTextObj;
    static GameObject lastEnvCard;



    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            switch(child.name)
            {
                case "GSText": stateTextObj = child.gameObject;
                    break;
                case "LECText": lastEnvCard = child.gameObject;
                    break;
            }            
        }
    }

    //public
    public static void SetGameState(string txt)
    {
        stateTextObj.GetComponent<Text>().text = txt;
    }

    public static void SetLEC(string txt)
    {
        lastEnvCard.GetComponent<Text>().text = txt;
    }


}
