using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
