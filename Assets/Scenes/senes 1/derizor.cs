using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class derizor : MonoBehaviour
{
    public List<nulator> nulatori;
    public List<colisiaList> colisiaListi;
    public GameObject sepi;


    void Start()
    {
        StartCoroutine(startic());
    }

    public IEnumerator startic()
    {
        yield return new WaitForSeconds(1f);
        int nroxod = 0;
        while (true)
        {
            nulatori[nroxod].nulatik();
            yield return new WaitForSeconds(0.5f);
            if (!colisiaListi[nroxod].col)
            {
                obivlenia();
                nroxod = 0;
            }
            else
            {
                colisiaListi[nroxod].col = false;
                nroxod++;
            }
            if(nroxod >= 8)
                break;
            
            yield return new WaitForSeconds(0.5f);
        }
        Instantiate(sepi, sepi.transform.position + new Vector3 (0,-20), Quaternion.identity);

    }

    private void obivlenia()
    {
        colisiaListi[0].lanadix();
        //for (int i = 0;i < colisiaListi.Count; i++)
        //{
        //    colisiaListi[i].lanadix();
        //}
    }
}
