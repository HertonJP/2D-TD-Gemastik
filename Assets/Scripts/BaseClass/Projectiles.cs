using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    protected Transform target;
    [SerializeField] protected float projectilesSpeed = 5f;
    [SerializeField] protected int projectilesDamage = 1;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (!target)
        {
            return;
        }

    }
}