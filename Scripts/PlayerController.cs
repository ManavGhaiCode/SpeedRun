using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D rb;

    private void Start() {
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
    }
}
