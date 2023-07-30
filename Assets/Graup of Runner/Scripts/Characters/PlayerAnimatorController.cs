using System.Collections;
using Graup_of_Runner.Scripts.Camera;
using UnityEngine;
using UnityEngine.Serialization;
using CameraType = Graup_of_Runner.Scripts.Camera.CameraType;

namespace Graup_of_Runner.Scripts.Characters
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        public Animator PlayerAnim;
        public GameManager gameManager;
        public UIManager uIManager;
        public bool isJumpPlayer;
        public void StartRunAim()
        {
            gameManager.startGame = true;
            uIManager.taptoStartPanel.SetActive(false);
            CameraController.Instance.ChangeCamera(CameraType.FollowCamera);
        }

        public void DeadAnim()
        {
            PlayerAnim.SetBool("isDead",true);
        }

        public void RestartAnim()
        {
            PlayerAnim.SetBool("isDead",false);
        }

        public void WinAnim()
        {
            PlayerAnim.SetBool("isWin",true);
        }

        public void LoseAnim()
        {
            PlayerAnim.SetBool("isLose",true);
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
            PlayerAnim.SetBool("isAttackjump",true);
            PlayerAnim.SetBool("isRun",false);
            yield return new WaitForSeconds(1f);
            PlayerAnim.SetBool("isRun",true);
            PlayerAnim.SetBool("isAttackjump",false);
            isJumpPlayer = false;
        
        }
    
    
    
    }
}
