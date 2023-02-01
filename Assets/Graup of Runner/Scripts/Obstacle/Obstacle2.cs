using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle2 : MonoBehaviour
{
   [SerializeField] private bool wrongWay;
    
    void Awake()
    {
        if (!wrongWay)
        {
            transform.DOLocalRotate(new Vector3(0, -90, 0), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InBack);
        }
        else
        {
            transform.DOLocalRotate(new Vector3(0, -270, 0), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InBack);
        }
        
    }

    
}
