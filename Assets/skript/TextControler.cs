using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class TextControler : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject textik;
    private List<string> textL = new List<string> { 
    "ето тестовий вариант если показало то ти далбаебик"
    };


    private void Awake()
    {
        text.text = textL[0];
        textik.SetActive(false);
    }

    // печатает текст со списка
    public float textVivod(int tet = 0)
    {
        StartCoroutine(textVivodD(textL[tet]));
        float res = 0;

        for (int i = 0; i < textL[tet].Length; i++)
        {
            res += 0.1f;
        }
        return res + 3;
    }

    // печатает ведоний текст
    public float textVivod(string tet)
    {
        StartCoroutine(textVivodD(tet));
        float res = 0;

        for (int i = 0; i< tet.Length;i++)
        {
            res += 0.1f;
        }
        return res + 3;
    }

    private IEnumerator textVivodD(string tet)
    {
        textik.SetActive(true);
        string textL = tet;
        text.text = "";
        while (true)
        {
            int i = text.text.Length;
            if (i >= textL.Length)
                break;

            text.text += textL[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        textik.SetActive(false);
    }

}
