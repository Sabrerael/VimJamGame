using System.Collections;
using UnityEngine;

public class BrokenWood : MonoBehaviour {
    private float randomAngle;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D myRigidbody2D;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.velocity = new Vector3(Random.Range(-5f,5f), Random.Range(-5f,5f), 0);
        randomAngle = Random.Range(-90, 90);
        myRigidbody2D.rotation += randomAngle;
        StartCoroutine(Fade());
    }

    private IEnumerator Fade() {
        Color c = spriteRenderer.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f) {
            c.a = alpha;
            spriteRenderer.color = c;
            myRigidbody2D.rotation += randomAngle;
            yield return new WaitForSeconds(.05f);
        }
        GameObject.Destroy(this.gameObject);
    }
}
