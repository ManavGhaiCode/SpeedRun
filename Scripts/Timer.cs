using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField] private float t;
    [SerializeField] private TextController txt;

    private float timeToStop;

    private void Awake() {
        timeToStop = Time.time + t;
    }

    private void Update() {
        Debug.Log(timeToStop - Time.time);
        txt.SetText(Mathf.Ceil(timeToStop - Time.time).ToString());

        if (Time.time >= timeToStop) {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }
}