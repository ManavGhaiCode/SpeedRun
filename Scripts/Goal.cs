using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerController Player = hitInfo.GetComponent<PlayerController>();

        if (Player != null) {
            GameObject.FindGameObjectWithTag("main").GetComponent<SceneLoader>().LoadNextLevel();
        }
    }
}