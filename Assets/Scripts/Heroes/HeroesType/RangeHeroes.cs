using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeHeroes : Heroes
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        SetAttackPointRotation attackPointRotation = _firingPoint.GetComponent<SetAttackPointRotation>();
        if (target == null)
            return;
        attackPointRotation.SetTarget(target);
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject projectile = Instantiate(_projectilesPrefab, transform.position, Quaternion.identity);
        
        projectile.GetComponent<Projectiles>().SetTarget(target);
        projectile.transform.rotation = _firingPoint.rotation;
        projectile.transform.eulerAngles += new Vector3(0, 0, 90);
    }
}
