using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeScript : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    static public FadeScript instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void FadeIn()
    {
        canvasGroup.DOFade(0, 2);
    }
    public void FadeOut()
    {
        canvasGroup.DOFade(1, 2);
    }
}

