using TMPro;
using UnityEngine;

public class DisplayHighScore : MonoBehaviour {
    [SerializeField] TextMeshProUGUI level1BestTime = null;
    [SerializeField] TextMeshProUGUI level2BestTime = null;
    [SerializeField] TextMeshProUGUI level3BestTime = null;

    private void Start() {
        float level1Timer = PlayerPrefs.GetFloat("Level1HighScore", 0);
        float level1Seconds = (int) (level1Timer % 60);
        float level1Minutes = (int) (level1Timer / 60);
        level1BestTime.text = "Best Time: " + level1Minutes.ToString("00") + ":" + level1Seconds.ToString("00");

        float level2Timer = PlayerPrefs.GetFloat("Level2HighScore", 0);
        float level2Seconds = (int) (level2Timer % 60);
        float level2Minutes = (int) (level2Timer / 60);
        level2BestTime.text = "Best Time: " + level2Minutes.ToString("00") + ":" + level2Seconds.ToString("00");

        float level3Timer = PlayerPrefs.GetFloat("Level3HighScore", 0);
        float level3Seconds = (int) (level3Timer % 60);
        float level3Minutes = (int) (level3Timer / 60);
        level3BestTime.text = "Best Time: " + level3Minutes.ToString("00") + ":" + level3Seconds.ToString("00");
    }

}
