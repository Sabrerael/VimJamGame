using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] float movementSpeed = 5;

    private Vector2 movementValues = new Vector2();
    private Animator animator;
    private Rigidbody2D myRigidbody2D;

    private void Start() {
        animator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        myRigidbody2D.velocity = movementValues * movementSpeed;
    }

    public void SetMovementValues(Vector2 values) {
        movementValues = values;
        if (values.magnitude <= 0.0002) {
            animator.SetBool("Moving Left", false);
            animator.SetBool("Moving Right", false);
        } else if (values.x < 0) {
            animator.SetBool("Moving Right", true);
            animator.SetBool("Moving Left", false);
        } else {
            animator.SetBool("Moving Left", true);
            animator.SetBool("Moving Right", false);
        }
    } 
}
