using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject hero;
    private Color startColor;
    private bool isFull = false;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        if (Time.timeScale != 0 && !isFull)
        {
            sr.color = hoverColor;
        }
        
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (Time.timeScale != 0)
        {
            if (hero != null)
            {
                return;
            }
            HeroTiles heroToSpawn = BuildManager.main.GetSelectedHero();
            if (heroToSpawn == null || heroToSpawn.cost > LevelManager.main.nutrition)
            {
                Debug.Log("Not Enough Nutrition");
                return;
            }
            LevelManager.main.SpendCurrency(heroToSpawn.cost);
            Vector3 spawnPosition = transform.position + new Vector3(0, 0.5f, 0);
            hero = Instantiate(heroToSpawn.prefab, spawnPosition, Quaternion.identity);
            isFull = true;

            BuildManager.main.ResetSelectedHero();
        }
    }



}
