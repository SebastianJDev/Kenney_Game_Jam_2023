using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    [SerializeField]
    private Image sprite;
    [SerializeField] private float duracionFadeIn, duracionFadeOut;

    [ContextMenu("FadeIn")]
    public void FadeIn()
    {
        sprite.DOFade(1, duracionFadeIn).OnComplete(() =>
        {
        });
    }

    [ContextMenu("FadeOut")]
    public void FadeOut()
    {
        sprite.DOFade(0, duracionFadeOut).OnComplete(() => StartGame()).OnStart(() =>
        {
        });
    }

    private void StartGame()
    {
    }


    private void Start()
    {
        FadeOut();
    }

}
