using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkierController : MonoBehaviour
{
    AdventurerController myController;

    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<AdventurerController>();
        myController.SetAdventurerType(GameInformation.ADVENTURERS.SKIER);
        myController.SetHealth(GameInformation.TOTALHEALTH_SKIER);
        myController.SetCarryLimit(GameInformation.TOTALCARRY_SKIER);
        myController.SetMaxTurns(4);
        print("Im the Skier!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
