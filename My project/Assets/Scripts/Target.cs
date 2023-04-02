using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private EnemySpawner enemySpawner;
    public float wanderDuration = 2f;
    //public GameObject deathEffect;
    public float moveSpeed = 2f;
    public float rotationSpeed = 100f;
    private Vector3 wanderDirection;
    private float timer;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();

        }
    }

    public void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        enemySpawner.OnEnemyDeath();
        Destroy(gameObject);
        
    }
    // Start is called before the first frame update


    private void Start()
    {
        wanderDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        enemySpawner = FindObjectOfType<EnemySpawner>();
        timer = wanderDuration;
    }


    // Update is called once per frame
    void Update()
    {
        // Update the timer
        timer -= Time.deltaTime;

        // Check if the timer has expired
        if (timer <= 0f)
        {
            // Select a new random direction and reset the timer
            wanderDirection = Random.insideUnitSphere;
            timer = wanderDuration;
        }

        // Move the enemy forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Rotate the enemy towards the wander direction
        Vector3 targetDirection = wanderDirection - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}