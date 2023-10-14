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
    private float timeUntilFire = 2;
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        mana = 0;
    }
    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            anim.SetTrigger("isIdle");
            return;
        }
        if (!inRange())
        {
            target = null;
            
        }
        else
        {
            SetAttackPointRotation attackPointRotation = firingPoint.GetComponent<SetAttackPointRotation>();
            attackPointRotation.SetTarget(target);
            timeUntilFire += Time.deltaTime;
        }
        if(timeUntilFire >= (1f / attackSpeed))
        {
            anim.SetTrigger("isAttack");
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
        
        GameObject projectile = Instantiate(projectilesPrefab, transform.position,Quaternion.identity);
        projectile.GetComponent<Projectiles>().SetTarget(target);
        projectile.transform.rotation = firingPoint.rotation;
        projectile.transform.eulerAngles += new Vector3(0, 0, 90);
        //projectile.transform.rotation = Quaternion.Euler(0, 0, firingPoint.eulerAngles.z);
     
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
