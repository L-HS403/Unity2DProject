using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float maxDistance = 5f;
    private Vector3 direction;
    private Vector3 initialPosition;
    private bool returning = false;

    private GameObject player;
    private GameObject spawnPoint;
    private int damage;

    void Start()
    {
        initialPosition = transform.position;
        player = GameObject.FindWithTag("Player");
        spawnPoint = GameObject.FindWithTag("SpawnPoint");
        if (player != null)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                damage = playerStats.damage;
            }
        }
    }

    void Update()
    {
        if (!returning)
        {
            transform.position += direction * speed * Time.deltaTime;
            if (Vector3.Distance(initialPosition, transform.position) >= maxDistance)
            {
                returning = true;
            }
        }
        else
        {
            Vector3 returnDirection = (spawnPoint.transform.position - transform.position).normalized;
            transform.position += returnDirection * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, spawnPoint.transform.position) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.EnemyTakeDamage(damage);
            }
        }
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }
}
