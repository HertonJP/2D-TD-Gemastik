using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public int currency;

    private void Start()
    {
        currency = 100;   
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if(amount <= currency)
        {
            Debug.Log("Beli item");
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough");
            return false;
        }
    }
}
