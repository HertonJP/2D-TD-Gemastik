using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Heroes : MonoBehaviour
{
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject heroObject;

    [SerializeField] private float targetingRange = 3f;
    private SpriteRenderer heroSpriteRenderer;

    private Transform target;

    private void Start()
    {
        heroSpriteRenderer = heroObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(target == null)
        {
            FindTarget();
            return;
        }
        
        if (!inRange())
        {
            target = null;
        }
        CheckEnemyPassed();
    }


    private void CheckEnemyPassed()
    {
        Vector2 direction = target.position - transform.position;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, targetingRange, enemyMask);

        bool enemyPassed = false;

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform != target)
            {
                enemyPassed = true;
                break;
            }
        }

        // Flip the sprite based on the enemy passing
        if (enemyPassed)
        {
            heroSpriteRenderer.flipX = direction.x < 0;
        }
    }
    private bool inRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if(hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
