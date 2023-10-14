using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingProjectile : Projectiles
{

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        transform.position += (Vector3)direction * projectilesSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<enemyHealth>().TakeDamage(projectilesDamage);
        Destroy(gameObject);
    }
}
