using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunkingSystem : MonoBehaviour
{
    public float distance;
    public GameObject finisTarget;
    public int rank;

    void CalculateDistance()
    {
        distance = Vector3.Distance(transform.position, finisTarget.transform.position);
    }
   
    void Update()
    {
        CalculateDistance();
    }
}
