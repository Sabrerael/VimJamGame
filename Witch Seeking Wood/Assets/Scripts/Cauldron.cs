using UnityEngine;

public class Cauldron : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] int winningWoodAmount = 10;

    private int woodAtCauldron = 0;

    private void Update() {
        if (woodAtCauldron == winningWoodAmount) {
            Debug.Log("Win");
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            player.RemoveWoodCollected();
            woodAtCauldron++;
        }
    }
}
