using System.Collections;
using Graup_of_Runner.Scripts.Camera;
using UnityEngine;
using UnityEngine.Serialization;
using CameraType = UnityEngine.CameraType;

namespace Graup_of_Runner.Scripts.Characters.Enemy
{
    public class OpponentAmimatorController : MonoBehaviour
    {
      public Animator EnemyAnim;
      public bool isJumpPlayer;
      
      public void StartRunAim()
      {
         
          GameManager.Instance.startGame = true;

      }
      
      public void DeadAnim()
      {
          EnemyAnim.SetBool("isDead",true);
      }

      public void RestartAnim()
      {
          EnemyAnim.SetBool("isDead",false);
      }

      public void WinAnim()
      {
          EnemyAnim.SetBool("isWin",true);
      }

      public void LoseAnim()
      {
          EnemyAnim.SetBool("isLose",true);
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
          EnemyAnim.SetBool("isAttackjump",true);
          EnemyAnim.SetBool("isRun",false);
          yield return new WaitForSeconds(1f);
          EnemyAnim.SetBool("isRun",true);
          EnemyAnim.SetBool("isAttackjump",false);
          isJumpPlayer = false;
        
      }
    }
}