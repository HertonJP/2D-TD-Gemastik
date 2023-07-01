using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject hero;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if(hero != null)
        {
            return;
        }
        HeroTiles heroToSpawn = BuildManager.main.GetSelectedHero();
        if(heroToSpawn.cost > Currency.main.nutrition)
        {
            Debug.Log("Not Enough Nutrition");
            return;
        }
        Currency.main.SpendCurrency(heroToSpawn.cost);
        hero = Instantiate(heroToSpawn.prefab, transform.position, Quaternion.identity);
    }



}
