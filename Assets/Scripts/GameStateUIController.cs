using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateUIController : MonoBehaviour
{

    static GameObject stateTextObj;
   

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "GSText")
            {
                stateTextObj = child.gameObject; 
            }
        }
    }

    //public
    public static void SetGameState(string txt)
    {
        stateTextObj.GetComponent<Text>().text = txt;
    }


}
