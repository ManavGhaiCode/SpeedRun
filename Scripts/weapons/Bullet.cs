using UnityEngine;

public enum BulletType {
    Default = 0,
    Fire = 1
}

public class Bullet : MonoBehaviour {
    public int Damage = 0;
    public float lifespan;

    public GameObject EnemyHitEffect;
    public GameObject HitParticalEffect;

    public BulletType Type;

    public GameObject SplashDamageObj;

    private void Start() {
        Invoke("DestroyBullet", lifespan);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (Type == BulletType.Default) {
            if (enemy != null) {
                enemy.TakeDamage(Damage);
                EnemyHitPartical();
            }
        } else if (Type == BulletType.Fire) {
            if (enemy != null) {
                enemy.TakeDamage(Damage);
                EnemyHitPartical();

                GameObject splashDamage = Instantiate(SplashDamageObj, transform.position, transform.rotation);
                splashDamage.GetComponent<SplashDamage>().Damage = (int)Mathf.Floor(Damage / 2);
            }
        }

        Invoke("DestroyBullet", .05f);
    }

    private void EnemyHitPartical() {
        GameObject particleEffect = Instantiate(EnemyHitEffect, transform.position, transform.rotation);
        particleEffect.transform.localScale = new Vector3 (.3f, .3f, .3f);
    }

    private void DestroyBullet() {
        GameObject hit_particleEffect = Instantiate(HitParticalEffect, transform.position, transform.rotation);
        hit_particleEffect.transform.localScale = new Vector3 (.3f, .3f, .3f);
        Destroy(gameObject);
    }
}