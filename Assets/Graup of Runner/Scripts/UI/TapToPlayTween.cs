using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TapToPlayTween : MonoBehaviour
{
    public RectTransform TapToPlay;

    private void Awake()
    {
        TapToPlay.DOScale(Vector3.one * 3, 1f).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
    }
}
