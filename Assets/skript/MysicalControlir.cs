using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MysicalControlir : MonoBehaviour
{
    private bool nustiska;
    /////////////////////////////////////////
    [Header("defolt")]
    public AudioMixer am;
    private int ActiveParameters;
    private GameObject pleir;


    private void Awake()
    {
        pleir = gameObject;
    }

    // смена состаяния звука(snapshots)
    public void SetActiveParameters(int A)
    {
        ActiveParameters = A;
        nerexod(ActiveParameters, 1);
    }

    /////////////////////////////////////////
    [Header("sag")]
    public List<GameObject> ZvukSAG;
    public float ZaderzkaSAG;
    public Vector3 SmeseniaSAG;
    public Vector2 randomPitch = new Vector2(0.9f, 1.1f);
    public Vector2 randomVolume = new Vector2(0.9f, 1f);
    private bool kanesSAG = true;

    // воспроивести звук шага
    public void sag(bool Nada = false)
    {
        if (Nada) {
            Sagnut();
            kanesSAG = true;
            return;
        }
        if (kanesSAG)
            StartCoroutine(SagnutTimSAG());
    }

    public IEnumerator SagnutTimSAG() 
    {
        kanesSAG = false;
        Sagnut();
        yield return new WaitForSeconds(ZaderzkaSAG);
        kanesSAG = true;
    }

    private void Sagnut()
    {
        Vector3 vstavit = pleir.transform.position + SmeseniaSAG;
        GameObject i = Instantiate(ZvukSAG[UnityEngine.Random.Range(0, ZvukSAG.Count)], vstavit, Quaternion.identity);
        AudioSource ii = i.GetComponent<AudioSource>();
        ii.pitch = UnityEngine.Random.Range(randomPitch.x, randomPitch.y);
        ii.volume = UnityEngine.Random.Range(randomVolume.x, randomVolume.y);
    }


    /////////////////////////////////////////
    [Header("nerezvuk")]
    public List<AudioMixerSnapshot> AMSnap;

    // смена состаяния звука(snapshots)
    private void nerexod(int tin,float time)
    {
        AMSnap[tin].TransitionTo(time);
    }

    [Header("Text")]
    public List<GameObject> ZvukTEXT;
    public float ZaderzkaTEXT;

    // воспрозводит звук текста
    public void TEXT(float time)
    {
        StartCoroutine(TimTEXT(time));
    }

    private IEnumerator TimTEXT(float time)
    {
        time -= 3f;
        List<GameObject> dell = new List<GameObject>();
        float freim = ZaderzkaTEXT;
        for(int i = 0; i< Math.Round((time/ freim)+1); i++)
        {
            dell.Add(Instantiate(ZvukTEXT[UnityEngine.Random.Range(0, ZvukTEXT.Count)], Vector2.zero, Quaternion.identity));
            yield return new WaitForSeconds(freim);
        }

        yield return new WaitForSeconds(2);

        for (int i = 0; i < dell.Count; i++)
        {
            Destroy(dell[i]);
        }
    }

    [Header("noti")]
    public List<GameObject> ZvukNOTI;

    // воспроизводит ноту
    public void sigrat(int indecs , Transform tra)
    {
        StartCoroutine(timeDell(
            Instantiate(ZvukNOTI[indecs], tra.position, Quaternion.identity)
        ));
    }

    private IEnumerator timeDell(GameObject GO)
    {
        yield return new WaitForSeconds(1);
        Destroy(GO);
    }
    
}
