using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineerController : MonoBehaviour
{
    AdventurerController myController;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<AdventurerController>();
        myController.SetAdventurerType(GameInformation.ADVENTURERS.ENGINEER);
        myController.SetHealth(GameInformation.TOTALHEALTH_ENGINEER);
        myController.SetCarryLimit(GameInformation.TOTALCARRY_ENGINEER);
        myController.SetMaxTurns(4);
        print("Im the Engineer!");
    }

    // Update is called once per frame
    void Update()
    {
        //myController.GetMySprite().sprite = 
    }
}
