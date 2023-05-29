using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy {
    public float stopDistance = 1.5f;
    public float attackSpeed = 10f;

    private float TimeToAttack;
    [SerializeField] private float TimeBetweenAttacks = 1f;

    public override void Start() {
        base.Start();
        TimeToAttack = Time.time + TimeBetweenAttacks;
    }

    private void Update() {
        if (Player != null) {
            if (Vector2.Distance(transform.position, Player.position) > stopDistance - 1 && Vector2.Distance(transform.position, Player.position) > stopDistance + 1) {
                rb.MovePosition(Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime));
            } else {
                rb.velocity = Vector2.zero;

                if (Time.time > TimeToAttack) {
                    StartCoroutine(Attack());
                    TimeToAttack = Time.time + TimeBetweenAttacks;
                }
            }
        }

        rb.angularVelocity = 0;
    }

    IEnumerator Attack() {
        Player.GetComponent<PlayerController>().TakeDamage(1);

        Vector2 originalPosition = transform.position;

        float percent = 0f;

        while (percent <= 1) {
            if (Player != null) {
                percent += Time.deltaTime * attackSpeed;
                float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;

                transform.position = Vector2.Lerp(originalPosition, Player.position, interpolation);
                yield return null;
            } else {
                yield return null;
            }
        }
    }
}