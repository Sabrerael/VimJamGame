using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] float movementSpeed = 5;

    private Vector2 movementValues = new Vector2();
    private Rigidbody2D myRigidbody2D;

    private void Start() {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        myRigidbody2D.velocity = movementValues * movementSpeed;
    }

    public void SetMovementValues(Vector2 values) {
        movementValues = values;
    } 
}
