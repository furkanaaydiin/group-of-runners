using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animatorConroller;
    public GameManager gameManager;
    public CameraManager cameraManager;
    public UIManager uIManager;
    
    
    
    public bool isJumpPlayer;
    public void StartRunAim()
    {
        gameManager.startGame = true;
        uIManager.taptoStartPanel.SetActive(false);
        cameraManager.GameStartCam();
    }

    public void DeadAnim()
    {
        animatorConroller.SetBool("isDead",true);
    }

    public void RestartAnim()
    {
        animatorConroller.SetBool("isDead",false);
    }

    public void WinAnim()
    {
        animatorConroller.SetBool("isWin",true);
    }

    public void LoseAnim()
    {
        animatorConroller.SetBool("isLose",true);
    }
    public void AttackJump()
    {
        if (isJumpPlayer == false)
        {
            StartCoroutine(RunningendJumpCorontine());
        }
    }

    private  IEnumerator RunningendJumpCorontine()
    {
        isJumpPlayer = true;
        animatorConroller.SetBool("isAttackjump",true);
        animatorConroller.SetBool("isRun",false);
        yield return new WaitForSeconds(1f);
        animatorConroller.SetBool("isRun",true);
        animatorConroller.SetBool("isAttackjump",false);
        isJumpPlayer = false;


    }
    
    
    
}
