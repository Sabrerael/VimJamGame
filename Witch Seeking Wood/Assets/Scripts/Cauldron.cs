using UnityEngine;

public class Cauldron : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] int winningWoodAmount = 10;
    [SerializeField] int totalWoodInLevel = 20;

    private int woodAtCauldron = 0;
    private int wastedWood = 0;

    private void Update() {
        if (woodAtCauldron >= winningWoodAmount) {
            Debug.Log(woodAtCauldron + ", Win");
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            if (player.RemoveWoodCollected()) {
                woodAtCauldron++;
            }
        }
    }

    public void AddToWastedWood() {
        wastedWood++;
        CheckLoseCondition();
    }

    private void CheckLoseCondition() {
        if (totalWoodInLevel - wastedWood < winningWoodAmount) {
            Debug.Log("Lose");
        }
    }
}
