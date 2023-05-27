using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 5f;

    private int health = 40;
    private Transform Player;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update() {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int Damage) {
        health -= Damage;
    }
}