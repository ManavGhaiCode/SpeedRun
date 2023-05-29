using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5f;
    public Vector2 WeaponPos;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Vector2 mousePosistion;
    private float angle = 0;

    private int health = 10;
    [SerializeField] private HealthBar healthBar;

    private void Start() {
        healthBar.SetMaxHealth(health);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        float forceX = moveInput.normalized.x * speed * Time.fixedDeltaTime;
        float forceY = moveInput.normalized.y * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + new Vector2 (forceX, forceY));

        mousePosistion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 LookDir = mousePosistion - rb.position;

        angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    public void TakeWeapon(GameObject weapon) {
        GameObject CurrentWeapon = GameObject.FindGameObjectWithTag("PlayerWeapon");

        if (CurrentWeapon != null) {
            Destroy(CurrentWeapon);
        }

        Transform NewWeaponTransform = Instantiate(weapon, WeaponPos, Quaternion.identity).GetComponent<Transform>();
        NewWeaponTransform.SetParent(transform, false);
    }

    public void TakeDamage(int Damage) {
        health -= Damage;
        healthBar.SetHealth(health);

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
