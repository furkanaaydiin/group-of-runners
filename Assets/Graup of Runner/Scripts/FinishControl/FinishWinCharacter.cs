using System;
using System.Collections;
using System.Collections.Generic;
using Graup_of_Runner.Scripts.Characters;
using Graup_of_Runner.Scripts.Characters.Player;
using UnityEngine;
using UnityEngine.Serialization;

public class FinishWinCharacter : MonoBehaviour
{
    public Player _playerController;
    public PlayerAnimatorController playerAnimatorController;
    public UIManager uiManager;
    public Opponent[] AIopponent;

    public  bool finish;

   

    private void OnTriggerEnter(Collider other)
    {
        
       if(finish) return;
       if (other.CompareTag("player"))
       {
           finish = true;
           _playerController.runningSpeed = 0;
           _playerController.xSpeed = 0;
           playerAnimatorController.WinAnim();
           foreach (var opponent in AIopponent)
           {
            opponent.Lose();
           }
           uiManager.FinishPanels();
           
       }
       else if (other.CompareTag("AI"))
       {
          finish = true;
          var opponentScript = other.GetComponent<Opponent>();
          _playerController.runningSpeed = 0;
          _playerController.xSpeed = 0;
          playerAnimatorController.LoseAnim();
          opponentScript.Finish();
          foreach (var opponent in AIopponent)
          {
              if (opponent == opponentScript)
              {
                continue;
              }
              opponent.Lose();
          }
          uiManager.FinishPanels();
       }

    }
}
