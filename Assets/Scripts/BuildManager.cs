using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [SerializeField] private HeroTiles[] heroes;

    private int selectedHero = 0;


    private void Awake()
    {
        main = this;
    }

    public HeroTiles GetSelectedHero()
    {
        return heroes[selectedHero];
    }

    public void SetSelectedHero(int _selectedHero)
    {
        selectedHero = _selectedHero;
    }
}
