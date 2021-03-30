using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurersController : MonoBehaviour
{

    /*
     * This can start to serve as the master controller for the adventurers
     * 
     * Initiallizing them
     * 
     * keeping track of whose turn it is
     * 
     * check for deaths
     * 
     * check for instants
     * 
     * maybe store adventurer difference info? i.e. snow patrol extra turn?
     * 
     * 
     * **/

    public GameObject adventurerPrefab;
    public SnowController startTileTEST;


    // Start is called before the first frame update
    void Start()
    {
        InitializeCook();
    }

    void InitializeCook()
    {
        GameObject cook = Instantiate(adventurerPrefab, new Vector2(startTileTEST.transform.position.x, startTileTEST.transform.position.y), Quaternion.identity);
        cook.GetComponent<AdventurerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
