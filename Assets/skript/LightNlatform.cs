using System.Collections;
using UnityEngine;

public class LightNlatform : MonoBehaviour
{
    private Light lightT;
    private SpriteRenderer SR;

    private void Awake()
    {
        lightT = GetComponent<Light>();
        SR = GetComponent<SpriteRenderer>();
    }

    // мигнут
    public void litic() 
    { 
        StartCoroutine(litesik());
    }

    public IEnumerator litesik()
    {
        for (int i = 0; i < 10; i++)
        {
            lightT.intensity += 0.5f;
            yield return new WaitForSeconds(0.1f);
            SR.size += new Vector2(0.05f, 0.05f);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 10; i++)
        {
            lightT.intensity -= 1f;
            yield return new WaitForSeconds(1);
            SR.size -= new Vector2(0.1f, 0.1f);
        }
        lightT.intensity = 0f;

    }

}
