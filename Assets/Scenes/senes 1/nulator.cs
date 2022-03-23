using UnityEngine;

// руский корабаль иди на"7й.
public class nulator : MonoBehaviour
{
    public GameObject nulat;
    private MysicalControlir MC;
    public int nota;
    public float impuls;

    private void Start()
    {
        MC = PleirControlir.MCS;
    }

    public void nulatik() 
    {
        GameObject nula =  Instantiate(nulat, transform.position + new Vector3(0,0.1f), Quaternion.identity);
        Rigidbody2D rb = nula.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.AddForce(new Vector2(0, impuls), ForceMode2D.Impulse);
        MC.sigrat(nota, transform);
        notkaDelit nd = nula.GetComponent<notkaDelit>();
        if (nd != null)
            nd.dell = "xvatatil";
    }
}
