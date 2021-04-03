using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPatrolController : MonoBehaviour
{
    AdventurerController myController;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<AdventurerController>();
        myController.SetAdventurerType(GameInformation.ADVENTURERS.SNOWPATROL);
        myController.SetHealth(GameInformation.TOTALHEALTH_SNOWPATROL);
        myController.SetCarryLimit(GameInformation.TOTALCARRY_SNOWPATROL);
        myController.SetMaxTurns(5);
        print("Im the SnowPatrol!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
