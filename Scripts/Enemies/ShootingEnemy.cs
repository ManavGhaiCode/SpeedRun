using UnityEngine;

public class ShootingEnemy : Enemy {
    public float stopDistance = 1.5f;
    public float ShootDistance = 3f;
    public int Damage;
    public float bulletLifespan;

    private float TimeToShoot;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float TimeBetweenShoots;

    [SerializeField] private EnemyWeapon weapon;
    [SerializeField] private GameObject BulletPerfab;

    public override void Start() {
        base.Start();
        TimeToShoot = Time.time + TimeBetweenShoots;

        weapon.Damage = Damage;
        weapon.speed = bulletSpeed;
        weapon.bulletLifespan = bulletLifespan;
        weapon.BulletPerfab = BulletPerfab;
    }

    private void Update() {
        if (Player != null) {
            Vector2 LookDir = (Vector2)Player.position - rb.position;
            float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg;

            rb.rotation = angle;

            if (Vector2.Distance(Player.position, transform.position) < ShootDistance && Time.time > TimeToShoot) {
                TimeToShoot = Time.time + TimeBetweenShoots;

                weapon.Shoot();
            }

            if (Vector2.Distance(Player.position, transform.position) > stopDistance) {
                rb.MovePosition(Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime));
            }
        }
    } 
}