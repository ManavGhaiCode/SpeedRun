using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretGoal : MonoBehaviour {
    public string secretGoal;

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerController Player = hitInfo.GetComponent<PlayerController>();

        if (Player != null) {
            SceneManager.LoadScene(secretGoal);
        }
    }
}
