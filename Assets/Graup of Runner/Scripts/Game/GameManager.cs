using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public  class GameManager : MonoBehaviour
{
     public static GameManager Instance;
     [Header("Play end over")]
     public bool gameOver;
     public bool startGame;

     public int cup;

    public GameObject FinishTac;
    
    
    public ParticleSystem FinishParticle1, FinishParticle2;

    private void Awake()
    {
       Instance = this;
        
    }
   

    public void FinishParticleConfeti()
    {
        FinishParticle1.Play();
        FinishParticle2.Play();
        FinishTac.SetActive(false);
    }

    public void UseCup(int amountCup)
    {
        cup -= amountCup;
    }

    public bool HasEnoughCup(int amountCup)
    {
        return (cup >= amountCup);
    }

}
