using UnityEngine;

public class Fuentes : MonoBehaviour
{
    public int Usos = 0;
    public GameObject[] objetos;
    public RectTransform[] rectTransform;
    public void Drop()
    {
        if (rectTransform[0].childCount == 1 && rectTransform[1].childCount == 1 && rectTransform[2].childCount == 1)
        {
            return;
        }
        if (Usos < 6)
        {
            int numero = Random.Range(0,objetos.Length);
            bool Rect1 = rectTransform[0].childCount == 0;
            bool Rect2 = rectTransform[1].childCount == 0;
            bool Rect3 = rectTransform[2].childCount == 0;
            AudioManager.instance.Play("POP");


            if (Rect1)
            {
                Instantiate(objetos[numero].gameObject, rectTransform[0]);
            }else if (Rect2)
            {
                Instantiate(objetos[numero].gameObject, rectTransform[1]);
            }
            else if (Rect3)
            {
                Instantiate(objetos[numero].gameObject, rectTransform[2]);
            }
            Usos++;
        }
    }
}
