using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{
    CounterController mySnowCounter;
    int mySnowCount;

    // Start is called before the first frame update
    void Start()
    {
        mySnowCounter = GetComponentInChildren<CounterController>();
        mySnowCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetSnowCount() { return this.mySnowCount;  }

    public void SetSnowCount(int snowCount)
    {
        mySnowCount = snowCount;
        UpdateCounter();
    }

    public void AddSnow(int newSnow)
    {
        mySnowCount += newSnow;
        UpdateCounter();
    }

    void UpdateCounter()
    {
        mySnowCounter.SetNumber(mySnowCount);
    }
}
