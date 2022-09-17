using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public void LoadControls () {
        SceneManager.LoadScene("Controls");
    }

    public void LoadCredits() {
        SceneManager.LoadScene("Credits");
    }

    public void LoadLevelSelect() {
        SceneManager.LoadScene("Level Select");
    }

    public void LoadLevelOne() {
        SceneManager.LoadScene("Level 1");
    }

}
