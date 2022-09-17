using UnityEngine;

public class Cauldron : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] int winningWoodAmount = 10;
    [SerializeField] int totalWoodInLevel = 20;

    private int woodAtCauldron = 0;
    private int wastedWood = 0;

    private void Update() {
        if (woodAtCauldron >= winningWoodAmount) {
            LevelLoader.Instance.LoadWinScreen();
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
            LevelLoader.Instance.LoadLoseScreen();
        }
    }
}
