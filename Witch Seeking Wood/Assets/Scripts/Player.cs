using TMPro;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] TextMeshProUGUI woodUI = null;
    [SerializeField] GameObject thrownWoodPrefab = null;

    private int woodCollected = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Wood>()) {
            AddWoodCollected(other.GetComponent<Wood>().GetWoodValue());
            Destroy(other.gameObject);
        }
    }

    public int GetWoodCollected() { return woodCollected; }
    public void AddWoodCollected(int value) { 
        woodCollected += value; 
        woodUI.text = woodCollected.ToString();
    }

    public void ThrowWood() {
        Debug.Log("Throw Wood");
        if (woodCollected == 0) {
            return;
        }

        Instantiate(thrownWoodPrefab);

        woodCollected--;
        woodUI.text = woodCollected.ToString();
    }
}
