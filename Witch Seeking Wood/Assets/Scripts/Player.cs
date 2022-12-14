using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    [SerializeField] TextMeshProUGUI woodUI = null;
    [SerializeField] GameObject thrownWoodPrefab = null;
    [SerializeField] float throwingSpeed = 5;
    [SerializeField] AudioClip audioClip = null;

    private int woodCollected = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Wood>()) {
            AddWoodCollected(other.GetComponent<Wood>().GetWoodValue());
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            Destroy(other.gameObject);
        }
    }

    public int GetWoodCollected() { return woodCollected; }

    public void AddWoodCollected(int value) { 
        woodCollected += value; 
        woodUI.text = woodCollected.ToString();
    }

    public bool RemoveWoodCollected() {
        if (woodCollected > 0) {
            woodCollected--;
            woodUI.text = woodCollected.ToString();
            return true;
        }
        return false;
    }

    public void ThrowWood() {
        if (woodCollected == 0) {
            return;
        }

        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 normalizedMouseVector = (worldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(normalizedMouseVector.y, normalizedMouseVector.x)*Mathf.Rad2Deg;
        GameObject thrownWood = Instantiate(thrownWoodPrefab, transform.position, Quaternion.Euler(0, 0, angle));

        thrownWood.GetComponent<Rigidbody2D>().velocity = normalizedMouseVector * throwingSpeed;

        woodCollected--;
        woodUI.text = woodCollected.ToString();
    }
}
