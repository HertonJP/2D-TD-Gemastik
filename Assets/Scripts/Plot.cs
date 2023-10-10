using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plot : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] HeroHover hover;
    [SerializeField] Tilemap tileMap;

    [SerializeField] private GameObject hero;
    private Color startColor;
    private bool isFull = false;

    private void Start()
    {
       // startColor = sr.color;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PlaceCharacter();
        }
            
    }

    //private void OnMouseEnter()
    //{
    //    if (Time.timeScale != 0 && !isFull)
    //    {
    //        sr.color = hoverColor;
    //    }

    //}

    //private void OnMouseExit()
    //{
    //    sr.color = startColor;
    //}

    private void PlaceCharacter()
    {
        if (ValidateCharacterPlacement())
        {
            if (hero != null)
            {
                return;
            }
            HeroTiles heroToSpawn = BuildManager.main.GetSelectedHero();
            if (heroToSpawn == null || heroToSpawn.cost > LevelManager.main.nutrition)
            {
                return;
            }
            LevelManager.main.SpendCurrency(heroToSpawn.cost);
            Vector3 spawnPosition = hover.transform.position;
            hero = Instantiate(heroToSpawn.prefab, spawnPosition, Quaternion.identity);
            Debug.Log(spawnPosition);
            isFull = true;
            BuildManager.main.ResetSelectedHero();
            HeroHover.Instance.Activate(null);
            // reset hero
            hero = null;
        }
    }

    private bool ValidateCharacterPlacement()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        return Time.timeScale != 0 && tileMap.GetTile(tileMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition))) != null && hit.collider == null;
    }
}
