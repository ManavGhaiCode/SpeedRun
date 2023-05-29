using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 5f;

    public int health = 40;
    [HideInInspector] public Transform Player;
    [HideInInspector] public Rigidbody2D rb;

    public GameObject DeathParticalEffect;
    public Animator anim;

    public virtual void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void TakeDamage(int Damage) {
        health -= Damage;

        if (health <= 0) {
            Die();
        }

        anim.SetTrigger("Hit");
    }

    public void Die() {
        Instantiate(DeathParticalEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}