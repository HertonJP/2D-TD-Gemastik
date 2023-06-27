using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plot : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase highlightTile;

    private GameObject hero;

    private void OnMouseEnter()
    {
        // Highlight the tile by setting a different tile on the tilemap
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
        tilemap.SetTile(cellPosition, highlightTile);
    }

    private void OnMouseExit()
    {
        // Remove the highlight tile from the tilemap
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
        tilemap.SetTile(cellPosition, null);
    }

    private void OnMouseDown()
    {
        Debug.Log("Hero Spawned here: " + name);
        // Spawn your hero prefab at the plot's position
        // You can instantiate your hero prefab here and position it accordingly
        // For example:
        // Instantiate(heroPrefab, transform.position, Quaternion.identity);
    }
}