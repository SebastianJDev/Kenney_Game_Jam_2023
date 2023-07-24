using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ScaleTween : MonoBehaviour
{
    private RectTransform RectTransform;
    private LTDescr objeto;
    public LeanTweenType inType;
    public LeanTweenType outType;
    public float durationEntrada, durationSalida;
    public float tiempoEspera;
    public float delay;
    public UnityEvent onCompleteCallback;
    [Header("Animacion Escala")]
    public Vector3 escala;
    [Header("Animacion Transform")]
    public Vector3 PosicionInicialEntrada;
    public Vector3 PosicionFinalEntrada;
    public Vector3 PosicionFinalSalida;

    [SerializeField] private bool MoveScale, MoveTransform;
    public void OnEnable()
    {

        if (MoveScale)
        {
            transform.localScale = new Vector3(0, 0, 0);
            objeto = LeanTween.scale(gameObject, escala, durationEntrada).setDelay(delay).setEase(inType).setOnComplete(OnComplete);
        }
        else if (MoveTransform)
        {
            RectTransform = GetComponent<RectTransform>();
            RectTransform.localPosition = PosicionInicialEntrada;
            objeto = LeanTween.move(RectTransform, PosicionFinalEntrada, durationEntrada).setDelay(delay).setEase(inType).setOnComplete(OnComplete);

        }
    }
    public void OnComplete()
    {
        if (onCompleteCallback != null)
        {
            onCompleteCallback.Invoke();
        }
    }
    public IEnumerator Complete()
    {
        yield return new WaitForSeconds(tiempoEspera);
        OnClose();
    }

    public void OnClose()
    {
        if (MoveScale)
        {
            objeto = LeanTween.scale(RectTransform, escala, durationSalida).setEase(outType).setOnComplete(OnComplete);
        }
        else if (MoveTransform)
        {
            objeto = LeanTween.move(RectTransform, PosicionFinalSalida, durationSalida).setEase(outType).setOnComplete(OnComplete);
        }
    }
    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
