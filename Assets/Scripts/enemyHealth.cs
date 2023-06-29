using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private int HP = 2;


    private bool isDestroyed = false;
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if(HP <= 0 && !isDestroyed)
        {
            Spawner.onEnemyDestroy.Invoke();
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
