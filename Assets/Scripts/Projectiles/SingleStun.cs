using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStun : MovingProjectile
{
    public float stunDuration;
    public override void Update()
    {
        base.Update();
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        if (other.collider.GetComponent<Stun>() != null)
        {
            other.collider.GetComponent<Stun>().duration = stunDuration;
            other.collider.GetComponent<Stun>().isStunned = true;
        }
        Destroy(gameObject);
    }
}
