using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 5f;

    [HideInInspector] public int health = 40;
    [HideInInspector] public Transform Player;
    [HideInInspector] public Rigidbody2D rb;

    public GameObject DeathParticalEffect;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void TakeDamage(int Damage) {
        health -= Damage;

        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        Instantiate(DeathParticalEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}