using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifespan;

    private void Start() {
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}