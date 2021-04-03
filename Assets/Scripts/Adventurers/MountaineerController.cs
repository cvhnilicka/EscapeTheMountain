using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountaineerController : MonoBehaviour
{
    AdventurerController myController;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<AdventurerController>();
        myController.SetAdventurerType(GameInformation.ADVENTURERS.MOUNTAINEER);
        myController.SetHealth(GameInformation.TOTALHEALTH_MOUNTAINEER);
        myController.SetCarryLimit(GameInformation.TOTALCARRY_MOUNTAINEER);
        myController.SetMaxTurns(4);
        print("Im the MOUNTAINEER!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
