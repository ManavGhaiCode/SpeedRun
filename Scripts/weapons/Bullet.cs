using UnityEngine;

public class Bullet : MonoBehaviour {
    public int Damage = 0;
    public float lifespan;

    public GameObject EnemyHitEffect;
    public GameObject HitParticalEffect;

    private void Start() {
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null) {
            GameObject particleEffect = Instantiate(EnemyHitEffect, transform.position, transform.rotation);
            particleEffect.transform.localScale = new Vector3 (.3f, .3f, .3f);

            enemy.TakeDamage(Damage);
        }

        GameObject hit_particleEffect = Instantiate(HitParticalEffect, transform.position, transform.rotation);
        hit_particleEffect.transform.localScale = new Vector3 (.3f, .3f, .3f);
        Destroy(gameObject, .05f);
    }
}