using UnityEngine;

public class notkaDelit : MonoBehaviour
{
    public string dell;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == dell) 
        {
            colisiaList CL = collision.gameObject.GetComponent<colisiaList>();
            if (CL != null)
                CL.col=true;
            Destroy(gameObject); 
        }
    }
}
