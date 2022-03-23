using System.Collections;
using UnityEngine;
using TMPro;

// поднимает текст и делает прозрачней со старта
public class SagScript : MonoBehaviour
{
    public int freim = 15;
    public Vector3 smes = new Vector3 (0, 0.03f, 0);
    public TextMeshProUGUI TMP;

    void Start()
    {
        StartCoroutine(sag());
    }

    public IEnumerator sag()
    {
        for (int i = 0; i < freim; i++)
        {
            transform.position += smes;
            TMP.color = new Color(1, 1, 1, 1 - (i * (1 / (float)freim)));
            yield return new WaitForSeconds(0.04f);
        }
        Destroy(gameObject);
    }
}
