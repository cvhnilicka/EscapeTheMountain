using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerController : MonoBehaviour
{


    /*
     * Single adventurer specific functionality 
     *
     * Set Type
     * Get Type
     *
     * Set Health
     * Get Health
     * Take Damage
     * Add Health
     * Get CurrHealth
     * 
     * Set CarryLimit
     * Get CarryLimit
     * Add Weight
     * Remove Weight
     * Get CurrCarry
     * 
     * 
     * [] Carried Gear
     * [] Carried Equipment
     * 
     * 
     * Avialable actions?
     * 
     * etc
     * 
     * 
     * 
     * 
     * **/




    /*
     * Looks like i can set the location using the snow controllers on each tile
     * **/
    public SnowController test;


    


    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector2(test.gameObject.transform.position.x, test.gameObject.transform.position.y);
        //transform.rotation = test.gameObject.transform.rotation;

        print("AN ADVENTURERS APPEARS");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
