using UnityEngine;

public class WeaponPickup : MonoBehaviour {
    public GameObject WeaponRef;

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerController Player = hitInfo.GetComponent<PlayerController>();

        if (Player != null) {
            Player.TakeWeapon(WeaponRef);
            Destroy(gameObject);
        }  
    }
}