using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] private GameObject ShopPanel;
    private BuildManager buildManager;
    private int selectedHeroIndex = -1;

    private void Start()
    {
        buildManager = BuildManager.main;
        ShopPanel.SetActive(false);
    }

    public void onClickPanel(int heroIndex)
    {
        if (ShopPanel.activeSelf == true && selectedHeroIndex == heroIndex)
        {
            ShopPanel.SetActive(false);
            selectedHeroIndex = -1;
        }
        else
        {
            ShopPanel.SetActive(true);
            selectedHeroIndex = heroIndex;
        }
    }

    public void closePanel()
    {
        ShopPanel.SetActive(false);
        selectedHeroIndex = -1;
    }

    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.nutrition.ToString();
    }

    public void SetSelected()
    {
        if (selectedHeroIndex != -1)
        {
            HeroTiles selectedHero = buildManager.GetHeroByIndex(selectedHeroIndex);
            if (selectedHero != null)
            {
                GameObject heroPrefab = selectedHero.prefab;
                if (heroPrefab != null)
                {
                    // Assuming you have a reference to the selected hero tile,
                    // you can call the SpawnHero method in BuildManager to spawn the hero.
                    // Pass the hero prefab and the selected hero tile as arguments.
                    // buildManager.SpawnHero(heroPrefab, selectedHeroTile);
                }
            }
        }
    }
}