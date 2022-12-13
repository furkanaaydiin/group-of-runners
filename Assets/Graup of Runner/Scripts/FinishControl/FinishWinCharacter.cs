using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishWinCharacter : MonoBehaviour
{
    public PlayerController _playerController;
    public AnimatorController animatorController;
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
           animatorController.WinAnim();
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
          animatorController.LoseAnim();
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
