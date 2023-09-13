using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Heroes : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] private Transform firingPoint;

    [SerializeField] private int maxMana = 100;
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private int mana;
    private Transform target;
    private float timeUntilFire;

    private void Start()
    {
        mana = 0;
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
        else
        {
            timeUntilFire += Time.deltaTime;
        }
        if(timeUntilFire >= 1f / attackSpeed)
        {
            Attack();
            timeUntilFire = 0f;
        }
        if(mana == maxMana)
        {
            Ulti();
        }
    }

    private void Attack()
    {
        GameObject projectilesObj = Instantiate(projectilesPrefab, firingPoint.position, Quaternion.identity);
        Projectiles projectilesScript = projectilesObj.GetComponent<Projectiles>();
        projectilesScript.SetTarget(target);
        Debug.Log("Attack");
        mana += 5;
    }
    private void Ulti()
    {   
        Debug.Log("ngeskill");
        mana = 0;
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
