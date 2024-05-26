using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    public float speed = 1f;
    public int damage = 1;

    private bool isInvincible = false;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHP currentHP = collision.GetComponent<PlayerHP>();
            if (currentHP != null)
            {
                currentHP.TakeDamage(damage);
            }
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(Invincibility());
            }
        }
    }

    void Die()
    {
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

        spawner.EnemyDestroyed();
        scoreManager.AddScore(10);
 
        Destroy(gameObject);
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.5f);
        isInvincible = false;
    }
}
