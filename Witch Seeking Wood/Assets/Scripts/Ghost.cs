using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
    [SerializeField] GameObject player = null;
    [SerializeField] float movementSpeed = 1;

    private Rigidbody2D myRigidbody2D;

    private void Start() {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Vector3 playerPosition = player.transform.position;

        Vector3 offsetNormalized = (playerPosition - transform.position).normalized;

        myRigidbody2D.velocity = offsetNormalized * movementSpeed;
    }
}
