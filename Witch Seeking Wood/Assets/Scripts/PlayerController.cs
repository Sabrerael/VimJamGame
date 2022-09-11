using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    private Movement movement;
    private Player player;

    private void Start() {
        movement = GetComponent<Movement>();
        player = GetComponent<Player>();
    }

    public void OnFire(InputValue input) {
        player.ThrowWood();
    }

    public void OnMove(InputValue input) {
        movement.SetMovementValues(input.Get<Vector2>());
    }

}
