using System.Collections;
using UnityEngine;

public class Ghost : MonoBehaviour {
    [SerializeField] GameObject player = null;
    [SerializeField] float movementSpeed = 1;

    private bool stunned = false;
    private Rigidbody2D myRigidbody2D;

    private void Start() {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (stunned) { return; }

        Vector3 playerPosition = player.transform.position;

        Vector3 offsetNormalized = (playerPosition - transform.position).normalized;

        myRigidbody2D.velocity = offsetNormalized * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Fade to invisible, Teleport away from player, fade back in, start moving.
    }

    public void StunGhost(float stunTime) {
        stunned = true;
        myRigidbody2D.velocity = new Vector3(0,0,0);
        StartCoroutine(StunTimer(stunTime));
    }

    private IEnumerator StunTimer(float stunTime) {
        yield return new WaitForSeconds(stunTime);
        stunned = false;
    }
}
