using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FinisCamRotation : MonoBehaviour
{
    public Transform finishGameObjects;
    public float duration;
    public static FinisCamRotation Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void FinisRotation()
    {
        finishGameObjects.DOLocalRotate(new Vector3(0, 360, 0),
            duration,RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1,LoopType.Incremental);
    }

   
}
