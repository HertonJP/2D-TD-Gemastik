using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private int HP = 2;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            Spawner.onEnemyDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}
