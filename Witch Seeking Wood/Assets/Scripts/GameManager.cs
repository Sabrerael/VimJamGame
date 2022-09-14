using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] Player player = null;
    [SerializeField] Cauldron cauldron = null;
    [SerializeField] int totalWoodInLevel = 20;
    [SerializeField] int woodNeededToWin = 10;

    private int wastedWood = 0;

    public void AddToWastedWood() {
        wastedWood++;
        CheckLoseCondition();
    }

    private void CheckLoseCondition() {
        if (totalWoodInLevel - wastedWood < woodNeededToWin) {
            Debug.Log("Lose");
        }
    }
}
