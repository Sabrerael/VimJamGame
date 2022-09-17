using UnityEngine;

public class ThrownWood : MonoBehaviour {
    [SerializeField] float stunTime = 15;

    private Cauldron cauldron;

    private void Start() {
        cauldron = GameObject.FindObjectOfType<Cauldron>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Cauldron") { return; }

        if (other.gameObject.tag == "Enemy") {
            other.GetComponent<Ghost>().StunGhost(stunTime);
        }

        GameObject.Destroy(this.gameObject);
        cauldron.AddToWastedWood();
    }
}
