using UnityEngine;

public class LevelData : MonoBehaviour {
    public int number_Enemies = 0;
    public GameObject WallToDestroy;

    public void EnemyDeath() {
        number_Enemies -= 1;

        if (number_Enemies <= 0) {
            Destroy(WallToDestroy);
        }
    }
}