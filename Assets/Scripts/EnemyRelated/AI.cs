using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    public float _speed { get; private set; }
    [SerializeField] private Rigidbody2D rb;

    private Transform target;
    private int pathIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if(pathIndex == LevelManager.main.path.Length)
            {
                Spawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * speed;
    }

    public IEnumerator Slowed(float duration, float speedDecreaeAmount)
    {
        _speed -= speedDecreaeAmount;
        yield return new WaitForSeconds(duration);
        _speed = speed;
    }
}
