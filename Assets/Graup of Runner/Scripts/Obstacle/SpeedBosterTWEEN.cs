using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpeedBosterTWEEN : MonoBehaviour
{

    [SerializeField] private Transform spedboost;
    [SerializeField] private bool onTween;
    private void Awake()
    {
        if (onTween)
        {
            spedboost.transform.DOScale(Vector3.one * 0.8f, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
