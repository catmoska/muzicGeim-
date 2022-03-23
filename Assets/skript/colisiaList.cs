using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisiaList : MonoBehaviour
{
    public bool col;
    public Light lampa;
    public int nota;

    private void Awake()
    {
        if(lampa != null)
            lampa.intensity = 0f;
    }

    public void pleir()
    {
        PleirControlir.MCS.sigrat(nota , transform);
    }

    public void lanadix()
    {
        if (lampa != null)
            StartCoroutine(lanadixTime());
    }

    public IEnumerator lanadixTime()
    {
        for (int i = 0; i < 20; i++)
        {
            lampa.intensity += 1f / 10;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 10; i++)
        {
            lampa.intensity -= 2f / 10;
            yield return new WaitForSeconds(0.1f);
        }
        lampa.intensity = 0f;
    }
}
