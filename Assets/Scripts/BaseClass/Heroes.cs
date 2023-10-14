using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Heroes : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] protected int manaIncrease;
    public GameObject _projectilesPrefab { get; private set;}

    [SerializeField] private Transform firingPoint;
    public Transform _firingPoint { get; private set; }

    [SerializeField] protected int maxMana = 100;
    [SerializeField] private float targetingRange = 3f;

    [SerializeField] private float attackSpeed = 1f;
    public float _attackSpeed { get;  set; }

    [SerializeField] protected int mana;

    [SerializeField] protected Transform target;
    protected float timeUntilFire = 2;
    [SerializeField] AnimationState animState;

    public virtual void Start()
    {
        mana = 0;

        InitializeData();
    }

    public virtual void Update()
    {

        if (target == null)
        {
            FindTarget();
            animState.state = AnimationState.States.Idle;
            return;
        }

        if (!inRange())
        {
            target = null;
        }

        timeUntilFire += Time.deltaTime;
        if (mana >= maxMana)
        {
            Ulti();
        }
        if (timeUntilFire >= (1f / _attackSpeed) && target != null)
        {
            animState.state = AnimationState.States.Attack;
            Attack();
            timeUntilFire = 0f;
        }
    }

    protected virtual void Attack()
    {
        mana += manaIncrease;
    }

    protected virtual void Ulti()
    {   
        Debug.Log("ngeskill");
        mana = 0;
    }

    private bool inRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    protected void FindTarget()
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

    private void InitializeData()
    {
        _attackSpeed = attackSpeed;
        _firingPoint = firingPoint;
        _projectilesPrefab = projectilesPrefab;
    }
}
