using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSledController : MonoBehaviour
{
    AdventurerController myController;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<AdventurerController>();
        myController.SetAdventurerType(GameInformation.ADVENTURERS.DOGSLED);
        myController.SetHealth(GameInformation.TOTALHEALTH_DOGSLED);
        myController.SetCarryLimit(GameInformation.TOTALCARRY_DOGSLED);
        myController.SetMaxTurns(4);
        print("Im the DOGSLED!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
