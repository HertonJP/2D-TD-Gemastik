using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyUI;
    

    private void OnGUI()
    {
        Currency.main.nutrition.ToString();
    }
}
