using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public static LevelLoader Instance { get; private set;}

    private void Awake() {
        if (Instance != null && Instance != this) { 
            Destroy(this); 
        } else { 
           Instance = this; 
        } 
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }

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

    public void LoadLevelTwo() {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevelThree() {
        SceneManager.LoadScene("Level 3");
    }
    
    public void LoadWinScreen() {
        SceneManager.LoadScene("Win Screen");
    }

    public void LoadLoseScreen() {
        SceneManager.LoadScene("Lose Screen");
    }

}
