using TMPro;
using UnityEngine;

public class Cauldron : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] int winningWoodAmount = 10;
    [SerializeField] int totalWoodInLevel = 20;
    [SerializeField] string levelString = "Level1";
    [SerializeField] RectTransform winProgressBar = null;
    [SerializeField] TextMeshProUGUI winTextUI = null;
    [SerializeField] RectTransform loseProgressBar = null;
    [SerializeField] TextMeshProUGUI loseTextUI = null;
    [SerializeField] StopWatch stopWatch = null;

    private bool atStageTwo = false;
    private int woodAtCauldron = 0;
    private int wastedWood = 0;
    private int wastedWoodToLose = 0;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        wastedWoodToLose = totalWoodInLevel - winningWoodAmount + 1;
    }

    private void Update() {
        float winPercent = (float)woodAtCauldron / (float)winningWoodAmount;
        float losePercent = (float)wastedWood / (float)wastedWoodToLose;
        winProgressBar.localScale = new Vector3(winPercent, 1, 1);
        loseProgressBar.localScale = new Vector3(losePercent, 1, 1);
        if (woodAtCauldron >= winningWoodAmount) {
            stopWatch.SetBestTime(levelString);
            LevelLoader.Instance.LoadWinScreen();
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            if (player.RemoveWoodCollected()) {
                woodAtCauldron++;
                winTextUI.text = woodAtCauldron.ToString();
                if (!atStageTwo && woodAtCauldron > (winningWoodAmount/2)) {
                    animator.SetTrigger("Stage 2");
                }
            }
        }
    }

    public void AddToWastedWood() {
        wastedWood++;
        loseTextUI.text = wastedWood.ToString();
        CheckLoseCondition();
    }

    private void CheckLoseCondition() {
        if (totalWoodInLevel - wastedWood < winningWoodAmount) {
            LevelLoader.Instance.LoadLoseScreen();
        }
    }
}
