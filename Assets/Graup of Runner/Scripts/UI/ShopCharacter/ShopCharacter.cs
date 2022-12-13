using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopCharacter : MonoBehaviour
{
    public GameObject[] shopCharacter;
    
    

    private void Start()
    {
       
    }

    void CharacterPos()
    {
        
    }

    public void Characters()
    {
        for (int i = 0; i < shopCharacter.Length; i++)
        {
            shopCharacter[i].SetActive(false);
        }
    }
}
