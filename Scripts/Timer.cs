using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField] private float t;
    [SerializeField] private TextController txt;

    private float timeToStop;

    private void Awake() {
        timeToStop = Time.time + t;
    }

    private void Update() {
        txt.SetText(Mathf.Ceil(timeToStop - Time.time).ToString());

        if (Time.time >= timeToStop) {
            StartCoroutine(SendToEnd());
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }

    private IEnumerator SendToEnd() {
        yield return new WaitForSeconds(.5f);
        GameObject.FindGameObjectWithTag("main").GetComponent<SceneLoader>().LoadScene("DeathEnd");
    }
}