using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField] private float t;

    private float timeToStop;

    private void Awake() {
        timeToStop = Time.time + t;
    }

    private void Update() {
        Debug.Log(timeToStop - Time.time);

        if (Time.time >= timeToStop) {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }
}