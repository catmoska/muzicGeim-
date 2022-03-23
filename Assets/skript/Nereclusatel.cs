using UnityEngine;

public class Nereclusatel : MonoBehaviour
{
    private SpriteRenderer SR;
    public bool nazata;
    public GameObject activ;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // ������� ����� (� ConfigObzect) �� ����� ������ ��� ������� �� �����
    private void OnMouseDown()
    {
        Transform  Trns = PleirControlir.pleirTransform;
        if (activ != null && !nazata)
            Instantiate(activ, Trns.position, Quaternion.identity);
        SR.flipY = true;
        nazata = true;
    }
}
