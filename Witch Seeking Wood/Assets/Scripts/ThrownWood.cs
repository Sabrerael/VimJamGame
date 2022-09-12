using UnityEngine;

public class ThrownWood : MonoBehaviour {
    [SerializeField] float stunTime = 15;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") { return; }

        if (other.gameObject.tag == "Enemy") {
            // Code to bonk the ghost and stun them.
        }

        Destroy(this);
    }
}
