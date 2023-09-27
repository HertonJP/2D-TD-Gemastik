using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHover : MonoBehaviour
{
    private static HeroHover instance;

    private SpriteRenderer spriteRenderer;

    public static HeroHover Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HeroHover>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(this.gameObject);
    }

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