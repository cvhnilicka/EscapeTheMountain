using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookController : MonoBehaviour
{
    AdventurerController myController;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<AdventurerController>();
        myController.SetAdventurerType(GameInformation.ADVENTURERS.COOK);
        myController.SetHealth(GameInformation.TOTALHEALTH_COOK);
        myController.SetCarryLimit(GameInformation.TOTALCARRY_COOK);
        myController.SetMaxTurns(4);
        print("Im a CooK!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
