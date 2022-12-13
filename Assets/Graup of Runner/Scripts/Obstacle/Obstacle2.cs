using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle2 : MonoBehaviour
{
    
    void Awake()
    {
        transform.DOLocalRotate(new Vector3(0, -90, 0), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InBack);
    }

    
}
