using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle1 : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveY(-0.5f, Random.Range(1f, 1.3f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
