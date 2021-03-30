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


    private GameInformation.ADVENTURERS adventurertype;
    private int health;
    private int carrylimit;
    




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DisplayStats()
    {
        print("Adventurer: " + this.adventurertype.ToString());
        print("Health: " + this.health + "\tCarryLimit: " + this.carrylimit+"\n");

    }


    public void SetAdventurerType(GameInformation.ADVENTURERS adventurertype) { this.adventurertype = adventurertype; }
    public GameInformation.ADVENTURERS GetAdventurerType() { return this.adventurertype;  }

    public void SetHealth(int health) { this.health = health; }
    public int GetHealth() { return this.health; }

    public void SetCarryLimit(int carrylimit) { this.carrylimit = carrylimit; }
    public int GetCarryLimit() { return this.carrylimit;  }
}
