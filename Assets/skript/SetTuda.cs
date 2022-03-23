using UnityEngine;

public class SetTuda : MonoBehaviour
{
    public float sila = 20;
    public bool invers;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invers)
        {
            PleirControlir PC = collision.gameObject.GetComponent<PleirControlir>();
            if (PC != null)
                PC.invers = !PC.invers;
        }
        else
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.AddForce(new Vector2(-sila, 0), ForceMode2D.Impulse);

        }
    }
}
