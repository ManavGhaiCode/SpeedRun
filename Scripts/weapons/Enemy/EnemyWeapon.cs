using UnityEngine;

public class EnemyWeapon : MonoBehaviour {
    public GameObject BulletPerfab;
    public float speed;
    public int Damage;
    public float bulletLifespan;

    [SerializeField] private Transform firePoint;

    public void Shoot() {
        GameObject bullet = Instantiate(BulletPerfab, firePoint.position, firePoint.rotation);

        bullet.GetComponent<EnemyBullet>().Damage = Damage;
        bullet.GetComponent<EnemyBullet>().lifespan = bulletLifespan;
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * speed, ForceMode2D.Impulse);
    }
}