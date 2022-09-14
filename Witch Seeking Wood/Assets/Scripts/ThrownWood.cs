using UnityEngine;

public class ThrownWood : MonoBehaviour {
    [SerializeField] float stunTime = 15;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player") { return; }

        if (other.gameObject.tag == "Enemy") {
            // Code to bonk the ghost and stun them.
            Debug.Log("Bonk");
            other.GetComponent<Ghost>().StunGhost(stunTime);
        }

        GameObject.Destroy(this.gameObject);
    }
}
