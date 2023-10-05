using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float projectilesSpeed = 5f;
    [SerializeField] private int projectilesDamage = 1;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    private void Start()
    {
    }
    private void Update()
    {
        if (!target)
        {
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        transform.up = direction;
        transform.position += (Vector3)direction * projectilesSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<enemyHealth>().TakeDamage(projectilesDamage);
        Destroy(gameObject);
    }
}