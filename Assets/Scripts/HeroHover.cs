using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHover : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    private void Update()
    {
        followMouse();
    }

    private void followMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void Activate(Sprite sprite)
    {
        this.spriteRenderer.sprite = sprite;
    }
}
