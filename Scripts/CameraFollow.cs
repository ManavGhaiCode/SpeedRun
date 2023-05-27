using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float speed = .125f;
    private Transform Player;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void LateUpdate() {
        if (Player != null) {
            transform.position = Player.position;
        }
    }
}
