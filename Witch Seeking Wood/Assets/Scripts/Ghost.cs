using System.Collections;
using UnityEngine;

public class Ghost : MonoBehaviour {
    [SerializeField] GameObject player = null;
    [SerializeField] Transform[] teleportPoints = null;
    [SerializeField] float baseMovementSpeed = 1;
    [SerializeField] float movementSpeedIncrease = 0.25f;
    [SerializeField] float increaseStep = 10;

    private bool stunned = false;
    private bool teleporting = false;
    private float movementSpeed;
    private float timer;
    private Animator animator;
    private Rigidbody2D myRigidbody2D;

    private void Start() {
        animator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        movementSpeed = baseMovementSpeed;
        timer = 0;
    }

    private void Update() {
        if (stunned || teleporting) { return; }

        timer += Time.deltaTime;

        if (timer >= increaseStep) {
            movementSpeed += movementSpeedIncrease;
            timer = 0;
        }

        Vector3 playerPosition = player.transform.position;

        Vector3 offsetNormalized = (playerPosition - transform.position).normalized;

        myRigidbody2D.velocity = offsetNormalized * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Fade to invisible, Teleport away from player, fade back in, start moving.
        if (other.gameObject.tag == "Player") {
            Player player = other.gameObject.GetComponent<Player>();
            movementSpeed = 0;
            player.RemoveWoodCollected();
            player.RemoveWoodCollected();
            animator.SetTrigger("Teleport");
        }
    }

    public void StunGhost(float stunTime) {
        stunned = true;
        animator.SetBool("Stunned", true);
        myRigidbody2D.velocity = new Vector3(0,0,0);
        StartCoroutine(StunTimer(stunTime));
        timer = 0;
        movementSpeed = baseMovementSpeed;
    }

    public void ResetAfterTeleport() {
        movementSpeed = baseMovementSpeed;
        teleporting = false;
    }

    private void TeleportAway() {
        int randomIndex = Random.Range(0,teleportPoints.Length);
        transform.position = teleportPoints[randomIndex].position;
    }

    private IEnumerator StunTimer(float stunTime) {
        yield return new WaitForSeconds(stunTime);
        stunned = false;
        animator.SetBool("Stunned", false);
    }
}
