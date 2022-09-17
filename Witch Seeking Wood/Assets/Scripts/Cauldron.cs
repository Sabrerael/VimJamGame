using UnityEngine;

public class Cauldron : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] int winningWoodAmount = 10;
    [SerializeField] int totalWoodInLevel = 20;

    private bool atStageTwo = false;
    private int woodAtCauldron = 0;
    private int wastedWood = 0;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (woodAtCauldron >= winningWoodAmount) {
            LevelLoader.Instance.LoadWinScreen();
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            if (player.RemoveWoodCollected()) {
                woodAtCauldron++;
                if (!atStageTwo && woodAtCauldron > (winningWoodAmount/2)) {
                    animator.SetTrigger("Stage 2");
                }
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
