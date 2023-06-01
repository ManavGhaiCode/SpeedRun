using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public string NextLevel;

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel() {
        if (NextLevel != null) {
            SceneManager.LoadScene(NextLevel);
        }
    }
}
