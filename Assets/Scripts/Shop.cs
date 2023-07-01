using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] private GameObject ShopPanel;

    public void onClickPanel()
    {
        if(ShopPanel.activeSelf == true)
        {
            ShopPanel.SetActive(false);
        }
        else
        {
            ShopPanel.SetActive(true);
        }
    }

    public void closePanel()
    {
        ShopPanel.SetActive(false);
    }
    

    private void OnGUI()
    {
        Currency.main.nutrition.ToString();
    }

    public void SetSelected()
    {

    }
}