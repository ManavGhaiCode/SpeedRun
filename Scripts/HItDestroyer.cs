using UnityEngine;

public class HItDestroyer : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerController Player = hitInfo.GetComponent<PlayerController>();

        if (Player != null) {
            Destroy(gameObject);
        }
    }
}
