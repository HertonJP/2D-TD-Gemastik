using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [SerializeField] private GameObject[] heroPrefabs;

    private int selectedHero = 0;


    private void Awake()
    {
        main = this;
    }

    public GameObject GetSelectedHero()
    {
        return heroPrefabs[selectedHero];
    }
}
