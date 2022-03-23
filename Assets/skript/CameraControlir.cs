using UnityEngine;

public class CameraControlir : MonoBehaviour
{
    public Transform Pleir;
    public Vector3 Smesenia = new Vector3(3, -5, -10);
    public float SectionsX = 6;
    public float SectionsY = 10;


    void FixedUpdate()
    {
        transform.position = 
            new Vector3(
            Pleir.position.x > 0 ?
            (int)(Pleir.position.x / SectionsX) * SectionsX: 
            (int)(Pleir.position.x / SectionsX) * SectionsX - Smesenia.x * 2,

            Pleir.position.y < 0 ?
            (int)(Pleir.position.y / SectionsY) * SectionsY:
            (int)(Pleir.position.y / SectionsY) * SectionsY - Smesenia.y * 2
            )
            + Smesenia;
    }
}
