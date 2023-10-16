using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRangeActivation : MonoBehaviour
{
    [SerializeField] private HeroRangeVisual visual;
    private void OnMouseEnter()
    {
        Debug.Log("a");
        visual.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        Debug.Log("a");
        visual.GetComponent<SpriteRenderer>().enabled = false;
    }
}
