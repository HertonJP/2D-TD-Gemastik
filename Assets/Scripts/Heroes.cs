using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Heroes : MonoBehaviour
{
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private LayerMask enemyMask;

    [SerializeField] private float targetingRange = 3f;

    private Transform target;

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

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform != target)
            {
                // Flip the sprite horizontally
                SpriteRenderer spriteRenderer = rotationPoint.GetComponent<SpriteRenderer>();
                spriteRenderer.flipX = direction.x < 0;
                break;
            }
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
