using TMPro;
using UnityEngine;

public class StopWatch : MonoBehaviour {
    [SerializeField] TextMeshProUGUI timerText = null;

    private float timer;
    private float seconds;
    private float minutes; 

    private void Start() {
        timer = 0;
    }

    private void Update() {
        StopWatchCalculate();
    }

    public void SetBestTime(string level) {
        string levelString = level + "HighScore";
        Debug.Log(levelString);
        if (timer <= PlayerPrefs.GetFloat(levelString, timer) || PlayerPrefs.GetFloat(levelString, timer) == 0) {
            PlayerPrefs.SetFloat(levelString, timer);
        }
    }

    private void StopWatchCalculate() {
        timer += Time.deltaTime;
        seconds = (int) (timer % 60);
        minutes = (int) (timer / 60);

        timerText.text = minutes.ToString("00") + " : " + seconds.ToString("00");
    }
}
