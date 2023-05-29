using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public int Damage;
    public float lifespan;

    [SerializeField] private GameObject PlayerHitEffect;
    [SerializeField] private GameObject HitParticalEffect;

    private void Start() {
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerController Player = hitInfo.GetComponent<PlayerController>();

        if (Player != null) {
            GameObject particleEffect = Instantiate(PlayerHitEffect, transform.position, transform.rotation);
            particleEffect.transform.localScale = new Vector3 (.3f, .3f, .3f);

            Player.TakeDamage(Damage);
        }

        GameObject hit_particleEffect = Instantiate(HitParticalEffect, transform.position, transform.rotation);
        hit_particleEffect.transform.localScale = new Vector3 (.3f, .3f, .3f);
        Destroy(gameObject);
    }
}