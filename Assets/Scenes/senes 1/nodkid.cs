using UnityEngine;

public class nodkid : MonoBehaviour
{
    public float sila = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if(rb != null)
        {
            rb.AddForce(new Vector2(0, sila), ForceMode2D.Impulse);
        }
    }

    private void Start()
    {
        Destroy(gameObject, 1f);
    }
}
