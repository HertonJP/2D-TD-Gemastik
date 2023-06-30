using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static Currency main;
    public int nutrition;

    private void Start()
    {
        nutrition = 100;   
    }

    private void Awake()
    {
        main = this;
    }
    public void IncreaseCurrency(int amount)
    {
        nutrition += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if(amount <= nutrition)
        {
            Debug.Log("Beli item");
            nutrition -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough");
            return false;
        }
    }
}
